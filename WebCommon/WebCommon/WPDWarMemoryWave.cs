namespace WebCommon;

public class WPDWarMemoryWave : WPDPacketData
{
	public int waveNo;

	public int startDelayTime;

	public int clearPoint;

	public int targetType;

	public int targetArrangeKey;

	public string guideImageName;

	public string guideTitleKey;

	public string guideContentKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(waveNo);
		writer.Write(startDelayTime);
		writer.Write(clearPoint);
		writer.Write(targetType);
		writer.Write(targetArrangeKey);
		writer.Write(guideImageName);
		writer.Write(guideTitleKey);
		writer.Write(guideContentKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		waveNo = reader.ReadInt32();
		startDelayTime = reader.ReadInt32();
		clearPoint = reader.ReadInt32();
		targetType = reader.ReadInt32();
		targetArrangeKey = reader.ReadInt32();
		guideImageName = reader.ReadString();
		guideTitleKey = reader.ReadString();
		guideContentKey = reader.ReadString();
	}
}
