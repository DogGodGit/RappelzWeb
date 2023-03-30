namespace WebCommon;

public class WPDPotionAttr : WPDPacketData
{
	public int potionAttrId;

	public int attrId;

	public long incAttrValueId;

	public int requiredItemId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(potionAttrId);
		writer.Write(attrId);
		writer.Write(incAttrValueId);
		writer.Write(requiredItemId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		potionAttrId = reader.ReadInt32();
		attrId = reader.ReadInt32();
		incAttrValueId = reader.ReadInt64();
		requiredItemId = reader.ReadInt32();
	}
}
