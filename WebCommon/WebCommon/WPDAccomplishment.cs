namespace WebCommon;

public class WPDAccomplishment : WPDPacketData
{
	public int accomplishmentId;

	public int categoryId;

	public int type;

	public string nameKey;

	public string objectiveTextKey;

	public long objectiveValue;

	public int point;

	public int rewardType;

	public int rewardTitleId;

	public long itemRewardId;

	public int sortNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(accomplishmentId);
		writer.Write(categoryId);
		writer.Write(type);
		writer.Write(nameKey);
		writer.Write(objectiveTextKey);
		writer.Write(objectiveValue);
		writer.Write(point);
		writer.Write(rewardType);
		writer.Write(rewardTitleId);
		writer.Write(itemRewardId);
		writer.Write(sortNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		accomplishmentId = reader.ReadInt32();
		categoryId = reader.ReadInt32();
		type = reader.ReadInt32();
		nameKey = reader.ReadString();
		objectiveTextKey = reader.ReadString();
		objectiveValue = reader.ReadInt64();
		point = reader.ReadInt32();
		rewardType = reader.ReadInt32();
		rewardTitleId = reader.ReadInt32();
		itemRewardId = reader.ReadInt64();
		sortNo = reader.ReadInt32();
	}
}
