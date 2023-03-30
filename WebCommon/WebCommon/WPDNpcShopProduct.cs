namespace WebCommon;

public class WPDNpcShopProduct : WPDPacketData
{
	public int productId;

	public int shopId;

	public int categoryId;

	public int itemId;

	public bool itemOwned;

	public int requiredItemCount;

	public int limitCount;

	public int sortNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(productId);
		writer.Write(shopId);
		writer.Write(categoryId);
		writer.Write(itemId);
		writer.Write(itemOwned);
		writer.Write(requiredItemCount);
		writer.Write(limitCount);
		writer.Write(sortNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		productId = reader.ReadInt32();
		shopId = reader.ReadInt32();
		categoryId = reader.ReadInt32();
		itemId = reader.ReadInt32();
		itemOwned = reader.ReadBoolean();
		requiredItemCount = reader.ReadInt32();
		limitCount = reader.ReadInt32();
		sortNo = reader.ReadInt32();
	}
}
