namespace WebCommon;

public class WPDDragonNestObstacle : WPDPacketData
{
	public int obstacleId;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public float yRotation;

	public float scale;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(obstacleId);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(yRotation);
		writer.Write(scale);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		obstacleId = reader.ReadInt32();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		yRotation = reader.ReadSingle();
		scale = reader.ReadSingle();
	}
}
