namespace WebCommon;

public class WPDMainGearOptionAttrGrade : WPDPacketData
{
	public int attrGrade;

	public string colorCode;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(attrGrade);
		writer.Write(colorCode);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		attrGrade = reader.ReadInt32();
		colorCode = reader.ReadString();
	}
}
