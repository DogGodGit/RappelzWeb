namespace WebCommon;

public class WPDIllustratedBookAttrGrade : WPDPacketData
{
	public int grade;

	public string colorCode;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(grade);
		writer.Write(colorCode);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		grade = reader.ReadInt32();
		colorCode = reader.ReadString();
	}
}
