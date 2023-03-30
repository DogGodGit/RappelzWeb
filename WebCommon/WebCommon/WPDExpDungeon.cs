namespace WebCommon;

public class WPDExpDungeon : WPDPacketData
{
	public string nameKey;

	public string descriptionKey;

	public int requiredStamina;

	public int limitTime;

	public string sceneName;

	public float startXPosition;

	public float startYPosition;

	public float startZPosition;

	public float startYRotation;

	public int startDelayTime;

	public int exitDelayTime;

	public int waveIntervalTime;

	public int safeRevivalWaitingTime;

	public float sweepExpRewardFactor;

	public string guideImageName;

	public string guideTitleKey;

	public string startGuideContentKey;

	public string lakChargeMonsterAppearContentKey;

	public string lakChargeMonsterKillContentKey;

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
		writer.Write(limitTime);
		writer.Write(sceneName);
		writer.Write(startXPosition);
		writer.Write(startYPosition);
		writer.Write(startZPosition);
		writer.Write(startYRotation);
		writer.Write(startDelayTime);
		writer.Write(exitDelayTime);
		writer.Write(waveIntervalTime);
		writer.Write(safeRevivalWaitingTime);
		writer.Write(sweepExpRewardFactor);
		writer.Write(guideImageName);
		writer.Write(guideTitleKey);
		writer.Write(startGuideContentKey);
		writer.Write(lakChargeMonsterAppearContentKey);
		writer.Write(lakChargeMonsterKillContentKey);
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
		limitTime = reader.ReadInt32();
		sceneName = reader.ReadString();
		startXPosition = reader.ReadSingle();
		startYPosition = reader.ReadSingle();
		startZPosition = reader.ReadSingle();
		startYRotation = reader.ReadSingle();
		startDelayTime = reader.ReadInt32();
		exitDelayTime = reader.ReadInt32();
		waveIntervalTime = reader.ReadInt32();
		safeRevivalWaitingTime = reader.ReadInt32();
		sweepExpRewardFactor = reader.ReadSingle();
		guideImageName = reader.ReadString();
		guideTitleKey = reader.ReadString();
		startGuideContentKey = reader.ReadString();
		lakChargeMonsterAppearContentKey = reader.ReadString();
		lakChargeMonsterKillContentKey = reader.ReadString();
		locationId = reader.ReadInt32();
		x = reader.ReadSingle();
		z = reader.ReadSingle();
		xSize = reader.ReadSingle();
		zSize = reader.ReadSingle();
	}
}
