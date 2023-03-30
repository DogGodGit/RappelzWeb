namespace WebCommon;

public class WPDImprovementContent : WPDPacketData
{
	public int contentId;

	public string nameKey;

	public string descriptionKey;

	public bool isAchievementDisplay;

	public int requiredConditionType;

	public int requiredHeroLevel;

	public int requiredMainQuestNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(contentId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(isAchievementDisplay);
		writer.Write(requiredConditionType);
		writer.Write(requiredHeroLevel);
		writer.Write(requiredMainQuestNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		contentId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		isAchievementDisplay = reader.ReadBoolean();
		requiredConditionType = reader.ReadInt32();
		requiredHeroLevel = reader.ReadInt32();
		requiredMainQuestNo = reader.ReadInt32();
	}
}
