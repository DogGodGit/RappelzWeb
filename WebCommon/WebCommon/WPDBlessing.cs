namespace WebCommon;

public class WPDBlessing : WPDPacketData
{
	public int blessingId;

	public string nameKey;

	public string descriptionKey;

	public int moneyType;

	public int moneyAmount;

	public long senderItemRewardId;

	public long receiverGoldRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(blessingId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(moneyType);
		writer.Write(moneyAmount);
		writer.Write(senderItemRewardId);
		writer.Write(receiverGoldRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		blessingId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		moneyType = reader.ReadInt32();
		moneyAmount = reader.ReadInt32();
		senderItemRewardId = reader.ReadInt64();
		receiverGoldRewardId = reader.ReadInt64();
	}
}
