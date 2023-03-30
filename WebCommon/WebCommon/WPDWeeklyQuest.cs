namespace WebCommon;

public class WPDWeeklyQuest : WPDPacketData
{
	public string titleKey;

	public int roundCount;

	public int requiredHeroLevel;

	public int roundRefreshRequiredGold;

	public int roundImmediateCompletionRequiredItemId;

	public int tenRoundCompletionRequiredVipLevel;

	public float tenRoundCompletionRewardFactor;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(titleKey);
		writer.Write(roundCount);
		writer.Write(requiredHeroLevel);
		writer.Write(roundRefreshRequiredGold);
		writer.Write(roundImmediateCompletionRequiredItemId);
		writer.Write(tenRoundCompletionRequiredVipLevel);
		writer.Write(tenRoundCompletionRewardFactor);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		titleKey = reader.ReadString();
		roundCount = reader.ReadInt32();
		requiredHeroLevel = reader.ReadInt32();
		roundRefreshRequiredGold = reader.ReadInt32();
		roundImmediateCompletionRequiredItemId = reader.ReadInt32();
		tenRoundCompletionRequiredVipLevel = reader.ReadInt32();
		tenRoundCompletionRewardFactor = reader.ReadSingle();
	}
}
