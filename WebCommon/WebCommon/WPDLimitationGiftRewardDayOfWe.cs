namespace WebCommon;

public class WPDLimitationGiftRewardDayOfWeek : WPDPacketData
{
	public int dayOfWeek;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(dayOfWeek);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		dayOfWeek = reader.ReadInt32();
	}
}
