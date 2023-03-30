namespace WebCommon;

public class WPDWarMemoryStartPosition : WPDPacketData
{
	public int positionId;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public float radius;

	public int yRotationType;

	public float yRotation;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(positionId);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(radius);
		writer.Write(yRotationType);
		writer.Write(yRotation);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		positionId = reader.ReadInt32();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		radius = reader.ReadSingle();
		yRotationType = reader.ReadInt32();
		yRotation = reader.ReadSingle();
	}
}
