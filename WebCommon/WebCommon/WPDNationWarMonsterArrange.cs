namespace WebCommon;

public class WPDNationWarMonsterArrange : WPDPacketData
{
	public int arrangeId;

	public long monsterArrangeId;

	public int type;

	public int continentId;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public float yRotation;

	public int nationWarNpcId;

	public int regenTime;

	public float transmissionXPosition;

	public float transmissionYPosition;

	public float transmissionZPosition;

	public float transmissionRadius;

	public int transmissionYRotationType;

	public float transmissionYRotation;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(arrangeId);
		writer.Write(monsterArrangeId);
		writer.Write(type);
		writer.Write(continentId);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(yRotation);
		writer.Write(nationWarNpcId);
		writer.Write(regenTime);
		writer.Write(transmissionXPosition);
		writer.Write(transmissionYPosition);
		writer.Write(transmissionZPosition);
		writer.Write(transmissionRadius);
		writer.Write(transmissionYRotationType);
		writer.Write(transmissionYRotation);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		arrangeId = reader.ReadInt32();
		monsterArrangeId = reader.ReadInt64();
		type = reader.ReadInt32();
		continentId = reader.ReadInt32();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		yRotation = reader.ReadSingle();
		nationWarNpcId = reader.ReadInt32();
		regenTime = reader.ReadInt32();
		transmissionXPosition = reader.ReadSingle();
		transmissionYPosition = reader.ReadSingle();
		transmissionZPosition = reader.ReadSingle();
		transmissionRadius = reader.ReadSingle();
		transmissionYRotationType = reader.ReadInt32();
		transmissionYRotation = reader.ReadSingle();
	}
}
