namespace WebCommon;

public class WPDRookieGift : WPDPacketData
{
	public int giftNo;

	public int waitingTime;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(giftNo);
		writer.Write(waitingTime);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		giftNo = reader.ReadInt32();
		waitingTime = reader.ReadInt32();
	}
}
