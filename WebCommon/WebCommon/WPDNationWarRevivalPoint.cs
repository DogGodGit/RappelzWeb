namespace WebCommon;

public class WPDNationWarRevivalPoint : WPDPacketData
{
	public int revivalPointId;

	public string nameKey;

	public int continentId;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public float radius;

	public int yRotationType;

	public float yRotation;

	public int priority;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(revivalPointId);
		writer.Write(nameKey);
		writer.Write(continentId);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(radius);
		writer.Write(yRotationType);
		writer.Write(yRotation);
		writer.Write(priority);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		revivalPointId = reader.ReadInt32();
		nameKey = reader.ReadString();
		continentId = reader.ReadInt32();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		radius = reader.ReadSingle();
		yRotationType = reader.ReadInt32();
		yRotation = reader.ReadSingle();
		priority = reader.ReadInt32();
	}
}
