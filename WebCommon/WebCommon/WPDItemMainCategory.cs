namespace WebCommon;

public class WPDItemMainCategory : WPDPacketData
{
	public int mainCategoryId;

	public string nameKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(mainCategoryId);
		writer.Write(nameKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		mainCategoryId = reader.ReadInt32();
		nameKey = reader.ReadString();
	}
}
