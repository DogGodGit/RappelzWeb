namespace WebCommon;

public class WPDContinentObjectArrange : WPDPacketData
{
	public int continentId;

	public int arrangeNo;

	public int objectId;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public int yRotationType;

	public float yRotation;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(continentId);
		writer.Write(arrangeNo);
		writer.Write(objectId);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(yRotationType);
		writer.Write(yRotation);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		continentId = reader.ReadInt32();
		arrangeNo = reader.ReadInt32();
		objectId = reader.ReadInt32();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		yRotationType = reader.ReadInt32();
		yRotation = reader.ReadSingle();
	}
}
