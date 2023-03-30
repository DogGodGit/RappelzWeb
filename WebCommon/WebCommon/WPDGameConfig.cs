namespace WebCommon;

public class WPDGameConfig : WPDPacketData
{
	public int maxHeroCount;

	public int startContinentId;

	public float startXPosition;

	public float startYPosition;

	public float startZPosition;

	public float startRadius;

	public int startYRotationType;

	public float startYRotation;

	public int mailRetentionDay;

	public int mainGearOptionAttrMinCount;

	public int mainGearOptionAttrMaxCount;

	public int mainGearRefinementItemId;

	public int specialSkillId;

	public int specialSkillMaxLak;

	public int freeImmediateRevivalDailyCount;

	public int autoSaftyRevivalWatingTime;

	public float startContinentSaftyRevivalXPosition;

	public float startContinentSaftyRevivalYPosition;

	public float startContinentSaftyRevivalZPosition;

	public float startContinentSaftyRevivalRadius;

	public int startContinentSaftyRevivalYRotationType;

	public float startContinentSaftyRevivalYRotation;

	public int saftyRevivalContinentId;

	public float saftyRevivalXPosition;

	public float saftyRevivalYPosition;

	public float saftyRevivalZPosition;

	public float saftyRevivalRadius;

	public int saftyRevivalYRotationType;

	public float saftyRevivalYRotation;

	public int simpleShopSellSlotCount;

	public int mainGearDisassembleSlotCount;

	public int restRewardRequiredHeroLevel;

	public int restRewardGoldReceiveExpRate;

	public int restRewardDiaReceiveExpRate;

	public int partyMemberMaxCount;

	public int partyMemberLogOutDuration;

	public int partyInvitationLifetime;

	public int partyApplicationLifetime;

	public int partyCallCoolTime;

	public int chattingMaxLength;

	public int chattingMinInterval;

	public int worldChattingDisplayDuration;

	public int worldChattingItemId;

	public int chattingSendHistoryMaxCount;

	public int chattingBubbleDisplayDuration;

	public int chattingDisplayMaxCount;

	public long weekendAttendItemRewardId;

	public int mountLevelUpItemId;

	public int mountQualityUpRequiredLevelUpCount;

	public float equippedMountAttrFactor;

	public int mountGearOptionAttrCount;

	public int mountGearRefinementItemId;

	public int dungeonFreeSweepDailyCount;

	public int dungeonSweepItemId;

	public int wingEnchantItemId;

	public int wingEnchantExp;

	public int maxStamina;

	public int staminaRecoveryTime;

	public int defaultToastDisplayDuration;

	public int defaultToastDisplayCount;

	public int itemToastDisplayDuration;

	public int battlePowerToastDisplayDuration;

	public int contentOpenToastDisplayDuration;

	public int locationAreaToastDisplayDuration;

	public int guideToastDisplayDuration;

	public int wingVisibleMinVipLevel;

	public int hpPotionAutoUseHpRate;

	public float standingBattleRange;

	public float shortDistanceBattleRange;

	public int optimizationModeWaitingTime;

	public int deadWarningDisplayHpRate;

	public int pvpMinHeroLevel;

	public int cartNormalSpeed;

	public int cartHighSpeed;

	public int cartHighSpeedDuration;

	public int cartHighSpeedDurationExtension;

	public int cartAccelCoolTime;

	public int worldLevelExpBuffMinHeroLevel;

	public int nationTransmissionRequiredHeroLevel;

	public float nationTransmissionExitXPosition;

	public float nationTransmissionExitYPosition;

	public float nationTransmissionExitZPosition;

	public float nationTransmissionExitRadius;

	public float nationTransmissionExitYRotationType;

	public float nationTransmissionExitYRotation;

	public int bountyHunterQuestMaxCount;

	public int bountyHunterQuestRequiredHeroLevel;

	public int todayMissionCount;

	public int fieldOfHonorDisplayMaxRanking;

	public int fieldOfHonorDisplayHistoryCount;

	public int rankingDisplayMaxCount;

	public int guildRequiredHeroLevel;

	public int guildCreationRequiredVipLevel;

	public int guildCreationRequiredDia;

	public int guildRejoinIntervalTime;

	public int guildApplicationReceptionMaxCount;

	public int guildDailyApplicationMaxCount;

	public int guildDailyBanishmentMaxCount;

	public int guildInvitationLifetime;

