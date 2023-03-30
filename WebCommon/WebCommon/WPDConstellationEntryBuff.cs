namespace WebCommon;

public class WPDConstellationEntryBuff : WPDPacketData
{
	public int constellationId;

	public int step;

	public int cycle;

	public int entryNo;

	public int attrId;

	public long attrValueId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(constellationId);
		writer.Write(step);
		writer.Write(cycle);
		writer.Write(entryNo);
		writer.Write(attrId);
		writer.Write(attrValueId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		constellationId = reader.ReadInt32();
		step = reader.ReadInt32();
		cycle = reader.ReadInt32();
		entryNo = reader.ReadInt32();
		attrId = reader.ReadInt32();
		attrValueId = reader.ReadInt64();
	}
}
