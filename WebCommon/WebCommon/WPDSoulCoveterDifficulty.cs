namespace WebCommon;

public class WPDSoulCoveterDifficulty : WPDPacketData
{
	public int difficulty;

	public string nameKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(difficulty);
		writer.Write(nameKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		difficulty = reader.ReadInt32();
		nameKey = reader.ReadString();
	}
}
