namespace WebCommon;

public class WPDStoryDungeon : WPDPacketData
{
	public int dungeonNo;

	public string nameKey;

	public string subNameKey;

	public int enterCount;

	public int requiredConditionType;

	public int requiredHeroMinLevel;

	public int requiredHeroMaxLevel;

	public int requiredMainQuestNo;

	public int requiredStamina;

	public int limitTime;

	public string sceneName;

	public float startXPosition;

	public float startYPosition;

	public float startZPosition;

	public float startRadius;

	public float startYRotation;

	public int startDelayTime;

	public int exitDelayTime;

	public float tamingXPosition;

	public float tamingYPosition;

	public float tamingZPosition;

	public float tamingYRotation;

	public float clearXPosition;

	public float clearYPosition;

	public float clearZPosition;

	public float clearYRotation;

	public int safeRevivalWaitingTime;

	public int guideDisplayInterval;

	public int comboDuration;

	public int locationId;

	public float x;

	public float z;

	public float xSize;

	public float zSize;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(dungeonNo);
		writer.Write(nameKey);
		writer.Write(subNameKey);
		writer.Write(enterCount);
		writer.Write(requiredConditionType);
		writer.Write(requiredHeroMinLevel);
		writer.Write(requiredHeroMaxLevel);
		writer.Write(requiredMainQuestNo);
		writer.Write(requiredStamina);
		writer.Write(limitTime);
		writer.Write(sceneName);
		writer.Write(startXPosition);
		writer.Write(startYPosition);
		writer.Write(startZPosition);
		writer.Write(startRadius);
		writer.Write(startYRotation);
		writer.Write(startDelayTime);
		writer.Write(exitDelayTime);
		writer.Write(tamingXPosition);
		writer.Write(tamingYPosition);
		writer.Write(tamingZPosition);
		writer.Write(tamingYRotation);
		writer.Write(clearXPosition);
		writer.Write(clearYPosition);
		writer.Write(clearZPosition);
		writer.Write(clearYRotation);
		writer.Write(safeRevivalWaitingTime);
		writer.Write(guideDisplayInterval);
		writer.Write(comboDuration);
		writer.Write(locationId);
		writer.Write(x);
		writer.Write(z);
		writer.Write(xSize);
		writer.Write(zSize);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		dungeonNo = reader.ReadInt32();
		nameKey = reader.ReadString();
		subNameKey = reader.ReadString();
		enterCount = reader.ReadInt32();
		requiredConditionType = reader.ReadInt32();
		requiredHeroMinLevel = reader.ReadInt32();
		requiredHeroMaxLevel = reader.ReadInt32();
		requiredMainQuestNo = reader.ReadInt32();
		requiredStamina = reader.ReadInt32();
		limitTime = reader.ReadInt32();
		sceneName = reader.ReadString();
		startXPosition = reader.ReadSingle();
		startYPosition = reader.ReadSingle();
		startZPosition = reader.ReadSingle();
		startRadius = reader.ReadSingle();
		startYRotation = reader.ReadSingle();
		startDelayTime = reader.ReadInt32();
		exitDelayTime = reader.ReadInt32();
		tamingXPosition = reader.ReadSingle();
		tamingYPosition = reader.ReadSingle();
		tamingZPosition = reader.ReadSingle();
		tamingYRotation = reader.ReadSingle();
		clearXPosition = reader.ReadSingle();
		clearYPosition = reader.ReadSingle();
		clearZPosition = reader.ReadSingle();
		clearYRotation = reader.ReadSingle();
		safeRevivalWaitingTime = reader.ReadInt32();
		guideDisplayInterval = reader.ReadInt32();
		comboDuration = reader.ReadInt32();
		locationId = reader.ReadInt32();
		x = reader.ReadSingle();
		z = reader.ReadSingle();
		xSize = reader.ReadSingle();
		zSize = reader.ReadSingle();
	}
}
