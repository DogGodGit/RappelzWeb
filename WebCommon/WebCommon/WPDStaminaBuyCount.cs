namespace WebCommon;

public class WPDStaminaBuyCount : WPDPacketData
{
	public int buyCount;

	public int stamina;

	public int requiredDia;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(buyCount);
		writer.Write(stamina);
		writer.Write(requiredDia);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		buyCount = reader.ReadInt32();
		stamina = reader.ReadInt32();
		requiredDia = reader.ReadInt32();
	}
}
