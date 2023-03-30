namespace WebCommon;

public class WPDRankActiveSkillLevel : WPDPacketData
{
	public int skillId;

	public int level;

	public string effectDescriptionKey;

	public long nextLevelUpRequiredGold;

	public int nextLevelUpRequiredItemId;

	public int nextLevelUpRequiredItemCount;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(skillId);
		writer.Write(level);
		writer.Write(effectDescriptionKey);
		writer.Write(nextLevelUpRequiredGold);
		writer.Write(nextLevelUpRequiredItemId);
		writer.Write(nextLevelUpRequiredItemCount);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		skillId = reader.ReadInt32();
		level = reader.ReadInt32();
		effectDescriptionKey = reader.ReadString();
		nextLevelUpRequiredGold = reader.ReadInt64();
		nextLevelUpRequiredItemId = reader.ReadInt32();
		nextLevelUpRequiredItemCount = reader.ReadInt32();
	}
}
