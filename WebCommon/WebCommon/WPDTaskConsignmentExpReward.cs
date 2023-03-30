namespace WebCommon;

public class WPDTaskConsignmentExpReward : WPDPacketData
{
	public int consignmentId;

	public int level;

	public long expRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(consignmentId);
		writer.Write(level);
		writer.Write(expRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		consignmentId = reader.ReadInt32();
		level = reader.ReadInt32();
		expRewardId = reader.ReadInt64();
	}
}
