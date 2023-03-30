namespace WebCommon;

public class WPDOpen7DayEventMission : WPDPacketData
{
	public int missionId;

	public int day;

	public int type;

	public long targetValue;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(missionId);
		writer.Write(day);
		writer.Write(type);
		writer.Write(targetValue);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		missionId = reader.ReadInt32();
		day = reader.ReadInt32();
		type = reader.ReadInt32();
		targetValue = reader.ReadInt64();
	}
}
