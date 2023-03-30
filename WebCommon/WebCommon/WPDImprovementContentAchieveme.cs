namespace WebCommon;

public class WPDImprovementContentAchievement : WPDPacketData
{
	public int achievement;

	public int achievementRate;

	public string nameKey;

	public string colorCode;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(achievement);
		writer.Write(achievementRate);
		writer.Write(nameKey);
		writer.Write(colorCode);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		achievement = reader.ReadInt32();
		achievementRate = reader.ReadInt32();
		nameKey = reader.ReadString();
		colorCode = reader.ReadString();
	}
}
public class WPDImprovementContentAchievementLevel : WPDPacketData
{
	public int contentId;

	public int level;

	public int achievementValue;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(contentId);
		writer.Write(level);
		writer.Write(achievementValue);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		contentId = reader.ReadInt32();
		level = reader.ReadInt32();
		achievementValue = reader.ReadInt32();
	}
}
