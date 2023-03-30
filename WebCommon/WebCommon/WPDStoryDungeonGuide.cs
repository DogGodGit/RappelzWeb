namespace WebCommon;

public class WPDStoryDungeonGuide : WPDPacketData
{
	public int dungeonNo;

	public int difficulty;

	public int step;

	public int no;

	public string imageName;

	public string titleKey;

	public string contentKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(dungeonNo);
		writer.Write(difficulty);
		writer.Write(step);
		writer.Write(no);
		writer.Write(imageName);
		writer.Write(titleKey);
		writer.Write(contentKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		dungeonNo = reader.ReadInt32();
		difficulty = reader.ReadInt32();
		step = reader.ReadInt32();
		no = reader.ReadInt32();
		imageName = reader.ReadString();
		titleKey = reader.ReadString();
		contentKey = reader.ReadString();
	}
}
