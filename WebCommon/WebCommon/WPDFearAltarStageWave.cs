namespace WebCommon;

public class WPDFearAltarStageWave : WPDPacketData
{
	public int stageId;

	public int waveNo;

	public string guideImageName;

	public string guideTitleKey;

	public string guideContentKey;

	public int type;

	public float halidomMonsterXPosition;

	public float halidomMonsterYPosition;

	public float halidomMonsterZPosition;

	public int halidomMonsterYRotationType;

	public float halidomMonsterYRotation;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(stageId);
		writer.Write(waveNo);
		writer.Write(guideImageName);
		writer.Write(guideTitleKey);
		writer.Write(guideContentKey);
		writer.Write(type);
		writer.Write(halidomMonsterXPosition);
		writer.Write(halidomMonsterYPosition);
		writer.Write(halidomMonsterZPosition);
		writer.Write(halidomMonsterYRotationType);
		writer.Write(halidomMonsterYRotation);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		stageId = reader.ReadInt32();
		waveNo = reader.ReadInt32();
		guideImageName = reader.ReadString();
		guideTitleKey = reader.ReadString();
		guideContentKey = reader.ReadString();
		type = reader.ReadInt32();
		halidomMonsterXPosition = reader.ReadSingle();
		halidomMonsterYPosition = reader.ReadSingle();
		halidomMonsterZPosition = reader.ReadSingle();
		halidomMonsterYRotationType = reader.ReadInt32();
		halidomMonsterYRotation = reader.ReadSingle();
	}
}
