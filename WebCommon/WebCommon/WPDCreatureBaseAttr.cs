namespace WebCommon;

public class WPDCreatureBaseAttr : WPDPacketData
{
	public int attrId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(attrId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		attrId = reader.ReadInt32();
	}
}
