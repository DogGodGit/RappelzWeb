namespace WebCommon;

public class WPDAnkouTomb : WPDPacketData
{
	public string nameKey;

	public string descriptionKey;

	public string targetTitleKey;

	public string targetContentKey;

	public string sceneName;

	public int requiredConditionType;

	public int requiredHeroLevel;

	public int requiredMainQuestNo;

	public int requiredStamina;

	public int enterCount;

	public int enterMinMemberCount;

	public int enterMaxMemberCount;

	public int waveCount;

	public int matchingWaitingTime;

	public int enterWaitingTime;

	public int startDelayTime;

	public int limitTime;

	public int exitDelayTime;

	public float startXPosition;

	public float startYPosition;

	public float startZPosition;

	public float startRadius;

	public int startYRotationType;

	public float startYRotation;

	public float monsterSpawnXPosition;

	public float monsterSpawnYPosition;

	public float monsterSpawnZPosition;

	public float monsterSpawnRadius;

	public int monsterPoint;

	public int bossMonsterPoint;

	public int clearPoint;

	public int exp2xRewardRequiredUnOwnDia;

	public int exp3xRewardRequiredUnOwnDia;

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
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(sceneName);
		writer.Write(requiredConditionType);
		writer.Write(requiredHeroLevel);
		writer.Write(requiredMainQuestNo);
		writer.Write(requiredStamina);
		writer.Write(enterCount);
		writer.Write(enterMinMemberCount);
		writer.Write(enterMaxMemberCount);
		writer.Write(waveCount);
		writer.Write(matchingWaitingTime);
		writer.Write(enterWaitingTime);
		writer.Write(startDelayTime);
		writer.Write(limitTime);
		writer.Write(exitDelayTime);
		writer.Write(startXPosition);
		writer.Write(startYPosition);
		writer.Write(startZPosition);
		writer.Write(startRadius);
		writer.Write(startYRotationType);
		writer.Write(startYRotation);
		writer.Write(monsterSpawnXPosition);
		writer.Write(monsterSpawnYPosition);
		writer.Write(monsterSpawnZPosition);
		writer.Write(monsterSpawnRadius);
		writer.Write(monsterPoint);
		writer.Write(bossMonsterPoint);
		writer.Write(clearPoint);
		writer.Write(exp2xRewardRequiredUnOwnDia);
		writer.Write(exp3xRewardRequiredUnOwnDia);
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
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		sceneName = reader.ReadString();
		requiredConditionType = reader.ReadInt32();
		requiredHeroLevel = reader.ReadInt32();
		requiredMainQuestNo = reader.ReadInt32();
		requiredStamina = reader.ReadInt32();
		enterCount = reader.ReadInt32();
		enterMinMemberCount = reader.ReadInt32();
		enterMaxMemberCount = reader.ReadInt32();
		waveCount = reader.ReadInt32();
		matchingWaitingTime = reader.ReadInt32();
		enterWaitingTime = reader.ReadInt32();
		startDelayTime = reader.ReadInt32();
		limitTime = reader.ReadInt32();
		exitDelayTime = reader.ReadInt32();
		startXPosition = reader.ReadSingle();
		startYPosition = reader.ReadSingle();
		startZPosition = reader.ReadSingle();
		startRadius = reader.ReadSingle();
		startYRotationType = reader.ReadInt32();
		startYRotation = reader.ReadSingle();
		monsterSpawnXPosition = reader.ReadSingle();
		monsterSpawnYPosition = reader.ReadSingle();
		monsterSpawnZPosition = reader.ReadSingle();
		monsterSpawnRadius = reader.ReadSingle();
		monsterPoint = reader.ReadInt32();
		bossMonsterPoint = reader.ReadInt32();
		clearPoint = reader.ReadInt32();
		exp2xRewardRequiredUnOwnDia = reader.ReadInt32();
		exp3xRewardRequiredUnOwnDia = reader.ReadInt32();
		safeRevivalWaitingTime = reader.ReadInt32();
		locationId = reader.ReadInt32();
		x = reader.ReadSingle();
		z = reader.ReadSingle();
		xSize = reader.ReadSingle();
		zSize = reader.ReadSingle();
	}
}
