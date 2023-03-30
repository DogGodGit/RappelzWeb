namespace WebCommon;

public class WPDWingStepPart : WPDPacketData
{
	public int step;

	public int partId;

	public long increaseAttrValueId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(step);
		writer.Write(partId);
		writer.Write(increaseAttrValueId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		step = reader.ReadInt32();
		partId = reader.ReadInt32();
		increaseAttrValueId = reader.ReadInt64();
	}
}
