namespace WebCommon;

public class WPDGuildContent : WPDPacketData
{
	public int guildContentId;

	public string nameKey;

	public string descriptionKey;

	public string rewardTextKey;

	public string eventTimeTextKey;

	public string lockTextKey;

	public int achievementPoint;

	public bool isDailyObjective;

	public int sortNo;

	public int taskId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(guildContentId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(rewardTextKey);
		writer.Write(eventTimeTextKey);
		writer.Write(lockTextKey);
		writer.Write(achievementPoint);
		writer.Write(isDailyObjective);
		writer.Write(sortNo);
		writer.Write(taskId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		guildContentId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		rewardTextKey = reader.ReadString();
		eventTimeTextKey = reader.ReadString();
		lockTextKey = reader.ReadString();
		achievementPoint = reader.ReadInt32();
		isDailyObjective = reader.ReadBoolean();
		sortNo = reader.ReadInt32();
		taskId = reader.ReadInt32();
	}
}
