namespace WebCommon;

public class WPDAnkouTombDifficulty : WPDPacketData
{
	public int difficulty;

	public long recommendBattlePower;

	public int minHeroLevel;

	public int maxHeroLevel;

	public long goldRewardId;

	public long expRewardId;

	public long pointGoldRewardId;

	public long pointExpRewardId;

	public long maxAdditionalExp;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(difficulty);
		writer.Write(recommendBattlePower);
		writer.Write(minHeroLevel);
		writer.Write(maxHeroLevel);
		writer.Write(goldRewardId);
		writer.Write(expRewardId);
		writer.Write(pointGoldRewardId);
		writer.Write(pointExpRewardId);
		writer.Write(maxAdditionalExp);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		difficulty = reader.ReadInt32();
		recommendBattlePower = reader.ReadInt64();
		minHeroLevel = reader.ReadInt32();
		maxHeroLevel = reader.ReadInt32();
		goldRewardId = reader.ReadInt64();
		expRewardId = reader.ReadInt64();
		pointGoldRewardId = reader.ReadInt64();
		pointExpRewardId = reader.ReadInt64();
		maxAdditionalExp = reader.ReadInt64();
	}
}
