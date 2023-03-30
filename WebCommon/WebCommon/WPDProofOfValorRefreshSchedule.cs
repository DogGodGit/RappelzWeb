namespace WebCommon;

public class WPDProofOfValorRefreshSchedule : WPDPacketData
{
	public int scheduleId;

	public int refreshTime;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(scheduleId);
		writer.Write(refreshTime);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		scheduleId = reader.ReadInt32();
		refreshTime = reader.ReadInt32();
	}
}
