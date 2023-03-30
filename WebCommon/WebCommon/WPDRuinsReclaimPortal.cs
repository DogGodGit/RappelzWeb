namespace WebCommon;

public class WPDRuinsReclaimPortal : WPDPacketData
{
	public int portalId;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public float radius;

	public float exitXPosition;

	public float exitYPosition;

	public float exitZPosition;

	public float exitRadius;

	public int exitYRotationType;

	public float exitYRotation;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(portalId);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(radius);
		writer.Write(exitXPosition);
		writer.Write(exitYPosition);
		writer.Write(exitZPosition);
		writer.Write(exitRadius);
		writer.Write(exitYRotationType);
		writer.Write(exitYRotation);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		portalId = reader.ReadInt32();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		radius = reader.ReadSingle();
		exitXPosition = reader.ReadSingle();
		exitYPosition = reader.ReadSingle();
		exitZPosition = reader.ReadSingle();
		exitRadius = reader.ReadSingle();
		exitYRotationType = reader.ReadInt32();
		exitYRotation = reader.ReadSingle();
	}
}
