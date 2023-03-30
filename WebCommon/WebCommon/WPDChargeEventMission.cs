namespace WebCommon;

public class WPDChargeEventMission : WPDPacketData
{
	public int eventId;

	public int missionNo;

	public int requiredUnOwnDia;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(eventId);
		writer.Write(missionNo);
		writer.Write(requiredUnOwnDia);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		eventId = reader.ReadInt32();
		missionNo = reader.ReadInt32();
		requiredUnOwnDia = reader.ReadInt32();
	}
}
