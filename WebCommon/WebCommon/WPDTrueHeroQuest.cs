namespace WebCommon;

public class WPDTrueHeroQuest : WPDPacketData
{
	public string nameKey;

	public string descriptionKey;

	public string targetTitleKey;

	public string targetContentKey;

	public int requiredVipLevel;

	public int requiredHeroLevel;

	public int questNpcId;

	public string startDialogueKey;

	public string completionDialogueKey;

	public string completionTextKey;

	public string targetObjectPrefabName;

	public float targetObjectInteractionDuration;

	public float targetObjectInteractionMaxRange;

	public float targetObjectScale;

	public int targetObjectHeight;

	public float targetObjectRadius;

	public string targetObjectInteractionTextKey;

	public string chattingMessageKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(requiredVipLevel);
		writer.Write(requiredHeroLevel);
		writer.Write(questNpcId);
		writer.Write(startDialogueKey);
		writer.Write(completionDialogueKey);
		writer.Write(completionTextKey);
		writer.Write(targetObjectPrefabName);
		writer.Write(targetObjectInteractionDuration);
		writer.Write(targetObjectInteractionMaxRange);
		writer.Write(targetObjectScale);
		writer.Write(targetObjectHeight);
		writer.Write(targetObjectRadius);
		writer.Write(targetObjectInteractionTextKey);
		writer.Write(chattingMessageKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		requiredVipLevel = reader.ReadInt32();
		requiredHeroLevel = reader.ReadInt32();
		questNpcId = reader.ReadInt32();
		startDialogueKey = reader.ReadString();
		completionDialogueKey = reader.ReadString();
		completionTextKey = reader.ReadString();
		targetObjectPrefabName = reader.ReadString();
		targetObjectInteractionDuration = reader.ReadSingle();
		targetObjectInteractionMaxRange = reader.ReadSingle();
		targetObjectScale = reader.ReadSingle();
		targetObjectHeight = reader.ReadInt32();
		targetObjectRadius = reader.ReadSingle();
		targetObjectInteractionTextKey = reader.ReadString();
		chattingMessageKey = reader.ReadString();
	}
}
