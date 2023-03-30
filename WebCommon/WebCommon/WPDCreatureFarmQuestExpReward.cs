namespace WebCommon;

public class WPDCreatureFarmQuestExpReward : WPDPacketData
{
	public int level;

	public long expRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(level);
		writer.Write(expRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		level = reader.ReadInt32();
		expRewardId = reader.ReadInt64();
	}
}
