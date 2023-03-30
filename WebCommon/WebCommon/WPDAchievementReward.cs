namespace WebCommon;

public class WPDAchievementReward : WPDPacketData
{
	public int rewardNo;

	public int requiredAchievementPoint;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(rewardNo);
		writer.Write(requiredAchievementPoint);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		rewardNo = reader.ReadInt32();
		requiredAchievementPoint = reader.ReadInt32();
	}
}
