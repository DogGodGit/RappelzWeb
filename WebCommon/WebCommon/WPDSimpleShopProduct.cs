namespace WebCommon;

public class WPDSimpleShopProduct : WPDPacketData
{
	public int productId;

	public int itemId;

	public bool itemOwned;

	public int saleGold;

	public int sortNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(productId);
		writer.Write(itemId);
		writer.Write(itemOwned);
		writer.Write(saleGold);
		writer.Write(sortNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		productId = reader.ReadInt32();
		itemId = reader.ReadInt32();
		itemOwned = reader.ReadBoolean();
		saleGold = reader.ReadInt32();
		sortNo = reader.ReadInt32();
	}
}
