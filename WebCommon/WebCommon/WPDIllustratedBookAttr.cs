namespace WebCommon;

public class WPDIllustratedBookAttr : WPDPacketData
{
	public int illustratedBookId;

	public int attrId;

	public long attrValueId;

	public int grade;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(illustratedBookId);
		writer.Write(attrId);
		writer.Write(attrValueId);
		writer.Write(grade);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		illustratedBookId = reader.ReadInt32();
		attrId = reader.ReadInt32();
		attrValueId = reader.ReadInt64();
		grade = reader.ReadInt32();
	}
}
