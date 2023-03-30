namespace WebCommon;

public class WPDRestRewardTime : WPDPacketData
{
	public int restTime;

	public long requiredGold;

	public int requiredDia;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(restTime);
		writer.Write(requiredGold);
		writer.Write(requiredDia);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		restTime = reader.ReadInt32();
		requiredGold = reader.ReadInt64();
		requiredDia = reader.ReadInt32();
	}
}
