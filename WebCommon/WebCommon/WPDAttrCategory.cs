namespace WebCommon;

public class WPDAttrCategory : WPDPacketData
{
	public int attrCategoryId;

	public string nameKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(attrCategoryId);
		writer.Write(nameKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		attrCategoryId = reader.ReadInt32();
		nameKey = reader.ReadString();
	}
}