	public int guildNoticeMaxLength;

	public int guildViceMasterCount;

	public int guildLordCount;

	public int guildRankingDisplayMaxCount;

	public int rankOpenRequiredMainQuestNo;

	public int wingOpenRequiredHeroLevel;

	public int wingOpenProvideWingId;

	public int guildCallLifetime;

	public float guildCallRadius;

	public int nationCallLifetime;

	public float nationCallRadius;

	public string guildDailyObjectiveNoticeTextKey;

	public int guildDailyObjectiveNoticeCoolTime;

	public int defaultGuildWeeklyObjectiveId;

	public int guildHuntingDonationMaxCount;

	public int guildHuntingDonationItemId;

	public long guildHuntingDonationItemRewardId;

	public long guildHuntingDonationCompletionItemRewardId;

	public int signBoardDisplayDuration;

	public int noticeBoardDisplayDuration;

	public int creatureCardShopRandomProductCount;

	public int creatureCardShopPaidRefreshDia;

	public int guideActivationRequiredHeroLevel;

	public int accelerationRequiredMoveDuration;

	public int accelerationMoveSpeed;

	public int sceneryQuestRequiredMainQuestNo;

	public int menuContentOpenPreviewRequiredHeroLevel;

	public int monsterGroggyDuration;

	public int monsterStealDuration;

	public int rookieGiftScratchOpenDuration;

	public int openGiftRequiredHeroLevel;

	public int open7DayEventRequiredMainQuestNo;

	public int taskConsignmentRequiredVipLevel;

	public int warehouseRequiredVipLevel;

	public int freeWarehouseSlotCount;

	public int wingMemoryPieceInstallationRequiredHeroLevel;

	public int ordealQuestSlotCount;

	public int friendMaxCount;

	public int tempFriendMaxCount;

	public int deadRecordMaxCount;

	public int blacklistEntryMaxCount;

	public int blessingQuestListMaxCount;

	public int blessingQuestRequiredHeroLevel;

	public int blessingListMaxCount;

	public int ownerProspectQuestListMaxCount;

	public int targetProspectQuestListMaxCount;

	public int creatureMaxCount;

	public int creatureCheerMaxCount;

	public float creatureCheerAttrFactor;

	public float creatureEvaluationFactor;

	public int creatureAdditionalAttrCount;

	public int creatureSkillSlotMaxCount;

	public int creatureSkillSlotBaseOpenCount;

	public int creatureCompositionExpRetrievalRate;

	public int creatureCompositionExpRetrievalResultItemId;

	public int creatureCompositionSkillProtectionItemId;

	public int creatureInjectionExpRetrievalRate;

	public int creatureVariationRequiredItemId;

	public int creatureAdditionalAttrSwitchRequiredItemId;

	public int creatureReleaseExpRetrievalRate;

	public int participationCreatureDisplayRequiredVipLevel;

	public int presentPopularityPointRankingDisplayMaxCount;

	public int presentContributionPointRankingDisplayMaxCount;

	public int guildBlessingGuildTerritoryNpcId;

	public int nationAllianceUnavailableStartTime;

	public int nationAllianceUnavailableEndTime;

	public long nationAllianceRequiredFund;

	public int nationAllianceRenounceUnavailableDuration;

	public int nationBasePower;

	public long open7DayEventCostumeItemRewardId;

	public int open7DayEventCostumeRewardRequiredItemId;

	public int open7DayEventCostumeRewardRequiredItemCount;

	public int jobChangeRequiredHeroLevel;

	public int jobChangeRequiredItemId;

	public int jobChangeQuestCompletionClientTutorialId;

	public int chargeEventRequiredHeroLevel;

	public int consumeEventRequiredHeroLevel;

	public int artifactRequiredConditionType;

	public int artifactRequiredConditionValue;

	public int artifactMaxLevel;

	public int mountAwakeningRequiredHeroLevel;

	public int mountAwakeningItemId;

	public int mountPotionAttrItemId;

	public int costumeEnchantItemId;

	public int costumeCollectionActivationItemId;

	public int costumeCollectionShuffleItemId;

