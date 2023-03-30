namespace WebCommon;

public class WPDUndergroundMazeNpc : WPDPacketData
{
	public int npcId;

	public int floor;

	public string nameKey;

	public string dialogueKey;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public float yRotation;

	public float interactionMaxRange;

	public string prefabName;

	public float scale;

	public int height;

	public float radius;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(npcId);
		writer.Write(floor);
		writer.Write(nameKey);
		writer.Write(dialogueKey);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(yRotation);
		writer.Write(interactionMaxRange);
		writer.Write(prefabName);
		writer.Write(scale);
		writer.Write(height);
		writer.Write(radius);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		npcId = reader.ReadInt32();
		floor = reader.ReadInt32();
		nameKey = reader.ReadString();
		dialogueKey = reader.ReadString();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		yRotation = reader.ReadSingle();
		interactionMaxRange = reader.ReadSingle();
		prefabName = reader.ReadString();
		scale = reader.ReadSingle();
		height = reader.ReadInt32();
		radius = reader.ReadSingle();
	}
}
