namespace WebCommon;

public class WPDTaskConsignmentAvailableReward : WPDPacketData
{
	public int consignmentId;

	public int rewardNo;

	public int itemId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(consignmentId);
		writer.Write(rewardNo);
		writer.Write(itemId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		consignmentId = reader.ReadInt32();
		rewardNo = reader.ReadInt32();
		itemId = reader.ReadInt32();
	}
}
