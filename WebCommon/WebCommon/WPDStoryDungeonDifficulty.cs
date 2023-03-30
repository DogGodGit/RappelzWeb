namespace WebCommon;

public class WPDStoryDungeonDifficulty : WPDPacketData
{
	public int dungeonNo;

	public int difficulty;

	public string nameKey;

	public string descriptionKey;

	public long recommendBattlePower;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(dungeonNo);
		writer.Write(difficulty);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(recommendBattlePower);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		dungeonNo = reader.ReadInt32();
		difficulty = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		recommendBattlePower = reader.ReadInt64();
	}
}
