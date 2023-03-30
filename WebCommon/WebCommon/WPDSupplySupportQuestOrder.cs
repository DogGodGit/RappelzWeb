namespace WebCommon;

public class WPDSupplySupportQuestOrder : WPDPacketData
{
	public int orderId;

	public int orderItemId;

	public long failRefundGoldRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(orderId);
		writer.Write(orderItemId);
		writer.Write(failRefundGoldRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		orderId = reader.ReadInt32();
		orderItemId = reader.ReadInt32();
		failRefundGoldRewardId = reader.ReadInt64();
	}
}
