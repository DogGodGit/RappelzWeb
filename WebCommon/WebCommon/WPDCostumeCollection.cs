namespace WebCommon;

public class WPDCostumeCollection : WPDPacketData
{
	public int costumeCollectionId;

	public string nameKey;

	public string descriptionKey;

	public int activationItemCount;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(costumeCollectionId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(activationItemCount);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		costumeCollectionId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		activationItemCount = reader.ReadInt32();
	}
}
