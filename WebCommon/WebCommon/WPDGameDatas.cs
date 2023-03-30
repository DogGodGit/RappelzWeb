using System;
using System.IO;

namespace WebCommon;

public class WPDGameDatas : WPDPacketData
{
	public WPDGameConfig gameConfig;

	public WPDJob[] jobs;

	public WPDNation[] nations;

	public WPDAttrCategory[] attrCategories;

	public WPDAttr[] attrs;

	public WPDElemental[] elementals;

	public WPDItemType[] itemTypes;

	public WPDItemGrade[] itemGrades;

	public WPDItem[] items;

	public WPDMainGearCategory[] mainGearCategories;

	public WPDMainGearType[] mainGearTypes;

	public WPDMainGearTier[] mainGearTiers;

	public WPDMainGear[] mainGears;

	public WPDMainGearGrade[] mainGearGrades;

	public WPDMainGearQuality[] mainGearQualities;

	public WPDMainGearBaseAttr[] mainGearBaseAttrs;

	public WPDMainGearBaseAttrEnchantLevel[] mainGearBaseAttrEnchantLevels;

	public WPDMainGearEnchantStep[] mainGearEnchantSteps;

	public WPDMainGearEnchantLevel[] mainGearEnchantLevels;

	public WPDMainGearOptionAttrGrade[] mainGearOptionAttrGrades;

	public WPDMainGearRefinementRecipe[] mainGearRefinementRecipes;

	public WPDSubGear[] subGears;

	public WPDSubGearGrade[] subGearGrades;

	public WPDSubGearName[] subGearNames;

	public WPDSubGearRuneSocket[] subGearRuneSockets;

	public WPDSubGearRuneSocketAvailableItemType[] subGearRuneSocketAvailableItemTypes;

	public WPDSubGearSoulstoneSocket[] subGearSoulstoneSockets;

	public WPDSubGearAttr[] subGearAttrs;

	public WPDSubGearAttrValue[] subGearAttrValues;

	public WPDSubGearLevel[] subGearLevels;

	public WPDSubGearLevelQuality[] subGearLevelQualities;

	public WPDLocation[] locations;

	public WPDMonsterCharacter[] monsterCharacters;

	public WPDMonster[] monsters;

	public WPDContinent[] continents;

	public WPDMainMenu[] mainMenus;

	public WPDSubMenu[] subMenus;

	public WPDJobSkillMaster[] jobSkillMasters;

	public WPDJobSkill[] jobSkills;

	public WPDJobSkillLevel[] jobSkillLevels;

	public WPDJobSkillLevelMaster[] jobSkillLevelMasters;

	public WPDJobSkillHit[] jobSkillHits;

	public WPDJobChainSkill[] jobChainSkills;

	public WPDJobChainSkillHit[] jobChainSkillHits;

	public WPDJobSkillHitAbnormalState[] jobSkillHitAbnormalStates;

	public WPDPortal[] portals;

	public WPDNpc[] npcs;

	public WPDMainQuest[] mainQuests;

	public WPDMainQuestReward[] mainQuestRewards;

	public WPDContinentObject[] continentObjects;

	public WPDContinentObjectArrange[] continentObjectArranges;

	public WPDItemMainCategory[] itemMainCategories;

	public WPDItemSubCategory[] itemSubCategories;

	public WPDPaidImmediateRevival[] paidImmediateRevivals;

	public WPDMonsterSkill[] monsterSkills;

	public WPDMonsterSkillHit[] monsterSkillHits;

	public WPDMonsterOwnSkill[] monsterOwnSkills;

	public WPDAbnormalState[] abnormalStates;

	public WPDAbnormalStateLevel[] abnormalStateLevels;

	public WPDJobLevelMaster[] jobLevelMasters;

	public WPDJobLevel[] jobLevels;

	public WPDExpReward[] expRewards;

	public WPDGoldReward[] goldRewards;

	public WPDItemReward[] itemRewards;

	public WPDAttrValue[] attrValues;

	public WPDMonsterArrange[] monsterArranges;

	public WPDSimpleShopProduct[] simpleShopProducts;

	public WPDVipLevel[] vipLevels;

	public WPDInventorySlotExtendRecipe[] inventorySlotExtendRecipes;

	public WPDMainGearDisassembleAvailableResultEntry[] mainGearDisassembleAvailableResultEntries;

	public WPDItemCompositionRecipe[] itemCompositionRecipes;

	public WPDRestRewardTime[] restRewardTimes;

	public WPDChattingType[] chattingTypes;

	public WPDMainQuestDungeon[] mainQuestDungeons;

	public WPDMainQuestDungeonObstacle[] mainQuestDungeonObstacles;

	public WPDMainQuestDungeonStep[] mainQuestDungeonSteps;

	public WPDMainQuestDungeonGuide[] mainQuestDungeonGuides;

	public WPDLevelUpRewardEntry[] levelUpRewardEntries;

	public WPDLevelUpRewardItem[] levelUpRewardItems;

	public WPDDailyAttendRewardEntry[] dailyAttendRewardEntries;

	public WPDWeekendAttendRewardAvailableDayOfWeek[] weekendAttendRewardAvailableDayOfWeeks;

	public WPDAccessRewardEntry[] accessRewardEntries;

	public WPDAccessRewardItem[] accessRewardItems;

	public WPDVipLevelReward[] vipLevelRewards;

	public WPDMount[] mounts;

	public WPDMountQualityMaster[] mountQualityMasters;

	public WPDMountLevelMaster[] mountLevelMasters;

	public WPDMountQuality[] mountQualities;

	public WPDMountLevel[] mountLevels;

	public WPDMountGearType[] mountGearTypes;

	public WPDMountGearSlot[] mountGearSlots;

	public WPDMountGear[] mountGears;

	public WPDMountGearGrade[] mountGearGrades;

	public WPDMountGearQuality[] mountGearQualities;

	public WPDMountGearOptionAttrGrade[] mountGearOptionAttrGrades;

	public WPDMountGearPickBoxRecipe[] mountGearPickBoxRecipes;

	public WPDStoryDungeon[] storyDungeons;

	public WPDStoryDungeonDifficulty[] storyDungeonDifficulties;

	public WPDStoryDungeonObstacle[] storyDungeonObstacles;

	public WPDStoryDungeonAvailableReward[] storyDungeonAvailableRewards;

	public WPDStoryDungeonStep[] storyDungeonSteps;

	public WPDStoryDungeonGuide[] storyDungeonGuides;

	public WPDStoryDungeonTrap[] storyDungeonTraps;

	public WPDWingStep[] wingSteps;

	public WPDWingStepPart[] wingStepParts;

	public WPDWingPart[] wingParts;

	public WPDWingStepLevel[] wingStepLevels;

	public WPDWing[] wings;

	public WPDStaminaBuyCount[] staminaBuyCounts;

	public WPDExpDungeon expDungeon;

	public WPDExpDungeonDifficulty[] expDungeonDifficulties;

	public WPDExpDungeonDifficultyWave[] expDungeonDifficultyWaves;

	public WPDGoldDungeon goldDungeon;

	public WPDGoldDungeonDifficulty[] goldDungeonDifficulties;

	public WPDGoldDungeonStep[] goldDungeonSteps;

	public WPDGoldDungeonStepWave[] goldDungeonStepWaves;

	public WPDGoldDungeonStepMonsterArrange[] goldDungeonStepMonsterArranges;

	public WPDMainGearEnchantLevelSet[] mainGearEnchantLevelSets;

	public WPDMainGearEnchantLevelSetAttr[] mainGearEnchantLevelSetAttrs;

	public WPDMainGearSet[] mainGearSets;

	public WPDMainGearSetAttr[] mainGearSetAttrs;

	public WPDSubGearSoulstoneLevelSet[] subGearSoulstoneLevelSets;

	public WPDSubGearSoulstoneLevelSetAttr[] subGearSoulstoneLevelSetAttrs;

	public WPDCartGrade[] cartGrades;

	public WPDCart[] carts;

	public WPDWorldLevelExpFactor[] worldLevelExpFactors;

	public WPDLocationArea[] locationAreas;

	public WPDContinentMapMonster[] continentMapMonsters;

	public WPDTreatOfFarmQuest treatOfFarmQuest;

	public WPDTreatOfFarmQuestMission[] treatOfFarmQuestMissions;

	public WPDTreatOfFarmQuestReward[] treatOfFarmQuestRewards;

	public WPDContinentTransmissionExit[] continentTransmissionExits;

	public WPDUndergroundMaze undergroundMaze;

	public WPDUndergroundMazeEntrance[] undergroundMazeEntrances;

	public WPDUndergroundMazeFloor[] undergroundMazeFloors;

	public WPDUndergroundMazePortal[] undergroundMazePortals;

	public WPDUndergroundMazeMapMonster[] undergroundMazeMapMonsters;

	public WPDUndergroundMazeNpc[] undergroundMazeNpcs;

	public WPDUndergroundMazeNpcTransmissionEntry[] undergroundMazeNpcTransmissionEntries;

	public WPDUndergroundMazeMonsterArrange[] undergroundMazeMonsterArranges;

	public WPDBountyHunterQuest[] bountyHunterQuests;

	public WPDBountyHunterQuestReward[] bountyHunterQuestRewards;

	public WPDFishingQuest fishingQuest;

	public WPDFishingQuestSpot[] fishingQuestSpots;

	public WPDSecretLetterQuest secretLetterQuest;

	public WPDSecretLetterQuestReward[] secretLetterQuestRewards;

	public WPDSecretLetterGrade[] secretLetterGrades;

	public WPDMysteryBoxQuest mysteryBoxQuest;

	public WPDMysteryBoxQuestReward[] mysteryBoxQuestRewards;

	public WPDMysteryBoxGrade[] mysteryBoxGrades;

	public WPDExploitPointReward[] exploitPointRewards;

	public WPDArtifactRoom artifactRoom;

	public WPDArtifactRoomFloor[] artifactRoomFloors;

	public WPDTodayMission[] todayMissions;

	public WPDTodayMissionReward[] todayMissionRewards;

	public WPDSeriesMission[] seriesMissions;

	public WPDSeriesMissionStep[] seriesMissionSteps;

	public WPDSeriesMissionStepReward[] seriesMissionStepRewards;

	public WPDAncientRelic ancientRelic;

	public WPDAncientRelicObstacle[] ancientRelicObstacles;

	public WPDAncientRelicAvailableReward[] ancientRelicAvailableRewards;

	public WPDAncientRelicTrap[] ancientRelicTraps;

	public WPDAncientRelicStep[] ancientRelicSteps;

	public WPDAncientRelicStepWave[] ancientRelicStepWaves;

	public WPDAncientRelicStepRoute[] ancientRelicStepRoutes;

	public WPDAncientRelicMonsterSkillCastingGuide[] ancientRelicMonsterSkillCastingGuides;

	public WPDTodayTaskCategory[] todayTaskCategories;

	public WPDTodayTask[] todayTasks;

	public WPDTodayTaskAvailableReward[] todayTaskAvailableRewards;

	public WPDAchievementReward[] achievementRewards;

	public WPDAchievementRewardEntry[] achievementRewardEntries;

	public WPDDimensionInfiltrationEvent dimensionInfiltrationEvent;

	public WPDDimensionRaidQuest dimensionRaidQuest;

	public WPDDimensionRaidQuestStep[] dimensionRaidQuestSteps;

	public WPDDimensionRaidQuestReward[] dimensionRaidQuestRewards;

	public WPDHolyWarQuest holyWarQuest;

	public WPDHolyWarQuestSchedule[] holyWarQuestSchedules;

	public WPDHolyWarQuestGloryLevel[] holyWarQuestGloryLevels;

	public WPDHonorPointReward[] honorPointRewards;

	public WPDFieldOfHonor fieldOfHonor;

	public WPDFieldOfHonorRankingReward[] fieldOfHonorRankingRewards;

	public WPDHonorShopProduct[] honorShopProducts;

	public WPDRank[] ranks;

	public WPDRankAttr[] rankAttrs;

	public WPDRankReward[] rankRewards;

	public WPDBattlefieldSupportEvent battlefieldSupportEvent;

	public WPDLevelRankingReward[] levelRankingRewards;

	public WPDContentOpenEntry[] contentOpenEntries;

	public WPDAttainmentEntry[] attainmentEntries;

	public WPDAttainmentEntryReward[] attainmentEntryRewards;

	public WPDMenu[] menus;

	public WPDMenuContent[] menuContents;

	public WPDGuildLevel[] guildLevels;

	public WPDGuildMemberGrade[] guildMemberGrades;

	public WPDSupplySupportQuest supplySupportQuest;

	public WPDSupplySupportQuestOrder[] supplySupportQuestOrders;

	public WPDSupplySupportQuestWayPoint[] supplySupportQuestWayPoints;

	public WPDSupplySupportQuestCart[] supplySupportQuestCarts;

	public WPDHolyWarQuestReward[] holyWarQuestRewards;

	public WPDSupplySupportQuestReward[] supplySupportQuestRewards;

	public WPDNationDonationEntry[] nationDonationEntries;

	public WPDNationNoblesse[] nationNoblesses;

	public WPDNationNoblesseAttr[] nationNoblesseAttrs;

	public WPDNationFundReward[] nationFundRewards;

	public WPDGuildContributionPointReward[] guildContributionPointRewards;

	public WPDGuildBuildingPointReward[] guildBuildingPointRewards;

	public WPDGuildFundReward[] guildFundRewards;

	public WPDGuildPointReward[] guildPointRewards;

	public WPDGuildDonationEntry[] guildDonationEntries;

	public WPDNationWar nationWar;

	public WPDNationWarAvailableDayOfWeek[] nationWarAvailableDayOfWeeks;

	public WPDNationWarRevivalPoint[] nationWarRevivalPoints;

	public WPDNationWarRevivalPointActivationCondition[] nationWarRevivalPointActivationConditions;

	public WPDNationWarMonsterArrange[] nationWarMonsterArranges;

	public WPDNationWarNpc[] nationWarNpcs;

	public WPDNationWarTransmissionExit[] nationWarTransmissionExits;

	public WPDNationWarPaidTransmission[] nationWarPaidTransmissions;

