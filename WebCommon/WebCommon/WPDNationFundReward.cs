namespace WebCommon;

public class WPDNationFundReward : WPDPacketData
{
	public long nationFundRewardId;

	public int value;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(nationFundRewardId);
		writer.Write(value);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		nationFundRewardId = reader.ReadInt64();
		value = reader.ReadInt32();
	}
}
