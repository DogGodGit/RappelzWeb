namespace WebCommon;

public class WPDExpDungeonDifficulty : WPDPacketData
{
	public int difficulty;

	public int requiredConditionType;

	public int requiredHeroLevel;

	public int requiredMainQuestNo;

	public long expRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(difficulty);
		writer.Write(requiredConditionType);
		writer.Write(requiredHeroLevel);
		writer.Write(requiredMainQuestNo);
		writer.Write(expRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		difficulty = reader.ReadInt32();
		requiredConditionType = reader.ReadInt32();
		requiredHeroLevel = reader.ReadInt32();
		requiredMainQuestNo = reader.ReadInt32();
		expRewardId = reader.ReadInt64();
	}
}