	public WPDNationWarHeroObjectiveEntry[] nationWarHeroObjectiveEntries;

	public WPDNationWarExpReward[] nationWarExpRewards;

	public WPDGuildBuilding[] guildBuildings;

	public WPDGuildBuildingLevel[] guildBuildingLevels;

	public WPDGuildSkill[] guildSkills;

	public WPDGuildSkillAttr[] guildSkillAttrs;

	public WPDGuildSkillLevel[] guildSkillLevels;

	public WPDGuildSkillLevelAttrValue[] guildSkillLevelAttrValues;

	public WPDGuildAltar guildAltar;

	public WPDGuildAltarDefenseMonsterAttrFactor[] guildAltarDefenseMonsterAttrFactors;

	public WPDGuildTerritory guildTerritory;

	public WPDGuildTerritoryNpc[] guildTerritoryNpcs;

	public WPDGuildFarmQuest guildFarmQuest;

	public WPDGuildFarmQuestReward[] guildFarmQuestRewards;

	public WPDGuildFoodWarehouse guildFoodWarehouse;

	public WPDGuildFoodWarehouseLevel[] guildFoodWarehouseLevels;

	public WPDGuildMissionQuest guildMissionQuest;

	public WPDGuildMissionQuestReward[] guildMissionQuestRewards;

	public WPDGuildMission[] guildMissions;

	public WPDGuildSupplySupportQuest guildSupplySupportQuest;

	public WPDGuildSupplySupportQuestReward[] guildSupplySupportQuestRewards;

	public WPDNationNoblesseAppointmentAuthority[] nationNoblesseAppointmentAuthorities;

	public WPDMenuContentTutorialStep[] menuContentTutorialSteps;

	public WPDGuildContent[] guildContents;

	public WPDGuildDailyObjectiveReward[] guildDailyObjectiveRewards;

	public WPDGuildHuntingQuest guildHuntingQuest;

	public WPDGuildHuntingQuestObjective[] guildHuntingQuestObjectives;

	public WPDSoulCoveter soulCoveter;

	public WPDSoulCoveterAvailableReward[] soulCoveterAvailableRewards;

	public WPDSoulCoveterObstacle[] soulCoveterObstacles;

	public WPDSoulCoveterDifficulty[] soulCoveterDifficulties;

	public WPDSoulCoveterDifficultyWave[] soulCoveterDifficultyWaves;

	public WPDClientTutorialStep[] clientTutorialSteps;

	public WPDGuildWeeklyObjective[] guildWeeklyObjectives;

	public WPDOwnDiaReward[] ownDiaRewards;

	public WPDAccomplishmentCategory[] accomplishmentCategories;

	public WPDAccomplishment[] accomplishments;

	public WPDTitleCategory[] titleCategories;

	public WPDTitleType[] titleTypes;

	public WPDTitle[] titles;

	public WPDTitleGrade[] titleGrades;

	public WPDTitleActiveAttr[] titleActiveAttrs;

	public WPDTitlePassiveAttr[] titlePassiveAttrs;

	public WPDIllustratedBookCategory[] illustratedBookCategories;

	public WPDIllustratedBookType[] illustratedBookTypes;

	public WPDIllustratedBook[] illustratedBooks;

	public WPDIllustratedBookAttr[] illustratedBookAttrs;

	public WPDIllustratedBookAttrGrade[] illustratedBookAttrGrades;

	public WPDIllustratedBookExplorationStep[] illustratedBookExplorationSteps;

	public WPDIllustratedBookExplorationStepAttr[] illustratedBookExplorationStepAttrs;

	public WPDIllustratedBookExplorationStepReward[] illustratedBookExplorationStepRewards;

	public WPDSceneryQuest[] sceneryQuests;

	public WPDEliteMonsterCategory[] eliteMonsterCategories;

	public WPDEliteMonsterMaster[] eliteMonsterMasters;

	public WPDEliteMonster[] eliteMonsters;

	public WPDEliteMonsterKillAttrValue[] eliteMonsterKillAttrValues;

	public WPDEliteMonsterSpawnSchedule[] eliteMonsterSpawnSchedules;

	public WPDEliteDungeon eliteDungeon;

	public WPDCreatureCardCategory[] creatureCardCategories;

	public WPDCreatureCard[] creatureCards;

	public WPDCreatureCardGrade[] creatureCardGrades;

	public WPDCreatureCardCollectionEntry[] creatureCardCollectionEntries;

	public WPDCreatureCardCollectionCategory[] creatureCardCollectionCategories;

	public WPDCreatureCardCollection[] creatureCardCollections;

	public WPDCreatureCardCollectionAttr[] creatureCardCollectionAttrs;

	public WPDCreatureCardCollectionGrade[] creatureCardCollectionGrades;

	public WPDCreatureCardShopRefreshSchedule[] creatureCardShopRefreshSchedules;

	public WPDCreatureCardShopFixedProduct[] creatureCardShopFixedProducts;

	public WPDCreatureCardShopRandomProduct[] creatureCardShopRandomProducts;

	public WPDProofOfValor proofOfValor;

	public WPDProofOfValorBuffBox[] proofOfValorBuffBoxs;

	public WPDProofOfValorBuffBoxArrange[] proofOfValorBuffBoxArranges;

	public WPDProofOfValorBossMonsterArrange[] proofOfValorBossMonsterArranges;

	public WPDProofOfValorPaidRefresh[] proofOfValorPaidRefreshs;

	public WPDProofOfValorRefreshSchedule[] proofOfValorRefreshSchedules;

	public WPDProofOfValorReward[] proofOfValorRewards;

	public WPDProofOfValorClearGrade[] proofOfValorClearGrades;

	public WPDStaminaRecoverySchedule[] staminaRecoverySchedules;

	public WPDBanWord[] banWords;

	public WPDGuildContentAvailableReward[] guildContentAvailableRewards;

	public WPDMenuContentOpenPreview[] menuContentOpenPreviews;

	public WPDJobCommonSkill[] jobCommonSkills;

	public WPDNpcShop[] npcShops;

	public WPDNpcShopCategory[] npcShopCategories;

	public WPDNpcShopProduct[] npcShopProducts;

	public WPDAbnormalStateRankSkillLevel[] abnormalStateRankSkillLevels;

	public WPDRankActiveSkill[] rankActiveSkills;

	public WPDRankActiveSkillLevel[] rankActiveSkillLevels;

	public WPDRankPassiveSkill[] rankPassiveSkills;

	public WPDRankPassiveSkillAttr[] rankPassiveSkillAttrs;

	public WPDRankPassiveSkillLevel[] rankPassiveSkillLevels;

	public WPDRankPassiveSkillAttrLevel[] rankPassiveSkillAttrLevels;

	public WPDWisdomTemple wisdomTemple;

	public WPDWisdomTempleMonsterAttrFactor[] wisdomTempleMonsterAttrFactors;

	public WPDWisdomTempleColorMatchingObject[] wisdomTempleColorMatchingObjects;

	public WPDWisdomTempleArrangePosition[] wisdomTempleArrangePositions;

	public WPDWisdomTempleSweepReward[] wisdomTempleSweepRewards;

	public WPDWisdomTempleStep[] wisdomTempleSteps;

	public WPDWisdomTempleQuizMonsterPosition[] wisdomTempleQuizMonsterPositions;

	public WPDWisdomTempleQuizPoolEntry[] wisdomTempleQuizPoolEntries;

	public WPDWisdomTemplePuzzle[] wisdomTemplePuzzles;

	public WPDWisdomTempleStepReward[] wisdomTempleStepRewards;

	public WPDRookieGift[] rookieGifts;

	public WPDRookieGiftReward[] rookieGiftRewards;

	public WPDOpenGiftReward[] openGiftRewards;

	public WPDQuickMenu[] quickMenus;

	public WPDDailyQuest dailyQuest;

	public WPDDailyQuestReward[] dailyQuestRewards;

	public WPDDailyQuestGrade[] dailyQuestGrades;

	public WPDDailyQuestMission[] dailyQuestMissions;

	public WPDWeeklyQuest weeklyQuest;

	public WPDWeeklyQuestRoundReward[] weeklyQuestRoundRewards;

	public WPDWeeklyQuestMission[] weeklyQuestMissions;

	public WPDWeeklyQuestTenRoundReward[] weeklyQuestTenRoundRewards;

	public WPDRuinsReclaim ruinsReclaim;

	public WPDRuinsReclaimMonsterAttrFactor[] ruinsReclaimMonsterAttrFactors;

	public WPDRuinsReclaimAvailableReward[] ruinsReclaimAvailableRewards;

	public WPDRuinsReclaimRevivalPoint[] ruinsReclaimRevivalPoints;

	public WPDRuinsReclaimObstacle[] ruinsReclaimObstacles;

	public WPDRuinsReclaimTrap[] ruinsReclaimTraps;

	public WPDRuinsReclaimPortal[] ruinsReclaimPortals;

	public WPDRuinsReclaimOpenSchedule[] ruinsReclaimOpenSchedules;

	public WPDRuinsReclaimStep[] ruinsReclaimSteps;

	public WPDRuinsReclaimObjectArrange[] ruinsReclaimObjectArranges;

	public WPDRuinsReclaimStepReward[] ruinsReclaimStepRewards;

	public WPDRuinsReclaimStepWave[] ruinsReclaimStepWaves;

	public WPDRuinsReclaimStepWaveSkill[] ruinsReclaimStepWaveSkills;

	public WPDOpen7DayEventDay[] open7DayEventDaies;

	public WPDOpen7DayEventMission[] open7DayEventMissions;

	public WPDOpen7DayEventMissionReward[] open7DayEventMissionRewards;

	public WPDOpen7DayEventProduct[] open7DayEventProducts;

	public WPDRetrieval[] retrievals;

	public WPDRetrievalReward[] retrievalRewards;

	public WPDTaskConsignment[] taskConsignments;

	public WPDTaskConsignmentAvailableReward[] taskConsignmentAvailableRewards;

	public WPDTaskConsignmentExpReward[] taskConsignmentExpRewards;

	public WPDInfiniteWar infiniteWar;

	public WPDInfiniteWarBuffBox[] infiniteWarBuffBoxs;

	public WPDInfiniteWarMonsterAttrFactor[] infiniteWarMonsterAttrFactors;

	public WPDInfiniteWarOpenSchedule[] infiniteWarOpenSchedules;

	public WPDInfiniteWarAvailableReward[] infiniteWarAvailableRewards;

	public WPDTrueHeroQuest trueHeroQuest;

	public WPDTrueHeroQuestStep[] trueHeroQuestSteps;

	public WPDTrueHeroQuestReward[] trueHeroQuestRewards;

	public WPDRuinsReclaimRandomRewardPoolEntry[] ruinsReclaimRandomRewardPoolEntries;

	public WPDLimitationGift limitationGift;

	public WPDLimitationGiftRewardDayOfWeek[] limitationGiftRewardDayOfWeeks;

	public WPDLimitationGiftRewardSchedule[] limitationGiftRewardSchedules;

	public WPDLimitationGiftAvailableReward[] limitationGiftAvailableRewards;

	public WPDWeekendReward weekendReward;

	public WPDFieldBossEvent fieldBossEvent;

	public WPDFieldBossEventSchedule[] fieldBossEventSchedules;

	public WPDFieldBossEventAvailableReward[] fieldBossEventAvailableRewards;

	public WPDFieldBoss[] fieldBosss;

	public WPDWarehouseSlotExtendRecipe[] warehouseSlotExtendRecipes;

	public WPDFearAltar fearAltar;

	public WPDFearAltarReward[] fearAltarRewards;

	public WPDFearAltarHalidomCollectionReward[] fearAltarHalidomCollectionRewards;

	public WPDFearAltarHalidomElemental[] fearAltarHalidomElementals;

	public WPDFearAltarHalidomLevel[] fearAltarHalidomLevels;

	public WPDFearAltarHalidom[] fearAltarHalidoms;

	public WPDFearAltarStage[] fearAltarStages;

	public WPDFearAltarStageWave[] fearAltarStageWaves;

	public WPDDiaShopCategory[] diaShopCategories;

	public WPDDiaShopProduct[] diaShopProducts;

	public WPDWingMemoryPieceSlot[] wingMemoryPieceSlots;

	public WPDWingMemoryPieceStep[] wingMemoryPieceSteps;

	public WPDWingMemoryPieceSlotStep[] wingMemoryPieceSlotSteps;

	public WPDWingMemoryPieceType[] wingMemoryPieceTypes;

	public WPDWarMemory warMemory;

	public WPDWarMemoryMonsterAttrFactor[] warMemoryMonsterAttrFactors;

	public WPDWarMemoryStartPosition[] warMemoryStartPositions;

	public WPDWarMemorySchedule[] warMemorySchedules;

	public WPDWarMemoryAvailableReward[] warMemoryAvailableRewards;

	public WPDWarMemoryReward[] warMemoryRewards;

	public WPDWarMemoryRankingReward[] warMemoryRankingRewards;

	public WPDWarMemoryWave[] warMemoryWaves;

	public WPDWarMemoryTransformationObject[] warMemoryTransformationObjects;

	public WPDSubQuest[] subQuests;

	public WPDSubQuestReward[] subQuestRewards;

	public WPDOsirisRoom osirisRoom;

	public WPDOsirisRoomAvailableReward[] osirisRoomAvailableRewards;

	public WPDOsirisRoomDifficulty[] osirisRoomDifficulties;

	public WPDOsirisRoomDifficultyWave[] osirisRoomDifficultyWaves;

	public WPDOrdealQuest[] ordealQuests;

	public WPDOrdealQuestMission[] ordealQuestMissions;

	public WPDMoneyBuff[] moneyBuffs;

	public WPDMoneyBuffAttr[] moneyBuffAttrs;

	public WPDBiography[] biographies;

	public WPDBiographyReward[] biographyRewards;

	public WPDBiographyQuest[] biographyQuests;

	public WPDBiographyQuestStartDialogue[] biographyQuestStartDialogues;

	public WPDBiographyQuestDungeon[] biographyQuestDungeons;

	public WPDBiographyQuestDungeonWave[] biographyQuestDungeonWaves;

	public WPDBlessing[] blessings;

