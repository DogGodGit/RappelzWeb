namespace WebCommon;

public class WPDMoneyBuffAttr : WPDPacketData
{
	public int buffId;

	public int attrId;

	public float attrFactor;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(buffId);
		writer.Write(attrId);
		writer.Write(attrFactor);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		buffId = reader.ReadInt32();
		attrId = reader.ReadInt32();
		attrFactor = reader.ReadSingle();
	}
}
