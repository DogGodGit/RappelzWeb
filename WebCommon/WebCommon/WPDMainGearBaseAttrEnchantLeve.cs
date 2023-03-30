namespace WebCommon;

public class WPDMainGearBaseAttrEnchantLevel : WPDPacketData
{
	public int mainGearId;

	public int attrId;

	public int enchantLevel;

	public long attrValueId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(mainGearId);
		writer.Write(attrId);
		writer.Write(enchantLevel);
		writer.Write(attrValueId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		mainGearId = reader.ReadInt32();
		attrId = reader.ReadInt32();
		enchantLevel = reader.ReadInt32();
		attrValueId = reader.ReadInt64();
	}
}
