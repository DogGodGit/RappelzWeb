namespace WebCommon;

public class WPDGuildAltar : WPDPacketData
{
	public int guildTerritoryNpcId;

	public int dailyHeroMaxMoralPoint;

	public int dailyGuildMaxMoralPoint;

	public int donationGold;

	public int donationRewardMoralPoint;

	public int spellInjectionDuration;

	public int spellInjectionRewardMoralPoint;

	public long defenseMonsterArrangeId;

	public int defenseRewardMoralPoint;

	public int defenseCooltime;

	public int defenseLimitTime;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(guildTerritoryNpcId);
		writer.Write(dailyHeroMaxMoralPoint);
		writer.Write(dailyGuildMaxMoralPoint);
		writer.Write(donationGold);
		writer.Write(donationRewardMoralPoint);
		writer.Write(spellInjectionDuration);
		writer.Write(spellInjectionRewardMoralPoint);
		writer.Write(defenseMonsterArrangeId);
		writer.Write(defenseRewardMoralPoint);
		writer.Write(defenseCooltime);
		writer.Write(defenseLimitTime);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		guildTerritoryNpcId = reader.ReadInt32();
		dailyHeroMaxMoralPoint = reader.ReadInt32();
		dailyGuildMaxMoralPoint = reader.ReadInt32();
		donationGold = reader.ReadInt32();
		donationRewardMoralPoint = reader.ReadInt32();
		spellInjectionDuration = reader.ReadInt32();
		spellInjectionRewardMoralPoint = reader.ReadInt32();
		defenseMonsterArrangeId = reader.ReadInt64();
		defenseRewardMoralPoint = reader.ReadInt32();
		defenseCooltime = reader.ReadInt32();
		defenseLimitTime = reader.ReadInt32();
	}
}
