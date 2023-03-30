namespace WebCommon;

public class WPDSoulCoveterAvailableReward : WPDPacketData
{
	public int rewardNo;

	public int itemId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(rewardNo);
		writer.Write(itemId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		rewardNo = reader.ReadInt32();
		itemId = reader.ReadInt32();
	}
}
