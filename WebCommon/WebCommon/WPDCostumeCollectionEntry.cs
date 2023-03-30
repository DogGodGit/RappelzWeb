namespace WebCommon;

public class WPDCostumeCollectionEntry : WPDPacketData
{
	public int costumeCollectionId;

	public int costumeId;

	public int sortNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(costumeCollectionId);
		writer.Write(costumeId);
		writer.Write(sortNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		costumeCollectionId = reader.ReadInt32();
		costumeId = reader.ReadInt32();
		sortNo = reader.ReadInt32();
	}
}
