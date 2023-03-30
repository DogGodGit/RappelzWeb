namespace WebCommon;

public class WPDPaidImmediateRevival : WPDPacketData
{
	public int revivalCount;

	public int requiredDia;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(revivalCount);
		writer.Write(requiredDia);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		revivalCount = reader.ReadInt32();
		requiredDia = reader.ReadInt32();
	}
}
