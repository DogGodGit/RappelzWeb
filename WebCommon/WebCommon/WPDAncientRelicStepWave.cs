namespace WebCommon;

public class WPDAncientRelicStepWave : WPDPacketData
{
	public int step;

	public int waveNo;

	public bool isGuideDisplay;

	public string guideImageName;

	public string guideTitleKey;

	public string guideContentKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(step);
		writer.Write(waveNo);
		writer.Write(isGuideDisplay);
		writer.Write(guideImageName);
		writer.Write(guideTitleKey);
		writer.Write(guideContentKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		step = reader.ReadInt32();
		waveNo = reader.ReadInt32();
		isGuideDisplay = reader.ReadBoolean();
		guideImageName = reader.ReadString();
		guideTitleKey = reader.ReadString();
		guideContentKey = reader.ReadString();
	}
}
