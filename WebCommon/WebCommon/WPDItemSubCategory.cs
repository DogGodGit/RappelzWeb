namespace WebCommon;

public class WPDItemSubCategory : WPDPacketData
{
	public int mainCategoryId;

	public int subCategoryId;

	public string nameKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(mainCategoryId);
		writer.Write(subCategoryId);
		writer.Write(nameKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		mainCategoryId = reader.ReadInt32();
		subCategoryId = reader.ReadInt32();
		nameKey = reader.ReadString();
	}
}
