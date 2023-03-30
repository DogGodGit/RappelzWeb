namespace WebCommon;

public class WPDSoulCoveterDifficultyWave : WPDPacketData
{
	public int difficulty;

	public int waveNo;

	public string targetTitleKey;

	public string targetContentKey;

	public int targetArrangeNo;

	public string guideImageName;

	public string guideTitleKey;

	public string guideContentKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(difficulty);
		writer.Write(waveNo);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(targetArrangeNo);
		writer.Write(guideImageName);
		writer.Write(guideTitleKey);
		writer.Write(guideContentKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		difficulty = reader.ReadInt32();
		waveNo = reader.ReadInt32();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		targetArrangeNo = reader.ReadInt32();
		guideImageName = reader.ReadString();
		guideTitleKey = reader.ReadString();
		guideContentKey = reader.ReadString();
	}
}
