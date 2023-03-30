namespace WebCommon;

public class WPDOpen7DayEventDay : WPDPacketData
{
	public int day;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(day);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		day = reader.ReadInt32();
	}
}
