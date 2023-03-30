namespace WebCommon;

public class WPDGuildSkill : WPDPacketData
{
	public int guildSkillId;

	public string nameKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(guildSkillId);
		writer.Write(nameKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		guildSkillId = reader.ReadInt32();
		nameKey = reader.ReadString();
	}
}
