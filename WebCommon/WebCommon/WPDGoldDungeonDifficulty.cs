namespace WebCommon;

public class WPDGoldDungeonDifficulty : WPDPacketData
{
	public int difficulty;

	public int requiredHeroLevel;

	public long goldRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(difficulty);
		writer.Write(requiredHeroLevel);
		writer.Write(goldRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		difficulty = reader.ReadInt32();
		requiredHeroLevel = reader.ReadInt32();
		goldRewardId = reader.ReadInt64();
	}
}