	public WPDBlessingTargetLevel[] blessingTargetLevels;

	public WPDProspectQuestOwnerReward[] prospectQuestOwnerRewards;

	public WPDProspectQuestTargetReward[] prospectQuestTargetRewards;

	public WPDItemLuckyShop itemLuckyShop;

	public WPDCreatureCardLuckyShop creatureCardLuckyShop;

	public WPDCreatureCharacter[] creatureCharacters;

	public WPDCreatureGrade[] creatureGrades;

	public WPDCreature[] creatures;

	public WPDCreatureSkillGrade[] creatureSkillGrades;

	public WPDCreatureSkill[] creatureSkills;

	public WPDCreatureSkillAttr[] creatureSkillAttrs;

	public WPDCreatureBaseAttr[] creatureBaseAttrs;

	public WPDCreatureLevel[] creatureLevels;

	public WPDCreatureBaseAttrValue[] creatureBaseAttrValues;

	public WPDCreatureAdditionalAttr[] creatureAdditionalAttrs;

	public WPDCreatureInjectionLevel[] creatureInjectionLevels;

	public WPDCreatureAdditionalAttrValue[] creatureAdditionalAttrValues;

	public WPDCreatureSkillSlotOpenRecipe[] creatureSkillSlotOpenRecipes;

	public WPDCreatureSkillSlotProtection[] creatureSkillSlotProtections;

	public WPDDragonNest dragonNest;

	public WPDDragonNestAvailableReward[] dragonNestAvailableRewards;

	public WPDDragonNestObstacle[] dragonNestObstacles;

	public WPDDragonNestTrap[] dragonNestTraps;

	public WPDDragonNestStep[] dragonNestSteps;

	public WPDDragonNestStepReward[] dragonNestStepRewards;

	public WPDPresent[] presents;

	public WPDWeeklyPresentPopularityPointRankingRewardGroup[] weeklyPresentPopularityPointRankingRewardGroups;

	public WPDWeeklyPresentPopularityPointRankingReward[] weeklyPresentPopularityPointRankingRewards;

	public WPDWeeklyPresentContributionPointRankingRewardGroup[] weeklyPresentContributionPointRankingRewardGroups;

	public WPDWeeklyPresentContributionPointRankingReward[] weeklyPresentContributionPointRankingRewards;

	public WPDMainQuestStartDialogue[] mainQuestStartDialogues;

	public WPDMainQuestCompletionDialogue[] mainQuestCompletionDialogues;

	public WPDCreatureFarmQuest creatureFarmQuest;

	public WPDCreatureFarmQuestExpReward[] creatureFarmQuestExpRewards;

	public WPDCreatureFarmQuestItemReward[] creatureFarmQuestItemRewards;

	public WPDCreatureFarmQuestMission[] creatureFarmQuestMissions;

	public WPDCostume[] costumes;

	public WPDCostumeEffect[] costumeEffects;

	public WPDSafeTimeEvent safeTimeEvent;

	public WPDFishingQuestGuildTerritorySpot[] fishingQuestGuildTerritorySpots;

	public WPDGuildBlessingBuff[] guildBlessingBuffs;

	public WPDInAppProduct[] inAppProducts;

	public WPDInAppProductPrice[] inAppProductPrices;

	public WPDCashProduct[] cashProducts;

	public WPDJobChangeQuest[] jobChangeQuests;

	public WPDJobChangeQuestDifficulty[] jobChangeQuestDifficulties;

	public WPDFirstChargeEvent firstChargeEvent;

	public WPDFirstChargeEventReward[] firstChargeEventRewards;

	public WPDRechargeEvent rechargeEvent;

	public WPDRechargeEventReward[] rechargeEventRewards;

	public WPDChargeEvent[] chargeEvents;

	public WPDChargeEventMission[] chargeEventMissions;

	public WPDAnkouTomb ankouTomb;

	public WPDAnkouTombSchedule[] ankouTombSchedules;

	public WPDAnkouTombDifficulty[] ankouTombDifficulties;

	public WPDAnkouTombAvailableReward[] ankouTombAvailableRewards;

	public WPDPotionAttr[] potionAttrs;

	public WPDRecommendBattlePowerLevel[] recommendBattlePowerLevels;

	public WPDImprovementMainCategory[] improvementMainCategories;

	public WPDImprovementMainCategoryContent[] improvementMainCategoryContents;

	public WPDImprovementSubCategory[] improvementSubCategories;

	public WPDImprovementSubCategoryContent[] improvementSubCategoryContents;

	public WPDImprovementContent[] improvementContents;

	public WPDImprovementContentAchievementLevel[] improvementContentAchievementLevels;

	public WPDImprovementContentAchievement[] improvementContentAchievements;

	public WPDConstellation[] constellations;

	public WPDConstellationStep[] constellationSteps;

	public WPDConstellationCycle[] constellationCycles;

	public WPDConstellationCycleBuff[] constellationCycleBuffs;

	public WPDConstellationEntry[] constellationEntries;

	public WPDConstellationEntryBuff[] constellationEntryBuffs;

	public WPDChargeEventMissionReward[] chargeEventMissionRewards;

	public WPDDailyChargeEvent dailyChargeEvent;

	public WPDDailyChargeEventMission[] dailyChargeEventMissions;

	public WPDDailyChargeEventMissionReward[] dailyChargeEventMissionRewards;

	public WPDConsumeEvent[] consumeEvents;

	public WPDConsumeEventMission[] consumeEventMissions;

	public WPDConsumeEventMissionReward[] consumeEventMissionRewards;

	public WPDDailyConsumeEvent dailyConsumeEvent;

	public WPDDailyConsumeEventMission[] dailyConsumeEventMissions;

	public WPDDailyConsumeEventMissionReward[] dailyConsumeEventMissionRewards;

	public WPDArtifact[] artifacts;

	public WPDArtifactAttr[] artifactAttrs;

	public WPDArtifactLevel[] artifactLevels;

	public WPDArtifactLevelAttr[] artifactLevelAttrs;

	public WPDArtifactLevelUpMaterial[] artifactLevelUpMaterials;

	public WPDTradeShip tradeShip;

	public WPDTradeShipSchedule[] tradeShipSchedules;

	public WPDTradeShipObstacle[] tradeShipObstacles;

	public WPDTradeShipStep[] tradeShipSteps;

	public WPDTradeShipDifficulty[] tradeShipDifficulties;

	public WPDTradeShipAvailableReward[] tradeShipAvailableRewards;

	public WPDTradeShipObject[] tradeShipObjects;

	public WPDMountAwakeningLevelMaster[] mountAwakeningLevelMasters;

	public WPDMountAwakeningLevel[] mountAwakeningLevels;

	public WPDMountPotionAttrCount[] mountPotionAttrCounts;

	public WPDCostumeDisplay[] costumeDisplays;

	public WPDCostumeCollection[] costumeCollections;

	public WPDCostumeCollectionAttr[] costumeCollectionAttrs;

	public WPDCostumeCollectionEntry[] costumeCollectionEntries;

	public WPDCostumeAttr[] costumeAttrs;

	public WPDCostumeEnchantLevel[] costumeEnchantLevels;

	public WPDCostumeEnchantLevelAttr[] costumeEnchantLevelAttrs;

	public WPDScheduleNotice[] scheduleNotices;

	public WPDSharingEvent[] sharingEvents;

	public WPDSystemMessage[] systemMessages;

	public WPDSharingEventSenderReward[] sharingEventSenderRewards;

