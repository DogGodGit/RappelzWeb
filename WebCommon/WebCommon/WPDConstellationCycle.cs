namespace WebCommon;

public class WPDConstellationCycle : WPDPacketData
{
	public int constellationId;

	public int step;

	public int cycle;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(constellationId);
		writer.Write(step);
		writer.Write(cycle);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		constellationId = reader.ReadInt32();
		step = reader.ReadInt32();
		cycle = reader.ReadInt32();
	}
}
