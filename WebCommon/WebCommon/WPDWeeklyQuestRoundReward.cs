namespace WebCommon;

public class WPDWeeklyQuestRoundReward : WPDPacketData
{
	public int roundNo;

	public int level;

	public long expRewardId;

	public long goldRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(roundNo);
		writer.Write(level);
		writer.Write(expRewardId);
		writer.Write(goldRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		roundNo = reader.ReadInt32();
		level = reader.ReadInt32();
		expRewardId = reader.ReadInt64();
		goldRewardId = reader.ReadInt64();
	}
}
