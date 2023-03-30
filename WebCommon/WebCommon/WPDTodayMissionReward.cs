namespace WebCommon;

public class WPDTodayMissionReward : WPDPacketData
{
	public int missionId;

	public int rewardNo;

	public long itemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(missionId);
		writer.Write(rewardNo);
		writer.Write(itemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		missionId = reader.ReadInt32();
		rewardNo = reader.ReadInt32();
		itemRewardId = reader.ReadInt64();
	}
}
