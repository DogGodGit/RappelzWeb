namespace WebCommon;

public class WPDNationWarHeroObjectiveEntry : WPDPacketData
{
	public int entryNo;

	public string nameKey;

	public string descriptionKey;

	public int type;

	public int objectiveCount;

	public int rewardType;

	public long ownDiaRewardId;

	public long exploitPointRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(entryNo);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(type);
		writer.Write(objectiveCount);
		writer.Write(rewardType);
		writer.Write(ownDiaRewardId);
		writer.Write(exploitPointRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		entryNo = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		type = reader.ReadInt32();
		objectiveCount = reader.ReadInt32();
		rewardType = reader.ReadInt32();
		ownDiaRewardId = reader.ReadInt64();
		exploitPointRewardId = reader.ReadInt64();
	}
}
