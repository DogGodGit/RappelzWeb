namespace WebCommon;

public class WPDCostumeCollectionAttr : WPDPacketData
{
	public int costumeCollectionId;

	public int attrId;

	public long attrValueId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(costumeCollectionId);
		writer.Write(attrId);
		writer.Write(attrValueId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		costumeCollectionId = reader.ReadInt32();
		attrId = reader.ReadInt32();
		attrValueId = reader.ReadInt64();
	}
}
