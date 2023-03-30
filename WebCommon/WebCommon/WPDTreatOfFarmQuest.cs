namespace WebCommon;

public class WPDTreatOfFarmQuest : WPDPacketData
{
	public int requiredHeroLevel;

	public string titleKey;

	public string targetMovingTextKey;

	public string targetKillTextKey;

	public int limitCount;

	public int questNpcId;

	public int monsterKillLimitTime;

	public string targetMovingDescriptionKey;

	public string targetKillDescriptionKey;

	public string startDialogueKey;

	public string completionDialogueKey;

	public string completionTextKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(requiredHeroLevel);
		writer.Write(titleKey);
		writer.Write(targetMovingTextKey);
		writer.Write(targetKillTextKey);
		writer.Write(limitCount);
		writer.Write(questNpcId);
		writer.Write(monsterKillLimitTime);
		writer.Write(targetMovingDescriptionKey);
		writer.Write(targetKillDescriptionKey);
		writer.Write(startDialogueKey);
		writer.Write(completionDialogueKey);
		writer.Write(completionTextKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		requiredHeroLevel = reader.ReadInt32();
		titleKey = reader.ReadString();
		targetMovingTextKey = reader.ReadString();
		targetKillTextKey = reader.ReadString();
		limitCount = reader.ReadInt32();
		questNpcId = reader.ReadInt32();
		monsterKillLimitTime = reader.ReadInt32();
		targetMovingDescriptionKey = reader.ReadString();
		targetKillDescriptionKey = reader.ReadString();
		startDialogueKey = reader.ReadString();
		completionDialogueKey = reader.ReadString();
		completionTextKey = reader.ReadString();
	}
}
