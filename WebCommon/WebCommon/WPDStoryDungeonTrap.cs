namespace WebCommon;

public class WPDStoryDungeonTrap : WPDPacketData
{
	public int dungeonNo;

	public int difficulty;

	public int trapId;

	public string prefabName;

	public float prefabScale;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public float yRotation;

	public float width;

	public float height;

	public float hitAreaOffset;

	public float startDelay;

	public float castingStartDelay;

	public int castingDuration;

	public int hitCount;

	public float castingTerm;

	public float damage;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(dungeonNo);
		writer.Write(difficulty);
		writer.Write(trapId);
		writer.Write(prefabName);
		writer.Write(prefabScale);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(yRotation);
		writer.Write(width);
		writer.Write(height);
		writer.Write(hitAreaOffset);
		writer.Write(startDelay);
		writer.Write(castingStartDelay);
		writer.Write(castingDuration);
		writer.Write(hitCount);
		writer.Write(castingTerm);
		writer.Write(damage);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		dungeonNo = reader.ReadInt32();
		difficulty = reader.ReadInt32();
		trapId = reader.ReadInt32();
		prefabName = reader.ReadString();
		prefabScale = reader.ReadSingle();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		yRotation = reader.ReadSingle();
		width = reader.ReadSingle();
		height = reader.ReadSingle();
		hitAreaOffset = reader.ReadSingle();
		startDelay = reader.ReadSingle();
		castingStartDelay = reader.ReadSingle();
		castingDuration = reader.ReadInt32();
		hitCount = reader.ReadInt32();
		castingTerm = reader.ReadSingle();
		damage = reader.ReadSingle();
	}
}
