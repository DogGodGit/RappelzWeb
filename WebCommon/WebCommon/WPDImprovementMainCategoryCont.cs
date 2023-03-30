namespace WebCommon;

public class WPDImprovementMainCategoryContent : WPDPacketData
{
	public int mainCategoryId;

	public int contentId;

	public int sortNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(mainCategoryId);
		writer.Write(contentId);
		writer.Write(sortNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		mainCategoryId = reader.ReadInt32();
		contentId = reader.ReadInt32();
		sortNo = reader.ReadInt32();
	}
}
