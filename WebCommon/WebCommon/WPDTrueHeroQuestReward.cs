namespace WebCommon;

public class WPDTrueHeroQuestReward : WPDPacketData
{
	public int level;

	public long expRewardId;

	public long exploitPointRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(level);
		writer.Write(expRewardId);
		writer.Write(exploitPointRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		level = reader.ReadInt32();
		expRewardId = reader.ReadInt64();
		exploitPointRewardId = reader.ReadInt64();
	}
}
