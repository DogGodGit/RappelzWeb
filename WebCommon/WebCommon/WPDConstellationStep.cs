namespace WebCommon;

public class WPDConstellationStep : WPDPacketData
{
	public int constellationId;

	public int step;

	public int requiredDia;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(constellationId);
		writer.Write(step);
		writer.Write(requiredDia);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		constellationId = reader.ReadInt32();
		step = reader.ReadInt32();
		requiredDia = reader.ReadInt32();
	}
}
