namespace WebCommon;

public class WPDBountyHunterQuest : WPDPacketData
{
	public int questId;

	public string titleKey;

	public string contentKey;

	public string targetTitleKey;

	public string targetContentKey;

	public string descriptionKey;

	public int targetMonsterMinLevel;

	public int targetCount;

	public int targetContinentId;

	public float targetXPosition;

	public float targetYPosition;

	public float targetZPosition;

	public float targetRadius;

	public string guideImageName;

	public string guideTitleKey;

	public string startGuideContentKey;

	public string completionGuideContentKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(questId);
		writer.Write(titleKey);
		writer.Write(contentKey);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(descriptionKey);
		writer.Write(targetMonsterMinLevel);
		writer.Write(targetCount);
		writer.Write(targetContinentId);
		writer.Write(targetXPosition);
		writer.Write(targetYPosition);
		writer.Write(targetZPosition);
		writer.Write(targetRadius);
		writer.Write(guideImageName);
		writer.Write(guideTitleKey);
		writer.Write(startGuideContentKey);
		writer.Write(completionGuideContentKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		questId = reader.ReadInt32();
		titleKey = reader.ReadString();
		contentKey = reader.ReadString();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		targetMonsterMinLevel = reader.ReadInt32();
		targetCount = reader.ReadInt32();
		targetContinentId = reader.ReadInt32();
		targetXPosition = reader.ReadSingle();
		targetYPosition = reader.ReadSingle();
		targetZPosition = reader.ReadSingle();
		targetRadius = reader.ReadSingle();
		guideImageName = reader.ReadString();
		guideTitleKey = reader.ReadString();
		startGuideContentKey = reader.ReadString();
		completionGuideContentKey = reader.ReadString();
	}
}
