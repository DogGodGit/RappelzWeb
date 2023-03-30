namespace WebCommon;

public class WPDDragonNestStep : WPDPacketData
{
	public int stepNo;

	public int type;

	public string targetTitleKey;

	public string targetContentKey;

	public int startDelayTime;

	public bool targetAreaDisplayed;

	public float targetXPosition;

	public float targetYPosition;

	public float targetZPosition;

	public float targetRadius;

	public int removeObstacleId;

	public string guideImageName;

	public string guideTitleKey;

	public string guideContentKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(stepNo);
		writer.Write(type);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(startDelayTime);
		writer.Write(targetAreaDisplayed);
		writer.Write(targetXPosition);
		writer.Write(targetYPosition);
		writer.Write(targetZPosition);
		writer.Write(targetRadius);
		writer.Write(removeObstacleId);
		writer.Write(guideImageName);
		writer.Write(guideTitleKey);
		writer.Write(guideContentKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		stepNo = reader.ReadInt32();
		type = reader.ReadInt32();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		startDelayTime = reader.ReadInt32();
		targetAreaDisplayed = reader.ReadBoolean();
		targetXPosition = reader.ReadSingle();
		targetYPosition = reader.ReadSingle();
		targetZPosition = reader.ReadSingle();
		targetRadius = reader.ReadSingle();
		removeObstacleId = reader.ReadInt32();
		guideImageName = reader.ReadString();
		guideTitleKey = reader.ReadString();
		guideContentKey = reader.ReadString();
	}
}
