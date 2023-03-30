namespace WebCommon;

public class WPDWisdomTempleArrangePosition : WPDPacketData
{
	public int row;

	public int col;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public float yRotation;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(row);
		writer.Write(col);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(yRotation);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		row = reader.ReadInt32();
		col = reader.ReadInt32();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		yRotation = reader.ReadSingle();
	}
}
