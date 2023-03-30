namespace WebCommon;

public class WPDNationNoblesseAppointmentAuthority : WPDPacketData
{
	public int noblesseId;

	public int targetNoblesseId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(noblesseId);
		writer.Write(targetNoblesseId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		noblesseId = reader.ReadInt32();
		targetNoblesseId = reader.ReadInt32();
	}
}
