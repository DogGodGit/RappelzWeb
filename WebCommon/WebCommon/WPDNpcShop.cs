namespace WebCommon;

public class WPDNpcShop : WPDPacketData
{
	public int shopId;

	public string nameKey;

	public int npcId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(shopId);
		writer.Write(nameKey);
		writer.Write(npcId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		shopId = reader.ReadInt32();
		nameKey = reader.ReadString();
		npcId = reader.ReadInt32();
	}
}
