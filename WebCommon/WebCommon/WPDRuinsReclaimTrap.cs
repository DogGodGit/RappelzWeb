namespace WebCommon;

public class WPDRuinsReclaimTrap : WPDPacketData
{
	public int trapId;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public float radius;

	public int damage;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(trapId);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(radius);
		writer.Write(damage);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		trapId = reader.ReadInt32();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		radius = reader.ReadSingle();
		damage = reader.ReadInt32();
	}
}
