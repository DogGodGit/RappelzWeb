namespace WebCommon;

public class WPDCreatureCardCollectionGrade : WPDPacketData
{
	public int grade;

	public string colorCode;

	public int collectionFamePoint;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(grade);
		writer.Write(colorCode);
		writer.Write(collectionFamePoint);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		grade = reader.ReadInt32();
		colorCode = reader.ReadString();
		collectionFamePoint = reader.ReadInt32();
	}
}
