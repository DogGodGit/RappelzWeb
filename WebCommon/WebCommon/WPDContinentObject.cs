namespace WebCommon;

public class WPDContinentObject : WPDPacketData
{
	public int objectId;

	public string nameKey;

	public float interactionDuration;

	public float interactionMaxRange;

	public string interactionTextKey;

	public string prefabName;

	public float scale;

	public int height;

	public float radius;

	public int regenTime;

	public bool isPublic;

	public bool interactionCompletionAnimationEnabled;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(objectId);
		writer.Write(nameKey);
		writer.Write(interactionDuration);
		writer.Write(interactionMaxRange);
		writer.Write(interactionTextKey);
		writer.Write(prefabName);
		writer.Write(scale);
		writer.Write(height);
		writer.Write(radius);
		writer.Write(regenTime);
		writer.Write(isPublic);
		writer.Write(interactionCompletionAnimationEnabled);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		objectId = reader.ReadInt32();
		nameKey = reader.ReadString();
		interactionDuration = reader.ReadSingle();
		interactionMaxRange = reader.ReadSingle();
		interactionTextKey = reader.ReadString();
		prefabName = reader.ReadString();
		scale = reader.ReadSingle();
		height = reader.ReadInt32();
		radius = reader.ReadSingle();
		regenTime = reader.ReadInt32();
		isPublic = reader.ReadBoolean();
		interactionCompletionAnimationEnabled = reader.ReadBoolean();
	}
}
