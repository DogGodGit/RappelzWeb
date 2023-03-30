namespace WebCommon;

public class WPDSupplySupportQuestReward : WPDPacketData
{
	public int cartId;

	public int level;

	public long expRewardId;

	public long goldRewardId;

	public long exploitPointRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(cartId);
		writer.Write(level);
		writer.Write(expRewardId);
		writer.Write(goldRewardId);
		writer.Write(exploitPointRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		cartId = reader.ReadInt32();
		level = reader.ReadInt32();
		expRewardId = reader.ReadInt64();
		goldRewardId = reader.ReadInt64();
		exploitPointRewardId = reader.ReadInt64();
	}
}
