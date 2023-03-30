namespace WebCommon;

public class WPDDimensionRaidQuestReward : WPDPacketData
{
	public int level;

	public long expRewardId;

	public long exploitPointRewardId;

	public long itemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(level);
		writer.Write(expRewardId);
		writer.Write(exploitPointRewardId);
		writer.Write(itemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		level = reader.ReadInt32();
		expRewardId = reader.ReadInt64();
		exploitPointRewardId = reader.ReadInt64();
		itemRewardId = reader.ReadInt64();
	}
}
