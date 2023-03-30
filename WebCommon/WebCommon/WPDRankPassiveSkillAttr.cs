namespace WebCommon;

public class WPDRankPassiveSkillAttr : WPDPacketData
{
	public int skillId;

	public int attrId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(skillId);
		writer.Write(attrId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		skillId = reader.ReadInt32();
		attrId = reader.ReadInt32();
	}
}
