namespace WebCommon;

public class WPDGuildFarmQuest : WPDPacketData
{
	public string nameKey;

	public string descriptionKey;

	public string targetTitleKey;

	public string targetContentKey;

	public string targetCompletionKey;

	public int startTime;

	public int endTime;

	public int limitCount;

	public int questGuildTerritoryNpcId;

	public int targetGuildTerritoryNpcId;

	public int interactionDuration;

	public string interactionTextKey;

	public long completionItemRewardId;

	public long completionGuildContributionPointRewardId;

	public long completionGuildBuildingPointRewardId;

	public string questStartDialogueKey;

	public string questCompletionDialogueKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(targetCompletionKey);
		writer.Write(startTime);
		writer.Write(endTime);
		writer.Write(limitCount);
		writer.Write(questGuildTerritoryNpcId);
		writer.Write(targetGuildTerritoryNpcId);
		writer.Write(interactionDuration);
		writer.Write(interactionTextKey);
		writer.Write(completionItemRewardId);
		writer.Write(completionGuildContributionPointRewardId);
		writer.Write(completionGuildBuildingPointRewardId);
		writer.Write(questStartDialogueKey);
		writer.Write(questCompletionDialogueKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		targetCompletionKey = reader.ReadString();
		startTime = reader.ReadInt32();
		endTime = reader.ReadInt32();
		limitCount = reader.ReadInt32();
		questGuildTerritoryNpcId = reader.ReadInt32();
		targetGuildTerritoryNpcId = reader.ReadInt32();
		interactionDuration = reader.ReadInt32();
		interactionTextKey = reader.ReadString();
		completionItemRewardId = reader.ReadInt64();
		completionGuildContributionPointRewardId = reader.ReadInt64();
		completionGuildBuildingPointRewardId = reader.ReadInt64();
		questStartDialogueKey = reader.ReadString();
		questCompletionDialogueKey = reader.ReadString();
	}
}
