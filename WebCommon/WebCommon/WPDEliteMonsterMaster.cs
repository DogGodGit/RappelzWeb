namespace WebCommon;

public class WPDEliteMonsterMaster : WPDPacketData
{
	public int eliteMonsterMasterId;

	public string nameKey;

	public int level;

	public int displayMonsterId;

	public int categoryId;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public int yRotationType;

	public float yRotation;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(eliteMonsterMasterId);
		writer.Write(nameKey);
		writer.Write(level);
		writer.Write(displayMonsterId);
		writer.Write(categoryId);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(yRotationType);
		writer.Write(yRotation);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		eliteMonsterMasterId = reader.ReadInt32();
		nameKey = reader.ReadString();
		level = reader.ReadInt32();
		displayMonsterId = reader.ReadInt32();
		categoryId = reader.ReadInt32();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		yRotationType = reader.ReadInt32();
		yRotation = reader.ReadSingle();
	}
}
