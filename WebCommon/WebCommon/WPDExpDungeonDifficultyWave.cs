namespace WebCommon;

public class WPDExpDungeonDifficultyWave : WPDPacketData
{
	public int difficulty;

	public int waveNo;

	public int waveLimitTime;

	public string targetTitleKey;

	public string targetContentKey;

	public int lakChargeAmount;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(difficulty);
		writer.Write(waveNo);
		writer.Write(waveLimitTime);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(lakChargeAmount);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		difficulty = reader.ReadInt32();
		waveNo = reader.ReadInt32();
		waveLimitTime = reader.ReadInt32();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		lakChargeAmount = reader.ReadInt32();
	}
}
