namespace WebCommon;

public class WPDOpen7DayEventProduct : WPDPacketData
{
	public int productId;

	public int day;

	public int itemId;

	public bool itemOwned;

	public int itemCount;

	public int requiredDia;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(productId);
		writer.Write(day);
		writer.Write(itemId);
		writer.Write(itemOwned);
		writer.Write(itemCount);
		writer.Write(requiredDia);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		productId = reader.ReadInt32();
		day = reader.ReadInt32();
		itemId = reader.ReadInt32();
		itemOwned = reader.ReadBoolean();
		itemCount = reader.ReadInt32();
		requiredDia = reader.ReadInt32();
	}
}
