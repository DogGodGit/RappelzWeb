namespace WebCommon;

public class WPDBiographyReward : WPDPacketData
{
	public int biographyId;

	public int rewardNo;

	public long itemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(biographyId);
		writer.Write(rewardNo);
		writer.Write(itemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		biographyId = reader.ReadInt32();
		rewardNo = reader.ReadInt32();
		itemRewardId = reader.ReadInt64();
	}
}
