namespace WebCommon;

public class WPDProofOfValorBuffBoxArrange : WPDPacketData
{
	public int arrangeId;

	public int buffBoxId;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public float radius;

	public int yRotationType;

	public float yRotation;

	public float acquisitionRange;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(arrangeId);
		writer.Write(buffBoxId);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(radius);
		writer.Write(yRotationType);
		writer.Write(yRotation);
		writer.Write(acquisitionRange);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		arrangeId = reader.ReadInt32();
		buffBoxId = reader.ReadInt32();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		radius = reader.ReadSingle();
		yRotationType = reader.ReadInt32();
		yRotation = reader.ReadSingle();
		acquisitionRange = reader.ReadSingle();
	}
}
