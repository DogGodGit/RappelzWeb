namespace WebCommon;

public class WPDConsumeEventMission : WPDPacketData
{
	public int eventId;

	public int missionNo;

	public int requiredDia;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(eventId);
		writer.Write(missionNo);
		writer.Write(requiredDia);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		eventId = reader.ReadInt32();
		missionNo = reader.ReadInt32();
		requiredDia = reader.ReadInt32();
	}
}
