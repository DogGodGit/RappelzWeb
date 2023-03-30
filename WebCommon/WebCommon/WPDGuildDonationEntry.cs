namespace WebCommon;

public class WPDGuildDonationEntry : WPDPacketData
{
	public int entryId;

	public string nameKey;

	public int moneyType;

	public long moneyAmount;

	public long guildContributionPointRewardId;

	public long guildFundRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(entryId);
		writer.Write(nameKey);
		writer.Write(moneyType);
		writer.Write(moneyAmount);
		writer.Write(guildContributionPointRewardId);
		writer.Write(guildFundRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		entryId = reader.ReadInt32();
		nameKey = reader.ReadString();
		moneyType = reader.ReadInt32();
		moneyAmount = reader.ReadInt64();
		guildContributionPointRewardId = reader.ReadInt64();
		guildFundRewardId = reader.ReadInt64();
	}
}
