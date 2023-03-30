namespace WebCommon;

public class WPDWisdomTempleColorMatchingObject : WPDPacketData
{
	public int objectId;

	public string prefabName;

	public float interactionDuration;

	public float interactionMaxRange;

	public float scale;

	public int height;

	public float radius;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(objectId);
		writer.Write(prefabName);
		writer.Write(interactionDuration);
		writer.Write(interactionMaxRange);
		writer.Write(scale);
		writer.Write(height);
		writer.Write(radius);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		objectId = reader.ReadInt32();
		prefabName = reader.ReadString();
		interactionDuration = reader.ReadSingle();
		interactionMaxRange = reader.ReadSingle();
		scale = reader.ReadSingle();
		height = reader.ReadInt32();
		radius = reader.ReadSingle();
	}
}
