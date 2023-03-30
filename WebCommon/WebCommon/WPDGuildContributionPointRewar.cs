namespace WebCommon;

public class WPDGuildContributionPointReward : WPDPacketData
{
	public long guildContributionPointRewardId;

	public int value;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(guildContributionPointRewardId);
		writer.Write(value);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		guildContributionPointRewardId = reader.ReadInt64();
		value = reader.ReadInt32();
	}
}
