namespace WebCommon;

public class WPDCashProduct : WPDPacketData
{
	public int productId;

	public string nameKey;

	public string inAppProductKey;

	public string imageName;

	public int type;

	public int unOwnDia;

	public int itemId;

	public bool itemOwned;

	public int itemCount;

	public int vipPoint;

	public int firstPurchaseBonusUnOwnDia;

	public int sortNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(productId);
		writer.Write(nameKey);
		writer.Write(inAppProductKey);
		writer.Write(imageName);
		writer.Write(type);
		writer.Write(unOwnDia);
		writer.Write(itemId);
		writer.Write(itemOwned);
		writer.Write(itemCount);
		writer.Write(vipPoint);
		writer.Write(firstPurchaseBonusUnOwnDia);
		writer.Write(sortNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		productId = reader.ReadInt32();
		nameKey = reader.ReadString();
		inAppProductKey = reader.ReadString();
		imageName = reader.ReadString();
		type = reader.ReadInt32();
		unOwnDia = reader.ReadInt32();
		itemId = reader.ReadInt32();
		itemOwned = reader.ReadBoolean();
		itemCount = reader.ReadInt32();
		vipPoint = reader.ReadInt32();
		firstPurchaseBonusUnOwnDia = reader.ReadInt32();
		sortNo = reader.ReadInt32();
	}
}
