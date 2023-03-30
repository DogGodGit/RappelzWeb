namespace WebCommon;

public class WPDCreatureSkillGrade : WPDPacketData
{
	public int skillGrade;

	public string colorCode;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(skillGrade);
		writer.Write(colorCode);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		skillGrade = reader.ReadInt32();
		colorCode = reader.ReadString();
	}
}
