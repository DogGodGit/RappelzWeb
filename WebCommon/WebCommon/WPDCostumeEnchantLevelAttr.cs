namespace WebCommon;

public class WPDCostumeEnchantLevelAttr : WPDPacketData
{
	public int costumeId;

	public int enchantLevel;

	public int attrId;

	public long attrValueId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(costumeId);
		writer.Write(enchantLevel);
		writer.Write(attrId);
		writer.Write(attrValueId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		costumeId = reader.ReadInt32();
		enchantLevel = reader.ReadInt32();
		attrId = reader.ReadInt32();
		attrValueId = reader.ReadInt64();
	}
}
