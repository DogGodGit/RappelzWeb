namespace WebCommon;

public class WPDTodayTask : WPDPacketData
{
	public int taskId;

	public int categoryId;

	public string nameKey;

	public string descriptionKey;

	public string rewardTextKey;

	public string eventTimeTextKey;

	public string lockTextKey;

	public int rank;

	public int achievementPoint;

	public int sortNo;

	public bool isRecommend;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(taskId);
		writer.Write(categoryId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(rewardTextKey);
		writer.Write(eventTimeTextKey);
		writer.Write(lockTextKey);
		writer.Write(rank);
		writer.Write(achievementPoint);
		writer.Write(sortNo);
		writer.Write(isRecommend);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		taskId = reader.ReadInt32();
		categoryId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		rewardTextKey = reader.ReadString();
		eventTimeTextKey = reader.ReadString();
		lockTextKey = reader.ReadString();
		rank = reader.ReadInt32();
		achievementPoint = reader.ReadInt32();
		sortNo = reader.ReadInt32();
		isRecommend = reader.ReadBoolean();
	}
}
