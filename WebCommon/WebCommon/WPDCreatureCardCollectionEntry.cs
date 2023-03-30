namespace WebCommon;

public class WPDCreatureCardCollectionEntry : WPDPacketData
{
	public int collectionId;

	public int creatureCardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(collectionId);
		writer.Write(creatureCardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		collectionId = reader.ReadInt32();
		creatureCardId = reader.ReadInt32();
	}
}
