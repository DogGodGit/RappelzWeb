namespace WebCommon;

public class WPDSafeTimeEvent : WPDPacketData
{
	public int requiredAutoDuration;

	public int startTime;

	public int endTime;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(requiredAutoDuration);
		writer.Write(startTime);
		writer.Write(endTime);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		requiredAutoDuration = reader.ReadInt32();
		startTime = reader.ReadInt32();
		endTime = reader.ReadInt32();
	}
}
