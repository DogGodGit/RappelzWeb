namespace WebCommon;

public class WPDNpcShopCategory : WPDPacketData
{
	public int shopId;

	public int categoryId;

	public string nameKey;

	public int requiredItemId;

	public int sortNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(shopId);
		writer.Write(categoryId);
		writer.Write(nameKey);
		writer.Write(requiredItemId);
		writer.Write(sortNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		shopId = reader.ReadInt32();
		categoryId = reader.ReadInt32();
		nameKey = reader.ReadString();
		requiredItemId = reader.ReadInt32();
		sortNo = reader.ReadInt32();
	}
}
