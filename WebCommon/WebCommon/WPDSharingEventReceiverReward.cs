namespace WebCommon;

public class WPDSharingEventReceiverReward : WPDPacketData
{
	public int eventId;

	public int rewardNo;

	public int itemId;

	public bool itemOwned;

	public int itemCount;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(eventId);
		writer.Write(rewardNo);
		writer.Write(itemId);
		writer.Write(itemOwned);
		writer.Write(itemCount);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		eventId = reader.ReadInt32();
		rewardNo = reader.ReadInt32();
		itemId = reader.ReadInt32();
		itemOwned = reader.ReadBoolean();
		itemCount = reader.ReadInt32();
	}
}
