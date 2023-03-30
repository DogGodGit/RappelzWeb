using System;

namespace WebCommon;

public class WPDDiaShopProduct : WPDPacketData
{
	public int productId;

	public int categoryId;

	public int costumeProductType;

	public int itemId;

	public bool itemOwned;

	public int tagType;

	public int moneyType;

	public int moneyItemId;

	public int originalPrice;

	public int price;

	public int buyLimitType;

	public int buyLimitCount;

	public int periodType;

	public DateTime periodStartTime;

	public DateTime periodEndTime;

	public int periodDayOfWeek;

	public bool recommended;

	public bool isLimitEdition;

	public int categorySortNo;

	public int limitEditionSortNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(productId);
		writer.Write(categoryId);
		writer.Write(costumeProductType);
		writer.Write(itemId);
		writer.Write(itemOwned);
		writer.Write(tagType);
		writer.Write(moneyType);
		writer.Write(moneyItemId);
		writer.Write(originalPrice);
		writer.Write(price);
		writer.Write(buyLimitType);
		writer.Write(buyLimitCount);
		writer.Write(periodType);
		writer.Write(periodStartTime);
		writer.Write(periodEndTime);
		writer.Write(periodDayOfWeek);
		writer.Write(recommended);
		writer.Write(isLimitEdition);
		writer.Write(categorySortNo);
		writer.Write(limitEditionSortNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		productId = reader.ReadInt32();
		categoryId = reader.ReadInt32();
		costumeProductType = reader.ReadInt32();
		itemId = reader.ReadInt32();
		itemOwned = reader.ReadBoolean();
		tagType = reader.ReadInt32();
		moneyType = reader.ReadInt32();
		moneyItemId = reader.ReadInt32();
		originalPrice = reader.ReadInt32();
		price = reader.ReadInt32();
		buyLimitType = reader.ReadInt32();
		buyLimitCount = reader.ReadInt32();
		periodType = reader.ReadInt32();
		periodStartTime = reader.ReadDateTime();
		periodEndTime = reader.ReadDateTime();
		periodDayOfWeek = reader.ReadInt32();
		recommended = reader.ReadBoolean();
		isLimitEdition = reader.ReadBoolean();
		categorySortNo = reader.ReadInt32();
		limitEditionSortNo = reader.ReadInt32();
	}
}
