namespace WebCommon;

public class WPDWisdomTempleQuizMonsterPosition : WPDPacketData
{
	public int stepNo;

	public int row;

	public int col;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(stepNo);
		writer.Write(row);
		writer.Write(col);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		stepNo = reader.ReadInt32();
		row = reader.ReadInt32();
		col = reader.ReadInt32();
	}
}
