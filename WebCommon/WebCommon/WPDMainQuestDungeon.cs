namespace WebCommon;

public class WPDMainQuestDungeon : WPDPacketData
{
	public int dungeonId;

	public string nameKey;

	public string descriptionKey;

	public string sceneName;

	public int startDelayTime;

	public int limitTime;

	public int exitDelayTime;

	public float startXPosition;

	public float startYPosition;

	public float startZPosition;

	public float startRadius;

	public float startYRotation;

	public int safeRevivalWaitingTime;

	public int guideDisplayInterval;

	public bool completionExitPositionEnabled;

	public float completionExitXPosition;

	public float completionExitYPosition;

	public float completionExitZPosition;

	public float completionExitYRotation;

	public int locationId;

	public float x;

	public float z;

	public float xSize;

	public float zSize;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(dungeonId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(sceneName);
		writer.Write(startDelayTime);
		writer.Write(limitTime);
		writer.Write(exitDelayTime);
		writer.Write(startXPosition);
		writer.Write(startYPosition);
		writer.Write(startZPosition);
		writer.Write(startRadius);
		writer.Write(startYRotation);
		writer.Write(safeRevivalWaitingTime);
		writer.Write(guideDisplayInterval);
		writer.Write(completionExitPositionEnabled);
		writer.Write(completionExitXPosition);
		writer.Write(completionExitYPosition);
		writer.Write(completionExitZPosition);
		writer.Write(completionExitYRotation);
		writer.Write(locationId);
		writer.Write(x);
		writer.Write(z);
		writer.Write(xSize);
		writer.Write(zSize);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		dungeonId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		sceneName = reader.ReadString();
		startDelayTime = reader.ReadInt32();
		limitTime = reader.ReadInt32();
		exitDelayTime = reader.ReadInt32();
		startXPosition = reader.ReadSingle();
		startYPosition = reader.ReadSingle();
		startZPosition = reader.ReadSingle();
		startRadius = reader.ReadSingle();
		startYRotation = reader.ReadSingle();
		safeRevivalWaitingTime = reader.ReadInt32();
		guideDisplayInterval = reader.ReadInt32();
		completionExitPositionEnabled = reader.ReadBoolean();
		completionExitXPosition = reader.ReadSingle();
		completionExitYPosition = reader.ReadSingle();
		completionExitZPosition = reader.ReadSingle();
		completionExitYRotation = reader.ReadSingle();
		locationId = reader.ReadInt32();
		x = reader.ReadSingle();
		z = reader.ReadSingle();
		xSize = reader.ReadSingle();
		zSize = reader.ReadSingle();
	}
}
