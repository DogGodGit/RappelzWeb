namespace WebCommon;

public class WPDRuinsReclaimObjectArrange : WPDPacketData
{
	public int stepNo;

	public int arrangeNo;

	public string prefabName;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public float radius;

	public float objectInteractionDuration;

	public float objectInteractionMaxRange;

	public float objectScale;

	public int objectHeight;

	public float objectRadius;

	public string objectInteractionTextKey;

	public long goldRewardId;

	public long itemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(stepNo);
		writer.Write(arrangeNo);
		writer.Write(prefabName);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(radius);
		writer.Write(objectInteractionDuration);
		writer.Write(objectInteractionMaxRange);
		writer.Write(objectScale);
		writer.Write(objectHeight);
		writer.Write(objectRadius);
		writer.Write(objectInteractionTextKey);
		writer.Write(goldRewardId);
		writer.Write(itemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		stepNo = reader.ReadInt32();
		arrangeNo = reader.ReadInt32();
		prefabName = reader.ReadString();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		radius = reader.ReadSingle();
		objectInteractionDuration = reader.ReadSingle();
		objectInteractionMaxRange = reader.ReadSingle();
		objectScale = reader.ReadSingle();
		objectHeight = reader.ReadInt32();
		objectRadius = reader.ReadSingle();
		objectInteractionTextKey = reader.ReadString();
		goldRewardId = reader.ReadInt64();
		itemRewardId = reader.ReadInt64();
	}
}
