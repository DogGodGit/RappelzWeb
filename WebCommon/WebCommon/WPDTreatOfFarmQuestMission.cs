namespace WebCommon;

public class WPDTreatOfFarmQuestMission : WPDPacketData
{
	public int missionId;

	public string targetPositionNameKey;

	public int targetContinentId;

	public float targetXPosition;

	public float targetYPosition;

	public float targetZPosition;

	public float targetRadius;

	public float monsterSpawnXPosition;

	public float monsterSpawnYPosition;

	public float monsterSpawnZPosition;

	public int monsterYRotationType;

	public float monsterYRotation;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(missionId);
		writer.Write(targetPositionNameKey);
		writer.Write(targetContinentId);
		writer.Write(targetXPosition);
		writer.Write(targetYPosition);
		writer.Write(targetZPosition);
		writer.Write(targetRadius);
		writer.Write(monsterSpawnXPosition);
		writer.Write(monsterSpawnYPosition);
		writer.Write(monsterSpawnZPosition);
		writer.Write(monsterYRotationType);
		writer.Write(monsterYRotation);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		missionId = reader.ReadInt32();
		targetPositionNameKey = reader.ReadString();
		targetContinentId = reader.ReadInt32();
		targetXPosition = reader.ReadSingle();
		targetYPosition = reader.ReadSingle();
		targetZPosition = reader.ReadSingle();
		targetRadius = reader.ReadSingle();
		monsterSpawnXPosition = reader.ReadSingle();
		monsterSpawnYPosition = reader.ReadSingle();
		monsterSpawnZPosition = reader.ReadSingle();
		monsterYRotationType = reader.ReadInt32();
		monsterYRotation = reader.ReadSingle();
	}
}
