namespace WebCommon;

public class WPDWeeklyPresentContributionPointRankingRewardGroup : WPDPacketData
{
	public int groupNo;

	public int highRanking;

	public int lowRanking;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(groupNo);
		writer.Write(highRanking);
		writer.Write(lowRanking);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		groupNo = reader.ReadInt32();
		highRanking = reader.ReadInt32();
		lowRanking = reader.ReadInt32();
	}
}
public class WPDWeeklyPresentContributionPointRankingReward : WPDPacketData
{
	public int groupNo;

	public int rewardNo;

	public long itemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(groupNo);
		writer.Write(rewardNo);
		writer.Write(itemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		groupNo = reader.ReadInt32();
		rewardNo = reader.ReadInt32();
		itemRewardId = reader.ReadInt64();
	}
}
