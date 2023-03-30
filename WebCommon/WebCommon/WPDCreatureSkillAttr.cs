namespace WebCommon;

public class WPDCreatureSkillAttr : WPDPacketData
{
	public int skillId;

	public int skillGrade;

	public long attrValueId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(skillId);
		writer.Write(skillGrade);
		writer.Write(attrValueId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		skillId = reader.ReadInt32();
		skillGrade = reader.ReadInt32();
		attrValueId = reader.ReadInt64();
	}
}
