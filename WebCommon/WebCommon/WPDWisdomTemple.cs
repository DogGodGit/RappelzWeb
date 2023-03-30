namespace WebCommon;

public class WPDWisdomTemple : WPDPacketData
{
	public string nameKey;

	public string descriptionKey;

	public string sceneName;

	public int requiredConditionType;

	public int requiredHeroLevel;

	public int requiredMainQuestNo;

	public int requiredStamina;

	public int startDelayTime;

	public int limitTime;

	public int exitDelayTime;

	public float startXPosition;

	public float startYPosition;

	public float startZPosition;

	public float startYRotation;

	public int availableRewardItemId;

	public string guideImageName;

	public int colorMatchingPoint;

	public int colorMatchingObjectivePoint;

	public int colorMatchingMonsterSpawnInterval;

	public long colorMatchingMonsterArrangeId;

	public float colorMatchingMonsterXPosition;

	public float colorMatchingMonsterYPosition;

	public float colorMatchingMonsterZPosition;

	public int colorMatchingMonsterYRotationType;

	public float colorMatchingMonsterYRotation;

	public int colorMatchingMonsterKillPoint;

	public int colorMatchingMonsterKillObjectId;

	public string colorMatchingMonsterSpawnGuideTitleKey;

	public string colorMatchingMonsterSpawnGuideContentKey;

	public long findTreasureBoxMonsterArrangeId;

	public string findTreasureBoxSuccessGuideTitleKey;

	public string findTreasureBoxSuccessGuideContentKey;

	public string puzzleRewardTargetTitleKey;

	public string puzzleRewardTargetContentKey;

	public string puzzleRewardGuideTitleKey;

	public string puzzleRewardGuideContentKey;

	public string puzzleRewardObjectPrefabName;

	public float puzzleRewardObjectInteractionDuration;

	public float puzzleRewardObjectInteractionMaxRange;

	public float puzzleRewardObjectScale;

	public int puzzleRewardObjectHeight;

	public float puzzleRewardObjectRadius;

	public string quizRightAnswerGuideTitleKey;

	public string quizRightAnswerGuideContentKey;

	public string quizWrongAnswerGuideTitleKey;

	public string quizWrongAnswerGuideContentKey;

	public int bossMonsterSpawnDelayTime;

	public long bossMonsterArrangeId;

	public float bossMonsterXPosition;

	public float bossMonsterYPosition;

	public float bossMonsterZPosition;

	public float bossMonsterYRotation;

	public string bossMonsterTargetTitleKey;

	public string bossMonsterTargetContentKey;

	public string bossMonsterSpawnGuideTitleKey;

	public string bossMonsterSpawnGuideContentKey;

	public long bossMonsterKillItemRewardId;

