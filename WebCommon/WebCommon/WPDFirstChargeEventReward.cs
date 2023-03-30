namespace WebCommon;

public class WPDFirstChargeEventReward : WPDPacketData
{
	public int rewardNo;

	public long itemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(rewardNo);
		writer.Write(itemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		rewardNo = reader.ReadInt32();
		itemRewardId = reader.ReadInt64();
	}
}
