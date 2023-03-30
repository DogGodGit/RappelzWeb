namespace WebCommon;

public class WPDDailyConsumeEventMission : WPDPacketData
{
	public int missionNo;

	public int requiredDia;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(missionNo);
		writer.Write(requiredDia);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		missionNo = reader.ReadInt32();
		requiredDia = reader.ReadInt32();
	}
}
