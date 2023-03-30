namespace WebCommon;

public class WPDVipLevel : WPDPacketData
{
	public int vipLevel;

	public string descriptionKey;

	public int requiredAccVipPoint;

	public int mainGearEnchantMaxCount;

	public int mainGearRefinementMaxCount;

	public int mountGearRefinementMaxCount;

	public int expPotionUseMaxCount;

	public int staminaBuyMaxCount;

	public int expDungeonEnterCount;

	public int goldDungeonEnterCount;

	public int osirisRoomEnterCount;

	public int expScrollUseMaxCount;

	public int dailyMaxExploitPoint;

	public int artifactRoomInitMaxCount;

	public int ancientRelicEnterCount;

	public int fieldOfHonorEnterCount;

	public int distortionScrollUseMaxCount;

	public int guildDonationMaxCount;

	public int nationDonationmaxCount;

	public int soulCoveterWeeklyEnterCount;

	public bool creatureCardCompositionEnabled;

	public int creatureCardShopPaidRefreshMaxCount;

	public int proofOfValorEnterCount;

	public int trueHeroQuestStepNo;

	public int fearAltarEnterCount;

	public float expDungeonAdditionalExpRewardFactor;

	public int luckyShopPickMaxCount;

	public int creatureVariationMaxCount;

	public int tradeShipEnterCount;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(vipLevel);
		writer.Write(descriptionKey);
		writer.Write(requiredAccVipPoint);
		writer.Write(mainGearEnchantMaxCount);
		writer.Write(mainGearRefinementMaxCount);
		writer.Write(mountGearRefinementMaxCount);
		writer.Write(expPotionUseMaxCount);
		writer.Write(staminaBuyMaxCount);
		writer.Write(expDungeonEnterCount);
		writer.Write(goldDungeonEnterCount);
		writer.Write(osirisRoomEnterCount);
		writer.Write(expScrollUseMaxCount);
		writer.Write(dailyMaxExploitPoint);
		writer.Write(artifactRoomInitMaxCount);
		writer.Write(ancientRelicEnterCount);
		writer.Write(fieldOfHonorEnterCount);
		writer.Write(distortionScrollUseMaxCount);
		writer.Write(guildDonationMaxCount);
		writer.Write(nationDonationmaxCount);
		writer.Write(soulCoveterWeeklyEnterCount);
		writer.Write(creatureCardCompositionEnabled);
		writer.Write(creatureCardShopPaidRefreshMaxCount);
		writer.Write(proofOfValorEnterCount);
		writer.Write(trueHeroQuestStepNo);
		writer.Write(fearAltarEnterCount);
		writer.Write(expDungeonAdditionalExpRewardFactor);
		writer.Write(luckyShopPickMaxCount);
		writer.Write(creatureVariationMaxCount);
		writer.Write(tradeShipEnterCount);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		vipLevel = reader.ReadInt32();
		descriptionKey = reader.ReadString();
		requiredAccVipPoint = reader.ReadInt32();
		mainGearEnchantMaxCount = reader.ReadInt32();
		mainGearRefinementMaxCount = reader.ReadInt32();
		mountGearRefinementMaxCount = reader.ReadInt32();
		expPotionUseMaxCount = reader.ReadInt32();
		staminaBuyMaxCount = reader.ReadInt32();
		expDungeonEnterCount = reader.ReadInt32();
		goldDungeonEnterCount = reader.ReadInt32();
		osirisRoomEnterCount = reader.ReadInt32();
		expScrollUseMaxCount = reader.ReadInt32();
		dailyMaxExploitPoint = reader.ReadInt32();
		artifactRoomInitMaxCount = reader.ReadInt32();
		ancientRelicEnterCount = reader.ReadInt32();
		fieldOfHonorEnterCount = reader.ReadInt32();
		distortionScrollUseMaxCount = reader.ReadInt32();
		guildDonationMaxCount = reader.ReadInt32();
		nationDonationmaxCount = reader.ReadInt32();
		soulCoveterWeeklyEnterCount = reader.ReadInt32();
		creatureCardCompositionEnabled = reader.ReadBoolean();
		creatureCardShopPaidRefreshMaxCount = reader.ReadInt32();
		proofOfValorEnterCount = reader.ReadInt32();
		trueHeroQuestStepNo = reader.ReadInt32();
		fearAltarEnterCount = reader.ReadInt32();
		expDungeonAdditionalExpRewardFactor = reader.ReadSingle();
		luckyShopPickMaxCount = reader.ReadInt32();
		creatureVariationMaxCount = reader.ReadInt32();
		tradeShipEnterCount = reader.ReadInt32();
	}
}
