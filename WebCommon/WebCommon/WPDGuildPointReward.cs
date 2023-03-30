namespace WebCommon;

public class WPDGuildPointReward : WPDPacketData
{
	public long guildPointRewardId;

	public int value;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(guildPointRewardId);
		writer.Write(value);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		guildPointRewardId = reader.ReadInt64();
		value = reader.ReadInt32();
	}
}
