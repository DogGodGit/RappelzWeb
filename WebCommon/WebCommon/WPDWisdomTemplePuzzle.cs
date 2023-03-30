namespace WebCommon;

public class WPDWisdomTemplePuzzle : WPDPacketData
{
	public int puzzleId;

	public string targetTitleKey;

	public string targetContentKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(puzzleId);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		puzzleId = reader.ReadInt32();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
	}
}
