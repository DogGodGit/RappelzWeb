namespace WebCommon;

public class WPDConstellationEntry : WPDPacketData
{
	public int constellationId;

	public int step;

	public int cycle;

	public int entryNo;

	public int requiredStarEssense;

	public long requiredGold;

	public int successRate;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(constellationId);
		writer.Write(step);
		writer.Write(cycle);
		writer.Write(entryNo);
		writer.Write(requiredStarEssense);
		writer.Write(requiredGold);
		writer.Write(successRate);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		constellationId = reader.ReadInt32();
		step = reader.ReadInt32();
		cycle = reader.ReadInt32();
		entryNo = reader.ReadInt32();
		requiredStarEssense = reader.ReadInt32();
		requiredGold = reader.ReadInt64();
		successRate = reader.ReadInt32();
	}
}
