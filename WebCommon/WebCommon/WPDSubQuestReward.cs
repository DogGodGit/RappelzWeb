namespace WebCommon;

public class WPDSubQuestReward : WPDPacketData
{
	public int questId;

	public int rewardNo;

	public long itemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(questId);
		writer.Write(rewardNo);
		writer.Write(itemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		questId = reader.ReadInt32();
		rewardNo = reader.ReadInt32();
		itemRewardId = reader.ReadInt64();
	}
}
