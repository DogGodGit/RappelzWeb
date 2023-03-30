namespace WebCommon;

public class WPDWarMemoryTransformationObject : WPDPacketData
{
	public int waveNo;

	public int transformationObjectId;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public float radius;

	public string objectPrefabName;

	public float objectInteractionDuration;

	public float objectInteractionMaxRange;

	public float objectScale;

	public int objectHeight;

	public float objectRadius;

	public string objectInteractionTextKey;

	public int objectLifetime;

	public int transformationMonsterId;

	public int transformationLifetime;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(waveNo);
		writer.Write(transformationObjectId);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(radius);
		writer.Write(objectPrefabName);
		writer.Write(objectInteractionDuration);
		writer.Write(objectInteractionMaxRange);
		writer.Write(objectScale);
		writer.Write(objectHeight);
		writer.Write(objectRadius);
		writer.Write(objectInteractionTextKey);
		writer.Write(objectLifetime);
		writer.Write(transformationMonsterId);
		writer.Write(transformationLifetime);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		waveNo = reader.ReadInt32();
		transformationObjectId = reader.ReadInt32();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		radius = reader.ReadSingle();
		objectPrefabName = reader.ReadString();
		objectInteractionDuration = reader.ReadSingle();
		objectInteractionMaxRange = reader.ReadSingle();
		objectScale = reader.ReadSingle();
		objectHeight = reader.ReadInt32();
		objectRadius = reader.ReadSingle();
		objectInteractionTextKey = reader.ReadString();
		objectLifetime = reader.ReadInt32();
		transformationMonsterId = reader.ReadInt32();
		transformationLifetime = reader.ReadInt32();
	}
}
