namespace WebCommon;

public class WPDRookieGiftReward : WPDPacketData
{
	public int giftNo;

	public int rewardNo;

	public long itemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(giftNo);
		writer.Write(rewardNo);
		writer.Write(itemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		giftNo = reader.ReadInt32();
		rewardNo = reader.ReadInt32();
		itemRewardId = reader.ReadInt64();
	}
}
