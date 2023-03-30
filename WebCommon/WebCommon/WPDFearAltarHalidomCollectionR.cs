namespace WebCommon;

public class WPDFearAltarHalidomCollectionReward : WPDPacketData
{
	public int rewardNo;

	public int collectionCount;

	public long itemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(rewardNo);
		writer.Write(collectionCount);
		writer.Write(itemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		rewardNo = reader.ReadInt32();
		collectionCount = reader.ReadInt32();
		itemRewardId = reader.ReadInt64();
	}
}
