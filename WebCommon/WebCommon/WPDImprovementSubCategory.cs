namespace WebCommon;

public class WPDImprovementSubCategory : WPDPacketData
{
	public int subCategoryId;

	public int mainCategoryId;

	public string nameKey;

	public int sortNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(subCategoryId);
		writer.Write(mainCategoryId);
		writer.Write(nameKey);
		writer.Write(sortNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		subCategoryId = reader.ReadInt32();
		mainCategoryId = reader.ReadInt32();
		nameKey = reader.ReadString();
		sortNo = reader.ReadInt32();
	}
}
