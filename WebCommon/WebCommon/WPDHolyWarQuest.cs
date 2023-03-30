namespace WebCommon;

public class WPDHolyWarQuest : WPDPacketData
{
	public string targetTitleKey;

	public string targetContentKey;

	public string descriptionKey;

	public int requiredHeroLevel;

	public int questNpcId;

	public int limitTime;

	public string startDialogueKey;

	public string completionDialogueKey;

	public string completionTextKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(descriptionKey);
		writer.Write(requiredHeroLevel);
		writer.Write(questNpcId);
		writer.Write(limitTime);
		writer.Write(startDialogueKey);
		writer.Write(completionDialogueKey);
		writer.Write(completionTextKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		requiredHeroLevel = reader.ReadInt32();
		questNpcId = reader.ReadInt32();
		limitTime = reader.ReadInt32();
		startDialogueKey = reader.ReadString();
		completionDialogueKey = reader.ReadString();
		completionTextKey = reader.ReadString();
	}
}
