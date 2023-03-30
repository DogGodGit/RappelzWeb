namespace WebCommon;

public class WPDImprovementSubCategoryContent : WPDPacketData
{
	public int subCategoryId;

	public int contentId;

	public int sortNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(subCategoryId);
		writer.Write(contentId);
		writer.Write(sortNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		subCategoryId = reader.ReadInt32();
		contentId = reader.ReadInt32();
		sortNo = reader.ReadInt32();
	}
}
