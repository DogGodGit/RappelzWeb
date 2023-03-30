namespace WebCommon;

public class WPDMainQuestReward : WPDPacketData
{
	public int mainQuestNo;

	public int rewardNo;

	public int type;

	public int jobId;

	public int mainGearId;

	public bool mainGearOwned;

	public int subGearId;

	public long itemRewardId;

	public int mountId;

	public int creatureCardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(mainQuestNo);
		writer.Write(rewardNo);
		writer.Write(type);
		writer.Write(jobId);
		writer.Write(mainGearId);
		writer.Write(mainGearOwned);
		writer.Write(subGearId);
		writer.Write(itemRewardId);
		writer.Write(mountId);
		writer.Write(creatureCardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		mainQuestNo = reader.ReadInt32();
		rewardNo = reader.ReadInt32();
		type = reader.ReadInt32();
		jobId = reader.ReadInt32();
		mainGearId = reader.ReadInt32();
		mainGearOwned = reader.ReadBoolean();
		subGearId = reader.ReadInt32();
		itemRewardId = reader.ReadInt64();
		mountId = reader.ReadInt32();
		creatureCardId = reader.ReadInt32();
	}
}
