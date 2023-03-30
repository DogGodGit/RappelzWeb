namespace WebCommon;

public class WPDWarMemory : WPDPacketData
{
	public string nameKey;

	public string descriptionKey;

	public string sceneName;

	public int requiredConditionType;

	public int requiredHeroLevel;

	public int requiredMainQuestNo;

	public int freeEnterCount;

	public int enterRequiredItemId;

	public int enterMinMemberCount;

	public int enterMaxMemberCount;

	public int matchingWaitingTime;

	public int enterWaitingTime;

	public int startDelayTime;

	public int limitTime;

	public int exitDelayTime;

	public string transformationGuideImageName;

	public string transformationGuideTitleKey;

	public string transformationGuideContentKey;

	public string monsterSummonGuideTitleKey;

	public string monsterSummonGuideContentKey;

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
		writer.Write(sceneName);
		writer.Write(requiredConditionType);
		writer.Write(requiredHeroLevel);
		writer.Write(requiredMainQuestNo);
		writer.Write(freeEnterCount);
		writer.Write(enterRequiredItemId);
		writer.Write(enterMinMemberCount);
		writer.Write(enterMaxMemberCount);
		writer.Write(matchingWaitingTime);
		writer.Write(enterWaitingTime);
		writer.Write(startDelayTime);
		writer.Write(limitTime);
		writer.Write(exitDelayTime);
		writer.Write(transformationGuideImageName);
		writer.Write(transformationGuideTitleKey);
		writer.Write(transformationGuideContentKey);
		writer.Write(monsterSummonGuideTitleKey);
		writer.Write(monsterSummonGuideContentKey);
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
		sceneName = reader.ReadString();
		requiredConditionType = reader.ReadInt32();
		requiredHeroLevel = reader.ReadInt32();
		requiredMainQuestNo = reader.ReadInt32();
		freeEnterCount = reader.ReadInt32();
		enterRequiredItemId = reader.ReadInt32();
		enterMinMemberCount = reader.ReadInt32();
		enterMaxMemberCount = reader.ReadInt32();
		matchingWaitingTime = reader.ReadInt32();
		enterWaitingTime = reader.ReadInt32();
		startDelayTime = reader.ReadInt32();
		limitTime = reader.ReadInt32();
		exitDelayTime = reader.ReadInt32();
		transformationGuideImageName = reader.ReadString();
		transformationGuideTitleKey = reader.ReadString();
		transformationGuideContentKey = reader.ReadString();
		monsterSummonGuideTitleKey = reader.ReadString();
		monsterSummonGuideContentKey = reader.ReadString();
		safeRevivalWaitingTime = reader.ReadInt32();
		locationId = reader.ReadInt32();
		x = reader.ReadSingle();
		z = reader.ReadSingle();
		xSize = reader.ReadSingle();
		zSize = reader.ReadSingle();
	}
}
