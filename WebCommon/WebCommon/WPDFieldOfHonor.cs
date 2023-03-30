namespace WebCommon;

public class WPDFieldOfHonor : WPDPacketData
{
	public string nameKey;

	public string descriptionKey;

	public string targetTitleKey;

	public string targetContentKey;

	public string sceneName;

	public int requiredConditionType;

	public int requiredHeroLevel;

	public int requiredMainQuestNo;

	public int startDelayTime;

	public int limitTime;

	public int exitDelayTime;

	public float startXPosition;

	public float startYPosition;

	public float startZPosition;

	public float startYRotation;

	public float targetXPosition;

	public float targetYPosition;

	public float targetZPosition;

	public float targetYRotation;

	public long winnerHonorPointRewardId;

	public long loserHonorPointRewardId;

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
		writer.Write(startDelayTime);
		writer.Write(limitTime);
		writer.Write(exitDelayTime);
		writer.Write(startXPosition);
		writer.Write(startYPosition);
		writer.Write(startZPosition);
		writer.Write(startYRotation);
		writer.Write(targetXPosition);
		writer.Write(targetYPosition);
		writer.Write(targetZPosition);
		writer.Write(targetYRotation);
		writer.Write(winnerHonorPointRewardId);
		writer.Write(loserHonorPointRewardId);
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
		startDelayTime = reader.ReadInt32();
		limitTime = reader.ReadInt32();
		exitDelayTime = reader.ReadInt32();
		startXPosition = reader.ReadSingle();
		startYPosition = reader.ReadSingle();
		startZPosition = reader.ReadSingle();
		startYRotation = reader.ReadSingle();
		targetXPosition = reader.ReadSingle();
		targetYPosition = reader.ReadSingle();
		targetZPosition = reader.ReadSingle();
		targetYRotation = reader.ReadSingle();
		winnerHonorPointRewardId = reader.ReadInt64();
		loserHonorPointRewardId = reader.ReadInt64();
		locationId = reader.ReadInt32();
		x = reader.ReadSingle();
		z = reader.ReadSingle();
		xSize = reader.ReadSingle();
		zSize = reader.ReadSingle();
	}
}
