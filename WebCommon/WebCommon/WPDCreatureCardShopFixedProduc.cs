namespace WebCommon;

public class WPDCreatureCardShopFixedProduct : WPDPacketData
{
	public int productId;

	public int itemId;

	public bool itemOwned;

	public int saleSoulPowder;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(productId);
		writer.Write(itemId);
		writer.Write(itemOwned);
		writer.Write(saleSoulPowder);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		productId = reader.ReadInt32();
		itemId = reader.ReadInt32();
		itemOwned = reader.ReadBoolean();
		saleSoulPowder = reader.ReadInt32();
	}
}