	public long sweepItemRewardId;

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
		writer.Write(requiredStamina);
		writer.Write(startDelayTime);
		writer.Write(limitTime);
		writer.Write(exitDelayTime);
		writer.Write(startXPosition);
		writer.Write(startYPosition);
		writer.Write(startZPosition);
		writer.Write(startYRotation);
		writer.Write(availableRewardItemId);
		writer.Write(guideImageName);
		writer.Write(colorMatchingPoint);
		writer.Write(colorMatchingObjectivePoint);
		writer.Write(colorMatchingMonsterSpawnInterval);
		writer.Write(colorMatchingMonsterArrangeId);
		writer.Write(colorMatchingMonsterXPosition);
		writer.Write(colorMatchingMonsterYPosition);
		writer.Write(colorMatchingMonsterZPosition);
		writer.Write(colorMatchingMonsterYRotationType);
		writer.Write(colorMatchingMonsterYRotation);
		writer.Write(colorMatchingMonsterKillPoint);
		writer.Write(colorMatchingMonsterKillObjectId);
		writer.Write(colorMatchingMonsterSpawnGuideTitleKey);
		writer.Write(colorMatchingMonsterSpawnGuideContentKey);
		writer.Write(findTreasureBoxMonsterArrangeId);
		writer.Write(findTreasureBoxSuccessGuideTitleKey);
		writer.Write(findTreasureBoxSuccessGuideContentKey);
		writer.Write(puzzleRewardTargetTitleKey);
		writer.Write(puzzleRewardTargetContentKey);
		writer.Write(puzzleRewardGuideTitleKey);
		writer.Write(puzzleRewardGuideContentKey);
		writer.Write(puzzleRewardObjectPrefabName);
		writer.Write(puzzleRewardObjectInteractionDuration);
		writer.Write(puzzleRewardObjectInteractionMaxRange);
		writer.Write(puzzleRewardObjectScale);
		writer.Write(puzzleRewardObjectHeight);
		writer.Write(puzzleRewardObjectRadius);
		writer.Write(quizRightAnswerGuideTitleKey);
		writer.Write(quizRightAnswerGuideContentKey);
		writer.Write(quizWrongAnswerGuideTitleKey);
		writer.Write(quizWrongAnswerGuideContentKey);
		writer.Write(bossMonsterSpawnDelayTime);
		writer.Write(bossMonsterArrangeId);
		writer.Write(bossMonsterXPosition);
		writer.Write(bossMonsterYPosition);
		writer.Write(bossMonsterZPosition);
		writer.Write(bossMonsterYRotation);
		writer.Write(bossMonsterTargetTitleKey);
		writer.Write(bossMonsterTargetContentKey);
		writer.Write(bossMonsterSpawnGuideTitleKey);
		writer.Write(bossMonsterSpawnGuideContentKey);
		writer.Write(bossMonsterKillItemRewardId);
		writer.Write(sweepItemRewardId);
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
		requiredStamina = reader.ReadInt32();
		startDelayTime = reader.ReadInt32();
		limitTime = reader.ReadInt32();
		exitDelayTime = reader.ReadInt32();
		startXPosition = reader.ReadSingle();
		startYPosition = reader.ReadSingle();
		startZPosition = reader.ReadSingle();
		startYRotation = reader.ReadSingle();
		availableRewardItemId = reader.ReadInt32();
		guideImageName = reader.ReadString();
		colorMatchingPoint = reader.ReadInt32();
		colorMatchingObjectivePoint = reader.ReadInt32();
		colorMatchingMonsterSpawnInterval = reader.ReadInt32();
		colorMatchingMonsterArrangeId = reader.ReadInt64();
		colorMatchingMonsterXPosition = reader.ReadSingle();
		colorMatchingMonsterYPosition = reader.ReadSingle();
		colorMatchingMonsterZPosition = reader.ReadSingle();
		colorMatchingMonsterYRotationType = reader.ReadInt32();
		colorMatchingMonsterYRotation = reader.ReadSingle();
		colorMatchingMonsterKillPoint = reader.ReadInt32();
		colorMatchingMonsterKillObjectId = reader.ReadInt32();
		colorMatchingMonsterSpawnGuideTitleKey = reader.ReadString();
		colorMatchingMonsterSpawnGuideContentKey = reader.ReadString();
		findTreasureBoxMonsterArrangeId = reader.ReadInt64();
		findTreasureBoxSuccessGuideTitleKey = reader.ReadString();
		findTreasureBoxSuccessGuideContentKey = reader.ReadString();
		puzzleRewardTargetTitleKey = reader.ReadString();
		puzzleRewardTargetContentKey = reader.ReadString();
		puzzleRewardGuideTitleKey = reader.ReadString();
		puzzleRewardGuideContentKey = reader.ReadString();
		puzzleRewardObjectPrefabName = reader.ReadString();
		puzzleRewardObjectInteractionDuration = reader.ReadSingle();
		puzzleRewardObjectInteractionMaxRange = reader.ReadSingle();
		puzzleRewardObjectScale = reader.ReadSingle();
		puzzleRewardObjectHeight = reader.ReadInt32();
		puzzleRewardObjectRadius = reader.ReadSingle();
		quizRightAnswerGuideTitleKey = reader.ReadString();
		quizRightAnswerGuideContentKey = reader.ReadString();
		quizWrongAnswerGuideTitleKey = reader.ReadString();
		quizWrongAnswerGuideContentKey = reader.ReadString();
		bossMonsterSpawnDelayTime = reader.ReadInt32();
		bossMonsterArrangeId = reader.ReadInt64();
		bossMonsterXPosition = reader.ReadSingle();
		bossMonsterYPosition = reader.ReadSingle();
		bossMonsterZPosition = reader.ReadSingle();
		bossMonsterYRotation = reader.ReadSingle();
		bossMonsterTargetTitleKey = reader.ReadString();
		bossMonsterTargetContentKey = reader.ReadString();
		bossMonsterSpawnGuideTitleKey = reader.ReadString();
		bossMonsterSpawnGuideContentKey = reader.ReadString();
		bossMonsterKillItemRewardId = reader.ReadInt64();
		sweepItemRewardId = reader.ReadInt64();
		locationId = reader.ReadInt32();
		x = reader.ReadSingle();
		z = reader.ReadSingle();
		xSize = reader.ReadSingle();
		zSize = reader.ReadSingle();
	}
}
