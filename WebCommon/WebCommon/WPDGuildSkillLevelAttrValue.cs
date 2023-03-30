namespace WebCommon;

public class WPDGuildSkillLevelAttrValue : WPDPacketData
{
	public int guildSkillId;

	public int level;

	public int attrId;

	public long attrValueId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(guildSkillId);
		writer.Write(level);
		writer.Write(attrId);
		writer.Write(attrValueId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		guildSkillId = reader.ReadInt32();
		level = reader.ReadInt32();
		attrId = reader.ReadInt32();
		attrValueId = reader.ReadInt64();
	}
}
