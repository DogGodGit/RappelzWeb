namespace WebCommon;

public class WPDEliteDungeon : WPDPacketData
{
	public string nameKey;

	public string descriptionKey;

	public string targetTitleKey;

	public string targetContentKey;

	public int baseEnterCount;

	public int enterCountAddInterval;

	public int requiredStamina;

	public string sceneName;

	public int startDelayTime;

	public int limitTime;

	public int exitDelayTime;

	public int safeRevivalWaitingTime;

	public float startXPosition;

	public float startYPosition;

	public float startZPosition;

	public float startYRotation;

	public float monsterXPosition;

	public float monsterYPosition;

	public float monsterZPosition;

	public float monsterYRotation;

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
		writer.Write(baseEnterCount);
		writer.Write(enterCountAddInterval);
		writer.Write(requiredStamina);
		writer.Write(sceneName);
		writer.Write(startDelayTime);
		writer.Write(limitTime);
		writer.Write(exitDelayTime);
		writer.Write(safeRevivalWaitingTime);
		writer.Write(startXPosition);
		writer.Write(startYPosition);
		writer.Write(startZPosition);
		writer.Write(startYRotation);
		writer.Write(monsterXPosition);
		writer.Write(monsterYPosition);
		writer.Write(monsterZPosition);
		writer.Write(monsterYRotation);
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
		baseEnterCount = reader.ReadInt32();
		enterCountAddInterval = reader.ReadInt32();
		requiredStamina = reader.ReadInt32();
		sceneName = reader.ReadString();
		startDelayTime = reader.ReadInt32();
		limitTime = reader.ReadInt32();
		exitDelayTime = reader.ReadInt32();
		safeRevivalWaitingTime = reader.ReadInt32();
		startXPosition = reader.ReadSingle();
		startYPosition = reader.ReadSingle();
		startZPosition = reader.ReadSingle();
		startYRotation = reader.ReadSingle();
		monsterXPosition = reader.ReadSingle();
		monsterYPosition = reader.ReadSingle();
		monsterZPosition = reader.ReadSingle();
		monsterYRotation = reader.ReadSingle();
		locationId = reader.ReadInt32();
		x = reader.ReadSingle();
		z = reader.ReadSingle();
		xSize = reader.ReadSingle();
		zSize = reader.ReadSingle();
	}
}
