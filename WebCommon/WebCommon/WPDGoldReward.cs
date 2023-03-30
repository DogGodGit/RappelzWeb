namespace WebCommon;

public class WPDGoldReward : WPDPacketData
{
	public long goldRewardId;

	public long value;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(goldRewardId);
		writer.Write(value);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		goldRewardId = reader.ReadInt64();
		value = reader.ReadInt64();
	}
}
