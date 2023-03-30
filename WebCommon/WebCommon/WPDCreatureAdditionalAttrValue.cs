namespace WebCommon;

public class WPDCreatureAdditionalAttrValue : WPDPacketData
{
	public int attrId;

	public int injectionLevel;

	public long attrValueId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(attrId);
		writer.Write(injectionLevel);
		writer.Write(attrValueId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		attrId = reader.ReadInt32();
		injectionLevel = reader.ReadInt32();
		attrValueId = reader.ReadInt64();
	}
}
