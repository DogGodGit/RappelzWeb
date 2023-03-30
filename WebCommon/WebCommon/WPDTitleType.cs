namespace WebCommon;

public class WPDTitleType : WPDPacketData
{
	public int type;

	public int categoryId;

	public string nameKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(type);
		writer.Write(categoryId);
		writer.Write(nameKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		type = reader.ReadInt32();
		categoryId = reader.ReadInt32();
		nameKey = reader.ReadString();
	}
}
