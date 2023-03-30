namespace WebCommon;

public class WPDAttrValue : WPDPacketData
{
	public long attrValueId;

	public int value;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(attrValueId);
		writer.Write(value);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		attrValueId = reader.ReadInt64();
		value = reader.ReadInt32();
	}
}
