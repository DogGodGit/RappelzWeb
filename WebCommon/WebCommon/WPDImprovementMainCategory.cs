namespace WebCommon;

public class WPDImprovementMainCategory : WPDPacketData
{
	public int mainCategoryId;

	public string nameKey;

	public int sortNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(mainCategoryId);
		writer.Write(nameKey);
		writer.Write(sortNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		mainCategoryId = reader.ReadInt32();
		nameKey = reader.ReadString();
		sortNo = reader.ReadInt32();
	}
}
