namespace WebCommon;

public class WPDFearAltarStage : WPDPacketData
{
	public int stageId;

	public string nameKey;

	public string targetTitleKey;

	public string targetContentKey;

	public string sceneName;

	public float startXPosition;

	public float startYPosition;

	public float startZPosition;

	public float startRadius;

	public int startYRotationType;

	public float startYRotation;

	public int locationId;

	public float x;

	public float z;

	public float xSize;

	public float zSize;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(stageId);
		writer.Write(nameKey);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(sceneName);
		writer.Write(startXPosition);
		writer.Write(startYPosition);
		writer.Write(startZPosition);
		writer.Write(startRadius);
		writer.Write(startYRotationType);
		writer.Write(startYRotation);
		writer.Write(locationId);
		writer.Write(x);
		writer.Write(z);
		writer.Write(xSize);
		writer.Write(zSize);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		stageId = reader.ReadInt32();
		nameKey = reader.ReadString();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		sceneName = reader.ReadString();
		startXPosition = reader.ReadSingle();
		startYPosition = reader.ReadSingle();
		startZPosition = reader.ReadSingle();
		startRadius = reader.ReadSingle();
		startYRotationType = reader.ReadInt32();
		startYRotation = reader.ReadSingle();
		locationId = reader.ReadInt32();
		x = reader.ReadSingle();
		z = reader.ReadSingle();
		xSize = reader.ReadSingle();
		zSize = reader.ReadSingle();
	}
}
