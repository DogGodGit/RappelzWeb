namespace WebCommon;

public class WPDGuildDailyObjectiveReward : WPDPacketData
{
	public int rewardNo;

	public int completionMemberCount;

	public long itemReward1Id;

	public long itemReward2Id;

	public long itemReward3Id;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(rewardNo);
		writer.Write(completionMemberCount);
		writer.Write(itemReward1Id);
		writer.Write(itemReward2Id);
		writer.Write(itemReward3Id);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		rewardNo = reader.ReadInt32();
		completionMemberCount = reader.ReadInt32();
		itemReward1Id = reader.ReadInt64();
		itemReward2Id = reader.ReadInt64();
		itemReward3Id = reader.ReadInt64();
	}
}
