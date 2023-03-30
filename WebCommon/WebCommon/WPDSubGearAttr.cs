namespace WebCommon;

public class WPDSubGearAttr : WPDPacketData
{
	public int subGearId;

	public int attrId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(subGearId);
		writer.Write(attrId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		subGearId = reader.ReadInt32();
		attrId = reader.ReadInt32();
	}
}
