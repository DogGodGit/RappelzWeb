namespace WebCommon;

public class WPDProofOfValor : WPDPacketData
{
	public string nameKey;

	public string descriptionKey;

	public int requiredConditionType;

	public int requiredHeroLevel;

	public int requiredMainQuestNo;

	public int requiredStamina;

	public int dailyFreeRefreshCount;

	public int dailyPaidRefreshCount;

	public string sceneName;

	public int startDelayTime;

	public int limitTime;

	public int exitDelayTime;

	public float startXPosition;

	public float startYPosition;

	public float startZPosition;

	public float startYRotation;

	public string targetTitleKey;

	public string targetContentKey;

	public string guideImageName;

	public string startGuideTitleKey;

	public string startGuideContentKey;

	public string buffBoxCreationGuideTitleKey;

	public string buffBoxCreationGuideContentKey;

	public int buffBoxCreationTime;

	public int buffBoxCreationInterval;

	public int buffBoxLifetime;

	public int buffDuration;

	public int failureRewardSoulPowder;

	public int locationId;

	public float x;

	public float z;

	public float xSize;

	public float zSize;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(requiredConditionType);
		writer.Write(requiredHeroLevel);
		writer.Write(requiredMainQuestNo);
		writer.Write(requiredStamina);
		writer.Write(dailyFreeRefreshCount);
		writer.Write(dailyPaidRefreshCount);
		writer.Write(sceneName);
		writer.Write(startDelayTime);
		writer.Write(limitTime);
		writer.Write(exitDelayTime);
		writer.Write(startXPosition);
		writer.Write(startYPosition);
		writer.Write(startZPosition);
		writer.Write(startYRotation);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(guideImageName);
		writer.Write(startGuideTitleKey);
		writer.Write(startGuideContentKey);
		writer.Write(buffBoxCreationGuideTitleKey);
		writer.Write(buffBoxCreationGuideContentKey);
		writer.Write(buffBoxCreationTime);
		writer.Write(buffBoxCreationInterval);
		writer.Write(buffBoxLifetime);
		writer.Write(buffDuration);
		writer.Write(failureRewardSoulPowder);
		writer.Write(locationId);
		writer.Write(x);
		writer.Write(z);
		writer.Write(xSize);
		writer.Write(zSize);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		requiredConditionType = reader.ReadInt32();
		requiredHeroLevel = reader.ReadInt32();
		requiredMainQuestNo = reader.ReadInt32();
		requiredStamina = reader.ReadInt32();
		dailyFreeRefreshCount = reader.ReadInt32();
		dailyPaidRefreshCount = reader.ReadInt32();
		sceneName = reader.ReadString();
		startDelayTime = reader.ReadInt32();
		limitTime = reader.ReadInt32();
		exitDelayTime = reader.ReadInt32();
		startXPosition = reader.ReadSingle();
		startYPosition = reader.ReadSingle();
		startZPosition = reader.ReadSingle();
		startYRotation = reader.ReadSingle();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		guideImageName = reader.ReadString();
		startGuideTitleKey = reader.ReadString();
		startGuideContentKey = reader.ReadString();
		buffBoxCreationGuideTitleKey = reader.ReadString();
		buffBoxCreationGuideContentKey = reader.ReadString();
		buffBoxCreationTime = reader.ReadInt32();
		buffBoxCreationInterval = reader.ReadInt32();
		buffBoxLifetime = reader.ReadInt32();
		buffDuration = reader.ReadInt32();
		failureRewardSoulPowder = reader.ReadInt32();
		locationId = reader.ReadInt32();
		x = reader.ReadSingle();
		z = reader.ReadSingle();
		xSize = reader.ReadSingle();
		zSize = reader.ReadSingle();
	}
}
