namespace WebCommon;

public class WPDRankPassiveSkillLevel : WPDPacketData
{
	public int skillId;

	public int level;

	public string effectDescriptionKey;

	public long nextLevelUpRequiredGold;

	public int nextLevelUpRequiredSpiritStone;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(skillId);
		writer.Write(level);
		writer.Write(effectDescriptionKey);
		writer.Write(nextLevelUpRequiredGold);
		writer.Write(nextLevelUpRequiredSpiritStone);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		skillId = reader.ReadInt32();
		level = reader.ReadInt32();
		effectDescriptionKey = reader.ReadString();
		nextLevelUpRequiredGold = reader.ReadInt64();
		nextLevelUpRequiredSpiritStone = reader.ReadInt32();
	}
}
