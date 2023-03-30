namespace WebCommon;

public class WPDInfiniteWar : WPDPacketData
{
	public string nameKey;

	public string descriptionKey;

	public int enterCount;

	public string sceneName;

	public int requiredConditionType;

	public int requiredHeroLevel;

	public int requiredMainQuestNo;

	public int requiredStamina;

	public int enterMinMemberCount;

	public int enterMaxMemberCount;

	public int matchingWaitingTime;

	public int enterWaitingTime;

	public int startDelayTime;

	public int limitTime;

	public int exitDelayTime;

	public string guideImageName;

	public string startGuideTitleKey;

	public string startGuideContentKey;

	public int monsterSpawnDelayTime;

	public string monsterSpawnGuideTitleKey;

	public string monsterSpawnGuideContentKey;

	public int heroKillPoint;

	public int buffBoxCreationInterval;

	public int buffBoxCreationCount;

	public float buffBoxXPosition;

	public float buffBoxYPosition;

	public float buffBoxZPosition;

	public float buffBoxRadius;

	public int buffBoxLifetime;

	public float buffBoxAcquisitionRange;

	public int buffDuration;

	public string buffCreationGuideTitleKey;

	public string buffCreationGuideContentKey;

	public int safeRevivalWaitingTime;

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
		writer.Write(enterCount);
		writer.Write(sceneName);
		writer.Write(requiredConditionType);
		writer.Write(requiredHeroLevel);
		writer.Write(requiredMainQuestNo);
		writer.Write(requiredStamina);
		writer.Write(enterMinMemberCount);
		writer.Write(enterMaxMemberCount);
		writer.Write(matchingWaitingTime);
		writer.Write(enterWaitingTime);
		writer.Write(startDelayTime);
		writer.Write(limitTime);
		writer.Write(exitDelayTime);
		writer.Write(guideImageName);
		writer.Write(startGuideTitleKey);
		writer.Write(startGuideContentKey);
		writer.Write(monsterSpawnDelayTime);
		writer.Write(monsterSpawnGuideTitleKey);
		writer.Write(monsterSpawnGuideContentKey);
		writer.Write(heroKillPoint);
		writer.Write(buffBoxCreationInterval);
		writer.Write(buffBoxCreationCount);
		writer.Write(buffBoxXPosition);
		writer.Write(buffBoxYPosition);
		writer.Write(buffBoxZPosition);
		writer.Write(buffBoxRadius);
		writer.Write(buffBoxLifetime);
		writer.Write(buffBoxAcquisitionRange);
		writer.Write(buffDuration);
		writer.Write(buffCreationGuideTitleKey);
		writer.Write(buffCreationGuideContentKey);
		writer.Write(safeRevivalWaitingTime);
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
		enterCount = reader.ReadInt32();
		sceneName = reader.ReadString();
		requiredConditionType = reader.ReadInt32();
		requiredHeroLevel = reader.ReadInt32();
		requiredMainQuestNo = reader.ReadInt32();
		requiredStamina = reader.ReadInt32();
		enterMinMemberCount = reader.ReadInt32();
		enterMaxMemberCount = reader.ReadInt32();
		matchingWaitingTime = reader.ReadInt32();
		enterWaitingTime = reader.ReadInt32();
		startDelayTime = reader.ReadInt32();
		limitTime = reader.ReadInt32();
		exitDelayTime = reader.ReadInt32();
		guideImageName = reader.ReadString();
		startGuideTitleKey = reader.ReadString();
		startGuideContentKey = reader.ReadString();
		monsterSpawnDelayTime = reader.ReadInt32();
		monsterSpawnGuideTitleKey = reader.ReadString();
		monsterSpawnGuideContentKey = reader.ReadString();
		heroKillPoint = reader.ReadInt32();
		buffBoxCreationInterval = reader.ReadInt32();
		buffBoxCreationCount = reader.ReadInt32();
		buffBoxXPosition = reader.ReadSingle();
		buffBoxYPosition = reader.ReadSingle();
		buffBoxZPosition = reader.ReadSingle();
		buffBoxRadius = reader.ReadSingle();
		buffBoxLifetime = reader.ReadInt32();
		buffBoxAcquisitionRange = reader.ReadSingle();
		buffDuration = reader.ReadInt32();
		buffCreationGuideTitleKey = reader.ReadString();
		buffCreationGuideContentKey = reader.ReadString();
		safeRevivalWaitingTime = reader.ReadInt32();
		locationId = reader.ReadInt32();
		x = reader.ReadSingle();
		z = reader.ReadSingle();
		xSize = reader.ReadSingle();
		zSize = reader.ReadSingle();
	}
}
