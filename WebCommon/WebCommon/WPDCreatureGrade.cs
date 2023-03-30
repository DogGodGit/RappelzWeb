namespace WebCommon;

public class WPDCreatureGrade : WPDPacketData
{
	public int grade;

	public string nameKey;

	public string colorCode;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(grade);
		writer.Write(nameKey);
		writer.Write(colorCode);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		grade = reader.ReadInt32();
		nameKey = reader.ReadString();
		colorCode = reader.ReadString();
	}
}
