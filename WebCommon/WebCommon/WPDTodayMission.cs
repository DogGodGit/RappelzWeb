namespace WebCommon;

public class WPDTodayMission : WPDPacketData
{
	public int missionId;

	public string nameKey;

	public int targetCount;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(missionId);
		writer.Write(nameKey);
		writer.Write(targetCount);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		missionId = reader.ReadInt32();
		nameKey = reader.ReadString();
		targetCount = reader.ReadInt32();
	}
}
