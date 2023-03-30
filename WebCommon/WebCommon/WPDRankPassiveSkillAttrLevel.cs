namespace WebCommon;

public class WPDRankPassiveSkillAttrLevel : WPDPacketData
{
	public int skillId;

	public int attrId;

	public int level;

	public long attrValueId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(skillId);
		writer.Write(attrId);
		writer.Write(level);
		writer.Write(attrValueId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		skillId = reader.ReadInt32();
		attrId = reader.ReadInt32();
		level = reader.ReadInt32();
		attrValueId = reader.ReadInt64();
	}
}
