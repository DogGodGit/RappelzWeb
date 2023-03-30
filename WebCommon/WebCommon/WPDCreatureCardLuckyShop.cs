namespace WebCommon;

public class WPDCreatureCardLuckyShop : WPDPacketData
{
	public string nameKey;

	public int freePickCount;

	public int freePickWaitingTime;

	public int pick1TimeDia;

	public int pick5TimeDia;

	public long pick1TimeGoldRewardId;

	public long pick5TimeGoldRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(nameKey);
		writer.Write(freePickCount);
		writer.Write(freePickWaitingTime);
		writer.Write(pick1TimeDia);
		writer.Write(pick5TimeDia);
		writer.Write(pick1TimeGoldRewardId);
		writer.Write(pick5TimeGoldRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		nameKey = reader.ReadString();
		freePickCount = reader.ReadInt32();
		freePickWaitingTime = reader.ReadInt32();
		pick1TimeDia = reader.ReadInt32();
		pick5TimeDia = reader.ReadInt32();
		pick1TimeGoldRewardId = reader.ReadInt64();
		pick5TimeGoldRewardId = reader.ReadInt64();
	}
}
