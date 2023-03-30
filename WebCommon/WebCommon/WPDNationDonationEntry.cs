namespace WebCommon;

public class WPDNationDonationEntry : WPDPacketData
{
	public int entryId;

	public string nameKey;

	public int moneyType;

	public long moneyAmount;

	public long exploitPointRewardId;

	public long nationFundRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(entryId);
		writer.Write(nameKey);
		writer.Write(moneyType);
		writer.Write(moneyAmount);
		writer.Write(exploitPointRewardId);
		writer.Write(nationFundRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		entryId = reader.ReadInt32();
		nameKey = reader.ReadString();
		moneyType = reader.ReadInt32();
		moneyAmount = reader.ReadInt64();
		exploitPointRewardId = reader.ReadInt64();
		nationFundRewardId = reader.ReadInt64();
	}
}
