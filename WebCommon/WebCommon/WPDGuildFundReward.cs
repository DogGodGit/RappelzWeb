namespace WebCommon;

public class WPDGuildFundReward : WPDPacketData
{
	public long guildFundRewardId;

	public int value;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(guildFundRewardId);
		writer.Write(value);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		guildFundRewardId = reader.ReadInt64();
		value = reader.ReadInt32();
	}
}
