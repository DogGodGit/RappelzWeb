namespace WebCommon;

public class WPDCostumeAttr : WPDPacketData
{
	public int costumeId;

	public int attrId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(costumeId);
		writer.Write(attrId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		costumeId = reader.ReadInt32();
		attrId = reader.ReadInt32();
	}
}
