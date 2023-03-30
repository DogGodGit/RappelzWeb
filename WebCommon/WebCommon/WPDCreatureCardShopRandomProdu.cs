namespace WebCommon;

public class WPDCreatureCardShopRandomProduct : WPDPacketData
{
	public int productId;

	public int creatureCardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(productId);
		writer.Write(creatureCardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		productId = reader.ReadInt32();
		creatureCardId = reader.ReadInt32();
	}
}
