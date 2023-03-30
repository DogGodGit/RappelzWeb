namespace WebCommon;

public class WPDSupplySupportQuestWayPoint : WPDPacketData
{
	public int wayPoint;

	public int cartChangeNpcId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(wayPoint);
		writer.Write(cartChangeNpcId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		wayPoint = reader.ReadInt32();
		cartChangeNpcId = reader.ReadInt32();
	}
}
