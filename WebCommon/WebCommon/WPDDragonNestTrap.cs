namespace WebCommon;

public class WPDDragonNestTrap : WPDPacketData
{
	public int trapId;

	public string prefabName;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public float radius;

	public int damage;

	public int activationStepNo;

	public int deactivationStepNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(trapId);
		writer.Write(prefabName);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(radius);
		writer.Write(damage);
		writer.Write(activationStepNo);
		writer.Write(deactivationStepNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		trapId = reader.ReadInt32();
		prefabName = reader.ReadString();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		radius = reader.ReadSingle();
		damage = reader.ReadInt32();
		activationStepNo = reader.ReadInt32();
		deactivationStepNo = reader.ReadInt32();
	}
}
