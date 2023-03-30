namespace WebCommon;

public class WPDRuinsReclaimStepWaveSkill : WPDPacketData
{
	public int stepNo;

	public int waveNo;

	public int castingInterval;

	public string guideImageName;

	public string guideTitleKey;

	public string guideContentKey;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public float radius;

	public int transformationMonsterId;

	public int transformationLifetime;

	public string objectPrefabName;

	public float objectInteractionDuration;

	public float objectInteractionMaxRange;

	public float objectScale;

	public int objectHeight;

	public float objectRadius;

	public string objectInteractionTextKey;

	public int objectLifetime;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(stepNo);
		writer.Write(waveNo);
		writer.Write(castingInterval);
		writer.Write(guideImageName);
		writer.Write(guideTitleKey);
		writer.Write(guideContentKey);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(radius);
		writer.Write(transformationMonsterId);
		writer.Write(transformationLifetime);
		writer.Write(objectPrefabName);
		writer.Write(objectInteractionDuration);
		writer.Write(objectInteractionMaxRange);
		writer.Write(objectScale);
		writer.Write(objectHeight);
		writer.Write(objectRadius);
		writer.Write(objectInteractionTextKey);
		writer.Write(objectLifetime);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		stepNo = reader.ReadInt32();
		waveNo = reader.ReadInt32();
		castingInterval = reader.ReadInt32();
		guideImageName = reader.ReadString();
		guideTitleKey = reader.ReadString();
		guideContentKey = reader.ReadString();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		radius = reader.ReadSingle();
		transformationMonsterId = reader.ReadInt32();
		transformationLifetime = reader.ReadInt32();
		objectPrefabName = reader.ReadString();
		objectInteractionDuration = reader.ReadSingle();
		objectInteractionMaxRange = reader.ReadSingle();
		objectScale = reader.ReadSingle();
		objectHeight = reader.ReadInt32();
		objectRadius = reader.ReadSingle();
		objectInteractionTextKey = reader.ReadString();
		objectLifetime = reader.ReadInt32();
	}
}
