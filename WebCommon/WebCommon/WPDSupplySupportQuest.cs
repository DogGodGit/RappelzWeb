namespace WebCommon;

public class WPDSupplySupportQuest : WPDPacketData
{
	public string targetTitleKey;

	public string targetContentKey;

	public int requiredHeroLevel;

	public int startNpcId;

	public int completionNpcId;

	public int limitCount;

	public int guaranteeGold;

	public int limitTime;

	public string startDialogueKey;

	public string completionDialogueKey;

	public string completionTextKey;

	public string failGuideImageName;

	public string failGuideTitleKey;

	public string failGuideContentKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(requiredHeroLevel);
		writer.Write(startNpcId);
		writer.Write(completionNpcId);
		writer.Write(limitCount);
		writer.Write(guaranteeGold);
		writer.Write(limitTime);
		writer.Write(startDialogueKey);
		writer.Write(completionDialogueKey);
		writer.Write(completionTextKey);
		writer.Write(failGuideImageName);
		writer.Write(failGuideTitleKey);
		writer.Write(failGuideContentKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		requiredHeroLevel = reader.ReadInt32();
		startNpcId = reader.ReadInt32();
		completionNpcId = reader.ReadInt32();
		limitCount = reader.ReadInt32();
		guaranteeGold = reader.ReadInt32();
		limitTime = reader.ReadInt32();
		startDialogueKey = reader.ReadString();
		completionDialogueKey = reader.ReadString();
		completionTextKey = reader.ReadString();
		failGuideImageName = reader.ReadString();
		failGuideTitleKey = reader.ReadString();
		failGuideContentKey = reader.ReadString();
	}
}
