namespace WebCommon;

public class WPDDiaShopCategory : WPDPacketData
{
	public int categoryId;

	public string nameKey;

	public int requiredVipLevel;

	public int sortNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(categoryId);
		writer.Write(nameKey);
		writer.Write(requiredVipLevel);
		writer.Write(sortNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		categoryId = reader.ReadInt32();
		nameKey = reader.ReadString();
		requiredVipLevel = reader.ReadInt32();
		sortNo = reader.ReadInt32();
	}
}
