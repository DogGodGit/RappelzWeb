namespace WebCommon;

public class WPDRuinsReclaimStepWave : WPDPacketData
{
	public int stepNo;

	public int waveNo;

	public string targetTitleKey;

	public string targetContentKey;

	public int targetType;

	public int targetArrangeKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(stepNo);
		writer.Write(waveNo);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(targetType);
		writer.Write(targetArrangeKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		stepNo = reader.ReadInt32();
		waveNo = reader.ReadInt32();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		targetType = reader.ReadInt32();
		targetArrangeKey = reader.ReadInt32();
	}
}
