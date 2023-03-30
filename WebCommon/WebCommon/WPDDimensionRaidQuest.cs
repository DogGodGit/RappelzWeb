namespace WebCommon;

public class WPDDimensionRaidQuest : WPDPacketData
{
	public string contentKey;

	public int requiredHeroLevel;

	public int questNpcId;

	public int limitCount;

	public int targetInteractionDuration;

	public string startDialogueKey;

	public string completionDialogueKey;

	public string completionTextKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(contentKey);
		writer.Write(requiredHeroLevel);
		writer.Write(questNpcId);
		writer.Write(limitCount);
		writer.Write(targetInteractionDuration);
		writer.Write(startDialogueKey);
		writer.Write(completionDialogueKey);
		writer.Write(completionTextKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		contentKey = reader.ReadString();
		requiredHeroLevel = reader.ReadInt32();
		questNpcId = reader.ReadInt32();
		limitCount = reader.ReadInt32();
		targetInteractionDuration = reader.ReadInt32();
		startDialogueKey = reader.ReadString();
		completionDialogueKey = reader.ReadString();
		completionTextKey = reader.ReadString();
	}
}
