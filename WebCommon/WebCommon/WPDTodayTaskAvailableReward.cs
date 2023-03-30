namespace WebCommon;

public class WPDTodayTaskAvailableReward : WPDPacketData
{
	public int taskId;

	public int rewardNo;

	public int itemId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(taskId);
		writer.Write(rewardNo);
		writer.Write(itemId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		taskId = reader.ReadInt32();
		rewardNo = reader.ReadInt32();
		itemId = reader.ReadInt32();
	}
}