	public int costumeCollectionShuffleItemCount;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(maxHeroCount);
		writer.Write(startContinentId);
		writer.Write(startXPosition);
		writer.Write(startYPosition);
		writer.Write(startZPosition);
		writer.Write(startRadius);
		writer.Write(startYRotationType);
		writer.Write(startYRotation);
		writer.Write(mailRetentionDay);
		writer.Write(mainGearOptionAttrMinCount);
		writer.Write(mainGearOptionAttrMaxCount);
		writer.Write(mainGearRefinementItemId);
		writer.Write(specialSkillId);
		writer.Write(specialSkillMaxLak);
		writer.Write(freeImmediateRevivalDailyCount);
		writer.Write(autoSaftyRevivalWatingTime);
		writer.Write(startContinentSaftyRevivalXPosition);
		writer.Write(startContinentSaftyRevivalYPosition);
		writer.Write(startContinentSaftyRevivalZPosition);
		writer.Write(startContinentSaftyRevivalRadius);
		writer.Write(startContinentSaftyRevivalYRotationType);
		writer.Write(startContinentSaftyRevivalYRotation);
		writer.Write(saftyRevivalContinentId);
		writer.Write(saftyRevivalXPosition);
		writer.Write(saftyRevivalYPosition);
		writer.Write(saftyRevivalZPosition);
		writer.Write(saftyRevivalRadius);
		writer.Write(saftyRevivalYRotationType);
		writer.Write(saftyRevivalYRotation);
		writer.Write(simpleShopSellSlotCount);
		writer.Write(mainGearDisassembleSlotCount);
		writer.Write(restRewardRequiredHeroLevel);
		writer.Write(restRewardGoldReceiveExpRate);
		writer.Write(restRewardDiaReceiveExpRate);
		writer.Write(partyMemberMaxCount);
		writer.Write(partyMemberLogOutDuration);
		writer.Write(partyInvitationLifetime);
		writer.Write(partyApplicationLifetime);
		writer.Write(partyCallCoolTime);
		writer.Write(chattingMaxLength);
		writer.Write(chattingMinInterval);
		writer.Write(worldChattingDisplayDuration);
		writer.Write(worldChattingItemId);
		writer.Write(chattingSendHistoryMaxCount);
		writer.Write(chattingBubbleDisplayDuration);
		writer.Write(chattingDisplayMaxCount);
		writer.Write(weekendAttendItemRewardId);
		writer.Write(mountLevelUpItemId);
		writer.Write(mountQualityUpRequiredLevelUpCount);
		writer.Write(equippedMountAttrFactor);
		writer.Write(mountGearOptionAttrCount);
		writer.Write(mountGearRefinementItemId);
		writer.Write(dungeonFreeSweepDailyCount);
		writer.Write(dungeonSweepItemId);
		writer.Write(wingEnchantItemId);
		writer.Write(wingEnchantExp);
		writer.Write(maxStamina);
		writer.Write(staminaRecoveryTime);
		writer.Write(defaultToastDisplayDuration);
		writer.Write(defaultToastDisplayCount);
		writer.Write(itemToastDisplayDuration);
		writer.Write(battlePowerToastDisplayDuration);
		writer.Write(contentOpenToastDisplayDuration);
		writer.Write(locationAreaToastDisplayDuration);
		writer.Write(guideToastDisplayDuration);
		writer.Write(wingVisibleMinVipLevel);
		writer.Write(hpPotionAutoUseHpRate);
		writer.Write(standingBattleRange);
		writer.Write(shortDistanceBattleRange);
		writer.Write(optimizationModeWaitingTime);
		writer.Write(deadWarningDisplayHpRate);
		writer.Write(pvpMinHeroLevel);
		writer.Write(cartNormalSpeed);
		writer.Write(cartHighSpeed);
		writer.Write(cartHighSpeedDuration);
		writer.Write(cartHighSpeedDurationExtension);
		writer.Write(cartAccelCoolTime);
		writer.Write(worldLevelExpBuffMinHeroLevel);
		writer.Write(nationTransmissionRequiredHeroLevel);
		writer.Write(nationTransmissionExitXPosition);
		writer.Write(nationTransmissionExitYPosition);
		writer.Write(nationTransmissionExitZPosition);
		writer.Write(nationTransmissionExitRadius);
		writer.Write(nationTransmissionExitYRotationType);
		writer.Write(nationTransmissionExitYRotation);
		writer.Write(bountyHunterQuestMaxCount);
		writer.Write(bountyHunterQuestRequiredHeroLevel);
		writer.Write(todayMissionCount);
		writer.Write(fieldOfHonorDisplayMaxRanking);
		writer.Write(fieldOfHonorDisplayHistoryCount);
		writer.Write(rankingDisplayMaxCount);
		writer.Write(guildRequiredHeroLevel);
		writer.Write(guildCreationRequiredVipLevel);
		writer.Write(guildCreationRequiredDia);
		writer.Write(guildRejoinIntervalTime);
		writer.Write(guildApplicationReceptionMaxCount);
		writer.Write(guildDailyApplicationMaxCount);
		writer.Write(guildDailyBanishmentMaxCount);
		writer.Write(guildInvitationLifetime);
		writer.Write(guildNoticeMaxLength);
		writer.Write(guildViceMasterCount);
		writer.Write(guildLordCount);
		writer.Write(guildRankingDisplayMaxCount);
		writer.Write(rankOpenRequiredMainQuestNo);
		writer.Write(wingOpenRequiredHeroLevel);
		writer.Write(wingOpenProvideWingId);
		writer.Write(guildCallLifetime);
		writer.Write(guildCallRadius);
		writer.Write(nationCallLifetime);
		writer.Write(nationCallRadius);
		writer.Write(guildDailyObjectiveNoticeTextKey);
		writer.Write(guildDailyObjectiveNoticeCoolTime);
		writer.Write(defaultGuildWeeklyObjectiveId);
		writer.Write(guildHuntingDonationMaxCount);
		writer.Write(guildHuntingDonationItemId);
		writer.Write(guildHuntingDonationItemRewardId);
		writer.Write(guildHuntingDonationCompletionItemRewardId);
		writer.Write(signBoardDisplayDuration);
		writer.Write(noticeBoardDisplayDuration);
		writer.Write(creatureCardShopRandomProductCount);
		writer.Write(creatureCardShopPaidRefreshDia);
		writer.Write(guideActivationRequiredHeroLevel);
		writer.Write(accelerationRequiredMoveDuration);
		writer.Write(accelerationMoveSpeed);
		writer.Write(sceneryQuestRequiredMainQuestNo);
		writer.Write(menuContentOpenPreviewRequiredHeroLevel);
		writer.Write(monsterGroggyDuration);
		writer.Write(monsterStealDuration);
		writer.Write(rookieGiftScratchOpenDuration);
		writer.Write(openGiftRequiredHeroLevel);
		writer.Write(open7DayEventRequiredMainQuestNo);
		writer.Write(taskConsignmentRequiredVipLevel);
		writer.Write(warehouseRequiredVipLevel);
		writer.Write(freeWarehouseSlotCount);
		writer.Write(wingMemoryPieceInstallationRequiredHeroLevel);
		writer.Write(ordealQuestSlotCount);
		writer.Write(friendMaxCount);
		writer.Write(tempFriendMaxCount);
		writer.Write(deadRecordMaxCount);
		writer.Write(blacklistEntryMaxCount);
		writer.Write(blessingQuestListMaxCount);
		writer.Write(blessingQuestRequiredHeroLevel);
		writer.Write(blessingListMaxCount);
		writer.Write(ownerProspectQuestListMaxCount);
		writer.Write(targetProspectQuestListMaxCount);
		writer.Write(creatureMaxCount);
		writer.Write(creatureCheerMaxCount);
		writer.Write(creatureCheerAttrFactor);
		writer.Write(creatureEvaluationFactor);
		writer.Write(creatureAdditionalAttrCount);
		writer.Write(creatureSkillSlotMaxCount);
		writer.Write(creatureSkillSlotBaseOpenCount);
		writer.Write(creatureCompositionExpRetrievalRate);
		writer.Write(creatureCompositionExpRetrievalResultItemId);
		writer.Write(creatureCompositionSkillProtectionItemId);
		writer.Write(creatureInjectionExpRetrievalRate);
		writer.Write(creatureVariationRequiredItemId);
		writer.Write(creatureAdditionalAttrSwitchRequiredItemId);
		writer.Write(creatureReleaseExpRetrievalRate);
		writer.Write(participationCreatureDisplayRequiredVipLevel);
		writer.Write(presentPopularityPointRankingDisplayMaxCount);
		writer.Write(presentContributionPointRankingDisplayMaxCount);
		writer.Write(guildBlessingGuildTerritoryNpcId);
		writer.Write(nationAllianceUnavailableStartTime);
		writer.Write(nationAllianceUnavailableEndTime);
		writer.Write(nationAllianceRequiredFund);
		writer.Write(nationAllianceRenounceUnavailableDuration);
		writer.Write(nationBasePower);
		writer.Write(open7DayEventCostumeItemRewardId);
		writer.Write(open7DayEventCostumeRewardRequiredItemId);
		writer.Write(open7DayEventCostumeRewardRequiredItemCount);
		writer.Write(jobChangeRequiredHeroLevel);
		writer.Write(jobChangeRequiredItemId);
		writer.Write(jobChangeQuestCompletionClientTutorialId);
		writer.Write(chargeEventRequiredHeroLevel);
		writer.Write(consumeEventRequiredHeroLevel);
		writer.Write(artifactRequiredConditionType);
		writer.Write(artifactRequiredConditionValue);
		writer.Write(artifactMaxLevel);
		writer.Write(mountAwakeningRequiredHeroLevel);
		writer.Write(mountAwakeningItemId);
		writer.Write(mountPotionAttrItemId);
		writer.Write(costumeEnchantItemId);
		writer.Write(costumeCollectionActivationItemId);
		writer.Write(costumeCollectionShuffleItemId);
		writer.Write(costumeCollectionShuffleItemCount);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		maxHeroCount = reader.ReadInt32();
		startContinentId = reader.ReadInt32();
		startXPosition = reader.ReadSingle();
		startYPosition = reader.ReadSingle();
		startZPosition = reader.ReadSingle();
		startRadius = reader.ReadSingle();
		startYRotationType = reader.ReadInt32();
		startYRotation = reader.ReadSingle();
		mailRetentionDay = reader.ReadInt32();
		mainGearOptionAttrMinCount = reader.ReadInt32();
		mainGearOptionAttrMaxCount = reader.ReadInt32();
		mainGearRefinementItemId = reader.ReadInt32();
		specialSkillId = reader.ReadInt32();
		specialSkillMaxLak = reader.ReadInt32();
		freeImmediateRevivalDailyCount = reader.ReadInt32();
		autoSaftyRevivalWatingTime = reader.ReadInt32();
		startContinentSaftyRevivalXPosition = reader.ReadSingle();
		startContinentSaftyRevivalYPosition = reader.ReadSingle();
		startContinentSaftyRevivalZPosition = reader.ReadSingle();
		startContinentSaftyRevivalRadius = reader.ReadSingle();
		startContinentSaftyRevivalYRotationType = reader.ReadInt32();
		startContinentSaftyRevivalYRotation = reader.ReadSingle();
		saftyRevivalContinentId = reader.ReadInt32();
		saftyRevivalXPosition = reader.ReadSingle();
		saftyRevivalYPosition = reader.ReadSingle();
		saftyRevivalZPosition = reader.ReadSingle();
		saftyRevivalRadius = reader.ReadSingle();
		saftyRevivalYRotationType = reader.ReadInt32();
		saftyRevivalYRotation = reader.ReadSingle();
		simpleShopSellSlotCount = reader.ReadInt32();
		mainGearDisassembleSlotCount = reader.ReadInt32();
		restRewardRequiredHeroLevel = reader.ReadInt32();
		restRewardGoldReceiveExpRate = reader.ReadInt32();
		restRewardDiaReceiveExpRate = reader.ReadInt32();
		partyMemberMaxCount = reader.ReadInt32();
		partyMemberLogOutDuration = reader.ReadInt32();
		partyInvitationLifetime = reader.ReadInt32();
		partyApplicationLifetime = reader.ReadInt32();
		partyCallCoolTime = reader.ReadInt32();
		chattingMaxLength = reader.ReadInt32();
		chattingMinInterval = reader.ReadInt32();
		worldChattingDisplayDuration = reader.ReadInt32();
		worldChattingItemId = reader.ReadInt32();
		chattingSendHistoryMaxCount = reader.ReadInt32();
		chattingBubbleDisplayDuration = reader.ReadInt32();
		chattingDisplayMaxCount = reader.ReadInt32();
		weekendAttendItemRewardId = reader.ReadInt64();
		mountLevelUpItemId = reader.ReadInt32();
		mountQualityUpRequiredLevelUpCount = reader.ReadInt32();
		equippedMountAttrFactor = reader.ReadSingle();
		mountGearOptionAttrCount = reader.ReadInt32();
		mountGearRefinementItemId = reader.ReadInt32();
		dungeonFreeSweepDailyCount = reader.ReadInt32();
		dungeonSweepItemId = reader.ReadInt32();
		wingEnchantItemId = reader.ReadInt32();
		wingEnchantExp = reader.ReadInt32();
		maxStamina = reader.ReadInt32();
		staminaRecoveryTime = reader.ReadInt32();
		defaultToastDisplayDuration = reader.ReadInt32();
		defaultToastDisplayCount = reader.ReadInt32();
		itemToastDisplayDuration = reader.ReadInt32();
		battlePowerToastDisplayDuration = reader.ReadInt32();
		contentOpenToastDisplayDuration = reader.ReadInt32();
		locationAreaToastDisplayDuration = reader.ReadInt32();
		guideToastDisplayDuration = reader.ReadInt32();
		wingVisibleMinVipLevel = reader.ReadInt32();
		hpPotionAutoUseHpRate = reader.ReadInt32();
		standingBattleRange = reader.ReadSingle();
		shortDistanceBattleRange = reader.ReadSingle();
		optimizationModeWaitingTime = reader.ReadInt32();
		deadWarningDisplayHpRate = reader.ReadInt32();
		pvpMinHeroLevel = reader.ReadInt32();
		cartNormalSpeed = reader.ReadInt32();
		cartHighSpeed = reader.ReadInt32();
		cartHighSpeedDuration = reader.ReadInt32();
		cartHighSpeedDurationExtension = reader.ReadInt32();
		cartAccelCoolTime = reader.ReadInt32();
		worldLevelExpBuffMinHeroLevel = reader.ReadInt32();
		nationTransmissionRequiredHeroLevel = reader.ReadInt32();
		nationTransmissionExitXPosition = reader.ReadSingle();
		nationTransmissionExitYPosition = reader.ReadSingle();
		nationTransmissionExitZPosition = reader.ReadSingle();
		nationTransmissionExitRadius = reader.ReadSingle();
		nationTransmissionExitYRotationType = reader.ReadSingle();
		nationTransmissionExitYRotation = reader.ReadSingle();
		bountyHunterQuestMaxCount = reader.ReadInt32();
		bountyHunterQuestRequiredHeroLevel = reader.ReadInt32();
		todayMissionCount = reader.ReadInt32();
		fieldOfHonorDisplayMaxRanking = reader.ReadInt32();
		fieldOfHonorDisplayHistoryCount = reader.ReadInt32();
		rankingDisplayMaxCount = reader.ReadInt32();
		guildRequiredHeroLevel = reader.ReadInt32();
		guildCreationRequiredVipLevel = reader.ReadInt32();
		guildCreationRequiredDia = reader.ReadInt32();
		guildRejoinIntervalTime = reader.ReadInt32();
		guildApplicationReceptionMaxCount = reader.ReadInt32();
		guildDailyApplicationMaxCount = reader.ReadInt32();
		guildDailyBanishmentMaxCount = reader.ReadInt32();
		guildInvitationLifetime = reader.ReadInt32();
		guildNoticeMaxLength = reader.ReadInt32();
		guildViceMasterCount = reader.ReadInt32();
		guildLordCount = reader.ReadInt32();
		guildRankingDisplayMaxCount = reader.ReadInt32();
		rankOpenRequiredMainQuestNo = reader.ReadInt32();
		wingOpenRequiredHeroLevel = reader.ReadInt32();
		wingOpenProvideWingId = reader.ReadInt32();
		guildCallLifetime = reader.ReadInt32();
		guildCallRadius = reader.ReadSingle();
		nationCallLifetime = reader.ReadInt32();
		nationCallRadius = reader.ReadSingle();
		guildDailyObjectiveNoticeTextKey = reader.ReadString();
		guildDailyObjectiveNoticeCoolTime = reader.ReadInt32();
		defaultGuildWeeklyObjectiveId = reader.ReadInt32();
		guildHuntingDonationMaxCount = reader.ReadInt32();
		guildHuntingDonationItemId = reader.ReadInt32();
		guildHuntingDonationItemRewardId = reader.ReadInt64();
		guildHuntingDonationCompletionItemRewardId = reader.ReadInt64();
		signBoardDisplayDuration = reader.ReadInt32();
		noticeBoardDisplayDuration = reader.ReadInt32();
		creatureCardShopRandomProductCount = reader.ReadInt32();
		creatureCardShopPaidRefreshDia = reader.ReadInt32();
		guideActivationRequiredHeroLevel = reader.ReadInt32();
		accelerationRequiredMoveDuration = reader.ReadInt32();
		accelerationMoveSpeed = reader.ReadInt32();
		sceneryQuestRequiredMainQuestNo = reader.ReadInt32();
		menuContentOpenPreviewRequiredHeroLevel = reader.ReadInt32();
		monsterGroggyDuration = reader.ReadInt32();
		monsterStealDuration = reader.ReadInt32();
		rookieGiftScratchOpenDuration = reader.ReadInt32();
		openGiftRequiredHeroLevel = reader.ReadInt32();
		open7DayEventRequiredMainQuestNo = reader.ReadInt32();
		taskConsignmentRequiredVipLevel = reader.ReadInt32();
		warehouseRequiredVipLevel = reader.ReadInt32();
		freeWarehouseSlotCount = reader.ReadInt32();
		wingMemoryPieceInstallationRequiredHeroLevel = reader.ReadInt32();
		ordealQuestSlotCount = reader.ReadInt32();
		friendMaxCount = reader.ReadInt32();
		tempFriendMaxCount = reader.ReadInt32();
		deadRecordMaxCount = reader.ReadInt32();
		blacklistEntryMaxCount = reader.ReadInt32();
		blessingQuestListMaxCount = reader.ReadInt32();
		blessingQuestRequiredHeroLevel = reader.ReadInt32();
		blessingListMaxCount = reader.ReadInt32();
		ownerProspectQuestListMaxCount = reader.ReadInt32();
		targetProspectQuestListMaxCount = reader.ReadInt32();
		creatureMaxCount = reader.ReadInt32();
		creatureCheerMaxCount = reader.ReadInt32();
		creatureCheerAttrFactor = reader.ReadSingle();
		creatureEvaluationFactor = reader.ReadSingle();
		creatureAdditionalAttrCount = reader.ReadInt32();
		creatureSkillSlotMaxCount = reader.ReadInt32();
		creatureSkillSlotBaseOpenCount = reader.ReadInt32();
		creatureCompositionExpRetrievalRate = reader.ReadInt32();
		creatureCompositionExpRetrievalResultItemId = reader.ReadInt32();
		creatureCompositionSkillProtectionItemId = reader.ReadInt32();
		creatureInjectionExpRetrievalRate = reader.ReadInt32();
		creatureVariationRequiredItemId = reader.ReadInt32();
		creatureAdditionalAttrSwitchRequiredItemId = reader.ReadInt32();
		creatureReleaseExpRetrievalRate = reader.ReadInt32();
		participationCreatureDisplayRequiredVipLevel = reader.ReadInt32();
		presentPopularityPointRankingDisplayMaxCount = reader.ReadInt32();
		presentContributionPointRankingDisplayMaxCount = reader.ReadInt32();
		guildBlessingGuildTerritoryNpcId = reader.ReadInt32();
		nationAllianceUnavailableStartTime = reader.ReadInt32();
		nationAllianceUnavailableEndTime = reader.ReadInt32();
		nationAllianceRequiredFund = reader.ReadInt64();
		nationAllianceRenounceUnavailableDuration = reader.ReadInt32();
		nationBasePower = reader.ReadInt32();
		open7DayEventCostumeItemRewardId = reader.ReadInt64();
		open7DayEventCostumeRewardRequiredItemId = reader.ReadInt32();
		open7DayEventCostumeRewardRequiredItemCount = reader.ReadInt32();
		jobChangeRequiredHeroLevel = reader.ReadInt32();
		jobChangeRequiredItemId = reader.ReadInt32();
		jobChangeQuestCompletionClientTutorialId = reader.ReadInt32();
		chargeEventRequiredHeroLevel = reader.ReadInt32();
		consumeEventRequiredHeroLevel = reader.ReadInt32();
		artifactRequiredConditionType = reader.ReadInt32();
		artifactRequiredConditionValue = reader.ReadInt32();
		artifactMaxLevel = reader.ReadInt32();
		mountAwakeningRequiredHeroLevel = reader.ReadInt32();
		mountAwakeningItemId = reader.ReadInt32();
		mountPotionAttrItemId = reader.ReadInt32();
		costumeEnchantItemId = reader.ReadInt32();
		costumeCollectionActivationItemId = reader.ReadInt32();
		costumeCollectionShuffleItemId = reader.ReadInt32();
		costumeCollectionShuffleItemCount = reader.ReadInt32();
	}
}
