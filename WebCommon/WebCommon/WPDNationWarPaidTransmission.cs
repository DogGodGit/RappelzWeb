namespace WebCommon;

public class WPDNationWarPaidTransmission : WPDPacketData
{
	public int transmissionCount;

	public int requiredDia;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(transmissionCount);
		writer.Write(requiredDia);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		transmissionCount = reader.ReadInt32();
		requiredDia = reader.ReadInt32();
	}
}
