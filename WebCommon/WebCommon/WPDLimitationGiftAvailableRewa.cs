namespace WebCommon;

public class WPDLimitationGiftAvailableReward : WPDPacketData
{
	public int scheduleId;

	public int rewardNo;

	public int itemId;

	public int sortNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(scheduleId);
		writer.Write(rewardNo);
		writer.Write(itemId);
		writer.Write(sortNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		scheduleId = reader.ReadInt32();
		rewardNo = reader.ReadInt32();
		itemId = reader.ReadInt32();
		sortNo = reader.ReadInt32();
	}
}
