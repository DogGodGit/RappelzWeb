namespace WebCommon;

public class WPDMysteryBoxQuestReward : WPDPacketData
{
	public int grade;

	public int level;

	public long expRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(grade);
		writer.Write(level);
		writer.Write(expRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		grade = reader.ReadInt32();
		level = reader.ReadInt32();
		expRewardId = reader.ReadInt64();
	}
}
