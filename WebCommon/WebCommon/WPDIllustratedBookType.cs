namespace WebCommon;

public class WPDIllustratedBookType : WPDPacketData
{
	public int type;

	public string nameKey;

	public int categoryId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(type);
		writer.Write(nameKey);
		writer.Write(categoryId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		type = reader.ReadInt32();
		nameKey = reader.ReadString();
		categoryId = reader.ReadInt32();
	}
}
