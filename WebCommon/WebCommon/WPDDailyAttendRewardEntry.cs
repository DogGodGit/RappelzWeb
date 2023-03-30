namespace WebCommon;

public class WPDDailyAttendRewardEntry : WPDPacketData
{
	public int day;

	public long itemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(day);
		writer.Write(itemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		day = reader.ReadInt32();
		itemRewardId = reader.ReadInt64();
	}
}
