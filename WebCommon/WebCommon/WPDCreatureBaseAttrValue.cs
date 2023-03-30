namespace WebCommon;

public class WPDCreatureBaseAttrValue : WPDPacketData
{
	public int creatureId;

	public int attrId;

	public int minAttrValue;

	public int maxAttrValue;

	public int incAttrValue;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(creatureId);
		writer.Write(attrId);
		writer.Write(minAttrValue);
		writer.Write(maxAttrValue);
		writer.Write(incAttrValue);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		creatureId = reader.ReadInt32();
		attrId = reader.ReadInt32();
		minAttrValue = reader.ReadInt32();
		maxAttrValue = reader.ReadInt32();
		incAttrValue = reader.ReadInt32();
	}
}
