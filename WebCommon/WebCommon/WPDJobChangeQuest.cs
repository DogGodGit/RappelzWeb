namespace WebCommon;

public class WPDJobChangeQuest : WPDPacketData
{
	public int questNo;

	public string titleKey;

	public string targetTitleKey;

	public string targetContentKey;

	public int questNpcId;

	public string startDialogueKey;

	public string completionDialogueKey;

	public int type;

	public bool isTargetOwnNation;

	public int targetContinentId;

	public float targetXPosition;

	public float targetYPosition;

	public float targetZPosition;

	public float targetRadius;

	public int targetMonsterId;

	public int targetContinentObjectId;

	public int targetCount;

	public int limitTime;

	public long targetMonsterArrangeId;

	public float targetGuildTerritoryXPosition;

	public float targetGuildTerritoryYPosition;

	public float targetGuildTerritoryZPosition;

	public float targetGuildTerritoryRadius;

	public long targetGuildMonsterArrangeId;

	public long completionItemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(questNo);
		writer.Write(titleKey);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(questNpcId);
		writer.Write(startDialogueKey);
		writer.Write(completionDialogueKey);
		writer.Write(type);
		writer.Write(isTargetOwnNation);
		writer.Write(targetContinentId);
		writer.Write(targetXPosition);
		writer.Write(targetYPosition);
		writer.Write(targetZPosition);
		writer.Write(targetRadius);
		writer.Write(targetMonsterId);
		writer.Write(targetContinentObjectId);
		writer.Write(targetCount);
		writer.Write(limitTime);
		writer.Write(targetMonsterArrangeId);
		writer.Write(targetGuildTerritoryXPosition);
		writer.Write(targetGuildTerritoryYPosition);
		writer.Write(targetGuildTerritoryZPosition);
		writer.Write(targetGuildTerritoryRadius);
		writer.Write(targetGuildMonsterArrangeId);
		writer.Write(completionItemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		questNo = reader.ReadInt32();
		titleKey = reader.ReadString();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		questNpcId = reader.ReadInt32();
		startDialogueKey = reader.ReadString();
		completionDialogueKey = reader.ReadString();
		type = reader.ReadInt32();
		isTargetOwnNation = reader.ReadBoolean();
		targetContinentId = reader.ReadInt32();
		targetXPosition = reader.ReadSingle();
		targetYPosition = reader.ReadSingle();
		targetZPosition = reader.ReadSingle();
		targetRadius = reader.ReadSingle();
		targetMonsterId = reader.ReadInt32();
		targetContinentObjectId = reader.ReadInt32();
		targetCount = reader.ReadInt32();
		limitTime = reader.ReadInt32();
		targetMonsterArrangeId = reader.ReadInt64();
		targetGuildTerritoryXPosition = reader.ReadSingle();
		targetGuildTerritoryYPosition = reader.ReadSingle();
		targetGuildTerritoryZPosition = reader.ReadSingle();
		targetGuildTerritoryRadius = reader.ReadSingle();
		targetGuildMonsterArrangeId = reader.ReadInt64();
		completionItemRewardId = reader.ReadInt64();
	}
}
