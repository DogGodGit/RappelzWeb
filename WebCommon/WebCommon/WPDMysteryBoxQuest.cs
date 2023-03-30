namespace WebCommon;

public class WPDMysteryBoxQuest : WPDPacketData
{
	public string targetTitleKey;

	public string targetContentKey;

	public int requiredHeroLevel;

	public int questNpcId;

	public int targetNpcId;

	public int limitCount;

	public int interactionDuration;

	public string descriptionKey;

	public string startDialogueKey;

	public string completionDialogueKey;

	public string completionTextKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(requiredHeroLevel);
		writer.Write(questNpcId);
		writer.Write(targetNpcId);
		writer.Write(limitCount);
		writer.Write(interactionDuration);
		writer.Write(descriptionKey);
		writer.Write(startDialogueKey);
		writer.Write(completionDialogueKey);
		writer.Write(completionTextKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		requiredHeroLevel = reader.ReadInt32();
		questNpcId = reader.ReadInt32();
		targetNpcId = reader.ReadInt32();
		limitCount = reader.ReadInt32();
		interactionDuration = reader.ReadInt32();
		descriptionKey = reader.ReadString();
		startDialogueKey = reader.ReadString();
		completionDialogueKey = reader.ReadString();
		completionTextKey = reader.ReadString();
	}
}
