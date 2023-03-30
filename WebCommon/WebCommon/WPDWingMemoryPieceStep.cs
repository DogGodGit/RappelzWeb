namespace WebCommon;

public class WPDWingMemoryPieceStep : WPDPacketData
{
	public int wingId;

	public int step;

	public int requiredMemoryPieceCount;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(wingId);
		writer.Write(step);
		writer.Write(requiredMemoryPieceCount);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		wingId = reader.ReadInt32();
		step = reader.ReadInt32();
		requiredMemoryPieceCount = reader.ReadInt32();
	}
}
