namespace WebCommon;

public class WPDFieldOfHonorRankingReward : WPDPacketData
{
	public int highRanking;

	public int lowRanking;

	public int rewardNo;

	public long itemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(highRanking);
		writer.Write(lowRanking);
		writer.Write(rewardNo);
		writer.Write(itemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		highRanking = reader.ReadInt32();
		lowRanking = reader.ReadInt32();
		rewardNo = reader.ReadInt32();
		itemRewardId = reader.ReadInt64();
	}
}
