namespace WebCommon;

public class WPDBattlefieldSupportEvent : WPDPacketData
{
	public int startTime;

	public int endTime;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(startTime);
		writer.Write(endTime);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		startTime = reader.ReadInt32();
		endTime = reader.ReadInt32();
	}
}
