namespace WebCommon;

public class WPDJobSkillLevelMaster : WPDPacketData
{
	public int skillId;

	public int level;

	public int nextLevelUpRequiredHeroLevel;

	public long nextLevelUpGold;

	public int nextLevelUpItemId;

	public int nextLevelUpItemCount;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(skillId);
		writer.Write(level);
		writer.Write(nextLevelUpRequiredHeroLevel);
		writer.Write(nextLevelUpGold);
		writer.Write(nextLevelUpItemId);
		writer.Write(nextLevelUpItemCount);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		skillId = reader.ReadInt32();
		level = reader.ReadInt32();
		nextLevelUpRequiredHeroLevel = reader.ReadInt32();
		nextLevelUpGold = reader.ReadInt64();
		nextLevelUpItemId = reader.ReadInt32();
		nextLevelUpItemCount = reader.ReadInt32();
	}
}
