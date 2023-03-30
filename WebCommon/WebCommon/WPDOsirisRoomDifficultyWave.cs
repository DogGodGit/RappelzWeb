namespace WebCommon;

public class WPDOsirisRoomDifficultyWave : WPDPacketData
{
	public int difficulty;

	public int waveNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(difficulty);
		writer.Write(waveNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		difficulty = reader.ReadInt32();
		waveNo = reader.ReadInt32();
	}
}
