namespace WebCommon;

public class WPDAchievementRewardEntry : WPDPacketData
{
	public int rewardNo;

	public int rewardEntryNo;

	public long itemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(rewardNo);
		writer.Write(rewardEntryNo);
		writer.Write(itemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		rewardNo = reader.ReadInt32();
		rewardEntryNo = reader.ReadInt32();
		itemRewardId = reader.ReadInt64();
	}
}
