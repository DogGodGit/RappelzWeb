namespace WebCommon;

public class WPDIllustratedBook : WPDPacketData
{
	public int illustratedBookId;

	public string nameKey;

	public string descriptionKey;

	public string imageName;

	public int type;

	public int explorationPoint;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(illustratedBookId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(imageName);
		writer.Write(type);
		writer.Write(explorationPoint);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		illustratedBookId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		imageName = reader.ReadString();
		type = reader.ReadInt32();
		explorationPoint = reader.ReadInt32();
	}
}
