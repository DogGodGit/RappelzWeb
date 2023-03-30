namespace WebCommon;

public class WPDFieldBossEventSchedule : WPDPacketData
{
	public int scheduleId;

	public int startTime;

	public int endTime;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(scheduleId);
		writer.Write(startTime);
		writer.Write(endTime);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		scheduleId = reader.ReadInt32();
		startTime = reader.ReadInt32();
		endTime = reader.ReadInt32();
	}
}
