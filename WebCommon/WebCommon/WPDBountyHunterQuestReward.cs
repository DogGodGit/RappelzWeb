namespace WebCommon;

public class WPDBountyHunterQuestReward : WPDPacketData
{
	public int questItemGrade;

	public int level;

	public long expRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(questItemGrade);
		writer.Write(level);
		writer.Write(expRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		questItemGrade = reader.ReadInt32();
		level = reader.ReadInt32();
		expRewardId = reader.ReadInt64();
	}
}
