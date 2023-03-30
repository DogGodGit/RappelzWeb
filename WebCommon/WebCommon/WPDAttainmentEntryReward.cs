namespace WebCommon;

public class WPDAttainmentEntryReward : WPDPacketData
{
	public int entryNo;

	public int rewardNo;

	public int type;

	public int mainGearId;

	public bool mainGearOwned;

	public long itemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(entryNo);
		writer.Write(rewardNo);
		writer.Write(type);
		writer.Write(mainGearId);
		writer.Write(mainGearOwned);
		writer.Write(itemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		entryNo = reader.ReadInt32();
		rewardNo = reader.ReadInt32();
		type = reader.ReadInt32();
		mainGearId = reader.ReadInt32();
		mainGearOwned = reader.ReadBoolean();
		itemRewardId = reader.ReadInt64();
	}
}
