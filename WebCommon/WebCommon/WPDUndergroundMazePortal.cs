namespace WebCommon;

public class WPDUndergroundMazePortal : WPDPacketData
{
	public int portalId;

	public int floor;

	public string nameKey;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public float radius;

	public float yRotation;

	public float exitXPosition;

	public float exitYPosition;

	public float exitZPosition;

	public float exitRadius;

	public int exitYRotationType;

	public float exitYRotation;

	public int linkedPortalId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(portalId);
		writer.Write(floor);
		writer.Write(nameKey);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(radius);
		writer.Write(yRotation);
		writer.Write(exitXPosition);
		writer.Write(exitYPosition);
		writer.Write(exitZPosition);
		writer.Write(exitRadius);
		writer.Write(exitYRotationType);
		writer.Write(exitYRotation);
		writer.Write(linkedPortalId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		portalId = reader.ReadInt32();
		floor = reader.ReadInt32();
		nameKey = reader.ReadString();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		radius = reader.ReadSingle();
		yRotation = reader.ReadSingle();
		exitXPosition = reader.ReadSingle();
		exitYPosition = reader.ReadSingle();
		exitZPosition = reader.ReadSingle();
		exitRadius = reader.ReadSingle();
		exitYRotationType = reader.ReadInt32();
		exitYRotation = reader.ReadSingle();
		linkedPortalId = reader.ReadInt32();
	}
}
