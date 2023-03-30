namespace WebCommon;

public class WPDGuildSkillAttr : WPDPacketData
{
	public int guildSkillId;

	public int attrId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(guildSkillId);
		writer.Write(attrId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		guildSkillId = reader.ReadInt32();
		attrId = reader.ReadInt32();
	}
}
