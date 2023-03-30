namespace WebCommon;

public class WPDTreatOfFarmQuestReward : WPDPacketData
{
	public int level;

	public long missionCompletionExpRewardId;

	public long missionCompletionItemRewardId;

	public long questCompletionItemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(level);
		writer.Write(missionCompletionExpRewardId);
		writer.Write(missionCompletionItemRewardId);
		writer.Write(questCompletionItemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		level = reader.ReadInt32();
		missionCompletionExpRewardId = reader.ReadInt64();
		missionCompletionItemRewardId = reader.ReadInt64();
		questCompletionItemRewardId = reader.ReadInt64();
	}
}
