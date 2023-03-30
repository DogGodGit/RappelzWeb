namespace WebCommon;

public class WPDItemReward : WPDPacketData
{
	public long itemRewardId;

	public int itemId;

	public int itemCount;

	public bool itemOwned;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(itemRewardId);
		writer.Write(itemId);
		writer.Write(itemCount);
		writer.Write(itemOwned);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		itemRewardId = reader.ReadInt64();
		itemId = reader.ReadInt32();
		itemCount = reader.ReadInt32();
		itemOwned = reader.ReadBoolean();
	}
}
