namespace WebCommon;

public class WPDSubGearAttrValue : WPDPacketData
{
	public int subGearId;

	public int attrId;

	public int level;

	public int quality;

	public long attrValueId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(subGearId);
		writer.Write(attrId);
		writer.Write(level);
		writer.Write(quality);
		writer.Write(attrValueId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		subGearId = reader.ReadInt32();
		attrId = reader.ReadInt32();
		level = reader.ReadInt32();
		quality = reader.ReadInt32();
		attrValueId = reader.ReadInt64();
	}
}
