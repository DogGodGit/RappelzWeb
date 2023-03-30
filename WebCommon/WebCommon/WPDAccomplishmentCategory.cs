namespace WebCommon;

public class WPDAccomplishmentCategory : WPDPacketData
{
	public int categoryId;

	public string nameKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(categoryId);
		writer.Write(nameKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		categoryId = reader.ReadInt32();
		nameKey = reader.ReadString();
	}
}
