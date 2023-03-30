namespace WebCommon;

public class WPDRuinsReclaimStep : WPDPacketData
{
	public int stepNo;

	public int type;

	public string targetTitleKey;

	public string targetContentKey;

	public float targetXPosition;

	public float targetYPosition;

	public float targetZPosition;

	public float targetRadius;

	public int removeObstacleId;

	public int activationPortalId;

	public int deactivationPortalId;

	public int revivalPointId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(stepNo);
		writer.Write(type);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(targetXPosition);
		writer.Write(targetYPosition);
		writer.Write(targetZPosition);
		writer.Write(targetRadius);
		writer.Write(removeObstacleId);
		writer.Write(activationPortalId);
		writer.Write(deactivationPortalId);
		writer.Write(revivalPointId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		stepNo = reader.ReadInt32();
		type = reader.ReadInt32();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		targetXPosition = reader.ReadSingle();
		targetYPosition = reader.ReadSingle();
		targetZPosition = reader.ReadSingle();
		targetRadius = reader.ReadSingle();
		removeObstacleId = reader.ReadInt32();
		activationPortalId = reader.ReadInt32();
		deactivationPortalId = reader.ReadInt32();
		revivalPointId = reader.ReadInt32();
	}
}
