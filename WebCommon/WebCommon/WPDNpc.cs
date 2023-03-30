namespace WebCommon;

public class WPDNpc : WPDPacketData
{
	public int npcId;

	public string nameKey;

	public string nickKey;

	public string dialogueKey;

	public string imageName;

	public int type;

	public int continentId;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public float yRotation;

	public float interactionMaxRange;

	public string prefabName;

	public string soundName;

	public float scale;

	public int height;

	public float radius;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(npcId);
		writer.Write(nameKey);
		writer.Write(nickKey);
		writer.Write(dialogueKey);
		writer.Write(imageName);
		writer.Write(type);
		writer.Write(continentId);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(yRotation);
		writer.Write(interactionMaxRange);
		writer.Write(prefabName);
		writer.Write(soundName);
		writer.Write(scale);
		writer.Write(height);
		writer.Write(radius);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		npcId = reader.ReadInt32();
		nameKey = reader.ReadString();
		nickKey = reader.ReadString();
		dialogueKey = reader.ReadString();
		imageName = reader.ReadString();
		type = reader.ReadInt32();
		continentId = reader.ReadInt32();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		yRotation = reader.ReadSingle();
		interactionMaxRange = reader.ReadSingle();
		prefabName = reader.ReadString();
		soundName = reader.ReadString();
		scale = reader.ReadSingle();
		height = reader.ReadInt32();
		radius = reader.ReadSingle();
	}
}
