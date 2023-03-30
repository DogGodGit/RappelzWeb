namespace WebCommon;

public class WPDMainGearGrade : WPDPacketData
{
	public int grade;

	public string colorCode;

	public string nameKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(grade);
		writer.Write(colorCode);
		writer.Write(nameKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		grade = reader.ReadInt32();
		colorCode = reader.ReadString();
		nameKey = reader.ReadString();
	}
}
