namespace WebCommon;

public class WPDCreatureCardCollection : WPDPacketData
{
	public int collectionId;

	public string nameKey;

	public int categoryId;

	public int grade;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(collectionId);
		writer.Write(nameKey);
		writer.Write(categoryId);
		writer.Write(grade);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		collectionId = reader.ReadInt32();
		nameKey = reader.ReadString();
		categoryId = reader.ReadInt32();
		grade = reader.ReadInt32();
	}
}