	public WPDSharingEventReceiverReward[] sharingEventReceiverRewards;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(gameConfig);
		writer.Write(jobs);
		writer.Write(nations);
		writer.Write(attrCategories);
		writer.Write(attrs);
		writer.Write(elementals);
		writer.Write(itemTypes);
		writer.Write(itemGrades);
		writer.Write(items);
		writer.Write(mainGearCategories);
		writer.Write(mainGearTypes);
		writer.Write(mainGearTiers);
		writer.Write(mainGears);
		writer.Write(mainGearGrades);
		writer.Write(mainGearQualities);
		writer.Write(mainGearBaseAttrs);
		writer.Write(mainGearBaseAttrEnchantLevels);
		writer.Write(mainGearEnchantSteps);
		writer.Write(mainGearEnchantLevels);
		writer.Write(mainGearOptionAttrGrades);
		writer.Write(mainGearRefinementRecipes);
		writer.Write(subGears);
		writer.Write(subGearGrades);
		writer.Write(subGearNames);
		writer.Write(subGearRuneSockets);
		writer.Write(subGearRuneSocketAvailableItemTypes);
		writer.Write(subGearSoulstoneSockets);
		writer.Write(subGearAttrs);
		writer.Write(subGearAttrValues);
		writer.Write(subGearLevels);
		writer.Write(subGearLevelQualities);
		writer.Write(locations);
		writer.Write(monsterCharacters);
		writer.Write(monsters);
		writer.Write(continents);
		writer.Write(mainMenus);
		writer.Write(subMenus);
		writer.Write(jobSkillMasters);
		writer.Write(jobSkills);
		writer.Write(jobSkillLevels);
		writer.Write(jobSkillLevelMasters);
		writer.Write(jobSkillHits);
		writer.Write(jobChainSkills);
		writer.Write(jobChainSkillHits);
		writer.Write(jobSkillHitAbnormalStates);
		writer.Write(portals);
		writer.Write(npcs);
		writer.Write(mainQuests);
		writer.Write(mainQuestRewards);
		writer.Write(continentObjects);
		writer.Write(continentObjectArranges);
		writer.Write(itemMainCategories);
		writer.Write(itemSubCategories);
		writer.Write(paidImmediateRevivals);
		writer.Write(monsterSkills);
		writer.Write(monsterSkillHits);
		writer.Write(monsterOwnSkills);
		writer.Write(abnormalStates);
		writer.Write(abnormalStateLevels);
		writer.Write(jobLevelMasters);
		writer.Write(jobLevels);
		writer.Write(expRewards);
		writer.Write(goldRewards);
		writer.Write(itemRewards);
		writer.Write(attrValues);
		writer.Write(monsterArranges);
		writer.Write(simpleShopProducts);
		writer.Write(vipLevels);
		writer.Write(inventorySlotExtendRecipes);
		writer.Write(mainGearDisassembleAvailableResultEntries);
		writer.Write(itemCompositionRecipes);
		writer.Write(restRewardTimes);
		writer.Write(chattingTypes);
		writer.Write(mainQuestDungeons);
		writer.Write(mainQuestDungeonObstacles);
		writer.Write(mainQuestDungeonSteps);
		writer.Write(mainQuestDungeonGuides);
		writer.Write(levelUpRewardEntries);
		writer.Write(levelUpRewardItems);
		writer.Write(dailyAttendRewardEntries);
		writer.Write(weekendAttendRewardAvailableDayOfWeeks);
		writer.Write(accessRewardEntries);
		writer.Write(accessRewardItems);
		writer.Write(vipLevelRewards);
		writer.Write(mounts);
		writer.Write(mountQualityMasters);
		writer.Write(mountLevelMasters);
		writer.Write(mountQualities);
		writer.Write(mountLevels);
		writer.Write(mountGearTypes);
		writer.Write(mountGearSlots);
		writer.Write(mountGears);
		writer.Write(mountGearGrades);
		writer.Write(mountGearQualities);
		writer.Write(mountGearOptionAttrGrades);
		writer.Write(mountGearPickBoxRecipes);
		writer.Write(storyDungeons);
		writer.Write(storyDungeonDifficulties);
		writer.Write(storyDungeonObstacles);
		writer.Write(storyDungeonAvailableRewards);
		writer.Write(storyDungeonSteps);
		writer.Write(storyDungeonGuides);
		writer.Write(storyDungeonTraps);
		writer.Write(wingSteps);
		writer.Write(wingStepParts);
		writer.Write(wingParts);
		writer.Write(wingStepLevels);
		writer.Write(wings);
		writer.Write(staminaBuyCounts);
		writer.Write(expDungeon);
		writer.Write(expDungeonDifficulties);
		writer.Write(expDungeonDifficultyWaves);
		writer.Write(goldDungeon);
		writer.Write(goldDungeonDifficulties);
		writer.Write(goldDungeonSteps);
		writer.Write(goldDungeonStepWaves);
		writer.Write(goldDungeonStepMonsterArranges);
		writer.Write(mainGearEnchantLevelSets);
		writer.Write(mainGearEnchantLevelSetAttrs);
		writer.Write(mainGearSets);
		writer.Write(mainGearSetAttrs);
		writer.Write(subGearSoulstoneLevelSets);
		writer.Write(subGearSoulstoneLevelSetAttrs);
		writer.Write(cartGrades);
		writer.Write(carts);
		writer.Write(worldLevelExpFactors);
		writer.Write(locationAreas);
		writer.Write(continentMapMonsters);
		writer.Write(treatOfFarmQuest);
		writer.Write(treatOfFarmQuestMissions);
		writer.Write(treatOfFarmQuestRewards);
		writer.Write(continentTransmissionExits);
		writer.Write(undergroundMaze);
		writer.Write(undergroundMazeEntrances);
		writer.Write(undergroundMazeFloors);
		writer.Write(undergroundMazePortals);
		writer.Write(undergroundMazeMapMonsters);
		writer.Write(undergroundMazeNpcs);
		writer.Write(undergroundMazeNpcTransmissionEntries);
		writer.Write(undergroundMazeMonsterArranges);
		writer.Write(bountyHunterQuests);
		writer.Write(bountyHunterQuestRewards);
		writer.Write(fishingQuest);
		writer.Write(fishingQuestSpots);
		writer.Write(secretLetterQuest);
		writer.Write(secretLetterQuestRewards);
		writer.Write(secretLetterGrades);
		writer.Write(mysteryBoxQuest);
		writer.Write(mysteryBoxQuestRewards);
		writer.Write(mysteryBoxGrades);
		writer.Write(exploitPointRewards);
		writer.Write(artifactRoom);
		writer.Write(artifactRoomFloors);
		writer.Write(todayMissions);
		writer.Write(todayMissionRewards);
		writer.Write(seriesMissions);
		writer.Write(seriesMissionSteps);
		writer.Write(seriesMissionStepRewards);
		writer.Write(ancientRelic);
		writer.Write(ancientRelicObstacles);
		writer.Write(ancientRelicAvailableRewards);
		writer.Write(ancientRelicTraps);
		writer.Write(ancientRelicSteps);
		writer.Write(ancientRelicStepWaves);
		writer.Write(ancientRelicStepRoutes);
		writer.Write(ancientRelicMonsterSkillCastingGuides);
		writer.Write(todayTaskCategories);
		writer.Write(todayTasks);
		writer.Write(todayTaskAvailableRewards);
		writer.Write(achievementRewards);
		writer.Write(achievementRewardEntries);
		writer.Write(dimensionInfiltrationEvent);
		writer.Write(dimensionRaidQuest);
		writer.Write(dimensionRaidQuestSteps);
		writer.Write(dimensionRaidQuestRewards);
		writer.Write(holyWarQuest);
		writer.Write(holyWarQuestSchedules);
		writer.Write(holyWarQuestGloryLevels);
		writer.Write(honorPointRewards);
		writer.Write(fieldOfHonor);
		writer.Write(fieldOfHonorRankingRewards);
		writer.Write(honorShopProducts);
		writer.Write(ranks);
		writer.Write(rankAttrs);
		writer.Write(rankRewards);
		writer.Write(battlefieldSupportEvent);
		writer.Write(levelRankingRewards);
		writer.Write(contentOpenEntries);
		writer.Write(attainmentEntries);
		writer.Write(attainmentEntryRewards);
		writer.Write(menus);
		writer.Write(menuContents);
		writer.Write(guildLevels);
		writer.Write(guildMemberGrades);
		writer.Write(supplySupportQuest);
		writer.Write(supplySupportQuestOrders);
		writer.Write(supplySupportQuestWayPoints);
		writer.Write(supplySupportQuestCarts);
		writer.Write(holyWarQuestRewards);
		writer.Write(supplySupportQuestRewards);
		writer.Write(nationDonationEntries);
		writer.Write(nationNoblesses);
		writer.Write(nationNoblesseAttrs);
		writer.Write(nationFundRewards);
		writer.Write(guildContributionPointRewards);
		writer.Write(guildBuildingPointRewards);
		writer.Write(guildFundRewards);
		writer.Write(guildPointRewards);
		writer.Write(guildDonationEntries);
		writer.Write(nationWar);
		writer.Write(nationWarAvailableDayOfWeeks);
		writer.Write(nationWarRevivalPoints);
		writer.Write(nationWarRevivalPointActivationConditions);
		writer.Write(nationWarMonsterArranges);
		writer.Write(nationWarNpcs);
		writer.Write(nationWarTransmissionExits);
		writer.Write(nationWarPaidTransmissions);
		writer.Write(nationWarHeroObjectiveEntries);
		writer.Write(nationWarExpRewards);
		writer.Write(guildBuildings);
		writer.Write(guildBuildingLevels);
		writer.Write(guildSkills);
		writer.Write(guildSkillAttrs);
		writer.Write(guildSkillLevels);
		writer.Write(guildSkillLevelAttrValues);
		writer.Write(guildAltar);
		writer.Write(guildAltarDefenseMonsterAttrFactors);
		writer.Write(guildTerritory);
		writer.Write(guildTerritoryNpcs);
		writer.Write(guildFarmQuest);
		writer.Write(guildFarmQuestRewards);
		writer.Write(guildFoodWarehouse);
		writer.Write(guildFoodWarehouseLevels);
		writer.Write(guildMissionQuest);
		writer.Write(guildMissionQuestRewards);
		writer.Write(guildMissions);
		writer.Write(guildSupplySupportQuest);
		writer.Write(guildSupplySupportQuestRewards);
		writer.Write(nationNoblesseAppointmentAuthorities);
		writer.Write(menuContentTutorialSteps);
		writer.Write(guildContents);
		writer.Write(guildDailyObjectiveRewards);
		writer.Write(guildHuntingQuest);
		writer.Write(guildHuntingQuestObjectives);
		writer.Write(soulCoveter);
		writer.Write(soulCoveterAvailableRewards);
		writer.Write(soulCoveterObstacles);
		writer.Write(soulCoveterDifficulties);
		writer.Write(soulCoveterDifficultyWaves);
		writer.Write(clientTutorialSteps);
		writer.Write(guildWeeklyObjectives);
		writer.Write(ownDiaRewards);
		writer.Write(accomplishmentCategories);
		writer.Write(accomplishments);
		writer.Write(titleCategories);
		writer.Write(titleTypes);
		writer.Write(titles);
		writer.Write(titleGrades);
		writer.Write(titleActiveAttrs);
		writer.Write(titlePassiveAttrs);
		writer.Write(illustratedBookCategories);
		writer.Write(illustratedBookTypes);
		writer.Write(illustratedBooks);
		writer.Write(illustratedBookAttrs);
		writer.Write(illustratedBookAttrGrades);
		writer.Write(illustratedBookExplorationSteps);
		writer.Write(illustratedBookExplorationStepAttrs);
		writer.Write(illustratedBookExplorationStepRewards);
		writer.Write(sceneryQuests);
		writer.Write(eliteMonsterCategories);
		writer.Write(eliteMonsterMasters);
		writer.Write(eliteMonsters);
		writer.Write(eliteMonsterKillAttrValues);
		writer.Write(eliteMonsterSpawnSchedules);
		writer.Write(eliteDungeon);
		writer.Write(creatureCardCategories);
		writer.Write(creatureCards);
		writer.Write(creatureCardGrades);
		writer.Write(creatureCardCollectionEntries);
		writer.Write(creatureCardCollectionCategories);
		writer.Write(creatureCardCollections);
		writer.Write(creatureCardCollectionAttrs);
		writer.Write(creatureCardCollectionGrades);
		writer.Write(creatureCardShopRefreshSchedules);
		writer.Write(creatureCardShopFixedProducts);
		writer.Write(creatureCardShopRandomProducts);
		writer.Write(proofOfValor);
		writer.Write(proofOfValorBuffBoxs);
		writer.Write(proofOfValorBuffBoxArranges);
		writer.Write(proofOfValorBossMonsterArranges);
		writer.Write(proofOfValorPaidRefreshs);
		writer.Write(proofOfValorRefreshSchedules);
		writer.Write(proofOfValorRewards);
		writer.Write(proofOfValorClearGrades);
		writer.Write(staminaRecoverySchedules);
		writer.Write(banWords);
		writer.Write(guildContentAvailableRewards);
		writer.Write(menuContentOpenPreviews);
		writer.Write(jobCommonSkills);
		writer.Write(npcShops);
		writer.Write(npcShopCategories);
		writer.Write(npcShopProducts);
		writer.Write(abnormalStateRankSkillLevels);
		writer.Write(rankActiveSkills);
		writer.Write(rankActiveSkillLevels);
		writer.Write(rankPassiveSkills);
		writer.Write(rankPassiveSkillAttrs);
		writer.Write(rankPassiveSkillLevels);
		writer.Write(rankPassiveSkillAttrLevels);
		writer.Write(wisdomTemple);
		writer.Write(wisdomTempleMonsterAttrFactors);
		writer.Write(wisdomTempleColorMatchingObjects);
		writer.Write(wisdomTempleArrangePositions);
		writer.Write(wisdomTempleSweepRewards);
		writer.Write(wisdomTempleSteps);
		writer.Write(wisdomTempleQuizMonsterPositions);
		writer.Write(wisdomTempleQuizPoolEntries);
		writer.Write(wisdomTemplePuzzles);
		writer.Write(wisdomTempleStepRewards);
		writer.Write(rookieGifts);
		writer.Write(rookieGiftRewards);
		writer.Write(openGiftRewards);
		writer.Write(quickMenus);
		writer.Write(dailyQuest);
		writer.Write(dailyQuestRewards);
		writer.Write(dailyQuestGrades);
		writer.Write(dailyQuestMissions);
		writer.Write(weeklyQuest);
		writer.Write(weeklyQuestRoundRewards);
		writer.Write(weeklyQuestMissions);
		writer.Write(weeklyQuestTenRoundRewards);
		writer.Write(ruinsReclaim);
		writer.Write(ruinsReclaimMonsterAttrFactors);
		writer.Write(ruinsReclaimAvailableRewards);
		writer.Write(ruinsReclaimRevivalPoints);
		writer.Write(ruinsReclaimObstacles);
		writer.Write(ruinsReclaimTraps);
		writer.Write(ruinsReclaimPortals);
		writer.Write(ruinsReclaimOpenSchedules);
		writer.Write(ruinsReclaimSteps);
		writer.Write(ruinsReclaimObjectArranges);
		writer.Write(ruinsReclaimStepRewards);
		writer.Write(ruinsReclaimStepWaves);
		writer.Write(ruinsReclaimStepWaveSkills);
		writer.Write(open7DayEventDaies);
		writer.Write(open7DayEventMissions);
		writer.Write(open7DayEventMissionRewards);
		writer.Write(open7DayEventProducts);
		writer.Write(retrievals);
		writer.Write(retrievalRewards);
		writer.Write(taskConsignments);
		writer.Write(taskConsignmentAvailableRewards);
		writer.Write(taskConsignmentExpRewards);
		writer.Write(infiniteWar);
		writer.Write(infiniteWarBuffBoxs);
		writer.Write(infiniteWarMonsterAttrFactors);
		writer.Write(infiniteWarOpenSchedules);
		writer.Write(infiniteWarAvailableRewards);
		writer.Write(trueHeroQuest);
		writer.Write(trueHeroQuestSteps);
		writer.Write(trueHeroQuestRewards);
		writer.Write(ruinsReclaimRandomRewardPoolEntries);
		writer.Write(limitationGift);
		writer.Write(limitationGiftRewardDayOfWeeks);
		writer.Write(limitationGiftRewardSchedules);
		writer.Write(limitationGiftAvailableRewards);
		writer.Write(weekendReward);
		writer.Write(fieldBossEvent);
		writer.Write(fieldBossEventSchedules);
		writer.Write(fieldBossEventAvailableRewards);
		writer.Write(fieldBosss);
		writer.Write(warehouseSlotExtendRecipes);
		writer.Write(fearAltar);
		writer.Write(fearAltarRewards);
		writer.Write(fearAltarHalidomCollectionRewards);
		writer.Write(fearAltarHalidomElementals);
		writer.Write(fearAltarHalidomLevels);
		writer.Write(fearAltarHalidoms);
		writer.Write(fearAltarStages);
		writer.Write(fearAltarStageWaves);
		writer.Write(diaShopCategories);
		writer.Write(diaShopProducts);
		writer.Write(wingMemoryPieceSlots);
		writer.Write(wingMemoryPieceSteps);
		writer.Write(wingMemoryPieceSlotSteps);
		writer.Write(wingMemoryPieceTypes);
		writer.Write(warMemory);
		writer.Write(warMemoryMonsterAttrFactors);
		writer.Write(warMemoryStartPositions);
		writer.Write(warMemorySchedules);
		writer.Write(warMemoryAvailableRewards);
		writer.Write(warMemoryRewards);
		writer.Write(warMemoryRankingRewards);
		writer.Write(warMemoryWaves);
		writer.Write(warMemoryTransformationObjects);
		writer.Write(subQuests);
		writer.Write(subQuestRewards);
		writer.Write(osirisRoom);
		writer.Write(osirisRoomAvailableRewards);
		writer.Write(osirisRoomDifficulties);
		writer.Write(osirisRoomDifficultyWaves);
		writer.Write(ordealQuests);
		writer.Write(ordealQuestMissions);
		writer.Write(moneyBuffs);
		writer.Write(moneyBuffAttrs);
		writer.Write(biographies);
		writer.Write(biographyRewards);
		writer.Write(biographyQuests);
		writer.Write(biographyQuestStartDialogues);
		writer.Write(biographyQuestDungeons);
		writer.Write(biographyQuestDungeonWaves);
		writer.Write(blessings);
		writer.Write(blessingTargetLevels);
		writer.Write(prospectQuestOwnerRewards);
		writer.Write(prospectQuestTargetRewards);
		writer.Write(itemLuckyShop);
		writer.Write(creatureCardLuckyShop);
		writer.Write(creatureCharacters);
		writer.Write(creatureGrades);
		writer.Write(creatures);
		writer.Write(creatureSkillGrades);
		writer.Write(creatureSkills);
		writer.Write(creatureSkillAttrs);
		writer.Write(creatureBaseAttrs);
		writer.Write(creatureLevels);
		writer.Write(creatureBaseAttrValues);
		writer.Write(creatureAdditionalAttrs);
		writer.Write(creatureInjectionLevels);
		writer.Write(creatureAdditionalAttrValues);
		writer.Write(creatureSkillSlotOpenRecipes);
		writer.Write(creatureSkillSlotProtections);
		writer.Write(dragonNest);
		writer.Write(dragonNestAvailableRewards);
		writer.Write(dragonNestObstacles);
		writer.Write(dragonNestTraps);
		writer.Write(dragonNestSteps);
		writer.Write(dragonNestStepRewards);
		writer.Write(presents);
		writer.Write(weeklyPresentPopularityPointRankingRewardGroups);
		writer.Write(weeklyPresentPopularityPointRankingRewards);
		writer.Write(weeklyPresentContributionPointRankingRewardGroups);
		writer.Write(weeklyPresentContributionPointRankingRewards);
		writer.Write(mainQuestStartDialogues);
		writer.Write(mainQuestCompletionDialogues);
		writer.Write(creatureFarmQuest);
		writer.Write(creatureFarmQuestExpRewards);
		writer.Write(creatureFarmQuestItemRewards);
		writer.Write(creatureFarmQuestMissions);
		writer.Write(costumes);
		writer.Write(costumeEffects);
		writer.Write(safeTimeEvent);
		writer.Write(fishingQuestGuildTerritorySpots);
		writer.Write(guildBlessingBuffs);
		writer.Write(inAppProducts);
		writer.Write(inAppProductPrices);
		writer.Write(cashProducts);
		writer.Write(jobChangeQuests);
		writer.Write(jobChangeQuestDifficulties);
		writer.Write(firstChargeEvent);
		writer.Write(firstChargeEventRewards);
		writer.Write(rechargeEvent);
		writer.Write(rechargeEventRewards);
		writer.Write(chargeEvents);
		writer.Write(chargeEventMissions);
		writer.Write(ankouTomb);
		writer.Write(ankouTombSchedules);
		writer.Write(ankouTombDifficulties);
		writer.Write(ankouTombAvailableRewards);
		writer.Write(potionAttrs);
		writer.Write(recommendBattlePowerLevels);
		writer.Write(improvementMainCategories);
		writer.Write(improvementMainCategoryContents);
		writer.Write(improvementSubCategories);
		writer.Write(improvementSubCategoryContents);
		writer.Write(improvementContents);
		writer.Write(improvementContentAchievementLevels);
		writer.Write(improvementContentAchievements);
		writer.Write(constellations);
		writer.Write(constellationSteps);
		writer.Write(constellationCycles);
		writer.Write(constellationCycleBuffs);
		writer.Write(constellationEntries);
		writer.Write(constellationEntryBuffs);
		writer.Write(chargeEventMissionRewards);
		writer.Write(dailyChargeEvent);
		writer.Write(dailyChargeEventMissions);
		writer.Write(dailyChargeEventMissionRewards);
		writer.Write(consumeEvents);
		writer.Write(consumeEventMissions);
		writer.Write(consumeEventMissionRewards);
		writer.Write(dailyConsumeEvent);
		writer.Write(dailyConsumeEventMissions);
		writer.Write(dailyConsumeEventMissionRewards);
		writer.Write(artifacts);
		writer.Write(artifactAttrs);
		writer.Write(artifactLevels);
		writer.Write(artifactLevelAttrs);
		writer.Write(artifactLevelUpMaterials);
		writer.Write(tradeShip);
		writer.Write(tradeShipSchedules);
		writer.Write(tradeShipObstacles);
		writer.Write(tradeShipSteps);
		writer.Write(tradeShipDifficulties);
		writer.Write(tradeShipAvailableRewards);
		writer.Write(tradeShipObjects);
		writer.Write(mountAwakeningLevelMasters);
		writer.Write(mountAwakeningLevels);
		writer.Write(mountPotionAttrCounts);
		writer.Write(costumeDisplays);
		writer.Write(costumeCollections);
		writer.Write(costumeCollectionAttrs);
		writer.Write(costumeCollectionEntries);
		writer.Write(costumeAttrs);
		writer.Write(costumeEnchantLevels);
		writer.Write(costumeEnchantLevelAttrs);
		writer.Write(scheduleNotices);
		writer.Write(sharingEvents);
		writer.Write(systemMessages);
		writer.Write(sharingEventSenderRewards);
		writer.Write(sharingEventReceiverRewards);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		gameConfig = reader.ReadPDPacketData<WPDGameConfig>();
		jobs = reader.ReadPDPacketDatas<WPDJob>();
		nations = reader.ReadPDPacketDatas<WPDNation>();
		attrCategories = reader.ReadPDPacketDatas<WPDAttrCategory>();
		attrs = reader.ReadPDPacketDatas<WPDAttr>();
		elementals = reader.ReadPDPacketDatas<WPDElemental>();
		itemTypes = reader.ReadPDPacketDatas<WPDItemType>();
		itemGrades = reader.ReadPDPacketDatas<WPDItemGrade>();
		items = reader.ReadPDPacketDatas<WPDItem>();
		mainGearCategories = reader.ReadPDPacketDatas<WPDMainGearCategory>();
		mainGearTypes = reader.ReadPDPacketDatas<WPDMainGearType>();
		mainGearTiers = reader.ReadPDPacketDatas<WPDMainGearTier>();
		mainGears = reader.ReadPDPacketDatas<WPDMainGear>();
		mainGearGrades = reader.ReadPDPacketDatas<WPDMainGearGrade>();
		mainGearQualities = reader.ReadPDPacketDatas<WPDMainGearQuality>();
		mainGearBaseAttrs = reader.ReadPDPacketDatas<WPDMainGearBaseAttr>();
		mainGearBaseAttrEnchantLevels = reader.ReadPDPacketDatas<WPDMainGearBaseAttrEnchantLevel>();
		mainGearEnchantSteps = reader.ReadPDPacketDatas<WPDMainGearEnchantStep>();
		mainGearEnchantLevels = reader.ReadPDPacketDatas<WPDMainGearEnchantLevel>();
		mainGearOptionAttrGrades = reader.ReadPDPacketDatas<WPDMainGearOptionAttrGrade>();
		mainGearRefinementRecipes = reader.ReadPDPacketDatas<WPDMainGearRefinementRecipe>();
		subGears = reader.ReadPDPacketDatas<WPDSubGear>();
		subGearGrades = reader.ReadPDPacketDatas<WPDSubGearGrade>();
		subGearNames = reader.ReadPDPacketDatas<WPDSubGearName>();
		subGearRuneSockets = reader.ReadPDPacketDatas<WPDSubGearRuneSocket>();
		subGearRuneSocketAvailableItemTypes = reader.ReadPDPacketDatas<WPDSubGearRuneSocketAvailableItemType>();
		subGearSoulstoneSockets = reader.ReadPDPacketDatas<WPDSubGearSoulstoneSocket>();
		subGearAttrs = reader.ReadPDPacketDatas<WPDSubGearAttr>();
		subGearAttrValues = reader.ReadPDPacketDatas<WPDSubGearAttrValue>();
		subGearLevels = reader.ReadPDPacketDatas<WPDSubGearLevel>();
		subGearLevelQualities = reader.ReadPDPacketDatas<WPDSubGearLevelQuality>();
		locations = reader.ReadPDPacketDatas<WPDLocation>();
		monsterCharacters = reader.ReadPDPacketDatas<WPDMonsterCharacter>();
		monsters = reader.ReadPDPacketDatas<WPDMonster>();
		continents = reader.ReadPDPacketDatas<WPDContinent>();
		mainMenus = reader.ReadPDPacketDatas<WPDMainMenu>();
		subMenus = reader.ReadPDPacketDatas<WPDSubMenu>();
		jobSkillMasters = reader.ReadPDPacketDatas<WPDJobSkillMaster>();
		jobSkills = reader.ReadPDPacketDatas<WPDJobSkill>();
		jobSkillLevels = reader.ReadPDPacketDatas<WPDJobSkillLevel>();
		jobSkillLevelMasters = reader.ReadPDPacketDatas<WPDJobSkillLevelMaster>();
		jobSkillHits = reader.ReadPDPacketDatas<WPDJobSkillHit>();
		jobChainSkills = reader.ReadPDPacketDatas<WPDJobChainSkill>();
		jobChainSkillHits = reader.ReadPDPacketDatas<WPDJobChainSkillHit>();
		jobSkillHitAbnormalStates = reader.ReadPDPacketDatas<WPDJobSkillHitAbnormalState>();
		portals = reader.ReadPDPacketDatas<WPDPortal>();
		npcs = reader.ReadPDPacketDatas<WPDNpc>();
		mainQuests = reader.ReadPDPacketDatas<WPDMainQuest>();
		mainQuestRewards = reader.ReadPDPacketDatas<WPDMainQuestReward>();
		continentObjects = reader.ReadPDPacketDatas<WPDContinentObject>();
		continentObjectArranges = reader.ReadPDPacketDatas<WPDContinentObjectArrange>();
		itemMainCategories = reader.ReadPDPacketDatas<WPDItemMainCategory>();
		itemSubCategories = reader.ReadPDPacketDatas<WPDItemSubCategory>();
		paidImmediateRevivals = reader.ReadPDPacketDatas<WPDPaidImmediateRevival>();
		monsterSkills = reader.ReadPDPacketDatas<WPDMonsterSkill>();
		monsterSkillHits = reader.ReadPDPacketDatas<WPDMonsterSkillHit>();
		monsterOwnSkills = reader.ReadPDPacketDatas<WPDMonsterOwnSkill>();
		abnormalStates = reader.ReadPDPacketDatas<WPDAbnormalState>();
		abnormalStateLevels = reader.ReadPDPacketDatas<WPDAbnormalStateLevel>();
		jobLevelMasters = reader.ReadPDPacketDatas<WPDJobLevelMaster>();
		jobLevels = reader.ReadPDPacketDatas<WPDJobLevel>();
		expRewards = reader.ReadPDPacketDatas<WPDExpReward>();
		goldRewards = reader.ReadPDPacketDatas<WPDGoldReward>();
		itemRewards = reader.ReadPDPacketDatas<WPDItemReward>();
		attrValues = reader.ReadPDPacketDatas<WPDAttrValue>();
		monsterArranges = reader.ReadPDPacketDatas<WPDMonsterArrange>();
		simpleShopProducts = reader.ReadPDPacketDatas<WPDSimpleShopProduct>();
		vipLevels = reader.ReadPDPacketDatas<WPDVipLevel>();
		inventorySlotExtendRecipes = reader.ReadPDPacketDatas<WPDInventorySlotExtendRecipe>();
		mainGearDisassembleAvailableResultEntries = reader.ReadPDPacketDatas<WPDMainGearDisassembleAvailableResultEntry>();
		itemCompositionRecipes = reader.ReadPDPacketDatas<WPDItemCompositionRecipe>();
		restRewardTimes = reader.ReadPDPacketDatas<WPDRestRewardTime>();
		chattingTypes = reader.ReadPDPacketDatas<WPDChattingType>();
		mainQuestDungeons = reader.ReadPDPacketDatas<WPDMainQuestDungeon>();
		mainQuestDungeonObstacles = reader.ReadPDPacketDatas<WPDMainQuestDungeonObstacle>();
		mainQuestDungeonSteps = reader.ReadPDPacketDatas<WPDMainQuestDungeonStep>();
		mainQuestDungeonGuides = reader.ReadPDPacketDatas<WPDMainQuestDungeonGuide>();
		levelUpRewardEntries = reader.ReadPDPacketDatas<WPDLevelUpRewardEntry>();
		levelUpRewardItems = reader.ReadPDPacketDatas<WPDLevelUpRewardItem>();
		dailyAttendRewardEntries = reader.ReadPDPacketDatas<WPDDailyAttendRewardEntry>();
		weekendAttendRewardAvailableDayOfWeeks = reader.ReadPDPacketDatas<WPDWeekendAttendRewardAvailableDayOfWeek>();
		accessRewardEntries = reader.ReadPDPacketDatas<WPDAccessRewardEntry>();
		accessRewardItems = reader.ReadPDPacketDatas<WPDAccessRewardItem>();
		vipLevelRewards = reader.ReadPDPacketDatas<WPDVipLevelReward>();
		mounts = reader.ReadPDPacketDatas<WPDMount>();
		mountQualityMasters = reader.ReadPDPacketDatas<WPDMountQualityMaster>();
		mountLevelMasters = reader.ReadPDPacketDatas<WPDMountLevelMaster>();
		mountQualities = reader.ReadPDPacketDatas<WPDMountQuality>();
		mountLevels = reader.ReadPDPacketDatas<WPDMountLevel>();
		mountGearTypes = reader.ReadPDPacketDatas<WPDMountGearType>();
		mountGearSlots = reader.ReadPDPacketDatas<WPDMountGearSlot>();
		mountGears = reader.ReadPDPacketDatas<WPDMountGear>();
		mountGearGrades = reader.ReadPDPacketDatas<WPDMountGearGrade>();
		mountGearQualities = reader.ReadPDPacketDatas<WPDMountGearQuality>();
		mountGearOptionAttrGrades = reader.ReadPDPacketDatas<WPDMountGearOptionAttrGrade>();
		mountGearPickBoxRecipes = reader.ReadPDPacketDatas<WPDMountGearPickBoxRecipe>();
		storyDungeons = reader.ReadPDPacketDatas<WPDStoryDungeon>();
		storyDungeonDifficulties = reader.ReadPDPacketDatas<WPDStoryDungeonDifficulty>();
		storyDungeonObstacles = reader.ReadPDPacketDatas<WPDStoryDungeonObstacle>();
		storyDungeonAvailableRewards = reader.ReadPDPacketDatas<WPDStoryDungeonAvailableReward>();
		storyDungeonSteps = reader.ReadPDPacketDatas<WPDStoryDungeonStep>();
		storyDungeonGuides = reader.ReadPDPacketDatas<WPDStoryDungeonGuide>();
		storyDungeonTraps = reader.ReadPDPacketDatas<WPDStoryDungeonTrap>();
		wingSteps = reader.ReadPDPacketDatas<WPDWingStep>();
		wingStepParts = reader.ReadPDPacketDatas<WPDWingStepPart>();
		wingParts = reader.ReadPDPacketDatas<WPDWingPart>();
		wingStepLevels = reader.ReadPDPacketDatas<WPDWingStepLevel>();
		wings = reader.ReadPDPacketDatas<WPDWing>();
		staminaBuyCounts = reader.ReadPDPacketDatas<WPDStaminaBuyCount>();
		expDungeon = reader.ReadPDPacketData<WPDExpDungeon>();
		expDungeonDifficulties = reader.ReadPDPacketDatas<WPDExpDungeonDifficulty>();
		expDungeonDifficultyWaves = reader.ReadPDPacketDatas<WPDExpDungeonDifficultyWave>();
		goldDungeon = reader.ReadPDPacketData<WPDGoldDungeon>();
		goldDungeonDifficulties = reader.ReadPDPacketDatas<WPDGoldDungeonDifficulty>();
		goldDungeonSteps = reader.ReadPDPacketDatas<WPDGoldDungeonStep>();
		goldDungeonStepWaves = reader.ReadPDPacketDatas<WPDGoldDungeonStepWave>();
		goldDungeonStepMonsterArranges = reader.ReadPDPacketDatas<WPDGoldDungeonStepMonsterArrange>();
		mainGearEnchantLevelSets = reader.ReadPDPacketDatas<WPDMainGearEnchantLevelSet>();
		mainGearEnchantLevelSetAttrs = reader.ReadPDPacketDatas<WPDMainGearEnchantLevelSetAttr>();
		mainGearSets = reader.ReadPDPacketDatas<WPDMainGearSet>();
		mainGearSetAttrs = reader.ReadPDPacketDatas<WPDMainGearSetAttr>();
		subGearSoulstoneLevelSets = reader.ReadPDPacketDatas<WPDSubGearSoulstoneLevelSet>();
		subGearSoulstoneLevelSetAttrs = reader.ReadPDPacketDatas<WPDSubGearSoulstoneLevelSetAttr>();
		cartGrades = reader.ReadPDPacketDatas<WPDCartGrade>();
		carts = reader.ReadPDPacketDatas<WPDCart>();
		worldLevelExpFactors = reader.ReadPDPacketDatas<WPDWorldLevelExpFactor>();
		locationAreas = reader.ReadPDPacketDatas<WPDLocationArea>();
		continentMapMonsters = reader.ReadPDPacketDatas<WPDContinentMapMonster>();
		treatOfFarmQuest = reader.ReadPDPacketData<WPDTreatOfFarmQuest>();
		treatOfFarmQuestMissions = reader.ReadPDPacketDatas<WPDTreatOfFarmQuestMission>();
		treatOfFarmQuestRewards = reader.ReadPDPacketDatas<WPDTreatOfFarmQuestReward>();
		continentTransmissionExits = reader.ReadPDPacketDatas<WPDContinentTransmissionExit>();
		undergroundMaze = reader.ReadPDPacketData<WPDUndergroundMaze>();
		undergroundMazeEntrances = reader.ReadPDPacketDatas<WPDUndergroundMazeEntrance>();
		undergroundMazeFloors = reader.ReadPDPacketDatas<WPDUndergroundMazeFloor>();
		undergroundMazePortals = reader.ReadPDPacketDatas<WPDUndergroundMazePortal>();
		undergroundMazeMapMonsters = reader.ReadPDPacketDatas<WPDUndergroundMazeMapMonster>();
		undergroundMazeNpcs = reader.ReadPDPacketDatas<WPDUndergroundMazeNpc>();
		undergroundMazeNpcTransmissionEntries = reader.ReadPDPacketDatas<WPDUndergroundMazeNpcTransmissionEntry>();
		undergroundMazeMonsterArranges = reader.ReadPDPacketDatas<WPDUndergroundMazeMonsterArrange>();
		bountyHunterQuests = reader.ReadPDPacketDatas<WPDBountyHunterQuest>();
		bountyHunterQuestRewards = reader.ReadPDPacketDatas<WPDBountyHunterQuestReward>();
		fishingQuest = reader.ReadPDPacketData<WPDFishingQuest>();
		fishingQuestSpots = reader.ReadPDPacketDatas<WPDFishingQuestSpot>();
		secretLetterQuest = reader.ReadPDPacketData<WPDSecretLetterQuest>();
		secretLetterQuestRewards = reader.ReadPDPacketDatas<WPDSecretLetterQuestReward>();
		secretLetterGrades = reader.ReadPDPacketDatas<WPDSecretLetterGrade>();
		mysteryBoxQuest = reader.ReadPDPacketData<WPDMysteryBoxQuest>();
		mysteryBoxQuestRewards = reader.ReadPDPacketDatas<WPDMysteryBoxQuestReward>();
		mysteryBoxGrades = reader.ReadPDPacketDatas<WPDMysteryBoxGrade>();
		exploitPointRewards = reader.ReadPDPacketDatas<WPDExploitPointReward>();
		artifactRoom = reader.ReadPDPacketData<WPDArtifactRoom>();
		artifactRoomFloors = reader.ReadPDPacketDatas<WPDArtifactRoomFloor>();
		todayMissions = reader.ReadPDPacketDatas<WPDTodayMission>();
		todayMissionRewards = reader.ReadPDPacketDatas<WPDTodayMissionReward>();
		seriesMissions = reader.ReadPDPacketDatas<WPDSeriesMission>();
		seriesMissionSteps = reader.ReadPDPacketDatas<WPDSeriesMissionStep>();
		seriesMissionStepRewards = reader.ReadPDPacketDatas<WPDSeriesMissionStepReward>();
		ancientRelic = reader.ReadPDPacketData<WPDAncientRelic>();
		ancientRelicObstacles = reader.ReadPDPacketDatas<WPDAncientRelicObstacle>();
		ancientRelicAvailableRewards = reader.ReadPDPacketDatas<WPDAncientRelicAvailableReward>();
		ancientRelicTraps = reader.ReadPDPacketDatas<WPDAncientRelicTrap>();
		ancientRelicSteps = reader.ReadPDPacketDatas<WPDAncientRelicStep>();
		ancientRelicStepWaves = reader.ReadPDPacketDatas<WPDAncientRelicStepWave>();
		ancientRelicStepRoutes = reader.ReadPDPacketDatas<WPDAncientRelicStepRoute>();
		ancientRelicMonsterSkillCastingGuides = reader.ReadPDPacketDatas<WPDAncientRelicMonsterSkillCastingGuide>();
		todayTaskCategories = reader.ReadPDPacketDatas<WPDTodayTaskCategory>();
		todayTasks = reader.ReadPDPacketDatas<WPDTodayTask>();
		todayTaskAvailableRewards = reader.ReadPDPacketDatas<WPDTodayTaskAvailableReward>();
		achievementRewards = reader.ReadPDPacketDatas<WPDAchievementReward>();
		achievementRewardEntries = reader.ReadPDPacketDatas<WPDAchievementRewardEntry>();
		dimensionInfiltrationEvent = reader.ReadPDPacketData<WPDDimensionInfiltrationEvent>();
		dimensionRaidQuest = reader.ReadPDPacketData<WPDDimensionRaidQuest>();
		dimensionRaidQuestSteps = reader.ReadPDPacketDatas<WPDDimensionRaidQuestStep>();
		dimensionRaidQuestRewards = reader.ReadPDPacketDatas<WPDDimensionRaidQuestReward>();
		holyWarQuest = reader.ReadPDPacketData<WPDHolyWarQuest>();
		holyWarQuestSchedules = reader.ReadPDPacketDatas<WPDHolyWarQuestSchedule>();
		holyWarQuestGloryLevels = reader.ReadPDPacketDatas<WPDHolyWarQuestGloryLevel>();
		honorPointRewards = reader.ReadPDPacketDatas<WPDHonorPointReward>();
		fieldOfHonor = reader.ReadPDPacketData<WPDFieldOfHonor>();
		fieldOfHonorRankingRewards = reader.ReadPDPacketDatas<WPDFieldOfHonorRankingReward>();
		honorShopProducts = reader.ReadPDPacketDatas<WPDHonorShopProduct>();
		ranks = reader.ReadPDPacketDatas<WPDRank>();
		rankAttrs = reader.ReadPDPacketDatas<WPDRankAttr>();
		rankRewards = reader.ReadPDPacketDatas<WPDRankReward>();
		battlefieldSupportEvent = reader.ReadPDPacketData<WPDBattlefieldSupportEvent>();
		levelRankingRewards = reader.ReadPDPacketDatas<WPDLevelRankingReward>();
		contentOpenEntries = reader.ReadPDPacketDatas<WPDContentOpenEntry>();
		attainmentEntries = reader.ReadPDPacketDatas<WPDAttainmentEntry>();
		attainmentEntryRewards = reader.ReadPDPacketDatas<WPDAttainmentEntryReward>();
		menus = reader.ReadPDPacketDatas<WPDMenu>();
		menuContents = reader.ReadPDPacketDatas<WPDMenuContent>();
		guildLevels = reader.ReadPDPacketDatas<WPDGuildLevel>();
		guildMemberGrades = reader.ReadPDPacketDatas<WPDGuildMemberGrade>();
		supplySupportQuest = reader.ReadPDPacketData<WPDSupplySupportQuest>();
		supplySupportQuestOrders = reader.ReadPDPacketDatas<WPDSupplySupportQuestOrder>();
		supplySupportQuestWayPoints = reader.ReadPDPacketDatas<WPDSupplySupportQuestWayPoint>();
		supplySupportQuestCarts = reader.ReadPDPacketDatas<WPDSupplySupportQuestCart>();
		holyWarQuestRewards = reader.ReadPDPacketDatas<WPDHolyWarQuestReward>();
		supplySupportQuestRewards = reader.ReadPDPacketDatas<WPDSupplySupportQuestReward>();
		nationDonationEntries = reader.ReadPDPacketDatas<WPDNationDonationEntry>();
		nationNoblesses = reader.ReadPDPacketDatas<WPDNationNoblesse>();
		nationNoblesseAttrs = reader.ReadPDPacketDatas<WPDNationNoblesseAttr>();
		nationFundRewards = reader.ReadPDPacketDatas<WPDNationFundReward>();
		guildContributionPointRewards = reader.ReadPDPacketDatas<WPDGuildContributionPointReward>();
		guildBuildingPointRewards = reader.ReadPDPacketDatas<WPDGuildBuildingPointReward>();
		guildFundRewards = reader.ReadPDPacketDatas<WPDGuildFundReward>();
		guildPointRewards = reader.ReadPDPacketDatas<WPDGuildPointReward>();
		guildDonationEntries = reader.ReadPDPacketDatas<WPDGuildDonationEntry>();
		nationWar = reader.ReadPDPacketData<WPDNationWar>();
		nationWarAvailableDayOfWeeks = reader.ReadPDPacketDatas<WPDNationWarAvailableDayOfWeek>();
		nationWarRevivalPoints = reader.ReadPDPacketDatas<WPDNationWarRevivalPoint>();
		nationWarRevivalPointActivationConditions = reader.ReadPDPacketDatas<WPDNationWarRevivalPointActivationCondition>();
		nationWarMonsterArranges = reader.ReadPDPacketDatas<WPDNationWarMonsterArrange>();
		nationWarNpcs = reader.ReadPDPacketDatas<WPDNationWarNpc>();
		nationWarTransmissionExits = reader.ReadPDPacketDatas<WPDNationWarTransmissionExit>();
		nationWarPaidTransmissions = reader.ReadPDPacketDatas<WPDNationWarPaidTransmission>();
		nationWarHeroObjectiveEntries = reader.ReadPDPacketDatas<WPDNationWarHeroObjectiveEntry>();
		nationWarExpRewards = reader.ReadPDPacketDatas<WPDNationWarExpReward>();
		guildBuildings = reader.ReadPDPacketDatas<WPDGuildBuilding>();
		guildBuildingLevels = reader.ReadPDPacketDatas<WPDGuildBuildingLevel>();
		guildSkills = reader.ReadPDPacketDatas<WPDGuildSkill>();
		guildSkillAttrs = reader.ReadPDPacketDatas<WPDGuildSkillAttr>();
		guildSkillLevels = reader.ReadPDPacketDatas<WPDGuildSkillLevel>();
		guildSkillLevelAttrValues = reader.ReadPDPacketDatas<WPDGuildSkillLevelAttrValue>();
		guildAltar = reader.ReadPDPacketData<WPDGuildAltar>();
		guildAltarDefenseMonsterAttrFactors = reader.ReadPDPacketDatas<WPDGuildAltarDefenseMonsterAttrFactor>();
		guildTerritory = reader.ReadPDPacketData<WPDGuildTerritory>();
		guildTerritoryNpcs = reader.ReadPDPacketDatas<WPDGuildTerritoryNpc>();
		guildFarmQuest = reader.ReadPDPacketData<WPDGuildFarmQuest>();
		guildFarmQuestRewards = reader.ReadPDPacketDatas<WPDGuildFarmQuestReward>();
		guildFoodWarehouse = reader.ReadPDPacketData<WPDGuildFoodWarehouse>();
		guildFoodWarehouseLevels = reader.ReadPDPacketDatas<WPDGuildFoodWarehouseLevel>();
		guildMissionQuest = reader.ReadPDPacketData<WPDGuildMissionQuest>();
		guildMissionQuestRewards = reader.ReadPDPacketDatas<WPDGuildMissionQuestReward>();
		guildMissions = reader.ReadPDPacketDatas<WPDGuildMission>();
		guildSupplySupportQuest = reader.ReadPDPacketData<WPDGuildSupplySupportQuest>();
		guildSupplySupportQuestRewards = reader.ReadPDPacketDatas<WPDGuildSupplySupportQuestReward>();
		nationNoblesseAppointmentAuthorities = reader.ReadPDPacketDatas<WPDNationNoblesseAppointmentAuthority>();
		menuContentTutorialSteps = reader.ReadPDPacketDatas<WPDMenuContentTutorialStep>();
		guildContents = reader.ReadPDPacketDatas<WPDGuildContent>();
		guildDailyObjectiveRewards = reader.ReadPDPacketDatas<WPDGuildDailyObjectiveReward>();
		guildHuntingQuest = reader.ReadPDPacketData<WPDGuildHuntingQuest>();
		guildHuntingQuestObjectives = reader.ReadPDPacketDatas<WPDGuildHuntingQuestObjective>();
		soulCoveter = reader.ReadPDPacketData<WPDSoulCoveter>();
		soulCoveterAvailableRewards = reader.ReadPDPacketDatas<WPDSoulCoveterAvailableReward>();
		soulCoveterObstacles = reader.ReadPDPacketDatas<WPDSoulCoveterObstacle>();
		soulCoveterDifficulties = reader.ReadPDPacketDatas<WPDSoulCoveterDifficulty>();
		soulCoveterDifficultyWaves = reader.ReadPDPacketDatas<WPDSoulCoveterDifficultyWave>();
		clientTutorialSteps = reader.ReadPDPacketDatas<WPDClientTutorialStep>();
		guildWeeklyObjectives = reader.ReadPDPacketDatas<WPDGuildWeeklyObjective>();
		ownDiaRewards = reader.ReadPDPacketDatas<WPDOwnDiaReward>();
		accomplishmentCategories = reader.ReadPDPacketDatas<WPDAccomplishmentCategory>();
		accomplishments = reader.ReadPDPacketDatas<WPDAccomplishment>();
		titleCategories = reader.ReadPDPacketDatas<WPDTitleCategory>();
		titleTypes = reader.ReadPDPacketDatas<WPDTitleType>();
		titles = reader.ReadPDPacketDatas<WPDTitle>();
		titleGrades = reader.ReadPDPacketDatas<WPDTitleGrade>();
		titleActiveAttrs = reader.ReadPDPacketDatas<WPDTitleActiveAttr>();
		titlePassiveAttrs = reader.ReadPDPacketDatas<WPDTitlePassiveAttr>();
		illustratedBookCategories = reader.ReadPDPacketDatas<WPDIllustratedBookCategory>();
		illustratedBookTypes = reader.ReadPDPacketDatas<WPDIllustratedBookType>();
		illustratedBooks = reader.ReadPDPacketDatas<WPDIllustratedBook>();
		illustratedBookAttrs = reader.ReadPDPacketDatas<WPDIllustratedBookAttr>();
		illustratedBookAttrGrades = reader.ReadPDPacketDatas<WPDIllustratedBookAttrGrade>();
		illustratedBookExplorationSteps = reader.ReadPDPacketDatas<WPDIllustratedBookExplorationStep>();
		illustratedBookExplorationStepAttrs = reader.ReadPDPacketDatas<WPDIllustratedBookExplorationStepAttr>();
		illustratedBookExplorationStepRewards = reader.ReadPDPacketDatas<WPDIllustratedBookExplorationStepReward>();
		sceneryQuests = reader.ReadPDPacketDatas<WPDSceneryQuest>();
		eliteMonsterCategories = reader.ReadPDPacketDatas<WPDEliteMonsterCategory>();
		eliteMonsterMasters = reader.ReadPDPacketDatas<WPDEliteMonsterMaster>();
		eliteMonsters = reader.ReadPDPacketDatas<WPDEliteMonster>();
		eliteMonsterKillAttrValues = reader.ReadPDPacketDatas<WPDEliteMonsterKillAttrValue>();
		eliteMonsterSpawnSchedules = reader.ReadPDPacketDatas<WPDEliteMonsterSpawnSchedule>();
		eliteDungeon = reader.ReadPDPacketData<WPDEliteDungeon>();
		creatureCardCategories = reader.ReadPDPacketDatas<WPDCreatureCardCategory>();
		creatureCards = reader.ReadPDPacketDatas<WPDCreatureCard>();
		creatureCardGrades = reader.ReadPDPacketDatas<WPDCreatureCardGrade>();
		creatureCardCollectionEntries = reader.ReadPDPacketDatas<WPDCreatureCardCollectionEntry>();
		creatureCardCollectionCategories = reader.ReadPDPacketDatas<WPDCreatureCardCollectionCategory>();
		creatureCardCollections = reader.ReadPDPacketDatas<WPDCreatureCardCollection>();
		creatureCardCollectionAttrs = reader.ReadPDPacketDatas<WPDCreatureCardCollectionAttr>();
		creatureCardCollectionGrades = reader.ReadPDPacketDatas<WPDCreatureCardCollectionGrade>();
		creatureCardShopRefreshSchedules = reader.ReadPDPacketDatas<WPDCreatureCardShopRefreshSchedule>();
		creatureCardShopFixedProducts = reader.ReadPDPacketDatas<WPDCreatureCardShopFixedProduct>();
		creatureCardShopRandomProducts = reader.ReadPDPacketDatas<WPDCreatureCardShopRandomProduct>();
		proofOfValor = reader.ReadPDPacketData<WPDProofOfValor>();
		proofOfValorBuffBoxs = reader.ReadPDPacketDatas<WPDProofOfValorBuffBox>();
		proofOfValorBuffBoxArranges = reader.ReadPDPacketDatas<WPDProofOfValorBuffBoxArrange>();
		proofOfValorBossMonsterArranges = reader.ReadPDPacketDatas<WPDProofOfValorBossMonsterArrange>();
		proofOfValorPaidRefreshs = reader.ReadPDPacketDatas<WPDProofOfValorPaidRefresh>();
		proofOfValorRefreshSchedules = reader.ReadPDPacketDatas<WPDProofOfValorRefreshSchedule>();
		proofOfValorRewards = reader.ReadPDPacketDatas<WPDProofOfValorReward>();
		proofOfValorClearGrades = reader.ReadPDPacketDatas<WPDProofOfValorClearGrade>();
		staminaRecoverySchedules = reader.ReadPDPacketDatas<WPDStaminaRecoverySchedule>();
		banWords = reader.ReadPDPacketDatas<WPDBanWord>();
		guildContentAvailableRewards = reader.ReadPDPacketDatas<WPDGuildContentAvailableReward>();
		menuContentOpenPreviews = reader.ReadPDPacketDatas<WPDMenuContentOpenPreview>();
		jobCommonSkills = reader.ReadPDPacketDatas<WPDJobCommonSkill>();
		npcShops = reader.ReadPDPacketDatas<WPDNpcShop>();
		npcShopCategories = reader.ReadPDPacketDatas<WPDNpcShopCategory>();
		npcShopProducts = reader.ReadPDPacketDatas<WPDNpcShopProduct>();
		abnormalStateRankSkillLevels = reader.ReadPDPacketDatas<WPDAbnormalStateRankSkillLevel>();
		rankActiveSkills = reader.ReadPDPacketDatas<WPDRankActiveSkill>();
		rankActiveSkillLevels = reader.ReadPDPacketDatas<WPDRankActiveSkillLevel>();
		rankPassiveSkills = reader.ReadPDPacketDatas<WPDRankPassiveSkill>();
		rankPassiveSkillAttrs = reader.ReadPDPacketDatas<WPDRankPassiveSkillAttr>();
		rankPassiveSkillLevels = reader.ReadPDPacketDatas<WPDRankPassiveSkillLevel>();
		rankPassiveSkillAttrLevels = reader.ReadPDPacketDatas<WPDRankPassiveSkillAttrLevel>();
		wisdomTemple = reader.ReadPDPacketData<WPDWisdomTemple>();
		wisdomTempleMonsterAttrFactors = reader.ReadPDPacketDatas<WPDWisdomTempleMonsterAttrFactor>();
		wisdomTempleColorMatchingObjects = reader.ReadPDPacketDatas<WPDWisdomTempleColorMatchingObject>();
		wisdomTempleArrangePositions = reader.ReadPDPacketDatas<WPDWisdomTempleArrangePosition>();
		wisdomTempleSweepRewards = reader.ReadPDPacketDatas<WPDWisdomTempleSweepReward>();
		wisdomTempleSteps = reader.ReadPDPacketDatas<WPDWisdomTempleStep>();
		wisdomTempleQuizMonsterPositions = reader.ReadPDPacketDatas<WPDWisdomTempleQuizMonsterPosition>();
		wisdomTempleQuizPoolEntries = reader.ReadPDPacketDatas<WPDWisdomTempleQuizPoolEntry>();
		wisdomTemplePuzzles = reader.ReadPDPacketDatas<WPDWisdomTemplePuzzle>();
		wisdomTempleStepRewards = reader.ReadPDPacketDatas<WPDWisdomTempleStepReward>();
		rookieGifts = reader.ReadPDPacketDatas<WPDRookieGift>();
		rookieGiftRewards = reader.ReadPDPacketDatas<WPDRookieGiftReward>();
		openGiftRewards = reader.ReadPDPacketDatas<WPDOpenGiftReward>();
		quickMenus = reader.ReadPDPacketDatas<WPDQuickMenu>();
		dailyQuest = reader.ReadPDPacketData<WPDDailyQuest>();
		dailyQuestRewards = reader.ReadPDPacketDatas<WPDDailyQuestReward>();
		dailyQuestGrades = reader.ReadPDPacketDatas<WPDDailyQuestGrade>();
		dailyQuestMissions = reader.ReadPDPacketDatas<WPDDailyQuestMission>();
		weeklyQuest = reader.ReadPDPacketData<WPDWeeklyQuest>();
		weeklyQuestRoundRewards = reader.ReadPDPacketDatas<WPDWeeklyQuestRoundReward>();
		weeklyQuestMissions = reader.ReadPDPacketDatas<WPDWeeklyQuestMission>();
		weeklyQuestTenRoundRewards = reader.ReadPDPacketDatas<WPDWeeklyQuestTenRoundReward>();
		ruinsReclaim = reader.ReadPDPacketData<WPDRuinsReclaim>();
		ruinsReclaimMonsterAttrFactors = reader.ReadPDPacketDatas<WPDRuinsReclaimMonsterAttrFactor>();
		ruinsReclaimAvailableRewards = reader.ReadPDPacketDatas<WPDRuinsReclaimAvailableReward>();
		ruinsReclaimRevivalPoints = reader.ReadPDPacketDatas<WPDRuinsReclaimRevivalPoint>();
		ruinsReclaimObstacles = reader.ReadPDPacketDatas<WPDRuinsReclaimObstacle>();
		ruinsReclaimTraps = reader.ReadPDPacketDatas<WPDRuinsReclaimTrap>();
		ruinsReclaimPortals = reader.ReadPDPacketDatas<WPDRuinsReclaimPortal>();
		ruinsReclaimOpenSchedules = reader.ReadPDPacketDatas<WPDRuinsReclaimOpenSchedule>();
		ruinsReclaimSteps = reader.ReadPDPacketDatas<WPDRuinsReclaimStep>();
		ruinsReclaimObjectArranges = reader.ReadPDPacketDatas<WPDRuinsReclaimObjectArrange>();
		ruinsReclaimStepRewards = reader.ReadPDPacketDatas<WPDRuinsReclaimStepReward>();
		ruinsReclaimStepWaves = reader.ReadPDPacketDatas<WPDRuinsReclaimStepWave>();
		ruinsReclaimStepWaveSkills = reader.ReadPDPacketDatas<WPDRuinsReclaimStepWaveSkill>();
		open7DayEventDaies = reader.ReadPDPacketDatas<WPDOpen7DayEventDay>();
		open7DayEventMissions = reader.ReadPDPacketDatas<WPDOpen7DayEventMission>();
		open7DayEventMissionRewards = reader.ReadPDPacketDatas<WPDOpen7DayEventMissionReward>();
		open7DayEventProducts = reader.ReadPDPacketDatas<WPDOpen7DayEventProduct>();
		retrievals = reader.ReadPDPacketDatas<WPDRetrieval>();
		retrievalRewards = reader.ReadPDPacketDatas<WPDRetrievalReward>();
		taskConsignments = reader.ReadPDPacketDatas<WPDTaskConsignment>();
		taskConsignmentAvailableRewards = reader.ReadPDPacketDatas<WPDTaskConsignmentAvailableReward>();
		taskConsignmentExpRewards = reader.ReadPDPacketDatas<WPDTaskConsignmentExpReward>();
		infiniteWar = reader.ReadPDPacketData<WPDInfiniteWar>();
		infiniteWarBuffBoxs = reader.ReadPDPacketDatas<WPDInfiniteWarBuffBox>();
		infiniteWarMonsterAttrFactors = reader.ReadPDPacketDatas<WPDInfiniteWarMonsterAttrFactor>();
		infiniteWarOpenSchedules = reader.ReadPDPacketDatas<WPDInfiniteWarOpenSchedule>();
		infiniteWarAvailableRewards = reader.ReadPDPacketDatas<WPDInfiniteWarAvailableReward>();
		trueHeroQuest = reader.ReadPDPacketData<WPDTrueHeroQuest>();
		trueHeroQuestSteps = reader.ReadPDPacketDatas<WPDTrueHeroQuestStep>();
		trueHeroQuestRewards = reader.ReadPDPacketDatas<WPDTrueHeroQuestReward>();
		ruinsReclaimRandomRewardPoolEntries = reader.ReadPDPacketDatas<WPDRuinsReclaimRandomRewardPoolEntry>();
		limitationGift = reader.ReadPDPacketData<WPDLimitationGift>();
		limitationGiftRewardDayOfWeeks = reader.ReadPDPacketDatas<WPDLimitationGiftRewardDayOfWeek>();
		limitationGiftRewardSchedules = reader.ReadPDPacketDatas<WPDLimitationGiftRewardSchedule>();
		limitationGiftAvailableRewards = reader.ReadPDPacketDatas<WPDLimitationGiftAvailableReward>();
		weekendReward = reader.ReadPDPacketData<WPDWeekendReward>();
		fieldBossEvent = reader.ReadPDPacketData<WPDFieldBossEvent>();
		fieldBossEventSchedules = reader.ReadPDPacketDatas<WPDFieldBossEventSchedule>();
		fieldBossEventAvailableRewards = reader.ReadPDPacketDatas<WPDFieldBossEventAvailableReward>();
		fieldBosss = reader.ReadPDPacketDatas<WPDFieldBoss>();
		warehouseSlotExtendRecipes = reader.ReadPDPacketDatas<WPDWarehouseSlotExtendRecipe>();
		fearAltar = reader.ReadPDPacketData<WPDFearAltar>();
		fearAltarRewards = reader.ReadPDPacketDatas<WPDFearAltarReward>();
		fearAltarHalidomCollectionRewards = reader.ReadPDPacketDatas<WPDFearAltarHalidomCollectionReward>();
		fearAltarHalidomElementals = reader.ReadPDPacketDatas<WPDFearAltarHalidomElemental>();
		fearAltarHalidomLevels = reader.ReadPDPacketDatas<WPDFearAltarHalidomLevel>();
		fearAltarHalidoms = reader.ReadPDPacketDatas<WPDFearAltarHalidom>();
		fearAltarStages = reader.ReadPDPacketDatas<WPDFearAltarStage>();
		fearAltarStageWaves = reader.ReadPDPacketDatas<WPDFearAltarStageWave>();
		diaShopCategories = reader.ReadPDPacketDatas<WPDDiaShopCategory>();
		diaShopProducts = reader.ReadPDPacketDatas<WPDDiaShopProduct>();
		wingMemoryPieceSlots = reader.ReadPDPacketDatas<WPDWingMemoryPieceSlot>();
		wingMemoryPieceSteps = reader.ReadPDPacketDatas<WPDWingMemoryPieceStep>();
		wingMemoryPieceSlotSteps = reader.ReadPDPacketDatas<WPDWingMemoryPieceSlotStep>();
		wingMemoryPieceTypes = reader.ReadPDPacketDatas<WPDWingMemoryPieceType>();
		warMemory = reader.ReadPDPacketData<WPDWarMemory>();
		warMemoryMonsterAttrFactors = reader.ReadPDPacketDatas<WPDWarMemoryMonsterAttrFactor>();
		warMemoryStartPositions = reader.ReadPDPacketDatas<WPDWarMemoryStartPosition>();
		warMemorySchedules = reader.ReadPDPacketDatas<WPDWarMemorySchedule>();
		warMemoryAvailableRewards = reader.ReadPDPacketDatas<WPDWarMemoryAvailableReward>();
		warMemoryRewards = reader.ReadPDPacketDatas<WPDWarMemoryReward>();
		warMemoryRankingRewards = reader.ReadPDPacketDatas<WPDWarMemoryRankingReward>();
		warMemoryWaves = reader.ReadPDPacketDatas<WPDWarMemoryWave>();
		warMemoryTransformationObjects = reader.ReadPDPacketDatas<WPDWarMemoryTransformationObject>();
		subQuests = reader.ReadPDPacketDatas<WPDSubQuest>();
		subQuestRewards = reader.ReadPDPacketDatas<WPDSubQuestReward>();
		osirisRoom = reader.ReadPDPacketData<WPDOsirisRoom>();
		osirisRoomAvailableRewards = reader.ReadPDPacketDatas<WPDOsirisRoomAvailableReward>();
		osirisRoomDifficulties = reader.ReadPDPacketDatas<WPDOsirisRoomDifficulty>();
		osirisRoomDifficultyWaves = reader.ReadPDPacketDatas<WPDOsirisRoomDifficultyWave>();
		ordealQuests = reader.ReadPDPacketDatas<WPDOrdealQuest>();
		ordealQuestMissions = reader.ReadPDPacketDatas<WPDOrdealQuestMission>();
		moneyBuffs = reader.ReadPDPacketDatas<WPDMoneyBuff>();
		moneyBuffAttrs = reader.ReadPDPacketDatas<WPDMoneyBuffAttr>();
		biographies = reader.ReadPDPacketDatas<WPDBiography>();
		biographyRewards = reader.ReadPDPacketDatas<WPDBiographyReward>();
		biographyQuests = reader.ReadPDPacketDatas<WPDBiographyQuest>();
		biographyQuestStartDialogues = reader.ReadPDPacketDatas<WPDBiographyQuestStartDialogue>();
		biographyQuestDungeons = reader.ReadPDPacketDatas<WPDBiographyQuestDungeon>();
		biographyQuestDungeonWaves = reader.ReadPDPacketDatas<WPDBiographyQuestDungeonWave>();
		blessings = reader.ReadPDPacketDatas<WPDBlessing>();
		blessingTargetLevels = reader.ReadPDPacketDatas<WPDBlessingTargetLevel>();
		prospectQuestOwnerRewards = reader.ReadPDPacketDatas<WPDProspectQuestOwnerReward>();
		prospectQuestTargetRewards = reader.ReadPDPacketDatas<WPDProspectQuestTargetReward>();
		itemLuckyShop = reader.ReadPDPacketData<WPDItemLuckyShop>();
		creatureCardLuckyShop = reader.ReadPDPacketData<WPDCreatureCardLuckyShop>();
		creatureCharacters = reader.ReadPDPacketDatas<WPDCreatureCharacter>();
		creatureGrades = reader.ReadPDPacketDatas<WPDCreatureGrade>();
		creatures = reader.ReadPDPacketDatas<WPDCreature>();
		creatureSkillGrades = reader.ReadPDPacketDatas<WPDCreatureSkillGrade>();
		creatureSkills = reader.ReadPDPacketDatas<WPDCreatureSkill>();
		creatureSkillAttrs = reader.ReadPDPacketDatas<WPDCreatureSkillAttr>();
		creatureBaseAttrs = reader.ReadPDPacketDatas<WPDCreatureBaseAttr>();
		creatureLevels = reader.ReadPDPacketDatas<WPDCreatureLevel>();
		creatureBaseAttrValues = reader.ReadPDPacketDatas<WPDCreatureBaseAttrValue>();
		creatureAdditionalAttrs = reader.ReadPDPacketDatas<WPDCreatureAdditionalAttr>();
		creatureInjectionLevels = reader.ReadPDPacketDatas<WPDCreatureInjectionLevel>();
		creatureAdditionalAttrValues = reader.ReadPDPacketDatas<WPDCreatureAdditionalAttrValue>();
		creatureSkillSlotOpenRecipes = reader.ReadPDPacketDatas<WPDCreatureSkillSlotOpenRecipe>();
		creatureSkillSlotProtections = reader.ReadPDPacketDatas<WPDCreatureSkillSlotProtection>();
		dragonNest = reader.ReadPDPacketData<WPDDragonNest>();
		dragonNestAvailableRewards = reader.ReadPDPacketDatas<WPDDragonNestAvailableReward>();
		dragonNestObstacles = reader.ReadPDPacketDatas<WPDDragonNestObstacle>();
		dragonNestTraps = reader.ReadPDPacketDatas<WPDDragonNestTrap>();
		dragonNestSteps = reader.ReadPDPacketDatas<WPDDragonNestStep>();
		dragonNestStepRewards = reader.ReadPDPacketDatas<WPDDragonNestStepReward>();
		presents = reader.ReadPDPacketDatas<WPDPresent>();
		weeklyPresentPopularityPointRankingRewardGroups = reader.ReadPDPacketDatas<WPDWeeklyPresentPopularityPointRankingRewardGroup>();
		weeklyPresentPopularityPointRankingRewards = reader.ReadPDPacketDatas<WPDWeeklyPresentPopularityPointRankingReward>();
		weeklyPresentContributionPointRankingRewardGroups = reader.ReadPDPacketDatas<WPDWeeklyPresentContributionPointRankingRewardGroup>();
		weeklyPresentContributionPointRankingRewards = reader.ReadPDPacketDatas<WPDWeeklyPresentContributionPointRankingReward>();
		mainQuestStartDialogues = reader.ReadPDPacketDatas<WPDMainQuestStartDialogue>();
		mainQuestCompletionDialogues = reader.ReadPDPacketDatas<WPDMainQuestCompletionDialogue>();
		creatureFarmQuest = reader.ReadPDPacketData<WPDCreatureFarmQuest>();
		creatureFarmQuestExpRewards = reader.ReadPDPacketDatas<WPDCreatureFarmQuestExpReward>();
		creatureFarmQuestItemRewards = reader.ReadPDPacketDatas<WPDCreatureFarmQuestItemReward>();
		creatureFarmQuestMissions = reader.ReadPDPacketDatas<WPDCreatureFarmQuestMission>();
		costumes = reader.ReadPDPacketDatas<WPDCostume>();
		costumeEffects = reader.ReadPDPacketDatas<WPDCostumeEffect>();
		safeTimeEvent = reader.ReadPDPacketData<WPDSafeTimeEvent>();
		fishingQuestGuildTerritorySpots = reader.ReadPDPacketDatas<WPDFishingQuestGuildTerritorySpot>();
		guildBlessingBuffs = reader.ReadPDPacketDatas<WPDGuildBlessingBuff>();
		inAppProducts = reader.ReadPDPacketDatas<WPDInAppProduct>();
		inAppProductPrices = reader.ReadPDPacketDatas<WPDInAppProductPrice>();
		cashProducts = reader.ReadPDPacketDatas<WPDCashProduct>();
		jobChangeQuests = reader.ReadPDPacketDatas<WPDJobChangeQuest>();
		jobChangeQuestDifficulties = reader.ReadPDPacketDatas<WPDJobChangeQuestDifficulty>();
		firstChargeEvent = reader.ReadPDPacketData<WPDFirstChargeEvent>();
		firstChargeEventRewards = reader.ReadPDPacketDatas<WPDFirstChargeEventReward>();
		rechargeEvent = reader.ReadPDPacketData<WPDRechargeEvent>();
		rechargeEventRewards = reader.ReadPDPacketDatas<WPDRechargeEventReward>();
		chargeEvents = reader.ReadPDPacketDatas<WPDChargeEvent>();
		chargeEventMissions = reader.ReadPDPacketDatas<WPDChargeEventMission>();
		ankouTomb = reader.ReadPDPacketData<WPDAnkouTomb>();
		ankouTombSchedules = reader.ReadPDPacketDatas<WPDAnkouTombSchedule>();
		ankouTombDifficulties = reader.ReadPDPacketDatas<WPDAnkouTombDifficulty>();
		ankouTombAvailableRewards = reader.ReadPDPacketDatas<WPDAnkouTombAvailableReward>();
		potionAttrs = reader.ReadPDPacketDatas<WPDPotionAttr>();
		recommendBattlePowerLevels = reader.ReadPDPacketDatas<WPDRecommendBattlePowerLevel>();
		improvementMainCategories = reader.ReadPDPacketDatas<WPDImprovementMainCategory>();
		improvementMainCategoryContents = reader.ReadPDPacketDatas<WPDImprovementMainCategoryContent>();
		improvementSubCategories = reader.ReadPDPacketDatas<WPDImprovementSubCategory>();
		improvementSubCategoryContents = reader.ReadPDPacketDatas<WPDImprovementSubCategoryContent>();
		improvementContents = reader.ReadPDPacketDatas<WPDImprovementContent>();
		improvementContentAchievementLevels = reader.ReadPDPacketDatas<WPDImprovementContentAchievementLevel>();
		improvementContentAchievements = reader.ReadPDPacketDatas<WPDImprovementContentAchievement>();
		constellations = reader.ReadPDPacketDatas<WPDConstellation>();
		constellationSteps = reader.ReadPDPacketDatas<WPDConstellationStep>();
		constellationCycles = reader.ReadPDPacketDatas<WPDConstellationCycle>();
		constellationCycleBuffs = reader.ReadPDPacketDatas<WPDConstellationCycleBuff>();
		constellationEntries = reader.ReadPDPacketDatas<WPDConstellationEntry>();
		constellationEntryBuffs = reader.ReadPDPacketDatas<WPDConstellationEntryBuff>();
		chargeEventMissionRewards = reader.ReadPDPacketDatas<WPDChargeEventMissionReward>();
		dailyChargeEvent = reader.ReadPDPacketData<WPDDailyChargeEvent>();
		dailyChargeEventMissions = reader.ReadPDPacketDatas<WPDDailyChargeEventMission>();
		dailyChargeEventMissionRewards = reader.ReadPDPacketDatas<WPDDailyChargeEventMissionReward>();
		consumeEvents = reader.ReadPDPacketDatas<WPDConsumeEvent>();
		consumeEventMissions = reader.ReadPDPacketDatas<WPDConsumeEventMission>();
		consumeEventMissionRewards = reader.ReadPDPacketDatas<WPDConsumeEventMissionReward>();
		dailyConsumeEvent = reader.ReadPDPacketData<WPDDailyConsumeEvent>();
		dailyConsumeEventMissions = reader.ReadPDPacketDatas<WPDDailyConsumeEventMission>();
		dailyConsumeEventMissionRewards = reader.ReadPDPacketDatas<WPDDailyConsumeEventMissionReward>();
		artifacts = reader.ReadPDPacketDatas<WPDArtifact>();
		artifactAttrs = reader.ReadPDPacketDatas<WPDArtifactAttr>();
		artifactLevels = reader.ReadPDPacketDatas<WPDArtifactLevel>();
		artifactLevelAttrs = reader.ReadPDPacketDatas<WPDArtifactLevelAttr>();
		artifactLevelUpMaterials = reader.ReadPDPacketDatas<WPDArtifactLevelUpMaterial>();
		tradeShip = reader.ReadPDPacketData<WPDTradeShip>();
		tradeShipSchedules = reader.ReadPDPacketDatas<WPDTradeShipSchedule>();
		tradeShipObstacles = reader.ReadPDPacketDatas<WPDTradeShipObstacle>();
		tradeShipSteps = reader.ReadPDPacketDatas<WPDTradeShipStep>();
		tradeShipDifficulties = reader.ReadPDPacketDatas<WPDTradeShipDifficulty>();
		tradeShipAvailableRewards = reader.ReadPDPacketDatas<WPDTradeShipAvailableReward>();
		tradeShipObjects = reader.ReadPDPacketDatas<WPDTradeShipObject>();
		mountAwakeningLevelMasters = reader.ReadPDPacketDatas<WPDMountAwakeningLevelMaster>();
		mountAwakeningLevels = reader.ReadPDPacketDatas<WPDMountAwakeningLevel>();
		mountPotionAttrCounts = reader.ReadPDPacketDatas<WPDMountPotionAttrCount>();
		costumeDisplays = reader.ReadPDPacketDatas<WPDCostumeDisplay>();
		costumeCollections = reader.ReadPDPacketDatas<WPDCostumeCollection>();
		costumeCollectionAttrs = reader.ReadPDPacketDatas<WPDCostumeCollectionAttr>();
		costumeCollectionEntries = reader.ReadPDPacketDatas<WPDCostumeCollectionEntry>();
		costumeAttrs = reader.ReadPDPacketDatas<WPDCostumeAttr>();
		costumeEnchantLevels = reader.ReadPDPacketDatas<WPDCostumeEnchantLevel>();
		costumeEnchantLevelAttrs = reader.ReadPDPacketDatas<WPDCostumeEnchantLevelAttr>();
		scheduleNotices = reader.ReadPDPacketDatas<WPDScheduleNotice>();
		sharingEvents = reader.ReadPDPacketDatas<WPDSharingEvent>();
		systemMessages = reader.ReadPDPacketDatas<WPDSystemMessage>();
		sharingEventSenderRewards = reader.ReadPDPacketDatas<WPDSharingEventSenderReward>();
		sharingEventReceiverRewards = reader.ReadPDPacketDatas<WPDSharingEventReceiverReward>();
	}

	public string SerializeBase64String()
	{
		byte[] result;
		using (MemoryStream stream = new MemoryStream())
		{
			WPacketWriter writer = new WPacketWriter(stream);
			Serialize(writer);
			result = stream.ToArray();
		}
		return Convert.ToBase64String(result);
	}

	public void DeserializeFromBase64String(string sData)
	{
		byte[] data = Convert.FromBase64String(sData);
		using MemoryStream stream = new MemoryStream(data);
		WPacketReader reader = new WPacketReader(stream);
		Deserialize(reader);
	}
}
