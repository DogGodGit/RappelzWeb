namespace WebCommon;

public class WPDExpReward : WPDPacketData
{
	public long expRewardId;

	public long value;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(expRewardId);
		writer.Write(value);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		expRewardId = reader.ReadInt64();
		value = reader.ReadInt64();
	}
}
