namespace WebCommon;

public class WPDOsirisRoom : WPDPacketData
{
	public string nameKey;

	public string descriptionKey;

	public int requiredStamina;

	public string sceneName;

	public int startDelayTime;

	public int limitTime;

	public int exitDelayTime;

	public float startXPosition;

	public float startYPosition;

	public float startZPosition;

	public float startYRotation;

	public int waveInterval;

	public int monsterSpawnInterval;

	public float monsterSpawnXPosition;

	public float monsterSpawnYPosition;

	public float monsterSpawnZPosition;

	public float monsterSpawnYRotation;

	public float targetXPosition;

	public float targetYPosition;

	public float targetZPosition;

	public float targetRadius;

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
		writer.Write(requiredStamina);
		writer.Write(sceneName);
		writer.Write(startDelayTime);
		writer.Write(limitTime);
		writer.Write(exitDelayTime);
		writer.Write(startXPosition);
		writer.Write(startYPosition);
		writer.Write(startZPosition);
		writer.Write(startYRotation);
		writer.Write(waveInterval);
		writer.Write(monsterSpawnInterval);
		writer.Write(monsterSpawnXPosition);
		writer.Write(monsterSpawnYPosition);
		writer.Write(monsterSpawnZPosition);
		writer.Write(monsterSpawnYRotation);
		writer.Write(targetXPosition);
		writer.Write(targetYPosition);
		writer.Write(targetZPosition);
		writer.Write(targetRadius);
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
		requiredStamina = reader.ReadInt32();
		sceneName = reader.ReadString();
		startDelayTime = reader.ReadInt32();
		limitTime = reader.ReadInt32();
		exitDelayTime = reader.ReadInt32();
		startXPosition = reader.ReadSingle();
		startYPosition = reader.ReadSingle();
		startZPosition = reader.ReadSingle();
		startYRotation = reader.ReadSingle();
		waveInterval = reader.ReadInt32();
		monsterSpawnInterval = reader.ReadInt32();
		monsterSpawnXPosition = reader.ReadSingle();
		monsterSpawnYPosition = reader.ReadSingle();
		monsterSpawnZPosition = reader.ReadSingle();
		monsterSpawnYRotation = reader.ReadSingle();
		targetXPosition = reader.ReadSingle();
		targetYPosition = reader.ReadSingle();
		targetZPosition = reader.ReadSingle();
		targetRadius = reader.ReadSingle();
		locationId = reader.ReadInt32();
		x = reader.ReadSingle();
		z = reader.ReadSingle();
		xSize = reader.ReadSingle();
		zSize = reader.ReadSingle();
	}
}
