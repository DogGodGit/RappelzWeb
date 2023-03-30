namespace WebCommon;

public class WPDFearAltarHalidomElemental : WPDPacketData
{
	public int halidomElementalId;

	public string nameKey;

	public long collectionItemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(halidomElementalId);
		writer.Write(nameKey);
		writer.Write(collectionItemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		halidomElementalId = reader.ReadInt32();
		nameKey = reader.ReadString();
		collectionItemRewardId = reader.ReadInt64();
	}
}
