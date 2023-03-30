namespace WebCommon;

public class WPDGuildSkillLevel : WPDPacketData
{
	public int guildSkillId;

	public int level;

	public int requiredGuildContributionPoint;

	public int requiredLaboratoryLevel;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(guildSkillId);
		writer.Write(level);
		writer.Write(requiredGuildContributionPoint);
		writer.Write(requiredLaboratoryLevel);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		guildSkillId = reader.ReadInt32();
		level = reader.ReadInt32();
		requiredGuildContributionPoint = reader.ReadInt32();
		requiredLaboratoryLevel = reader.ReadInt32();
	}
}
