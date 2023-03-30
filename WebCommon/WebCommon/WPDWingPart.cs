namespace WebCommon;

public class WPDWingPart : WPDPacketData
{
	public int partId;

	public int attrId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(partId);
		writer.Write(attrId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		partId = reader.ReadInt32();
		attrId = reader.ReadInt32();
	}
}
