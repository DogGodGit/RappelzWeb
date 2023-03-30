namespace WebCommon;

public class WPDDailyChargeEventMission : WPDPacketData
{
	public int missionNo;

	public int requiredUnOwnDia;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(missionNo);
		writer.Write(requiredUnOwnDia);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		missionNo = reader.ReadInt32();
		requiredUnOwnDia = reader.ReadInt32();
	}
}
