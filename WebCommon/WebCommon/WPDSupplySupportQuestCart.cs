namespace WebCommon;

public class WPDSupplySupportQuestCart : WPDPacketData
{
	public int cartId;

	public long destructionItemRewardId;

	public int sortNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(cartId);
		writer.Write(destructionItemRewardId);
		writer.Write(sortNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		cartId = reader.ReadInt32();
		destructionItemRewardId = reader.ReadInt64();
		sortNo = reader.ReadInt32();
	}
}
