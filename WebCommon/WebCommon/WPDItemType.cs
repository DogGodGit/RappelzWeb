namespace WebCommon;

public class WPDItemType : WPDPacketData
{
	public int itemType;

	public int maxCountPerInventorySlot;

	public int mainCategoryId;

	public int subCategoryId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(itemType);
		writer.Write(maxCountPerInventorySlot);
		writer.Write(mainCategoryId);
		writer.Write(subCategoryId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		itemType = reader.ReadInt32();
		maxCountPerInventorySlot = reader.ReadInt32();
		mainCategoryId = reader.ReadInt32();
		subCategoryId = reader.ReadInt32();
	}
}
