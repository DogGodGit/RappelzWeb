using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using WebCommon;

/// <summary>
/// MakeGameMetaData'的摘要描述.
/// </summary>
public class MakeGameMetaData
{
	public MakeGameMetaData()
	{
		//
		// TODO: 여기에 생성자 논리를 추가합니다.
		//
	}

	public static string GameMetaData()
	{
		SqlConnection conn = null;

		try
		{
			//===============================================================================================
			// 连接到一个数据库
			//===============================================================================================
			conn = DBUtil.GetUserConnection();
			conn.Open();

			//===============================================================================================
			// 조회
			//===============================================================================================
			DataRowCollection drcJobs = Dac.Jobs(conn, null);
			DataRowCollection drcNations = Dac.Nations(conn, null);
			DataRowCollection drcAttrCategories = Dac.AttrCategories(conn, null);
			DataRowCollection drcAttrs = Dac.Attrs(conn, null);
			DataRowCollection drcElementals = Dac.Elementals(conn, null);

			DataRowCollection drcItemTypes = Dac.ItemTypes(conn, null);
			DataRowCollection drcItemGrades = Dac.ItemGrades(conn, null);
			DataRowCollection drcItems = Dac.Items(conn, null);

			DataRowCollection drcMainGearCategories = Dac.MainGearCategories(conn, null);
			DataRowCollection drcMainGearTypes = Dac.MainGearTypes(conn, null);
			DataRowCollection drcMainGearTiers = Dac.MainGearTiers(conn, null);
			DataRowCollection drcMainGears = Dac.MainGears(conn, null);
			DataRowCollection drcMainGearGrades = Dac.MainGearGrades(conn, null);
			DataRowCollection drcMainGearQualities = Dac.MainGearQualities(conn, null);
			DataRowCollection drcMainGearBaseAttrs = Dac.MainGearBaseAttrs(conn, null);
			DataRowCollection drcMainGearBaseAttrEnchantLevels = Dac.MainGearBaseAttrEnchantLevels(conn, null);
			DataRowCollection drcMainGearEnchantSteps = Dac.MainGearEnchantSteps(conn, null);
			DataRowCollection drcMainGearEnchantLevels = Dac.MainGearEnchantLevels(conn, null);
			DataRowCollection drcMainGearOptionAttrGrades = Dac.MainGearOptionAttrGrades(conn, null);
			DataRowCollection drcMainGearRefinementRecipes = Dac.MainGearRefinementRecipes(conn, null);

			DataRowCollection drcSubGears = Dac.SubGears(conn, null);
			DataRowCollection drcSubGearGrades = Dac.SubGearGrades(conn, null);
			DataRowCollection drcSubGearNames = Dac.SubGearNames(conn, null);
			DataRowCollection drcSubGearRuneSockets = Dac.SubGearRuneSockets(conn, null);
			DataRowCollection drcSubGearRuneSocketAvailableItemTypes = Dac.SubGearRuneSocketAvailableItemTypes(conn, null);
			DataRowCollection drcSubGearSoulstoneSockets = Dac.SubGearSoulstoneSockets(conn, null);
			DataRowCollection drcSubGearAttrs = Dac.SubGearAttrs(conn, null);
			DataRowCollection drcSubGearAttrValues = Dac.SubGearAttrValues(conn, null);
			DataRowCollection drcSubGearLevels = Dac.SubGearLevels(conn, null);
			DataRowCollection drcSubGearLevelQualities = Dac.SubGearLevelQualities(conn, null);

			DataRowCollection drcLocations = Dac.Locations(conn, null);
			DataRowCollection drcMonsterCharacters = Dac.MonsterCharacters(conn, null);
			DataRowCollection drcMonsters = Dac.Monsters(conn, null);
			DataRowCollection drcContinents = Dac.Continents(conn, null);

			DataRowCollection drcMainMenus = Dac.MainMenus(conn, null);
			DataRowCollection drcSubMenus = Dac.SubMenus(conn, null);

			DataRowCollection drcJobSkillMasters = Dac.JobSkillMasters(conn, null);
			DataRowCollection drcJobSkills = Dac.JobSkills(conn, null);
			DataRowCollection drcJobSkillLevels = Dac.JobSkillLevels(conn, null);
			DataRowCollection drcJobSkillLevelMasters = Dac.JobSkillLevelMasters(conn, null);
			DataRowCollection drcJobSkillHits = Dac.JobSkillHits(conn, null);
			DataRowCollection drcJobChainSkills = Dac.JobChainSkills(conn, null);
			DataRowCollection drcJobChainSkillHits = Dac.JobChainSkillHits(conn, null);
			DataRowCollection drcJobSkillHitAbnormalStates = Dac.JobSkillHitAbnormalStates(conn, null);

			DataRowCollection drcPortals = Dac.Portals(conn, null);
			DataRowCollection drcNpcs = Dac.Npcs(conn, null);

			DataRowCollection drcMainQuests = Dac.MainQuests(conn, null);
			DataRowCollection drcMainQuestRewards = Dac.MainQuestRewards(conn, null);
			DataRowCollection drcContinentObjects = Dac.ContinentObjects(conn, null);
			DataRowCollection drcContinentObjectArranges = Dac.ContinentObjectArranges(conn, null);
			DataRowCollection drcItemMainCategories = Dac.ItemMainCategories(conn, null);
			DataRowCollection drcItemSubCategories = Dac.ItemSubCategories(conn, null);

			DataRowCollection drcPaidImmediateRevivals = Dac.PaidImmediateRevivals(conn, null);
			DataRowCollection drcMonsterSkills = Dac.MonsterSkills(conn, null);
			DataRowCollection drcMonsterSkillHits = Dac.MonsterSkillHits(conn, null);
			DataRowCollection drcMonsterOwnSkills = Dac.MonsterOwnSkills(conn, null);
			DataRowCollection drcAbnormalStates = Dac.AbnormalStates(conn, null);
			DataRowCollection drcAbnormalStateLevels = Dac.AbnormalStateLevels(conn, null);
			DataRowCollection drcJobLevelMasters = Dac.JobLevelMasters(conn, null);
			DataRowCollection drcJobLevels = Dac.JobLevels(conn, null);
			DataRowCollection drcExpRewards = Dac.ExpRewards(conn, null);
			DataRowCollection drcGoldRewards = Dac.GoldRewards(conn, null);
			DataRowCollection drcItemRewards = Dac.ItemRewards(conn, null);
			DataRowCollection drcAttrValues = Dac.AttrValues(conn, null);
			DataRowCollection drcMonsterArranges = Dac.MonsterArranges(conn, null);
			DataRowCollection drcSimpleShopProducts = Dac.SimpleShopProducts(conn, null);
			DataRowCollection drcVipLevels = Dac.VipLevels(conn, null);
			DataRowCollection drcInventorySlotExtendRecipes = Dac.InventorySlotExtendRecipes(conn, null);
			DataRowCollection drcMainGearDisassembleAvailableResultEntries = Dac.MainGearDisassembleAvailableResultEntries(conn, null);
			DataRowCollection drcItemCompositionRecipes = Dac.ItemCompositionRecipes(conn, null);
			DataRowCollection drcRestRewardTimes = Dac.RestRewardTimes(conn, null);
			DataRowCollection drcChattingTypes = Dac.ChattingTypes(conn, null);
			DataRowCollection drcMainQuestDungeons = Dac.MainQuestDungeons(conn, null);
			DataRowCollection drcMainQuestDungeonObstacles = Dac.MainQuestDungeonObstacles(conn, null);
			DataRowCollection drcMainQuestDungeonSteps = Dac.MainQuestDungeonSteps(conn, null);
			DataRowCollection drcMainQuestDungeonGuides = Dac.MainQuestDungeonGuides(conn, null);
			DataRowCollection drcLevelUpRewardEntries = Dac.LevelUpRewardEntries(conn, null);
			DataRowCollection drcLevelUpRewardItems = Dac.LevelUpRewardItems(conn, null);
			DataRowCollection drcDailyAttendRewardEntries = Dac.DailyAttendRewardEntries(conn, null);
			DataRowCollection drcWeekendAttendRewardAvailableDayOfWeeks = Dac.WeekendAttendRewardAvailableDayOfWeeks(conn, null);
			DataRowCollection drcAccessRewardEntries = Dac.AccessRewardEntries(conn, null);
			DataRowCollection drcAccessRewardItems = Dac.AccessRewardItems(conn, null);
			DataRowCollection drcVipLevelRewards = Dac.VipLevelRewards(conn, null);
			DataRowCollection drcMounts = Dac.Mounts(conn, null);
			DataRowCollection drcMountQualityMasters = Dac.MountQualityMasters(conn, null);
			DataRowCollection drcMountLevelMasters = Dac.MountLevelMasters(conn, null);
			DataRowCollection drcMountQualities = Dac.MountQualities(conn, null);
			DataRowCollection drcMountLevels = Dac.MountLevels(conn, null);
			DataRowCollection drcMountGearTypes = Dac.MountGearTypes(conn, null);
			DataRowCollection drcMountGearSlots = Dac.MountGearSlots(conn, null);
			DataRowCollection drcMountGears = Dac.MountGears(conn, null);
			DataRowCollection drcMountGearGrades = Dac.MountGearGrades(conn, null);
			DataRowCollection drcMountGearQualities = Dac.MountGearQualities(conn, null);
			DataRowCollection drcMountGearOptionAttrGrades = Dac.MountGearOptionAttrGrades(conn, null);
			DataRowCollection drcMountGearPickBoxRecipes = Dac.MountGearPickBoxRecipes(conn, null);
			DataRowCollection drcStoryDungeons = Dac.StoryDungeons(conn, null);
			DataRowCollection drcStoryDungeonDifficulties = Dac.StoryDungeonDifficulties(conn, null);
			DataRowCollection drcStoryDungeonObstacles = Dac.StoryDungeonObstacles(conn, null);
			DataRowCollection drcStoryDungeonAvailableRewards = Dac.StoryDungeonAvailableRewards(conn, null);
			DataRowCollection drcStoryDungeonSteps = Dac.StoryDungeonSteps(conn, null);
			DataRowCollection drcStoryDungeonGuides = Dac.StoryDungeonGuides(conn, null);
			DataRowCollection drcStoryDungeonTraps = Dac.StoryDungeonTraps(conn, null);
			DataRowCollection drcWingSteps = Dac.WingSteps(conn, null);
			DataRowCollection drcWingStepParts = Dac.WingStepParts(conn, null);
			DataRowCollection drcWingParts = Dac.WingParts(conn, null);
			DataRowCollection drcWingStepLevels = Dac.WingStepLevels(conn, null);
			DataRowCollection drcWings = Dac.Wings(conn, null);
			DataRowCollection drcStaminaBuyCounts = Dac.StaminaBuyCounts(conn, null);
			DataRow drExpDungeon = Dac.ExpDungeon(conn, null);
			DataRowCollection drcExpDungeonDifficulties = Dac.ExpDungeonDifficulties(conn, null);
			DataRowCollection drcExpDungeonDifficultyWaves = Dac.ExpDungeonDifficultyWaves(conn, null);
			DataRow drGoldDungeon = Dac.GoldDungeon(conn, null);
			DataRowCollection drcGoldDungeonDifficulties = Dac.GoldDungeonDifficulties(conn, null);
			DataRowCollection drcGoldDungeonSteps = Dac.GoldDungeonSteps(conn, null);
			DataRowCollection drcGoldDungeonStepWaves = Dac.GoldDungeonStepWaves(conn, null);
			DataRowCollection drcGoldDungeonStepMonsterArranges = Dac.GoldDungeonStepMonsterArranges(conn, null);
			DataRowCollection drcMainGearEnchantLevelSets = Dac.MainGearEnchantLevelSets(conn, null);
			DataRowCollection drcMainGearEnchantLevelSetAttrs = Dac.MainGearEnchantLevelSetAttrs(conn, null);
			DataRowCollection drcMainGearSets = Dac.MainGearSets(conn, null);
			DataRowCollection drcMainGearSetAttrs = Dac.MainGearSetAttrs(conn, null);
			DataRowCollection drcSubGearSoulstoneLevelSets = Dac.SubGearSoulstoneLevelSets(conn, null);
			DataRowCollection drcSubGearSoulstoneLevelSetAttrs = Dac.SubGearSoulstoneLevelSetAttrs(conn, null);
			DataRowCollection drcCartGrades = Dac.CartGrades(conn, null);
			DataRowCollection drcCarts = Dac.Carts(conn, null);
			DataRowCollection drcWorldLevelExpFactors = Dac.WorldLevelExpFactors(conn, null);
			DataRowCollection drcLocationAreas = Dac.LocationAreas(conn, null);
			DataRowCollection drcContinentMapMonsters = Dac.ContinentMapMonsters(conn, null);
			DataRow drTreatOfFarmQuest = Dac.TreatOfFarmQuest(conn, null);
			DataRowCollection drcTreatOfFarmQuestMissions = Dac.TreatOfFarmQuestMissions(conn, null);
			DataRowCollection drcTreatOfFarmQuestRewards = Dac.TreatOfFarmQuestRewards(conn, null);
			DataRowCollection drcContinentTransmissionExits = Dac.ContinentTransmissionExits(conn, null);
			DataRow drUndergroundMaze = Dac.UndergroundMaze(conn, null);
			DataRowCollection drcUndergroundMazeEntrances = Dac.UndergroundMazeEntrances(conn, null);
			DataRowCollection drcUndergroundMazeFloors = Dac.UndergroundMazeFloors(conn, null);
			DataRowCollection drcUndergroundMazePortals = Dac.UndergroundMazePortals(conn, null);

			DataRowCollection drcUndergroundMazeNpcs = Dac.UndergroundMazeNpcs(conn, null);
			DataRowCollection drcUndergroundMazeNpcTransmissionEntries = Dac.UndergroundMazeNpcTransmissionEntries(conn, null);
			DataRowCollection drcUndergroundMazeMonsterArranges = Dac.UndergroundMazeMonsterArranges(conn, null);
			DataRowCollection drcBountyHunterQuests = Dac.BountyHunterQuests(conn, null);
			DataRowCollection drcBountyHunterQuestRewards = Dac.BountyHunterQuestRewards(conn, null);
			DataRow drFishingQuest = Dac.FishingQuest(conn, null);
			DataRowCollection drcFishingQuestSpots = Dac.FishingQuestSpots(conn, null);
			DataRowCollection drcFishingQuestGuildTerritorySpots = Dac.FishingQuestGuildTerritorySpots(conn, null);
			DataRow drSecretLetterQuest = Dac.SecretLetterQuest(conn, null);
			DataRowCollection drcSecretLetterQuestRewards = Dac.SecretLetterQuestRewards(conn, null);
			DataRowCollection drcSecretLetterGrades = Dac.SecretLetterGrades(conn, null);
			DataRow drMysteryBoxQuest = Dac.MysteryBoxQuest(conn, null);
			DataRowCollection drcMysteryBoxQuestRewards = Dac.MysteryBoxQuestRewards(conn, null);
			DataRowCollection drcMysteryBoxGrades = Dac.MysteryBoxGrades(conn, null);
			DataRowCollection drcExploitPointRewards = Dac.ExploitPointRewards(conn, null);
			DataRow drArtifactRoom = Dac.ArtifactRoom(conn, null);
			DataRowCollection drcArtifactRoomFloors = Dac.ArtifactRoomFloors(conn, null);
			DataRowCollection drcTodayMissions = Dac.TodayMissions(conn, null);
			DataRowCollection drcTodayMissionRewards = Dac.TodayMissionRewards(conn, null);
			DataRowCollection drcSeriesMissions = Dac.SeriesMissions(conn, null);
			DataRowCollection drcSeriesMissionSteps = Dac.SeriesMissionSteps(conn, null);
			DataRowCollection drcSeriesMissionStepRewards = Dac.SeriesMissionStepRewards(conn, null);
			DataRow drAncientRelic = Dac.AncientRelic(conn, null);
			DataRowCollection drcAncientRelicObstacles = Dac.AncientRelicObstacles(conn, null);
			DataRowCollection drcAncientRelicAvailableRewards = Dac.AncientRelicAvailableRewards(conn, null);
			DataRowCollection drcAncientRelicTraps = Dac.AncientRelicTraps(conn, null);
			DataRowCollection drcAncientRelicSteps = Dac.AncientRelicSteps(conn, null);
			DataRowCollection drcAncientRelicStepWaves = Dac.AncientRelicStepWaves(conn, null);
			DataRowCollection drcAncientRelicStepRoutes = Dac.AncientRelicStepRoutes(conn, null);

			DataRowCollection drcTodayTaskCategories = Dac.TodayTaskCategories(conn, null);
			DataRowCollection drcTodayTasks = Dac.TodayTasks(conn, null);
			DataRowCollection drcTodayTaskAvailableRewards = Dac.TodayTaskAvailableRewards(conn, null);
			DataRowCollection drcAchievementRewards = Dac.AchievementRewards(conn, null);
			DataRowCollection drcAchievementRewardEntries = Dac.AchievementRewardEntries(conn, null);
			DataRow drDimensionInfiltrationEvent = Dac.DimensionInfiltrationEvent(conn, null);
			DataRow drDimensionRaidQuest = Dac.DimensionRaidQuest(conn, null);
			DataRowCollection drcDimensionRaidQuestSteps = Dac.DimensionRaidQuestSteps(conn, null);
			DataRowCollection drcDimensionRaidQuestRewards = Dac.DimensionRaidQuestRewards(conn, null);
			DataRow drHolyWarQuest = Dac.HolyWarQuest(conn, null);
			DataRowCollection drcHolyWarQuestSchedules = Dac.HolyWarQuestSchedules(conn, null);
			DataRowCollection drcHolyWarQuestGloryLevels = Dac.HolyWarQuestGloryLevels(conn, null);
			DataRowCollection drcHonorPointRewards = Dac.HonorPointRewards(conn, null);
			DataRow drFieldOfHonor = Dac.FieldOfHonor(conn, null);
			DataRowCollection drcFieldOfHonorRankingRewards = Dac.FieldOfHonorRankingRewards(conn, null);
			DataRowCollection drcHonorShopProducts = Dac.HonorShopProducts(conn, null);
			DataRowCollection drcRanks = Dac.Ranks(conn, null);
			DataRowCollection drcRankAttrs = Dac.RankAttrs(conn, null);
			DataRowCollection drcRankRewards = Dac.RankRewards(conn, null);
			DataRow drBattlefieldSupportEvent = Dac.BattlefieldSupportEvent(conn, null);
			DataRowCollection drcLevelRankingRewards = Dac.LevelRankingRewards(conn, null);

			DataRowCollection drcAttainmentEntries = Dac.AttainmentEntries(conn, null);
			DataRowCollection drcAttainmentEntryRewards = Dac.AttainmentEntryRewards(conn, null);
			DataRowCollection drcMenus = Dac.Menus(conn, null);
			DataRowCollection drcMenuContents = Dac.MenuContents(conn, null);
			DataRowCollection drcGuildLevels = Dac.GuildLevels(conn, null);
			DataRowCollection drcGuildMemberGrades = Dac.GuildMemberGrades(conn, null);
			DataRow drSupplySupportQuest = Dac.SupplySupportQuest(conn, null);
			DataRowCollection drcSupplySupportQuestOrders = Dac.SupplySupportQuestOrders(conn, null);
			DataRowCollection drcSupplySupportQuestWayPoints = Dac.SupplySupportQuestWayPoints(conn, null);
			DataRowCollection drcSupplySupportQuestCarts = Dac.SupplySupportQuestCarts(conn, null);
			DataRowCollection drcHolyWarQuestRewards = Dac.HolyWarQuestRewards(conn, null);
			DataRowCollection drcSupplySupportQuestRewards = Dac.SupplySupportQuestRewards(conn, null);
			DataRowCollection drcNationDonationEntries = Dac.NationDonationEntries(conn, null);
			DataRowCollection drcNationNoblesses = Dac.NationNoblesses(conn, null);
			DataRowCollection drcNationNoblesseAttrs = Dac.NationNoblesseAttrs(conn, null);
			DataRowCollection drcNationFundRewards = Dac.NationFundRewards(conn, null);
			DataRowCollection drcGuildContributionPointRewards = Dac.GuildContributionPointRewards(conn, null);
			DataRowCollection drcGuildBuildingPointRewards = Dac.GuildBuildingPointRewards(conn, null);
			DataRowCollection drcGuildFundRewards = Dac.GuildFundRewards(conn, null);
			DataRowCollection drcGuildPointRewards = Dac.GuildPointRewards(conn, null);
			DataRowCollection drcGuildDonationEntries = Dac.GuildDonationEntries(conn, null);
			DataRow drNationWar = Dac.NationWar(conn, null);
			DataRowCollection drcNationWarAvailableDayOfWeeks = Dac.NationWarAvailableDayOfWeeks(conn, null);
			DataRowCollection drcNationWarRevivalPoints = Dac.NationWarRevivalPoints(conn, null);
			DataRowCollection drcNationWarRevivalPointActivationConditions = Dac.NationWarRevivalPointActivationConditions(conn, null);
			DataRowCollection drcNationWarMonsterArranges = Dac.NationWarMonsterArranges(conn, null);
			DataRowCollection drcNationWarNpcs = Dac.NationWarNpcs(conn, null);
			DataRowCollection drcNationWarTransmissionExits = Dac.NationWarTransmissionExits(conn, null);
			DataRowCollection drcNationWarPaidTransmissions = Dac.NationWarPaidTransmissions(conn, null);
			DataRowCollection drcNationWarHeroObjectiveEntries = Dac.NationWarHeroObjectiveEntries(conn, null);
			DataRowCollection drcNationWarExpRewards = Dac.NationWarExpRewards(conn, null);
			DataRowCollection drcGuildBuildings = Dac.GuildBuildings(conn, null);
			DataRowCollection drcGuildBuildingLevels = Dac.GuildBuildingLevels(conn, null);
			DataRowCollection drcGuildSkills = Dac.GuildSkills(conn, null);
			DataRowCollection drcGuildSkillAttrs = Dac.GuildSkillAttrs(conn, null);
			DataRowCollection drcGuildSkillLevels = Dac.GuildSkillLevels(conn, null);
			DataRowCollection drcGuildSkillLevelAttrValues = Dac.GuildSkillLevelAttrValues(conn, null);
			DataRow drGuildAltar = Dac.GuildAltar(conn, null);
			DataRowCollection drcGuildAltarDefenseMonsterAttrFactors = Dac.GuildAltarDefenseMonsterAttrFactors(conn, null);
			DataRow drGuildTerritory = Dac.GuildTerritory(conn, null);
			DataRowCollection drcGuildTerritoryNpcs = Dac.GuildTerritoryNpcs(conn, null);
			DataRow drGuildFarmQuest = Dac.GuildFarmQuest(conn, null);
			DataRowCollection drcGuildFarmQuestRewards = Dac.GuildFarmQuestRewards(conn, null);
			DataRow drGuildFoodWarehouse = Dac.GuildFoodWarehouse(conn, null);
			DataRowCollection drcGuildFoodWarehouseLevels = Dac.GuildFoodWarehouseLevels(conn, null);
			DataRow drGuildMissionQuest = Dac.GuildMissionQuest(conn, null);
			DataRowCollection drcGuildMissionQuestRewards = Dac.GuildMissionQuestRewards(conn, null);
			DataRowCollection drcGuildMissions = Dac.GuildMissions(conn, null);
			DataRow drGuildSupplySupportQuest = Dac.GuildSupplySupportQuest(conn, null);
			DataRowCollection drcGuildSupplySupportQuestRewards = Dac.GuildSupplySupportQuestRewards(conn, null);
			DataRowCollection drcNationNoblesseAppointmentAuthorities = Dac.NationNoblesseAppointmentAuthorities(conn, null);
			DataRowCollection drcMenuContentTutorialSteps = Dac.MenuContentTutorialSteps(conn, null);
			DataRowCollection drcGuildContents = Dac.GuildContents(conn, null);
			DataRowCollection drcGuildDailyObjectiveRewards = Dac.GuildDailyObjectiveRewards(conn, null);
			DataRow drGuildHuntingQuest = Dac.GuildHuntingQuest(conn, null);
			DataRowCollection drcGuildHuntingQuestObjectives = Dac.GuildHuntingQuestObjectives(conn, null);
			DataRow drSoulCoveter = Dac.SoulCoveter(conn, null);
			DataRowCollection drcSoulCoveterAvailableRewards = Dac.SoulCoveterAvailableRewards(conn, null);
			DataRowCollection drcSoulCoveterObstacles = Dac.SoulCoveterObstacles(conn, null);
			DataRowCollection drcSoulCoveterDifficulties = Dac.SoulCoveterDifficulties(conn, null);
			DataRowCollection drcSoulCoveterDifficultyWaves = Dac.SoulCoveterDifficultyWaves(conn, null);
			DataRowCollection drcClientTutorialSteps = Dac.ClientTutorialSteps(conn, null);
			DataRowCollection drcGuildWeeklyObjectives = Dac.GuildWeeklyObjectives(conn, null);
			DataRowCollection drcOwnDiaRewards = Dac.OwnDiaRewards(conn, null);
			DataRowCollection drcAccomplishmentCategories = Dac.AccomplishmentCategories(conn, null);
			DataRowCollection drcAccomplishments = Dac.Accomplishments(conn, null);
			DataRowCollection drcTitleCategories = Dac.TitleCategories(conn, null);
			DataRowCollection drcTitleTypes = Dac.TitleTypes(conn, null);
			DataRowCollection drcTitles = Dac.Titles(conn, null);
			DataRowCollection drcTitleGrades = Dac.TitleGrades(conn, null);
			DataRowCollection drcTitleActiveAttrs = Dac.TitleActiveAttrs(conn, null);
			DataRowCollection drcTitlePassiveAttrs = Dac.TitlePassiveAttrs(conn, null);
			DataRowCollection drcIllustratedBookCategories = Dac.IllustratedBookCategories(conn, null);
			DataRowCollection drcIllustratedBookTypes = Dac.IllustratedBookTypes(conn, null);
			DataRowCollection drcIllustratedBooks = Dac.IllustratedBooks(conn, null);
			DataRowCollection drcIllustratedBookAttrs = Dac.IllustratedBookAttrs(conn, null);
			DataRowCollection drcIllustratedBookAttrGrades = Dac.IllustratedBookAttrGrades(conn, null);
			DataRowCollection drcIllustratedBookExplorationSteps = Dac.IllustratedBookExplorationSteps(conn, null);
			DataRowCollection drcIllustratedBookExplorationStepAttrs = Dac.IllustratedBookExplorationStepAttrs(conn, null);
			DataRowCollection drcIllustratedBookExplorationStepRewards = Dac.IllustratedBookExplorationStepRewards(conn, null);
			DataRowCollection drcSceneryQuests = Dac.SceneryQuests(conn, null);
			DataRowCollection drcEliteMonsterCategories = Dac.EliteMonsterCategories(conn, null);
			DataRowCollection drcEliteMonsterMasters = Dac.EliteMonsterMasters(conn, null);
			DataRowCollection drcEliteMonsters = Dac.EliteMonsters(conn, null);
			DataRowCollection drcEliteMonsterKillAttrValues = Dac.EliteMonsterKillAttrValues(conn, null);
			DataRowCollection drcEliteMonsterSpawnSchedules = Dac.EliteMonsterSpawnSchedules(conn, null);
			DataRow drEliteDungeon = Dac.EliteDungeon(conn, null);
			DataRowCollection drcCreatureCardCategories = Dac.CreatureCardCategories(conn, null);
			DataRowCollection drcCreatureCards = Dac.CreatureCards(conn, null);
			DataRowCollection drcCreatureCardGrades = Dac.CreatureCardGrades(conn, null);
			DataRowCollection drcCreatureCardCollectionEntries = Dac.CreatureCardCollectionEntries(conn, null);
			DataRowCollection drcCreatureCardCollectionCategories = Dac.CreatureCardCollectionCategories(conn, null);
			DataRowCollection drcCreatureCardCollections = Dac.CreatureCardCollections(conn, null);
			DataRowCollection drcCreatureCardCollectionAttrs = Dac.CreatureCardCollectionAttrs(conn, null);
			DataRowCollection drcCreatureCardCollectionGrades = Dac.CreatureCardCollectionGrades(conn, null);
			DataRowCollection drcCreatureCardShopRefreshSchedules = Dac.CreatureCardShopRefreshSchedules(conn, null);
			DataRowCollection drcCreatureCardShopFixedProducts = Dac.CreatureCardShopFixedProducts(conn, null);
			DataRowCollection drcCreatureCardShopRandomProducts = Dac.CreatureCardShopRandomProducts(conn, null);
			DataRow drProofOfValor = Dac.ProofOfValor(conn, null);
			DataRowCollection drcProofOfValorBuffBoxs = Dac.ProofOfValorBuffBoxs(conn, null);
			DataRowCollection drcProofOfValorBuffBoxArranges = Dac.ProofOfValorBuffBoxArranges(conn, null);
			DataRowCollection drcProofOfValorBossMonsterArranges = Dac.ProofOfValorBossMonsterArranges(conn, null);
			DataRowCollection drcProofOfValorPaidRefreshs = Dac.ProofOfValorPaidRefreshs(conn, null);
			DataRowCollection drcProofOfValorRefreshSchedules = Dac.ProofOfValorRefreshSchedules(conn, null);
			DataRowCollection drcProofOfValorRewards = Dac.ProofOfValorRewards(conn, null);
			DataRowCollection drcProofOfValorClearGrades = Dac.ProofOfValorClearGrades(conn, null);
			DataRowCollection drcStaminaRecoverySchedules = Dac.StaminaRecoverySchedules(conn, null);
			DataRowCollection drcBanWords = Dac.BanWords(conn, null);
			DataRowCollection drcGuildContentAvailableRewards = Dac.GuildContentAvailableRewards(conn, null);
			DataRowCollection drcMenuContentOpenPreviews = Dac.MenuContentOpenPreviews(conn, null);
			DataRowCollection drcJobCommonSkills = Dac.JobCommonSkills(conn, null);
			DataRowCollection drcNpcShops = Dac.NpcShops(conn, null);
			DataRowCollection drcNpcShopCategories = Dac.NpcShopCategories(conn, null);
			DataRowCollection drcNpcShopProducts = Dac.NpcShopProducts(conn, null);
			DataRowCollection drcAbnormalStateRankSkillLevels = Dac.AbnormalStateRankSkillLevels(conn, null);
			DataRowCollection drcRankActiveSkills = Dac.RankActiveSkills(conn, null);
			DataRowCollection drcRankActiveSkillLevels = Dac.RankActiveSkillLevels(conn, null);
			DataRowCollection drcRankPassiveSkills = Dac.RankPassiveSkills(conn, null);
			DataRowCollection drcRankPassiveSkillAttrs = Dac.RankPassiveSkillAttrs(conn, null);
			DataRowCollection drcRankPassiveSkillLevels = Dac.RankPassiveSkillLevels(conn, null);
			DataRowCollection drcRankPassiveSkillAttrLevels = Dac.RankPassiveSkillAttrLevels(conn, null);
			DataRow drWisdomTemple = Dac.WisdomTemple(conn, null);
			DataRowCollection drcWisdomTempleMonsterAttrFactors = Dac.WisdomTempleMonsterAttrFactors(conn, null);
			DataRowCollection drcWisdomTempleColorMatchingObjects = Dac.WisdomTempleColorMatchingObjects(conn, null);
			DataRowCollection drcWisdomTempleArrangePositions = Dac.WisdomTempleArrangePositions(conn, null);
			DataRowCollection drcWisdomTempleSweepRewards = Dac.WisdomTempleSweepRewards(conn, null);
			DataRowCollection drcWisdomTempleSteps = Dac.WisdomTempleSteps(conn, null);
			DataRowCollection drcWisdomTempleQuizMonsterPositions = Dac.WisdomTempleQuizMonsterPositions(conn, null);
			DataRowCollection drcWisdomTempleQuizPoolEntries = Dac.WisdomTempleQuizPoolEntries(conn, null);
			DataRowCollection drcWisdomTemplePuzzles = Dac.WisdomTemplePuzzles(conn, null);
			DataRowCollection drcWisdomTempleStepRewards = Dac.WisdomTempleStepRewards(conn, null);
			DataRowCollection drcRookieGifts = Dac.RookieGifts(conn, null);
			DataRowCollection drcRookieGiftRewards = Dac.RookieGiftRewards(conn, null);
			DataRowCollection drcOpenGiftRewards = Dac.OpenGiftRewards(conn, null);
			DataRowCollection drcQuickMenus = Dac.QuickMenus(conn, null);
			DataRow drDailyQuest = Dac.DailyQuest(conn, null);
			DataRowCollection drcDailyQuestRewards = Dac.DailyQuestRewards(conn, null);
			DataRowCollection drcDailyQuestGrades = Dac.DailyQuestGrades(conn, null);
			DataRowCollection drcDailyQuestMissions = Dac.DailyQuestMissions(conn, null);
			DataRow drWeeklyQuest = Dac.WeeklyQuest(conn, null);
			DataRowCollection drcWeeklyQuestRoundRewards = Dac.WeeklyQuestRoundRewards(conn, null);
			DataRowCollection drcWeeklyQuestMissions = Dac.WeeklyQuestMissions(conn, null);
			DataRowCollection drcWeeklyQuestTenRoundRewards = Dac.WeeklyQuestTenRoundRewards(conn, null);
			DataRow drRuinsReclaim = Dac.RuinsReclaim(conn, null);
			DataRowCollection drcRuinsReclaimMonsterAttrFactors = Dac.RuinsReclaimMonsterAttrFactors(conn, null);
			DataRowCollection drcRuinsReclaimAvailableRewards = Dac.RuinsReclaimAvailableRewards(conn, null);
			DataRowCollection drcRuinsReclaimRevivalPoints = Dac.RuinsReclaimRevivalPoints(conn, null);
			DataRowCollection drcRuinsReclaimObstacles = Dac.RuinsReclaimObstacles(conn, null);
			DataRowCollection drcRuinsReclaimTraps = Dac.RuinsReclaimTraps(conn, null);
			DataRowCollection drcRuinsReclaimPortals = Dac.RuinsReclaimPortals(conn, null);
			DataRowCollection drcRuinsReclaimOpenSchedules = Dac.RuinsReclaimOpenSchedules(conn, null);
			DataRowCollection drcRuinsReclaimSteps = Dac.RuinsReclaimSteps(conn, null);
			DataRowCollection drcRuinsReclaimObjectArranges = Dac.RuinsReclaimObjectArranges(conn, null);
			DataRowCollection drcRuinsReclaimStepRewards = Dac.RuinsReclaimStepRewards(conn, null);
			DataRowCollection drcRuinsReclaimStepWaves = Dac.RuinsReclaimStepWaves(conn, null);
			DataRowCollection drcRuinsReclaimStepWaveSkills = Dac.RuinsReclaimStepWaveSkills(conn, null);
			DataRowCollection drcOpen7DayEventDaies = Dac.Open7DayEventDaies(conn, null);
			DataRowCollection drcOpen7DayEventMissions = Dac.Open7DayEventMissions(conn, null);
			DataRowCollection drcOpen7DayEventMissionRewards = Dac.Open7DayEventMissionRewards(conn, null);
			DataRowCollection drcOpen7DayEventProducts = Dac.Open7DayEventProducts(conn, null);
			DataRowCollection drcRetrievals = Dac.Retrievals(conn, null);
			DataRowCollection drcRetrievalRewards = Dac.RetrievalRewards(conn, null);
			DataRowCollection drcTaskConsignments = Dac.TaskConsignments(conn, null);
			DataRowCollection drcTaskConsignmentAvailableRewards = Dac.TaskConsignmentAvailableRewards(conn, null);
			DataRowCollection drcTaskConsignmentExpRewards = Dac.TaskConsignmentExpRewards(conn, null);
			DataRow drInfiniteWar = Dac.InfiniteWar(conn, null);
			DataRowCollection drcInfiniteWarBuffBoxs = Dac.InfiniteWarBuffBoxs(conn, null);
			DataRowCollection drcInfiniteWarMonsterAttrFactors = Dac.InfiniteWarMonsterAttrFactors(conn, null);
			DataRowCollection drcInfiniteWarOpenSchedules = Dac.InfiniteWarOpenSchedules(conn, null);
			DataRowCollection drcInfiniteWarAvailableRewards = Dac.InfiniteWarAvailableRewards(conn, null);
			DataRow drTrueHeroQuest = Dac.TrueHeroQuest(conn, null);
			DataRowCollection drcTrueHeroQuestSteps = Dac.TrueHeroQuestSteps(conn, null);
			DataRowCollection drcTrueHeroQuestRewards = Dac.TrueHeroQuestRewards(conn, null);
			DataRowCollection drcRuinsReclaimRandomRewardPoolEntries = Dac.RuinsReclaimRandomRewardPoolEntries(conn, null);
			DataRow drLimitationGift = Dac.LimitationGift(conn, null);
			DataRowCollection drcLimitationGiftRewardDayOfWeeks = Dac.LimitationGiftRewardDayOfWeeks(conn, null);
			DataRowCollection drcLimitationGiftRewardSchedules = Dac.LimitationGiftRewardSchedules(conn, null);
			DataRowCollection drcLimitationGiftAvailableRewards = Dac.LimitationGiftAvailableRewards(conn, null);
			DataRow drWeekendReward = Dac.WeekendReward(conn, null);
			DataRow drFieldBossEvent = Dac.FieldBossEvent(conn, null);
			DataRowCollection drcFieldBossEventSchedules = Dac.FieldBossEventSchedules(conn, null);
			DataRowCollection drcFieldBossEventAvailableRewards = Dac.FieldBossEventAvailableRewards(conn, null);
			DataRowCollection drcFieldBosss = Dac.FieldBosss(conn, null);
			DataRowCollection drcWarehouseSlotExtendRecipes = Dac.WarehouseSlotExtendRecipes(conn, null);
			DataRow drFearAltar = Dac.FearAltar(conn, null);
			DataRowCollection drcFearAltarRewards = Dac.FearAltarRewards(conn, null);
			DataRowCollection drcFearAltarHalidomCollectionRewards = Dac.FearAltarHalidomCollectionRewards(conn, null);
			DataRowCollection drcFearAltarHalidomElementals = Dac.FearAltarHalidomElementals(conn, null);
			DataRowCollection drcFearAltarHalidomLevels = Dac.FearAltarHalidomLevels(conn, null);
			DataRowCollection drcFearAltarHalidoms = Dac.FearAltarHalidoms(conn, null);
			DataRowCollection drcFearAltarStages = Dac.FearAltarStages(conn, null);
			DataRowCollection drcFearAltarStageWaves = Dac.FearAltarStageWaves(conn, null);
			DataRowCollection drcDiaShopCategories = Dac.DiaShopCategories(conn, null);
			DataRowCollection drcDiaShopProducts = Dac.DiaShopProducts(conn, null);
			DataRowCollection drcWingMemoryPieceSlots = Dac.WingMemoryPieceSlots(conn, null);
			DataRowCollection drcWingMemoryPieceSteps = Dac.WingMemoryPieceSteps(conn, null);
			DataRowCollection drcWingMemoryPieceSlotSteps = Dac.WingMemoryPieceSlotSteps(conn, null);
			DataRowCollection drcWingMemoryPieceTypes = Dac.WingMemoryPieceTypes(conn, null);
			DataRow drWarMemory = Dac.WarMemory(conn, null);
			DataRowCollection drcWarMemoryMonsterAttrFactors = Dac.WarMemoryMonsterAttrFactors(conn, null);
			DataRowCollection drcWarMemoryStartPositions = Dac.WarMemoryStartPositions(conn, null);
			DataRowCollection drcWarMemorySchedules = Dac.WarMemorySchedules(conn, null);
			DataRowCollection drcWarMemoryAvailableRewards = Dac.WarMemoryAvailableRewards(conn, null);

			DataRowCollection drcWarMemoryRankingRewards = Dac.WarMemoryRankingRewards(conn, null);
			DataRowCollection drcWarMemoryWaves = Dac.WarMemoryWaves(conn, null);
			DataRowCollection drcWarMemoryTransformationObjects = Dac.WarMemoryTransformationObjects(conn, null);
			DataRowCollection drcSubQuests = Dac.SubQuests(conn, null);
			DataRowCollection drcSubQuestRewards = Dac.SubQuestRewards(conn, null);
			DataRow drOsirisRoom = Dac.OsirisRoom(conn, null);
			DataRowCollection drcOsirisRoomAvailableRewards = Dac.OsirisRoomAvailableRewards(conn, null);
			DataRowCollection drcOsirisRoomDifficulties = Dac.OsirisRoomDifficulties(conn, null);
			DataRowCollection drcOsirisRoomDifficultyWaves = Dac.OsirisRoomDifficultyWaves(conn, null);
			DataRowCollection drcOrdealQuests = Dac.OrdealQuests(conn, null);
			DataRowCollection drcOrdealQuestMissions = Dac.OrdealQuestMissions(conn, null);
			DataRowCollection drcMoneyBuffs = Dac.MoneyBuffs(conn, null);
			DataRowCollection drcMoneyBuffAttrs = Dac.MoneyBuffAttrs(conn, null);
			DataRowCollection drcBiographies = Dac.Biographies(conn, null);
			DataRowCollection drcBiographyRewards = Dac.BiographyRewards(conn, null);
			DataRowCollection drcBiographyQuests = Dac.BiographyQuests(conn, null);
			DataRowCollection drcBiographyQuestStartDialogues = Dac.BiographyQuestStartDialogues(conn, null);
			DataRowCollection drcBiographyQuestDungeons = Dac.BiographyQuestDungeons(conn, null);
			DataRowCollection drcBiographyQuestDungeonWaves = Dac.BiographyQuestDungeonWaves(conn, null);
			DataRowCollection drcBlessings = Dac.Blessings(conn, null);
			DataRowCollection drcBlessingTargetLevels = Dac.BlessingTargetLevels(conn, null);
			DataRow drItemLuckyShop = Dac.ItemLuckyShop(conn, null);
			DataRow drCreatureCardLuckyShop = Dac.CreatureCardLuckyShop(conn, null);
			DataRowCollection drcCreatureCharacters = Dac.CreatureCharacters(conn, null);
			DataRowCollection drcCreatureGrades = Dac.CreatureGrades(conn, null);
			DataRowCollection drcCreatures = Dac.Creatures(conn, null);
			DataRowCollection drcCreatureSkillGrades = Dac.CreatureSkillGrades(conn, null);
			DataRowCollection drcCreatureSkills = Dac.CreatureSkills(conn, null);
			DataRowCollection drcCreatureSkillAttrs = Dac.CreatureSkillAttrs(conn, null);
			DataRowCollection drcCreatureBaseAttrs = Dac.CreatureBaseAttrs(conn, null);
			DataRowCollection drcCreatureLevels = Dac.CreatureLevels(conn, null);
			DataRowCollection drcCreatureBaseAttrValues = Dac.CreatureBaseAttrValues(conn, null);
			DataRowCollection drcCreatureAdditionalAttrs = Dac.CreatureAdditionalAttrs(conn, null);
			DataRowCollection drcCreatureInjectionLevels = Dac.CreatureInjectionLevels(conn, null);
			DataRowCollection drcCreatureAdditionalAttrValues = Dac.CreatureAdditionalAttrValues(conn, null);
			DataRowCollection drcCreatureSkillSlotOpenRecipes = Dac.CreatureSkillSlotOpenRecipes(conn, null);
			DataRowCollection drcCreatureSkillSlotProtections = Dac.CreatureSkillSlotProtections(conn, null);
			DataRow drDragonNest = Dac.DragonNest(conn, null);
			DataRowCollection drcDragonNestAvailableRewards = Dac.DragonNestAvailableRewards(conn, null);
			DataRowCollection drcDragonNestObstacles = Dac.DragonNestObstacles(conn, null);
			DataRowCollection drcDragonNestTraps = Dac.DragonNestTraps(conn, null);
			DataRowCollection drcDragonNestSteps = Dac.DragonNestSteps(conn, null);
			DataRowCollection drcDragonNestStepRewards = Dac.DragonNestStepRewards(conn, null);
			DataRowCollection drcProspectQuestOwnerRewards = Dac.ProspectQuestOwnerRewards(conn, null);
			DataRowCollection drcProspectQuestTargetRewards = Dac.ProspectQuestTargetRewards(conn, null);
			DataRowCollection drcPresents = Dac.Presents(conn, null);
			DataRowCollection drcWeeklyPresentPopularityPointRankingRewardGroups = Dac.WeeklyPresentPopularityPointRankingRewardGroups(conn, null);
			DataRowCollection drcWeeklyPresentPopularityPointRankingRewards = Dac.WeeklyPresentPopularityPointRankingRewards(conn, null);
			DataRowCollection drcWeeklyPresentContributionPointRankingRewardGroups = Dac.WeeklyPresentContributionPointRankingRewardGroups(conn, null);
			DataRowCollection drcWeeklyPresentContributionPointRankingRewards = Dac.WeeklyPresentContributionPointRankingRewards(conn, null);
			DataRowCollection drcMainQuestStartDialogues = Dac.MainQuestStartDialogues(conn, null);
			DataRowCollection drcMainQuestCompletionDialogues = Dac.MainQuestCompletionDialogues(conn, null);
			DataRow drCreatureFarmQuest = Dac.CreatureFarmQuest(conn, null);
			DataRowCollection drcCreatureFarmQuestExpRewards = Dac.CreatureFarmQuestExpRewards(conn, null);
			DataRowCollection drcCreatureFarmQuestItemRewards = Dac.CreatureFarmQuestItemRewards(conn, null);
			DataRowCollection drcCreatureFarmQuestMissions = Dac.CreatureFarmQuestMissions(conn, null);
			DataRowCollection drcCostumes = Dac.Costumes(conn, null);
			DataRowCollection drcCostumeEffects = Dac.CostumeEffects(conn, null);
			DataRow drSafeTimeEvent = Dac.SafeTimeEvent(conn, null);
			DataRowCollection drcGuildBlessingBuffs = Dac.GuildBlessingBuffs(conn, null);
			DataRowCollection drcInAppProducts = Dac.InAppProducts(conn, null);
			DataRowCollection drcInAppProductPrices = Dac.InAppProductPrices(conn, null);
			DataRowCollection drcCashProducts = Dac.CashProducts(conn, null);
			DataRowCollection drcJobChangeQuests = Dac.JobChangeQuests(conn, null);
			DataRowCollection drcJobChangeQuestDifficulties = Dac.JobChangeQuestDifficulties(conn, null);
			DataRow drFirstChargeEvent = Dac.FirstChargeEvent(conn, null);
			DataRowCollection drcFirstChargeEventRewards = Dac.FirstChargeEventRewards(conn, null);
			DataRow drRechargeEvent = Dac.RechargeEvent(conn, null);
			DataRowCollection drcRechargeEventRewards = Dac.RechargeEventRewards(conn, null);
			DataRowCollection drcChargeEvents = Dac.ChargeEvents(conn, null);
			DataRowCollection drcChargeEventMissions = Dac.ChargeEventMissions(conn, null);
			DataRow drAnkouTomb = Dac.AnkouTomb(conn, null);
			DataRowCollection drcAnkouTombSchedules = Dac.AnkouTombSchedules(conn, null);
			DataRowCollection drcAnkouTombDifficulties = Dac.AnkouTombDifficulties(conn, null);
			DataRowCollection drcAnkouTombAvailableRewards = Dac.AnkouTombAvailableRewards(conn, null);
			DataRowCollection drcPotionAttrs = Dac.PotionAttrs(conn, null);
			DataRowCollection drcRecommendBattlePowerLevels = Dac.RecommendBattlePowerLevels(conn, null);
			DataRowCollection drcImprovementMainCategories = Dac.ImprovementMainCategories(conn, null);
			DataRowCollection drcImprovementMainCategoryContents = Dac.ImprovementMainCategoryContents(conn, null);
			DataRowCollection drcImprovementSubCategories = Dac.ImprovementSubCategories(conn, null);
			DataRowCollection drcImprovementSubCategoryContents = Dac.ImprovementSubCategoryContents(conn, null);
			DataRowCollection drcImprovementContents = Dac.ImprovementContents(conn, null);
			DataRowCollection drcImprovementContentAchievementLevels = Dac.ImprovementContentAchievementLevels(conn, null);
			DataRowCollection drcImprovementContentAchievements = Dac.ImprovementContentAchievements(conn, null);
			DataRowCollection drcConstellations = Dac.Constellations(conn, null);
			DataRowCollection drcConstellationSteps = Dac.ConstellationSteps(conn, null);
			DataRowCollection drcConstellationCycles = Dac.ConstellationCycles(conn, null);
			DataRowCollection drcConstellationCycleBuffs = Dac.ConstellationCycleBuffs(conn, null);
			DataRowCollection drcConstellationEntries = Dac.ConstellationEntries(conn, null);
			DataRowCollection drcConstellationEntryBuffs = Dac.ConstellationEntryBuffs(conn, null);
			DataRowCollection drcChargeEventMissionRewards = Dac.ChargeEventMissionRewards(conn, null);
			DataRow drDailyChargeEvent = Dac.DailyChargeEvent(conn, null);
			DataRowCollection drcDailyChargeEventMissions = Dac.DailyChargeEventMissions(conn, null);
			DataRowCollection drcDailyChargeEventMissionRewards = Dac.DailyChargeEventMissionRewards(conn, null);
			DataRowCollection drcConsumeEvents = Dac.ConsumeEvents(conn, null);
			DataRowCollection drcConsumeEventMissions = Dac.ConsumeEventMissions(conn, null);
			DataRowCollection drcConsumeEventMissionRewards = Dac.ConsumeEventMissionRewards(conn, null);
			DataRow drDailyConsumeEvent = Dac.DailyConsumeEvent(conn, null);
			DataRowCollection drcDailyConsumeEventMissions = Dac.DailyConsumeEventMissions(conn, null);
			DataRowCollection drcDailyConsumeEventMissionRewards = Dac.DailyConsumeEventMissionRewards(conn, null);
			DataRowCollection drcArtifacts = Dac.Artifacts(conn, null);
			DataRowCollection drcArtifactAttrs = Dac.ArtifactAttrs(conn, null);
			DataRowCollection drcArtifactLevels = Dac.ArtifactLevels(conn, null);
			DataRowCollection drcArtifactLevelAttrs = Dac.ArtifactLevelAttrs(conn, null);
			DataRowCollection drcArtifactLevelUpMaterials = Dac.ArtifactLevelUpMaterials(conn, null);
			DataRow drTradeShip = Dac.TradeShip(conn, null);
			DataRowCollection drcTradeShipSchedules = Dac.TradeShipSchedules(conn, null);
			DataRowCollection drcTradeShipObstacles = Dac.TradeShipObstacles(conn, null);
			DataRowCollection drcTradeShipSteps = Dac.TradeShipSteps(conn, null);
			DataRowCollection drcTradeShipDifficulties = Dac.TradeShipDifficulties(conn, null);
			DataRowCollection drcTradeShipAvailableRewards = Dac.TradeShipAvailableRewards(conn, null);
			DataRowCollection drcTradeShipObjects = Dac.TradeShipObjects(conn, null);
			DataRowCollection drcMountAwakeningLevelMasters = Dac.MountAwakeningLevelMasters(conn, null);
			DataRowCollection drcMountAwakeningLevels = Dac.MountAwakeningLevels(conn, null);
			DataRowCollection drcMountPotionAttrCounts = Dac.MountPotionAttrCounts(conn, null);
			DataRowCollection drcCostumeDisplays = Dac.CostumeDisplays(conn, null);
			DataRowCollection drcCostumeCollections = Dac.CostumeCollections(conn, null);
			DataRowCollection drcCostumeCollectionAttrs = Dac.CostumeCollectionAttrs(conn, null);
			DataRowCollection drcCostumeCollectionEntries = Dac.CostumeCollectionEntries(conn, null);
			DataRowCollection drcCostumeAttrs = Dac.CostumeAttrs(conn, null);
			DataRowCollection drcCostumeEnchantLevels = Dac.CostumeEnchantLevels(conn, null);
			DataRowCollection drcCostumeEnchantLevelAttrs = Dac.CostumeEnchantLevelAttrs(conn, null);
			DataRowCollection drcScheduleNotices = Dac.ScheduleNotices(conn, null);
			DataRowCollection drcSharingEvents = Dac.SharingEvents(conn, null);
			DataRowCollection drcSystemMessages = Dac.SystemMessages(conn, null);
			DataRowCollection drcSharingEventSenderRewards = Dac.SharingEventSenderRewardAll(conn, null);
			DataRowCollection drcSharingEventReceiverRewards = Dac.SharingEventReceiverRewardAll(conn, null);

            DataRow drGameConfig = Dac.GameConfig(conn, null);
            DataRowCollection drcWarMemoryRewards = Dac.WarMemoryRewards(conn, null);
            DataRowCollection drcUndergroundMazeMapMonsters = Dac.UndergroundMazeMapMonsters(conn, null);
            DataRowCollection drcAncientRelicMonsterSkillCastingGuides = Dac.AncientRelicMonsterSkillCastingGuides(conn, null);
            DataRowCollection drcContentOpenEntries = Dac.ContentOpenEntries(conn, null);
            //===============================================================================================
            // 关闭一个数据库连接
            //===============================================================================================
            DBUtil.Close(ref conn);

            // 数据

            WPDGameDatas gameDatas = new WPDGameDatas();

            //
            // 游戏设置
            //
            WPDGameConfig gameConfig = new WPDGameConfig();
            if (drGameConfig != null)
			{
				gameConfig.maxHeroCount = Convert.ToInt32(drGameConfig["maxHeroCount"]);
				gameConfig.startContinentId = Convert.ToInt32(drGameConfig["startContinentId"]);
				gameConfig.startXPosition = Convert.ToSingle(drGameConfig["startXPosition"]);
				gameConfig.startYPosition = Convert.ToSingle(drGameConfig["startYPosition"]);
				gameConfig.startZPosition = Convert.ToSingle(drGameConfig["startZPosition"]);
				gameConfig.startRadius = Convert.ToSingle(drGameConfig["startRadius"]);
				gameConfig.startYRotationType = Convert.ToInt32(drGameConfig["startYRotationType"]);
				gameConfig.startYRotation = Convert.ToSingle(drGameConfig["startYRotation"]); 
				gameConfig.mailRetentionDay = Convert.ToInt32(drGameConfig["mailRetentionDay"]);
				gameConfig.mainGearOptionAttrMinCount = Convert.ToInt32(drGameConfig["mainGearOptionAttrMinCount"]);
				gameConfig.mainGearOptionAttrMaxCount = Convert.ToInt32(drGameConfig["mainGearOptionAttrMaxCount"]);
				gameConfig.mainGearRefinementItemId = Convert.ToInt32(drGameConfig["mainGearRefinementItemId"]);
				gameConfig.specialSkillId = Convert.ToInt32(drGameConfig["specialSkillId"]);
				gameConfig.specialSkillMaxLak = Convert.ToInt32(drGameConfig["specialSkillMaxLak"]);
				gameConfig.freeImmediateRevivalDailyCount = Convert.ToInt32(drGameConfig["freeImmediateRevivalDailyCount"]);
				gameConfig.autoSaftyRevivalWatingTime = Convert.ToInt32(drGameConfig["autoSaftyRevivalWatingTime"]);
				gameConfig.startContinentSaftyRevivalXPosition = Convert.ToSingle(drGameConfig["startContinentSaftyRevivalXPosition"]);
				gameConfig.startContinentSaftyRevivalYPosition = Convert.ToSingle(drGameConfig["startContinentSaftyRevivalYPosition"]);
				gameConfig.startContinentSaftyRevivalZPosition = Convert.ToSingle(drGameConfig["startContinentSaftyRevivalZPosition"]);
				gameConfig.startContinentSaftyRevivalRadius = Convert.ToSingle(drGameConfig["startContinentSaftyRevivalRadius"]);
				gameConfig.startContinentSaftyRevivalYRotationType = Convert.ToInt32(drGameConfig["startContinentSaftyRevivalYRotationType"]);
				gameConfig.startContinentSaftyRevivalYRotation = Convert.ToSingle(drGameConfig["startContinentSaftyRevivalYRotation"]);
				gameConfig.saftyRevivalContinentId = Convert.ToInt32(drGameConfig["saftyRevivalContinentId"]);
				gameConfig.saftyRevivalXPosition = Convert.ToSingle(drGameConfig["saftyRevivalXPosition"]);
				gameConfig.saftyRevivalYPosition = Convert.ToSingle(drGameConfig["saftyRevivalYPosition"]);
				gameConfig.saftyRevivalZPosition = Convert.ToSingle(drGameConfig["saftyRevivalZPosition"]);
				gameConfig.saftyRevivalRadius = Convert.ToSingle(drGameConfig["saftyRevivalRadius"]);
				gameConfig.saftyRevivalYRotationType = Convert.ToInt32(drGameConfig["saftyRevivalYRotationType"]);
				gameConfig.saftyRevivalYRotation = Convert.ToSingle(drGameConfig["saftyRevivalYRotation"]);
				gameConfig.simpleShopSellSlotCount = Convert.ToInt32(drGameConfig["simpleShopSellSlotCount"]);
				gameConfig.mainGearDisassembleSlotCount = Convert.ToInt32(drGameConfig["mainGearDisassembleSlotCount"]);
				gameConfig.restRewardRequiredHeroLevel = Convert.ToInt32(drGameConfig["restRewardRequiredHeroLevel"]);
				gameConfig.restRewardGoldReceiveExpRate = Convert.ToInt32(drGameConfig["restRewardGoldReceiveExpRate"]);
				gameConfig.restRewardDiaReceiveExpRate = Convert.ToInt32(drGameConfig["restRewardDiaReceiveExpRate"]);
				gameConfig.partyMemberMaxCount = Convert.ToInt32(drGameConfig["partyMemberMaxCount"]);
				gameConfig.partyMemberLogOutDuration = Convert.ToInt32(drGameConfig["partyMemberLogOutDuration"]);
				gameConfig.partyInvitationLifetime = Convert.ToInt32(drGameConfig["partyInvitationLifetime"]);
				gameConfig.partyApplicationLifetime = Convert.ToInt32(drGameConfig["partyApplicationLifetime"]);
				gameConfig.partyCallCoolTime = Convert.ToInt32(drGameConfig["partyCallCoolTime"]);
				gameConfig.chattingMaxLength = Convert.ToInt32(drGameConfig["chattingMaxLength"]);
				gameConfig.chattingMinInterval = Convert.ToInt32(drGameConfig["chattingMinInterval"]);
				gameConfig.worldChattingDisplayDuration = Convert.ToInt32(drGameConfig["worldChattingDisplayDuration"]);
				gameConfig.worldChattingItemId = Convert.ToInt32(drGameConfig["worldChattingItemId"]);
				gameConfig.chattingSendHistoryMaxCount = Convert.ToInt32(drGameConfig["chattingSendHistoryMaxCount"]);
				gameConfig.chattingBubbleDisplayDuration = Convert.ToInt32(drGameConfig["chattingBubbleDisplayDuration"]);
				gameConfig.chattingDisplayMaxCount = Convert.ToInt32(drGameConfig["chattingDisplayMaxCount"]);
				gameConfig.weekendAttendItemRewardId = Convert.ToInt64(drGameConfig["weekendAttendItemRewardId"]);
				gameConfig.mountLevelUpItemId = Convert.ToInt32(drGameConfig["mountLevelUpItemId"]);
				gameConfig.mountQualityUpRequiredLevelUpCount = Convert.ToInt32(drGameConfig["mountQualityUpRequiredLevelUpCount"]);
				gameConfig.equippedMountAttrFactor = Convert.ToSingle(drGameConfig["equippedMountAttrFactor"]);
				gameConfig.mountGearOptionAttrCount = Convert.ToInt32(drGameConfig["mountGearOptionAttrCount"]);
				gameConfig.mountGearRefinementItemId = Convert.ToInt32(drGameConfig["mountGearRefinementItemId"]);
				gameConfig.dungeonFreeSweepDailyCount = Convert.ToInt32(drGameConfig["dungeonFreeSweepDailyCount"]);
				gameConfig.dungeonSweepItemId = Convert.ToInt32(drGameConfig["dungeonSweepItemId"]);
				gameConfig.wingEnchantItemId = Convert.ToInt32(drGameConfig["wingEnchantItemId"]);
				gameConfig.wingEnchantExp = Convert.ToInt32(drGameConfig["wingEnchantExp"]);
				gameConfig.maxStamina = Convert.ToInt32(drGameConfig["maxStamina"]);
				gameConfig.staminaRecoveryTime = Convert.ToInt32(drGameConfig["staminaRecoveryTime"]);
				gameConfig.defaultToastDisplayDuration = Convert.ToInt32(drGameConfig["defaultToastDisplayDuration"]);
				gameConfig.defaultToastDisplayCount = Convert.ToInt32(drGameConfig["defaultToastDisplayCount"]);
				gameConfig.itemToastDisplayDuration = Convert.ToInt32(drGameConfig["itemToastDisplayDuration"]);
				gameConfig.battlePowerToastDisplayDuration = Convert.ToInt32(drGameConfig["battlePowerToastDisplayDuration"]);
				gameConfig.contentOpenToastDisplayDuration = Convert.ToInt32(drGameConfig["contentOpenToastDisplayDuration"]);
				gameConfig.locationAreaToastDisplayDuration = Convert.ToInt32(drGameConfig["locationAreaToastDisplayDuration"]);
				gameConfig.guideToastDisplayDuration = Convert.ToInt32(drGameConfig["guideToastDisplayDuration"]);
				gameConfig.wingVisibleMinVipLevel = Convert.ToInt32(drGameConfig["wingVisibleMinVipLevel"]);
				gameConfig.hpPotionAutoUseHpRate = Convert.ToInt32(drGameConfig["hpPotionAutoUseHpRate"]);
				gameConfig.standingBattleRange = Convert.ToSingle(drGameConfig["standingBattleRange"]);
				gameConfig.shortDistanceBattleRange = Convert.ToSingle(drGameConfig["shortDistanceBattleRange"]);
				gameConfig.optimizationModeWaitingTime = Convert.ToInt32(drGameConfig["optimizationModeWaitingTime"]);
				gameConfig.deadWarningDisplayHpRate = Convert.ToInt32(drGameConfig["deadWarningDisplayHpRate"]);
				gameConfig.pvpMinHeroLevel = Convert.ToInt32(drGameConfig["pvpMinHeroLevel"]);
				gameConfig.cartNormalSpeed = Convert.ToInt32(drGameConfig["cartNormalSpeed"]);
				gameConfig.cartHighSpeed = Convert.ToInt32(drGameConfig["cartHighSpeed"]);
				gameConfig.cartHighSpeedDuration = Convert.ToInt32(drGameConfig["cartHighSpeedDuration"]);
				gameConfig.cartHighSpeedDurationExtension = Convert.ToInt32(drGameConfig["cartHighSpeedDurationExtension"]);
				gameConfig.cartAccelCoolTime = Convert.ToInt32(drGameConfig["cartAccelCoolTime"]);
				gameConfig.worldLevelExpBuffMinHeroLevel = Convert.ToInt32(drGameConfig["worldLevelExpBuffMinHeroLevel"]);
				gameConfig.nationTransmissionRequiredHeroLevel = Convert.ToInt32(drGameConfig["nationTransmissionRequiredHeroLevel"]);
				gameConfig.nationTransmissionExitXPosition = Convert.ToSingle(drGameConfig["nationTransmissionExitXPosition"]);
				gameConfig.nationTransmissionExitYPosition = Convert.ToSingle(drGameConfig["nationTransmissionExitYPosition"]);
				gameConfig.nationTransmissionExitZPosition = Convert.ToSingle(drGameConfig["nationTransmissionExitZPosition"]);
				gameConfig.nationTransmissionExitRadius = Convert.ToSingle(drGameConfig["nationTransmissionExitRadius"]);
				gameConfig.nationTransmissionExitYRotationType = Convert.ToSingle(drGameConfig["nationTransmissionExitYRotationType"]);
				gameConfig.nationTransmissionExitYRotation = Convert.ToSingle(drGameConfig["nationTransmissionExitYRotation"]);
				gameConfig.bountyHunterQuestMaxCount = Convert.ToInt32(drGameConfig["bountyHunterQuestMaxCount"]);
				gameConfig.bountyHunterQuestRequiredHeroLevel = Convert.ToInt32(drGameConfig["bountyHunterQuestRequiredHeroLevel"]);
				gameConfig.todayMissionCount = Convert.ToInt32(drGameConfig["todayMissionCount"]);
				gameConfig.fieldOfHonorDisplayMaxRanking = Convert.ToInt32(drGameConfig["fieldOfHonorDisplayMaxRanking"]);
				gameConfig.fieldOfHonorDisplayHistoryCount = Convert.ToInt32(drGameConfig["fieldOfHonorDisplayHistoryCount"]);
				gameConfig.rankingDisplayMaxCount = Convert.ToInt32(drGameConfig["rankingDisplayMaxCount"]);
				gameConfig.guildRequiredHeroLevel = Convert.ToInt32(drGameConfig["guildRequiredHeroLevel"]);
				gameConfig.guildCreationRequiredVipLevel = Convert.ToInt32(drGameConfig["guildCreationRequiredVipLevel"]);
				gameConfig.guildCreationRequiredDia = Convert.ToInt32(drGameConfig["guildCreationRequiredDia"]);
				gameConfig.guildRejoinIntervalTime = Convert.ToInt32(drGameConfig["guildRejoinIntervalTime"]);
				gameConfig.guildApplicationReceptionMaxCount = Convert.ToInt32(drGameConfig["guildApplicationReceptionMaxCount"]);
				gameConfig.guildDailyApplicationMaxCount = Convert.ToInt32(drGameConfig["guildDailyApplicationMaxCount"]);
				gameConfig.guildDailyBanishmentMaxCount = Convert.ToInt32(drGameConfig["guildDailyBanishmentMaxCount"]);
				gameConfig.guildInvitationLifetime = Convert.ToInt32(drGameConfig["guildInvitationLifetime"]);
				gameConfig.guildNoticeMaxLength = Convert.ToInt32(drGameConfig["guildNoticeMaxLength"]);
				gameConfig.guildViceMasterCount = Convert.ToInt32(drGameConfig["guildViceMasterCount"]);
				gameConfig.guildLordCount = Convert.ToInt32(drGameConfig["guildLordCount"]);
				gameConfig.guildRankingDisplayMaxCount = Convert.ToInt32(drGameConfig["guildRankingDisplayMaxCount"]);
				gameConfig.rankOpenRequiredMainQuestNo = Convert.ToInt32(drGameConfig["rankOpenRequiredMainQuestNo"]);
				gameConfig.wingOpenRequiredHeroLevel = Convert.ToInt32(drGameConfig["wingOpenRequiredHeroLevel"]);
				gameConfig.wingOpenProvideWingId = Convert.ToInt32(drGameConfig["wingOpenProvideWingId"]);
				gameConfig.guildCallLifetime = Convert.ToInt32(drGameConfig["guildCallLifetime"]);
				gameConfig.guildCallRadius = Convert.ToSingle(drGameConfig["guildCallRadius"]);
				gameConfig.nationCallLifetime = Convert.ToInt32(drGameConfig["nationCallLifetime"]);
				gameConfig.nationCallRadius = Convert.ToSingle(drGameConfig["nationCallRadius"]);
				gameConfig.guildDailyObjectiveNoticeTextKey = Convert.ToString(drGameConfig["guildDailyObjectiveNoticeTextKey"]);
				gameConfig.guildDailyObjectiveNoticeCoolTime = Convert.ToInt32(drGameConfig["guildDailyObjectiveNoticeCoolTime"]);
				gameConfig.defaultGuildWeeklyObjectiveId = Convert.ToInt32(drGameConfig["defaultGuildWeeklyObjectiveId"]);
				gameConfig.guildHuntingDonationMaxCount = Convert.ToInt32(drGameConfig["guildHuntingDonationMaxCount"]);
				gameConfig.guildHuntingDonationItemId = Convert.ToInt32(drGameConfig["guildHuntingDonationItemId"]);
				gameConfig.guildHuntingDonationItemRewardId = Convert.ToInt64(drGameConfig["guildHuntingDonationItemRewardId"]);
				gameConfig.guildHuntingDonationCompletionItemRewardId = Convert.ToInt64(drGameConfig["guildHuntingDonationCompletionItemRewardId"]);
				gameConfig.signBoardDisplayDuration = Convert.ToInt32(drGameConfig["signBoardDisplayDuration"]);
				gameConfig.noticeBoardDisplayDuration = Convert.ToInt32(drGameConfig["noticeBoardDisplayDuration"]);
				gameConfig.creatureCardShopRandomProductCount = Convert.ToInt32(drGameConfig["creatureCardShopRandomProductCount"]);
				gameConfig.creatureCardShopPaidRefreshDia = Convert.ToInt32(drGameConfig["creatureCardShopPaidRefreshDia"]);
				gameConfig.guideActivationRequiredHeroLevel = Convert.ToInt32(drGameConfig["guideActivationRequiredHeroLevel"]);
				gameConfig.accelerationRequiredMoveDuration = Convert.ToInt32(drGameConfig["accelerationRequiredMoveDuration"]);
				gameConfig.accelerationMoveSpeed = Convert.ToInt32(drGameConfig["accelerationMoveSpeed"]);
				gameConfig.sceneryQuestRequiredMainQuestNo = Convert.ToInt32(drGameConfig["sceneryQuestRequiredMainQuestNo"]);
				gameConfig.menuContentOpenPreviewRequiredHeroLevel = Convert.ToInt32(drGameConfig["menuContentOpenPreviewRequiredHeroLevel"]);
				gameConfig.monsterGroggyDuration = Convert.ToInt32(drGameConfig["monsterGroggyDuration"]);
				gameConfig.monsterStealDuration = Convert.ToInt32(drGameConfig["monsterStealDuration"]);
				gameConfig.rookieGiftScratchOpenDuration = Convert.ToInt32(drGameConfig["rookieGiftScratchOpenDuration"]);
				gameConfig.openGiftRequiredHeroLevel = Convert.ToInt32(drGameConfig["openGiftRequiredHeroLevel"]);
				gameConfig.open7DayEventRequiredMainQuestNo = Convert.ToInt32(drGameConfig["open7DayEventRequiredMainQuestNo"]);
				gameConfig.taskConsignmentRequiredVipLevel = Convert.ToInt32(drGameConfig["taskConsignmentRequiredVipLevel"]);
				gameConfig.warehouseRequiredVipLevel = Convert.ToInt32(drGameConfig["warehouseRequiredVipLevel"]);
				gameConfig.freeWarehouseSlotCount = Convert.ToInt32(drGameConfig["freeWarehouseSlotCount"]);
				gameConfig.wingMemoryPieceInstallationRequiredHeroLevel = Convert.ToInt32(drGameConfig["wingMemoryPieceInstallationRequiredHeroLevel"]);
				gameConfig.ordealQuestSlotCount = Convert.ToInt32(drGameConfig["ordealQuestSlotCount"]);
				gameConfig.friendMaxCount = Convert.ToInt32(drGameConfig["friendMaxCount"]);
				gameConfig.tempFriendMaxCount = Convert.ToInt32(drGameConfig["tempFriendMaxCount"]);
				gameConfig.deadRecordMaxCount = Convert.ToInt32(drGameConfig["deadRecordMaxCount"]);
				gameConfig.blacklistEntryMaxCount = Convert.ToInt32(drGameConfig["blacklistEntryMaxCount"]);
				gameConfig.blessingQuestListMaxCount = Convert.ToInt32(drGameConfig["blessingQuestListMaxCount"]);
				gameConfig.blessingQuestRequiredHeroLevel = Convert.ToInt32(drGameConfig["blessingQuestRequiredHeroLevel"]);
				gameConfig.blessingListMaxCount = Convert.ToInt32(drGameConfig["blessingListMaxCount"]);
				gameConfig.ownerProspectQuestListMaxCount = Convert.ToInt32(drGameConfig["ownerProspectQuestListMaxCount"]);
				gameConfig.targetProspectQuestListMaxCount = Convert.ToInt32(drGameConfig["targetProspectQuestListMaxCount"]);
				gameConfig.creatureMaxCount = Convert.ToInt32(drGameConfig["creatureMaxCount"]);
				gameConfig.creatureCheerMaxCount = Convert.ToInt32(drGameConfig["creatureCheerMaxCount"]);
				gameConfig.creatureCheerAttrFactor = Convert.ToSingle(drGameConfig["creatureCheerAttrFactor"]);
				gameConfig.creatureEvaluationFactor = Convert.ToSingle(drGameConfig["creatureEvaluationFactor"]);
				gameConfig.creatureAdditionalAttrCount = Convert.ToInt32(drGameConfig["creatureAdditionalAttrCount"]);
				gameConfig.creatureSkillSlotMaxCount = Convert.ToInt32(drGameConfig["creatureSkillSlotMaxCount"]);
				gameConfig.creatureSkillSlotBaseOpenCount = Convert.ToInt32(drGameConfig["creatureSkillSlotBaseOpenCount"]);
				gameConfig.creatureCompositionExpRetrievalRate = Convert.ToInt32(drGameConfig["creatureCompositionExpRetrievalRate"]);
				gameConfig.creatureCompositionExpRetrievalResultItemId = Convert.ToInt32(drGameConfig["creatureCompositionExpRetrievalResultItemId"]);
				gameConfig.creatureCompositionSkillProtectionItemId = Convert.ToInt32(drGameConfig["creatureCompositionSkillProtectionItemId"]);
				gameConfig.creatureInjectionExpRetrievalRate = Convert.ToInt32(drGameConfig["creatureInjectionExpRetrievalRate"]);
				gameConfig.creatureVariationRequiredItemId = Convert.ToInt32(drGameConfig["creatureVariationRequiredItemId"]);
				gameConfig.creatureAdditionalAttrSwitchRequiredItemId = Convert.ToInt32(drGameConfig["creatureAdditionalAttrSwitchRequiredItemId"]);
				gameConfig.creatureReleaseExpRetrievalRate = Convert.ToInt32(drGameConfig["creatureReleaseExpRetrievalRate"]);
				gameConfig.participationCreatureDisplayRequiredVipLevel = Convert.ToInt32(drGameConfig["participationCreatureDisplayRequiredVipLevel"]);
				gameConfig.presentPopularityPointRankingDisplayMaxCount = Convert.ToInt32(drGameConfig["presentPopularityPointRankingDisplayMaxCount"]);
				gameConfig.presentContributionPointRankingDisplayMaxCount = Convert.ToInt32(drGameConfig["presentContributionPointRankingDisplayMaxCount"]);
				gameConfig.guildBlessingGuildTerritoryNpcId = Convert.ToInt32(drGameConfig["guildBlessingGuildTerritoryNpcId"]);
				gameConfig.nationAllianceUnavailableStartTime = Convert.ToInt32(drGameConfig["nationAllianceUnavailableStartTime"]);
				gameConfig.nationAllianceUnavailableEndTime = Convert.ToInt32(drGameConfig["nationAllianceUnavailableEndTime"]);
				gameConfig.nationAllianceRequiredFund = Convert.ToInt64(drGameConfig["nationAllianceRequiredFund"]);
				gameConfig.nationAllianceRenounceUnavailableDuration = Convert.ToInt32(drGameConfig["nationAllianceRenounceUnavailableDuration"]);
				gameConfig.nationBasePower = Convert.ToInt32(drGameConfig["nationBasePower"]);
				gameConfig.open7DayEventCostumeItemRewardId = Convert.ToInt64(drGameConfig["open7DayEventCostumeItemRewardId"]);
				gameConfig.open7DayEventCostumeRewardRequiredItemId = Convert.ToInt32(drGameConfig["open7DayEventCostumeRewardRequiredItemId"]);
				gameConfig.open7DayEventCostumeRewardRequiredItemCount = Convert.ToInt32(drGameConfig["open7DayEventCostumeRewardRequiredItemCount"]);
				gameConfig.jobChangeRequiredHeroLevel = Convert.ToInt32(drGameConfig["jobChangeRequiredHeroLevel"]);
				gameConfig.jobChangeRequiredItemId = Convert.ToInt32(drGameConfig["jobChangeRequiredItemId"]);
				gameConfig.jobChangeQuestCompletionClientTutorialId = Convert.ToInt32(drGameConfig["jobChangeQuestCompletionClientTutorialId"]);
				gameConfig.chargeEventRequiredHeroLevel = Convert.ToInt32(drGameConfig["chargeEventRequiredHeroLevel"]);
				gameConfig.consumeEventRequiredHeroLevel = Convert.ToInt32(drGameConfig["consumeEventRequiredHeroLevel"]);
				gameConfig.artifactRequiredConditionType = Convert.ToInt32(drGameConfig["artifactRequiredConditionType"]);
				gameConfig.artifactRequiredConditionValue = Convert.ToInt32(drGameConfig["artifactRequiredConditionValue"]);
				gameConfig.artifactMaxLevel = Convert.ToInt32(drGameConfig["artifactMaxLevel"]);
				gameConfig.mountAwakeningRequiredHeroLevel = Convert.ToInt32(drGameConfig["mountAwakeningRequiredHeroLevel"]);
				gameConfig.mountAwakeningItemId = Convert.ToInt32(drGameConfig["mountAwakeningItemId"]);
				gameConfig.mountPotionAttrItemId = Convert.ToInt32(drGameConfig["mountPotionAttrItemId"]);
				gameConfig.costumeEnchantItemId = Convert.ToInt32(drGameConfig["costumeEnchantItemId"]);
				gameConfig.costumeCollectionActivationItemId = Convert.ToInt32(drGameConfig["costumeCollectionActivationItemId"]);
				gameConfig.costumeCollectionShuffleItemId = Convert.ToInt32(drGameConfig["costumeCollectionShuffleItemId"]);
				gameConfig.costumeCollectionShuffleItemCount = Convert.ToInt32(drGameConfig["costumeCollectionShuffleItemCount"]);
			}
			gameDatas.gameConfig = gameConfig;
			
			//
			// 직업 목록
			//
			List<WPDJob> jobs = new List<WPDJob>();
			foreach (DataRow dr in drcJobs)
			{
				WPDJob data = new WPDJob();
				data.jobId = Convert.ToInt32(dr["jobId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.moveSpeed = Convert.ToInt32(dr["moveSpeed"]);
				data.walkMoveSpeed = Convert.ToInt32(dr["walkMoveSpeed"]);
				data.offenseType = Convert.ToInt32(dr["offenseType"]);
				data.elementalId = Convert.ToInt32(dr["elementalId"]);
				data.radius = Convert.ToSingle(dr["radius"]);
				data.parentJobId = Convert.ToInt32(dr["parentJobId"]);

				jobs.Add(data);
			}
			gameDatas.jobs = jobs.ToArray();
			jobs.Clear();

			//
			// 국가 목록
			//
			List<WPDNation> nations = new List<WPDNation>();
			foreach (DataRow dr in drcNations)
			{
				WPDNation data = new WPDNation();
				data.nationId = Convert.ToInt32(dr["nationId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);

				nations.Add(data);
			}
			gameDatas.nations = nations.ToArray();
			nations.Clear();

			//
			// 속성카테고리 목록
			//
			List<WPDAttrCategory> attrCategories = new List<WPDAttrCategory>();
			foreach (DataRow dr in drcAttrCategories)
			{
				WPDAttrCategory data = new WPDAttrCategory();
				data.attrCategoryId = Convert.ToInt32(dr["attrCategoryId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);

				attrCategories.Add(data);
			}
			gameDatas.attrCategories = attrCategories.ToArray();
			attrCategories.Clear();

			//
			// 속성 목록
			//
			List<WPDAttr> attrs = new List<WPDAttr>();
			foreach (DataRow dr in drcAttrs)
			{
				WPDAttr data = new WPDAttr();
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.battlePowerFactor = Convert.ToInt32(dr["battlePowerFactor"]);
				data.attrCategoryId = Convert.ToInt32(dr["attrCategoryId"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);

				attrs.Add(data);
			}
			gameDatas.attrs = attrs.ToArray();
			attrs.Clear();

			//
			// 원소 목록
			//
			List<WPDElemental> elementals = new List<WPDElemental>();
			foreach (DataRow dr in drcElementals)
			{
				WPDElemental data = new WPDElemental();
				data.elementalId = Convert.ToInt32(dr["elementalId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);

				elementals.Add(data);
			}
			gameDatas.elementals = elementals.ToArray();
			elementals.Clear();

			//
			// 아이템타입 목록
			//
			List<WPDItemType> itemTypes = new List<WPDItemType>();
			foreach (DataRow dr in drcItemTypes)
			{
				WPDItemType data = new WPDItemType();
				data.itemType = Convert.ToInt32(dr["itemType"]);
				data.maxCountPerInventorySlot = Convert.ToInt32(dr["maxCountPerInventorySlot"]);
				data.mainCategoryId = Convert.ToInt32(dr["mainCategoryId"]);
				data.subCategoryId = Convert.ToInt32(dr["subCategoryId"]);

				itemTypes.Add(data);
			}
			gameDatas.itemTypes = itemTypes.ToArray();
			itemTypes.Clear();

			//
			// 아이템등급 목록
			//
			List<WPDItemGrade> itemGrades = new List<WPDItemGrade>();
			foreach (DataRow dr in drcItemGrades)
			{
				WPDItemGrade data = new WPDItemGrade();
				data.grade = Convert.ToInt32(dr["grade"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.colorCode = Convert.ToString(dr["colorCode"]);

				itemGrades.Add(data);
			}
			gameDatas.itemGrades = itemGrades.ToArray();
			itemGrades.Clear();

			//
			// 아이템 목록
			//
			List<WPDItem> items = new List<WPDItem>();
			foreach (DataRow dr in drcItems)
			{
				WPDItem data = new WPDItem();
				data.itemId = Convert.ToInt32(dr["itemId"]);
				data.itemType = Convert.ToInt32(dr["itemType"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.grade = Convert.ToInt32(dr["grade"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.requiredMinHeroLevel = Convert.ToInt32(dr["requiredMinHeroLevel"]);
				data.requiredMaxHeroLevel = Convert.ToInt32(dr["requiredMaxHeroLevel"]);
				data.usingType = Convert.ToInt32(dr["usingType"]);
				data.usingRecommendationEnabled = Convert.ToBoolean(dr["usingRecommendationEnabled"]);
				data.saleable = Convert.ToBoolean(dr["saleable"]);
				data.saleGold = Convert.ToInt32(dr["saleGold"]);
				data.autoUsable = Convert.ToBoolean(dr["autoUsable"]);
				data.value1 = Convert.ToInt32(dr["value1"]);
				data.value2 = Convert.ToInt32(dr["value2"]);
				data.longValue1 = Convert.ToInt64(dr["longValue1"]);
				data.longValue2 = Convert.ToInt64(dr["longValue2"]);

				items.Add(data);
			}
			gameDatas.items = items.ToArray();
			items.Clear();

			//
			// 메인장비 카테고리 목록
			//
			List<WPDMainGearCategory> mainGearCategories = new List<WPDMainGearCategory>();
			foreach (DataRow dr in drcMainGearCategories)
			{
				WPDMainGearCategory data = new WPDMainGearCategory();
				data.categoryId = Convert.ToInt32(dr["categoryId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.slotIndex = Convert.ToInt32(dr["slotIndex"]);

				mainGearCategories.Add(data);
			}
			gameDatas.mainGearCategories = mainGearCategories.ToArray();
			mainGearCategories.Clear();

			//
			// 메인장비 타입 목록
			//
			List<WPDMainGearType> mainGearTypes = new List<WPDMainGearType>();
			foreach (DataRow dr in drcMainGearTypes)
			{
				WPDMainGearType data = new WPDMainGearType();
				data.mainGearType = Convert.ToInt32(dr["mainGearType"]);
				data.categoryId = Convert.ToInt32(dr["categoryId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);

				mainGearTypes.Add(data);
			}
			gameDatas.mainGearTypes = mainGearTypes.ToArray();
			mainGearTypes.Clear();

			//
			// 메인장비 티어 목록
			//
			List<WPDMainGearTier> mainGearTiers = new List<WPDMainGearTier>();
			foreach (DataRow dr in drcMainGearTiers)
			{
				WPDMainGearTier data = new WPDMainGearTier();
				data.tier = Convert.ToInt32(dr["tier"]);
				data.requiredHeroLevel = Convert.ToInt32(dr["requiredHeroLevel"]);

				mainGearTiers.Add(data);
			}
			gameDatas.mainGearTiers = mainGearTiers.ToArray();
			mainGearTiers.Clear();

			//
			// 메인장비 목록
			//
			List<WPDMainGear> mainGears = new List<WPDMainGear>();
			foreach (DataRow dr in drcMainGears)
			{
				WPDMainGear data = new WPDMainGear();
				data.mainGearId = Convert.ToInt32(dr["mainGearId"]);
				data.mainGearType = Convert.ToInt32(dr["mainGearType"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.jobId = Convert.ToInt32(dr["jobId"]);
				data.tier = Convert.ToInt32(dr["tier"]);
				data.grade = Convert.ToInt32(dr["grade"]);
				data.quality = Convert.ToInt32(dr["quality"]);
				data.saleGold = Convert.ToInt32(dr["saleGold"]);
				data.prefabName = Convert.ToString(dr["prefabName"]);

				mainGears.Add(data);
			}
			gameDatas.mainGears = mainGears.ToArray();
			mainGears.Clear();

			//
			// 메인장비 등급 목록
			//
			List<WPDMainGearGrade> mainGearGrades = new List<WPDMainGearGrade>();
			foreach (DataRow dr in drcMainGearGrades)
			{
				WPDMainGearGrade data = new WPDMainGearGrade();
				data.grade = Convert.ToInt32(dr["grade"]);
				data.colorCode = Convert.ToString(dr["colorCode"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);

				mainGearGrades.Add(data);
			}
			gameDatas.mainGearGrades = mainGearGrades.ToArray();
			mainGearGrades.Clear();

			//
			// 메인장비 품질 목록
			//
			List<WPDMainGearQuality> mainGearQualities = new List<WPDMainGearQuality>();
			foreach (DataRow dr in drcMainGearQualities)
			{
				WPDMainGearQuality data = new WPDMainGearQuality();
				data.quality = Convert.ToInt32(dr["quality"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);

				mainGearQualities.Add(data);
			}
			gameDatas.mainGearQualities = mainGearQualities.ToArray();
			mainGearQualities.Clear();

			//
			// 메인장비 기본속성 목록
			//
			List<WPDMainGearBaseAttr> mainGearBaseAttrs = new List<WPDMainGearBaseAttr>();
			foreach (DataRow dr in drcMainGearBaseAttrs)
			{
				WPDMainGearBaseAttr data = new WPDMainGearBaseAttr();
				data.mainGearId = Convert.ToInt32(dr["mainGearId"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);

				mainGearBaseAttrs.Add(data);
			}
			gameDatas.mainGearBaseAttrs = mainGearBaseAttrs.ToArray();
			mainGearBaseAttrs.Clear();

			//
			// 메인장비 기본속성 강화레벨 목록
			//
			List<WPDMainGearBaseAttrEnchantLevel> mainGearBaseAttrEnchantLevels = new List<WPDMainGearBaseAttrEnchantLevel>();
			foreach (DataRow dr in drcMainGearBaseAttrEnchantLevels)
			{
				WPDMainGearBaseAttrEnchantLevel data = new WPDMainGearBaseAttrEnchantLevel();
				data.mainGearId = Convert.ToInt32(dr["mainGearId"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.enchantLevel = Convert.ToInt32(dr["enchantLevel"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);

				mainGearBaseAttrEnchantLevels.Add(data);
			}
			gameDatas.mainGearBaseAttrEnchantLevels = mainGearBaseAttrEnchantLevels.ToArray();
			mainGearBaseAttrEnchantLevels.Clear();

			//
			// 메인장비 강화 단계 목록
			//
			List<WPDMainGearEnchantStep> mainGearEnchantSteps = new List<WPDMainGearEnchantStep>();
			foreach (DataRow dr in drcMainGearEnchantSteps)
			{
				WPDMainGearEnchantStep data = new WPDMainGearEnchantStep();
				data.step = Convert.ToInt32(dr["step"]);
				data.nextEnchantMaterialItemId = Convert.ToInt32(dr["nextEnchantMaterialItemId"]);
				data.nextEnchantPenaltyPreventItemId = Convert.ToInt32(dr["nextEnchantPenaltyPreventItemId"]);

				mainGearEnchantSteps.Add(data);
			}
			gameDatas.mainGearEnchantSteps = mainGearEnchantSteps.ToArray();
			mainGearEnchantSteps.Clear();

			//
			// 메인장비 강화 레벨 목록
			//
			List<WPDMainGearEnchantLevel> mainGearEnchantLevels = new List<WPDMainGearEnchantLevel>();
			foreach (DataRow dr in drcMainGearEnchantLevels)
			{
				WPDMainGearEnchantLevel data = new WPDMainGearEnchantLevel();
				data.enchantLevel = Convert.ToInt32(dr["enchantLevel"]);
				data.step = Convert.ToInt32(dr["step"]);
				data.nextSuccessRate = Convert.ToInt32(dr["nextSuccessRate"]);
				data.penaltyPreventEnabled = Convert.ToBoolean(dr["penaltyPreventEnabled"]);

				mainGearEnchantLevels.Add(data);
			}
			gameDatas.mainGearEnchantLevels = mainGearEnchantLevels.ToArray();
			mainGearEnchantLevels.Clear();

			//
			// 메인장비 옵션속성 등급 목록
			//
			List<WPDMainGearOptionAttrGrade> mainGearOptionAttrGrades = new List<WPDMainGearOptionAttrGrade>();
			foreach (DataRow dr in drcMainGearOptionAttrGrades)
			{
				WPDMainGearOptionAttrGrade data = new WPDMainGearOptionAttrGrade();
				data.attrGrade = Convert.ToInt32(dr["attrGrade"]);
				data.colorCode = Convert.ToString(dr["colorCode"]);

				mainGearOptionAttrGrades.Add(data);
			}
			gameDatas.mainGearOptionAttrGrades = mainGearOptionAttrGrades.ToArray();
			mainGearOptionAttrGrades.Clear();

			//
			// 메인장비 세련 레시피 목록
			//
			List<WPDMainGearRefinementRecipe> mainGearRefinementRecipes = new List<WPDMainGearRefinementRecipe>();
			foreach (DataRow dr in drcMainGearRefinementRecipes)
			{
				WPDMainGearRefinementRecipe data = new WPDMainGearRefinementRecipe();
				data.protectionCount = Convert.ToInt32(dr["protectionCount"]);
				data.protectionItemId = Convert.ToInt32(dr["protectionItemId"]);

				mainGearRefinementRecipes.Add(data);
			}
			gameDatas.mainGearRefinementRecipes = mainGearRefinementRecipes.ToArray();
			mainGearRefinementRecipes.Clear();

			//
			// 보조장비 목록
			//
			List<WPDSubGear> subGears = new List<WPDSubGear>();
			foreach (DataRow dr in drcSubGears)
			{
				WPDSubGear data = new WPDSubGear();
				data.subGearId = Convert.ToInt32(dr["subGearId"]);
				data.slotIndex = Convert.ToInt32(dr["slotIndex"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);

				subGears.Add(data);
			}
			gameDatas.subGears = subGears.ToArray();
			subGears.Clear();

			//
			// 보조장비 등급 목록
			//
			List<WPDSubGearGrade> subGearGrades = new List<WPDSubGearGrade>();
			foreach (DataRow dr in drcSubGearGrades)
			{
				WPDSubGearGrade data = new WPDSubGearGrade();
				data.grade = Convert.ToInt32(dr["grade"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.colorCode = Convert.ToString(dr["colorCode"]);

				subGearGrades.Add(data);
			}
			gameDatas.subGearGrades = subGearGrades.ToArray();
			subGearGrades.Clear();

			//
			// 보조장비 이름 목록
			//
			List<WPDSubGearName> subGearNames = new List<WPDSubGearName>();
			foreach (DataRow dr in drcSubGearNames)
			{
				WPDSubGearName data = new WPDSubGearName();
				data.subGearId = Convert.ToInt32(dr["subGearId"]);
				data.grade = Convert.ToInt32(dr["grade"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);

				subGearNames.Add(data);
			}
			gameDatas.subGearNames = subGearNames.ToArray();
			subGearNames.Clear();

			//
			// 보조장비 룬 소켓 목록
			//
			List<WPDSubGearRuneSocket> subGearRuneSockets = new List<WPDSubGearRuneSocket>();
			foreach (DataRow dr in drcSubGearRuneSockets)
			{
				WPDSubGearRuneSocket data = new WPDSubGearRuneSocket();
				data.subGearId = Convert.ToInt32(dr["subGearId"]);
				data.socketIndex = Convert.ToInt32(dr["socketIndex"]);
				data.requiredSubGearLevel = Convert.ToInt32(dr["requiredSubGearLevel"]);
				data.enableTextKey = Convert.ToString(dr["enableTextKey"]);
				data.backgroundImageName = Convert.ToString(dr["backgroundImageName"]);
				data.miniBackgroundImageName = Convert.ToString(dr["miniBackgroundImageName"]);

				subGearRuneSockets.Add(data);
			}
			gameDatas.subGearRuneSockets = subGearRuneSockets.ToArray();
			subGearRuneSockets.Clear();

			//
			// 보조장비 룬 소켓 장착가능 아이템 타입 목록
			//
			List<WPDSubGearRuneSocketAvailableItemType> subGearRuneSocketAvailableItemTypes = new List<WPDSubGearRuneSocketAvailableItemType>();
			foreach (DataRow dr in drcSubGearRuneSocketAvailableItemTypes)
			{
				WPDSubGearRuneSocketAvailableItemType data = new WPDSubGearRuneSocketAvailableItemType();
				data.subGearId = Convert.ToInt32(dr["subGearId"]);
				data.socketIndex = Convert.ToInt32(dr["socketIndex"]);
				data.itemType = Convert.ToInt32(dr["itemType"]);

				subGearRuneSocketAvailableItemTypes.Add(data);
			}
			gameDatas.subGearRuneSocketAvailableItemTypes = subGearRuneSocketAvailableItemTypes.ToArray();
			subGearRuneSocketAvailableItemTypes.Clear();

			//
			// 보조장비 소울스톤 소켓 목록
			//
			List<WPDSubGearSoulstoneSocket> subGearSoulstoneSockets = new List<WPDSubGearSoulstoneSocket>();
			foreach (DataRow dr in drcSubGearSoulstoneSockets)
			{
				WPDSubGearSoulstoneSocket data = new WPDSubGearSoulstoneSocket();
				data.subGearId = Convert.ToInt32(dr["subGearId"]);
				data.socketIndex = Convert.ToInt32(dr["socketIndex"]);
				data.itemType = Convert.ToInt32(dr["itemType"]);
				data.requiredSubGearGrade = Convert.ToInt32(dr["requiredSubGearGrade"]);

				subGearSoulstoneSockets.Add(data);
			}
			gameDatas.subGearSoulstoneSockets = subGearSoulstoneSockets.ToArray();
			subGearSoulstoneSockets.Clear();

			//
			// 보조장비 속성 목록
			//
			List<WPDSubGearAttr> subGearAttrs = new List<WPDSubGearAttr>();
			foreach (DataRow dr in drcSubGearAttrs)
			{
				WPDSubGearAttr data = new WPDSubGearAttr();
				data.subGearId = Convert.ToInt32(dr["subGearId"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);

				subGearAttrs.Add(data);
			}
			gameDatas.subGearAttrs = subGearAttrs.ToArray();
			subGearAttrs.Clear();

			//
			// 보조장비 속성값 목록
			//
			List<WPDSubGearAttrValue> subGearAttrValues = new List<WPDSubGearAttrValue>();
			foreach (DataRow dr in drcSubGearAttrValues)
			{
				WPDSubGearAttrValue data = new WPDSubGearAttrValue();
				data.subGearId = Convert.ToInt32(dr["subGearId"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.quality = Convert.ToInt32(dr["quality"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);

				subGearAttrValues.Add(data);
			}
			gameDatas.subGearAttrValues = subGearAttrValues.ToArray();
			subGearAttrValues.Clear();

			//
			// 보조장비 레벨 목록
			//
			List<WPDSubGearLevel> subGearLevels = new List<WPDSubGearLevel>();
			foreach (DataRow dr in drcSubGearLevels)
			{
				WPDSubGearLevel data = new WPDSubGearLevel();
				data.subGearId = Convert.ToInt32(dr["subGearId"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.grade = Convert.ToInt32(dr["grade"]);
				data.nextLevelUpRequiredGold = Convert.ToInt32(dr["nextLevelUpRequiredGold"]);
				data.nextGradeUpItem1Id = Convert.ToInt32(dr["nextGradeUpItem1Id"]);
				data.nextGradeUpItem1Count = Convert.ToInt32(dr["nextGradeUpItem1Count"]);
				data.nextGradeUpItem2Id = Convert.ToInt32(dr["nextGradeUpItem2Id"]);
				data.nextGradeUpItem2Count = Convert.ToInt32(dr["nextGradeUpItem2Count"]);

				subGearLevels.Add(data);
			}
			gameDatas.subGearLevels = subGearLevels.ToArray();
			subGearLevels.Clear();

			//
			// 보조장비 레벨 품질 목록
			//
			List<WPDSubGearLevelQuality> subGearLevelQualities = new List<WPDSubGearLevelQuality>();
			foreach (DataRow dr in drcSubGearLevelQualities)
			{
				WPDSubGearLevelQuality data = new WPDSubGearLevelQuality();
				data.subGearId = Convert.ToInt32(dr["subGearId"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.quality = Convert.ToInt32(dr["quality"]);
				data.nextQualityUpItem1Id = Convert.ToInt32(dr["nextQualityUpItem1Id"]);
				data.nextQualityUpItem1Count = Convert.ToInt32(dr["nextQualityUpItem1Count"]);
				data.nextQualityUpItem2Id = Convert.ToInt32(dr["nextQualityUpItem2Id"]);
				data.nextQualityUpItem2Count = Convert.ToInt32(dr["nextQualityUpItem2Count"]);

				subGearLevelQualities.Add(data);
			}
			gameDatas.subGearLevelQualities = subGearLevelQualities.ToArray();
			subGearLevelQualities.Clear();

			//
			// 위치 목록
			//
			List<WPDLocation> locations = new List<WPDLocation>();
			foreach (DataRow dr in drcLocations)
			{
				WPDLocation data = new WPDLocation();
				data.locationId = Convert.ToInt32(dr["locationId"]);
				data.minimapMagnification = Convert.ToSingle(dr["minimapMagnification"]);
				data.accelerationEnabled = Convert.ToBoolean(dr["accelerationEnabled"]);

				locations.Add(data);
			}
			gameDatas.locations = locations.ToArray();
			locations.Clear();

			//
			// 몬스터캐릭터 목록
			//
			List<WPDMonsterCharacter> monsterCharacters = new List<WPDMonsterCharacter>();
			foreach (DataRow dr in drcMonsterCharacters)
			{
				WPDMonsterCharacter data = new WPDMonsterCharacter();
				data.monsterCharacterId = Convert.ToInt32(dr["monsterCharacterId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.prefabName = Convert.ToString(dr["prefabName"]);

				monsterCharacters.Add(data);
			}
			gameDatas.monsterCharacters = monsterCharacters.ToArray();
			monsterCharacters.Clear();

			//
			// 몬스터 목록
			//
			List<WPDMonster> monsters = new List<WPDMonster>();
			foreach (DataRow dr in drcMonsters)
			{
				WPDMonster data = new WPDMonster();
				data.monsterId = Convert.ToInt32(dr["monsterId"]);
				data.monsterCharacterId = Convert.ToInt32(dr["monsterCharacterId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.scale = Convert.ToSingle(dr["scale"]);
				data.height = Convert.ToInt32(dr["height"]);
				data.radius = Convert.ToSingle(dr["radius"]);
				data.moveSpeed = Convert.ToInt32(dr["moveSpeed"]);
				data.battleMoveSpeed = Convert.ToInt32(dr["battleMoveSpeed"]);
				data.visibilityRange = Convert.ToSingle(dr["visibilityRange"]);
				data.patrolRange = Convert.ToSingle(dr["patrolRange"]);
				data.activeAreaRadius = Convert.ToSingle(dr["activeAreaRadius"]);
				data.returnCompletionRadius = Convert.ToSingle(dr["returnCompletionRadius"]);
				data.skillCastingInterval = Convert.ToSingle(dr["skillCastingInterval"]);
				data.maxHp = Convert.ToInt32(dr["maxHp"]);
				data.physicalOffense = Convert.ToInt32(dr["physicalOffense"]);
				data.questAreaRadius = Convert.ToSingle(dr["questAreaRadius"]);
				data.moveEnabled = Convert.ToBoolean(dr["moveEnabled"]);
				data.attackEnabled = Convert.ToBoolean(dr["attackEnabled"]);
				data.attackStopRange = Convert.ToSingle(dr["attackStopRange"]);
				data.tamingEnabled = Convert.ToBoolean(dr["tamingEnabled"]);
				data.mentalStrength = Convert.ToInt32(dr["mentalStrength"]);
				data.stealRadius = Convert.ToSingle(dr["stealRadius"]);
				data.stealSuccessRate = Convert.ToInt32(dr["stealSuccessRate"]);
				data.stealItemRewardId = Convert.ToInt64(dr["stealItemRewardId"]);

				monsters.Add(data);
			}
			gameDatas.monsters = monsters.ToArray();
			monsters.Clear();

			//
			// 대륙 목록
			//
			List<WPDContinent> continents = new List<WPDContinent>();
			foreach (DataRow dr in drcContinents)
			{
				WPDContinent data = new WPDContinent();
				data.continentId = Convert.ToInt32(dr["continentId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.isNationTerritory = Convert.ToBoolean(dr["isNationTerritory"]);
				data.requiredHeroLevel = Convert.ToInt32(dr["requiredHeroLevel"]);
				data.isNationWarTarget = Convert.ToBoolean(dr["isNationWarTarget"]);
				data.sceneName = Convert.ToString(dr["sceneName"]);
				data.locationId = Convert.ToInt32(dr["locationId"]);
				data.x = Convert.ToSingle(dr["x"]);
				data.z = Convert.ToSingle(dr["z"]);
				data.xSize = Convert.ToSingle(dr["xSize"]);
				data.zSize = Convert.ToSingle(dr["zSize"]);

				continents.Add(data);
			}
			gameDatas.continents = continents.ToArray();
			continents.Clear();

			//
			// 메인메뉴 목록
			//
			List<WPDMainMenu> mainMenus = new List<WPDMainMenu>();
			foreach (DataRow dr in drcMainMenus)
			{
				WPDMainMenu data = new WPDMainMenu();
				data.menuId = Convert.ToInt32(dr["menuId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.popupName = Convert.ToString(dr["popupName"]);

				mainMenus.Add(data);
			}
			gameDatas.mainMenus = mainMenus.ToArray();
			mainMenus.Clear();

			//
			// 서브메뉴 목록
			//
			List<WPDSubMenu> subMenus = new List<WPDSubMenu>();
			foreach (DataRow dr in drcSubMenus)
			{
				WPDSubMenu data = new WPDSubMenu();
				data.menuId = Convert.ToInt32(dr["menuId"]);
				data.subMenuId = Convert.ToInt32(dr["subMenuId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.prefab1 = Convert.ToString(dr["prefab1"]);
				data.prefab2 = Convert.ToString(dr["prefab2"]);
				data.prefab3 = Convert.ToString(dr["prefab3"]);
				data.layout = Convert.ToInt32(dr["layout"]);
				data.isDefault = Convert.ToBoolean(dr["isDefault"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);
				data.contentId = Convert.ToInt32(dr["contentId"]);

				subMenus.Add(data);
			}
			gameDatas.subMenus = subMenus.ToArray();
			subMenus.Clear();

			//
			// 직업 스킬 마스터 목록
			//
			List<WPDJobSkillMaster> jobSkillMasters = new List<WPDJobSkillMaster>();
			foreach (DataRow dr in drcJobSkillMasters)
			{
				WPDJobSkillMaster data = new WPDJobSkillMaster();
				data.skillId = Convert.ToInt32(dr["skillId"]);
				data.openRequiredMainQuestNo = Convert.ToInt32(dr["openRequiredMainQuestNo"]);

				jobSkillMasters.Add(data);
			}
			gameDatas.jobSkillMasters = jobSkillMasters.ToArray();
			jobSkillMasters.Clear();

			//
			// 직업 스킬 목록
			//
			List<WPDJobSkill> jobSkills = new List<WPDJobSkill>();
			foreach (DataRow dr in drcJobSkills)
			{
				WPDJobSkill data = new WPDJobSkill();
				data.jobId = Convert.ToInt32(dr["jobId"]);
				data.skillId = Convert.ToInt32(dr["skillId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.formType = Convert.ToInt32(dr["formType"]);
				data.isRequireTarget = Convert.ToBoolean(dr["isRequireTarget"]);
				data.castRange = Convert.ToSingle(dr["castRange"]);
				data.hitRange = Convert.ToSingle(dr["hitRange"]);
				data.coolTime = Convert.ToSingle(dr["coolTime"]);
				data.heroHitType = Convert.ToInt32(dr["heroHitType"]);
				data.hitAreaType = Convert.ToInt32(dr["hitAreaType"]);
				data.hitAreaValue1 = Convert.ToSingle(dr["hitAreaValue1"]);
				data.hitAreaValue2 = Convert.ToSingle(dr["hitAreaValue2"]);
				data.hitAreaOffsetType = Convert.ToInt32(dr["hitAreaOffsetType"]);
				data.hitAreaOffset = Convert.ToSingle(dr["hitAreaOffset"]);
				data.slotIndex = Convert.ToInt32(dr["slotIndex"]);
				data.ssStartDelay = Convert.ToSingle(dr["ssStartDelay"]);
				data.ssDuration = Convert.ToSingle(dr["ssDuration"]);
				data.castingMoveType = Convert.ToInt32(dr["castingMoveType"]);
				data.castingMoveValue1 = Convert.ToInt32(dr["castingMoveValue1"]);
				data.castingMoveValue2 = Convert.ToInt32(dr["castingMoveValue2"]);
				data.autoPriorityGroup = Convert.ToInt32(dr["autoPriorityGroup"]);
				data.autoWeight = Convert.ToInt32(dr["autoWeight"]);
				data.clientSkillIndex = Convert.ToInt32(dr["clientSkillIndex"]);
				data.buffAbnormalStateId = Convert.ToInt32(dr["buffAbnormalStateId"]);

				jobSkills.Add(data);
			}
			gameDatas.jobSkills = jobSkills.ToArray();
			jobSkills.Clear();

			//
			// 직업 스킬 레벨 목록
			//
			List<WPDJobSkillLevel> jobSkillLevels = new List<WPDJobSkillLevel>();
			foreach (DataRow dr in drcJobSkillLevels)
			{
				WPDJobSkillLevel data = new WPDJobSkillLevel();
				data.jobId = Convert.ToInt32(dr["jobId"]);
				data.skillId = Convert.ToInt32(dr["skillId"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.summaryKey = Convert.ToString(dr["summaryKey"]);
				data.battlePower = Convert.ToInt64(dr["battlePower"]);
				data.physicalOffenseAmpAttrValueId = Convert.ToInt64(dr["physicalOffenseAmpAttrValueId"]);
				data.magicalOffenseAmpAttrValueId = Convert.ToInt64(dr["magicalOffenseAmpAttrValueId"]);
				data.offensePointAttrValueId = Convert.ToInt64(dr["offensePointAttrValueId"]);

				jobSkillLevels.Add(data);
			}
			gameDatas.jobSkillLevels = jobSkillLevels.ToArray();
			jobSkillLevels.Clear();


			//
			// 직업 스킬 레벨 마스터 목록
			//
			List<WPDJobSkillLevelMaster> jobSkillLevelMasters = new List<WPDJobSkillLevelMaster>();
			foreach (DataRow dr in drcJobSkillLevelMasters)
			{
				WPDJobSkillLevelMaster data = new WPDJobSkillLevelMaster();
				data.skillId = Convert.ToInt32(dr["skillId"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.nextLevelUpRequiredHeroLevel = Convert.ToInt32(dr["nextLevelUpRequiredHeroLevel"]);
				data.nextLevelUpGold = Convert.ToInt64(dr["nextLevelUpGold"]);
				data.nextLevelUpItemId = Convert.ToInt32(dr["nextLevelUpItemId"]);
				data.nextLevelUpItemCount = Convert.ToInt32(dr["nextLevelUpItemCount"]);

				jobSkillLevelMasters.Add(data);
			}
			gameDatas.jobSkillLevelMasters = jobSkillLevelMasters.ToArray();
			jobSkillLevelMasters.Clear();

			//
			// 직업 스킬 히트 목록
			//
			List<WPDJobSkillHit> jobSkillHits = new List<WPDJobSkillHit>();
			foreach (DataRow dr in drcJobSkillHits)
			{
				WPDJobSkillHit data = new WPDJobSkillHit();
				data.jobId = Convert.ToInt32(dr["jobId"]);
				data.skillId = Convert.ToInt32(dr["skillId"]);
				data.hitId = Convert.ToInt32(dr["hitId"]);
				data.damageFactor = Convert.ToSingle(dr["damageFactor"]);
				data.acquireLak = Convert.ToInt32(dr["acquireLak"]);

				jobSkillHits.Add(data);
			}
			gameDatas.jobSkillHits = jobSkillHits.ToArray();
			jobSkillHits.Clear();

			//
			// 직업 연계스킬 목록
			//
			List<WPDJobChainSkill> jobChainSkills = new List<WPDJobChainSkill>();
			foreach (DataRow dr in drcJobChainSkills)
			{
				WPDJobChainSkill data = new WPDJobChainSkill();
				data.jobId = Convert.ToInt32(dr["jobId"]);
				data.skillId = Convert.ToInt32(dr["skillId"]);
				data.chainSkillId = Convert.ToInt32(dr["chainSkillId"]);
				data.hitAreaType = Convert.ToInt32(dr["hitAreaType"]);
				data.hitAreaValue1 = Convert.ToSingle(dr["hitAreaValue1"]);
				data.hitAreaValue2 = Convert.ToSingle(dr["hitAreaValue2"]);
				data.hitAreaOffsetType = Convert.ToInt32(dr["hitAreaOffsetType"]);
				data.hitAreaOffset = Convert.ToSingle(dr["hitAreaOffset"]);
				data.castConditionStartTime = Convert.ToSingle(dr["castConditionStartTime"]);
				data.castConditionEndTIme = Convert.ToSingle(dr["castConditionEndTIme"]);

				jobChainSkills.Add(data);
			}
			gameDatas.jobChainSkills = jobChainSkills.ToArray();
			jobChainSkills.Clear();

			//
			// 직업 연계스킬 히트 목록
			//
			List<WPDJobChainSkillHit> jobChainSkillHits = new List<WPDJobChainSkillHit>();
			foreach (DataRow dr in drcJobChainSkillHits)
			{
				WPDJobChainSkillHit data = new WPDJobChainSkillHit();
				data.jobId = Convert.ToInt32(dr["jobId"]);
				data.skillId = Convert.ToInt32(dr["skillId"]);
				data.chainSkillId = Convert.ToInt32(dr["chainSkillId"]);
				data.hitId = Convert.ToInt32(dr["hitId"]);
				data.damageFactor = Convert.ToSingle(dr["damageFactor"]);
				data.acquireLak = Convert.ToInt32(dr["acquireLak"]);

				jobChainSkillHits.Add(data);
			}
			gameDatas.jobChainSkillHits = jobChainSkillHits.ToArray();
			jobChainSkillHits.Clear();

			//
			// 직업 스킬 히트 상태이상 목록
			//
			List<WPDJobSkillHitAbnormalState> jobSkillHitAbnormalStates = new List<WPDJobSkillHitAbnormalState>();
			foreach (DataRow dr in drcJobSkillHitAbnormalStates)
			{
				WPDJobSkillHitAbnormalState data = new WPDJobSkillHitAbnormalState();
				data.jobId = Convert.ToInt32(dr["jobId"]);
				data.skillId = Convert.ToInt32(dr["skillId"]);
				data.hitId = Convert.ToInt32(dr["hitId"]);
				data.abnormalStateId = Convert.ToInt32(dr["abnormalStateId"]);

				jobSkillHitAbnormalStates.Add(data);
			}
			gameDatas.jobSkillHitAbnormalStates = jobSkillHitAbnormalStates.ToArray();
			jobSkillHitAbnormalStates.Clear();

			//
			// 포탈 목록
			//
			List<WPDPortal> portals = new List<WPDPortal>();
			foreach (DataRow dr in drcPortals)
			{
				WPDPortal data = new WPDPortal();
				data.portalId = Convert.ToInt32(dr["portalId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.continentId = Convert.ToInt32(dr["continentId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.radius = Convert.ToSingle(dr["radius"]);
				data.exitXPosition = Convert.ToSingle(dr["exitXPosition"]);
				data.exitYPosition = Convert.ToSingle(dr["exitYPosition"]);
				data.exitZPosition = Convert.ToSingle(dr["exitZPosition"]);
				data.exitRadius = Convert.ToSingle(dr["exitRadius"]);
				data.exitYRotationType = Convert.ToInt32(dr["exitYRotationType"]);
				data.exitYRotation = Convert.ToSingle(dr["exitYRotation"]);
				data.linkedPortalId = Convert.ToInt32(dr["linkedPortalId"]);

				portals.Add(data);
			}
			gameDatas.portals = portals.ToArray();
			portals.Clear();

			//
			// NPC 목록
			//
			List<WPDNpc> npcs = new List<WPDNpc>();
			foreach (DataRow dr in drcNpcs)
			{
				WPDNpc data = new WPDNpc();
				data.npcId = Convert.ToInt32(dr["npcId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.nickKey = Convert.ToString(dr["nickKey"]);
				data.dialogueKey = Convert.ToString(dr["dialogueKey"]);
				data.imageName = Convert.ToString(dr["imageName"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.continentId = Convert.ToInt32(dr["continentId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);
				data.interactionMaxRange = Convert.ToSingle(dr["interactionMaxRange"]);
				data.prefabName = Convert.ToString(dr["prefabName"]);
				data.soundName = Convert.ToString(dr["soundName"]);
				data.scale = Convert.ToSingle(dr["scale"]);
				data.height = Convert.ToInt32(dr["height"]);
				data.radius = Convert.ToSingle(dr["radius"]);

				npcs.Add(data);
			}
			gameDatas.npcs = npcs.ToArray();
			npcs.Clear();

			//
			// 메인퀘스트 목록
			//
			List<WPDMainQuest> mainQuests = new List<WPDMainQuest>();
			foreach (DataRow dr in drcMainQuests)
			{
				WPDMainQuest data = new WPDMainQuest();
				data.mainQuestNo = Convert.ToInt32(dr["mainQuestNo"]);
				data.requiredHeroLevel = Convert.ToInt32(dr["requiredHeroLevel"]);
				data.titleKey = Convert.ToString(dr["titleKey"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.startNpcId = Convert.ToInt32(dr["startNpcId"]);
				data.startTextKey = Convert.ToString(dr["startTextKey"]);
				data.targetTextKey = Convert.ToString(dr["targetTextKey"]);
				data.targetContinentId = Convert.ToInt32(dr["targetContinentId"]);
				data.targetXPosition = Convert.ToSingle(dr["targetXPosition"]);
				data.targetYPosition = Convert.ToSingle(dr["targetYPosition"]);
				data.targetZPosition = Convert.ToSingle(dr["targetZPosition"]);
				data.targetRadius = Convert.ToSingle(dr["targetRadius"]);
				data.targetNpcId = Convert.ToInt32(dr["targetNpcId"]);
				data.targetContinentObjectId = Convert.ToInt32(dr["targetContinentObjectId"]);
				data.targetDungeonId = Convert.ToInt32(dr["targetDungeonId"]);
				data.targetMonsterId = Convert.ToInt32(dr["targetMonsterId"]);
				data.targetAcquisitionRate = Convert.ToInt32(dr["targetAcquisitionRate"]);
				data.targetContentId = Convert.ToInt32(dr["targetContentId"]);
				data.targetCount = Convert.ToInt32(dr["targetCount"]);
				data.transformationMonsterId = Convert.ToInt32(dr["transformationMonsterId"]);
				data.transformationLifetime = Convert.ToInt32(dr["transformationLifetime"]);
				data.transformationRestored = Convert.ToBoolean(dr["transformationRestored"]);
				data.completionNpcId = Convert.ToInt32(dr["completionNpcId"]);
				data.completionTextKey = Convert.ToString(dr["completionTextKey"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);
				data.goldRewardId = Convert.ToInt64(dr["goldRewardId"]);
				data.cartId = Convert.ToInt32(dr["cartId"]);

				mainQuests.Add(data);
			}
			gameDatas.mainQuests = mainQuests.ToArray();
			mainQuests.Clear();

			//
			// 메인퀘스트 보상아이템 목록
			//
			List<WPDMainQuestReward> mainQuestRewards = new List<WPDMainQuestReward>();
			foreach (DataRow dr in drcMainQuestRewards)
			{
				WPDMainQuestReward data = new WPDMainQuestReward();
				data.mainQuestNo = Convert.ToInt32(dr["mainQuestNo"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.jobId = Convert.ToInt32(dr["jobId"]);
				data.mainGearId = Convert.ToInt32(dr["mainGearId"]); 
				data.mainGearOwned = Convert.ToBoolean(dr["mainGearOwned"]);
				data.subGearId = Convert.ToInt32(dr["subGearId"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);
				data.mountId = Convert.ToInt32(dr["mountId"]);
				data.creatureCardId = Convert.ToInt32(dr["creatureCardId"]);

				mainQuestRewards.Add(data);
			}
			gameDatas.mainQuestRewards = mainQuestRewards.ToArray();
			mainQuestRewards.Clear();

			//
			// 오브젝트 목록
			//
			List<WPDContinentObject> continentObjects = new List<WPDContinentObject>();
			foreach (DataRow dr in drcContinentObjects)
			{
				WPDContinentObject data = new WPDContinentObject();
				data.objectId = Convert.ToInt32(dr["objectId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.interactionDuration = Convert.ToSingle(dr["interactionDuration"]);
				data.interactionMaxRange = Convert.ToSingle(dr["interactionMaxRange"]);
				data.interactionTextKey = Convert.ToString(dr["interactionTextKey"]);
				data.prefabName = Convert.ToString(dr["prefabName"]);
				data.scale = Convert.ToSingle(dr["scale"]);
				data.height = Convert.ToInt32(dr["height"]);
				data.radius = Convert.ToSingle(dr["radius"]);
				data.regenTime = Convert.ToInt32(dr["regenTime"]);
				data.isPublic = Convert.ToBoolean(dr["isPublic"]);
				data.interactionCompletionAnimationEnabled = Convert.ToBoolean(dr["interactionCompletionAnimationEnabled"]);

				continentObjects.Add(data);
			}
			gameDatas.continentObjects = continentObjects.ToArray();
			continentObjects.Clear();

			//
			// 대륙오브젝트배치 목록
			//
			List<WPDContinentObjectArrange> continentObjectArranges = new List<WPDContinentObjectArrange>();
			foreach (DataRow dr in drcContinentObjectArranges)
			{
				WPDContinentObjectArrange data = new WPDContinentObjectArrange();
				data.continentId = Convert.ToInt32(dr["continentId"]);
				data.arrangeNo = Convert.ToInt32(dr["arrangeNo"]);
				data.objectId = Convert.ToInt32(dr["objectId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.yRotationType = Convert.ToInt32(dr["yRotationType"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);

				continentObjectArranges.Add(data);
			}
			gameDatas.continentObjectArranges = continentObjectArranges.ToArray();
			continentObjectArranges.Clear();

			//
			// 아이템 메인 카테고리 목록
			//
			List<WPDItemMainCategory> itemMainCategories = new List<WPDItemMainCategory>();
			foreach (DataRow dr in drcItemMainCategories)
			{
				WPDItemMainCategory data = new WPDItemMainCategory();
				data.mainCategoryId = Convert.ToInt32(dr["mainCategoryId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);

				itemMainCategories.Add(data);
			}
			gameDatas.itemMainCategories = itemMainCategories.ToArray();
			itemMainCategories.Clear();

			//
			// 아이템 서브 카테고리 목록
			//
			List<WPDItemSubCategory> itemSubCategories = new List<WPDItemSubCategory>();
			foreach (DataRow dr in drcItemSubCategories)
			{
				WPDItemSubCategory data = new WPDItemSubCategory();
				data.mainCategoryId = Convert.ToInt32(dr["mainCategoryId"]);
				data.subCategoryId = Convert.ToInt32(dr["subCategoryId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);

				itemSubCategories.Add(data);
			}
			gameDatas.itemSubCategories = itemSubCategories.ToArray();
			itemSubCategories.Clear();

			//
			// 유료즉시부활 목록
			//
			List<WPDPaidImmediateRevival> paidImmediateRevivals = new List<WPDPaidImmediateRevival>();
			foreach (DataRow dr in drcPaidImmediateRevivals)
			{
				WPDPaidImmediateRevival data = new WPDPaidImmediateRevival();
				data.revivalCount = Convert.ToInt32(dr["revivalCount"]);
				data.requiredDia = Convert.ToInt32(dr["requiredDia"]);

				paidImmediateRevivals.Add(data);
			}
			gameDatas.paidImmediateRevivals = paidImmediateRevivals.ToArray();
			paidImmediateRevivals.Clear();

			//
			// 몬스터스킬 목록
			//
			List<WPDMonsterSkill> monsterSkills = new List<WPDMonsterSkill>();
			foreach (DataRow dr in drcMonsterSkills)
			{
				WPDMonsterSkill data = new WPDMonsterSkill();
				data.skillId = Convert.ToInt32(dr["skillId"]);
				data.baseDamageType = Convert.ToInt32(dr["baseDamageType"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.elementalId = Convert.ToInt32(dr["elementalId"]);
				data.formType = Convert.ToInt32(dr["formType"]);
				data.isRequiredTarget = Convert.ToBoolean(dr["isRequiredTarget"]);
				data.castRange = Convert.ToSingle(dr["castRange"]);
				data.hitRange = Convert.ToSingle(dr["hitRange"]);
				data.coolTime = Convert.ToSingle(dr["coolTime"]);
				data.hitAreaType = Convert.ToInt32(dr["hitAreaType"]);
				data.hitAreaValue1 = Convert.ToSingle(dr["hitAreaValue1"]);
				data.hitAreaValue2 = Convert.ToSingle(dr["hitAreaValue2"]);
				data.hitAreaOffsetType = Convert.ToInt32(dr["hitAreaOffsetType"]);
				data.hitAreaOffset = Convert.ToSingle(dr["hitAreaOffset"]);
				data.ssStartDelay = Convert.ToSingle(dr["ssStartDelay"]);
				data.ssDuration = Convert.ToSingle(dr["ssDuration"]);
				data.autoPriorityGroup = Convert.ToInt32(dr["autoPriorityGroup"]);
				data.autoWeight = Convert.ToInt32(dr["autoWeight"]);
				data.sound = Convert.ToString(dr["sound"]);
				data.soundVolume = Convert.ToSingle(dr["soundVolume"]);

				monsterSkills.Add(data);
			}
			gameDatas.monsterSkills = monsterSkills.ToArray();
			monsterSkills.Clear();

			//
			// 몬스터스킬히트 목록
			//
			List<WPDMonsterSkillHit> monsterSkillHits = new List<WPDMonsterSkillHit>();
			foreach (DataRow dr in drcMonsterSkillHits)
			{
				WPDMonsterSkillHit data = new WPDMonsterSkillHit();
				data.skillId = Convert.ToInt32(dr["skillId"]);
				data.hitId = Convert.ToInt32(dr["hitId"]);
				data.damageFactor = Convert.ToSingle(dr["damageFactor"]);

				monsterSkillHits.Add(data);
			}
			gameDatas.monsterSkillHits = monsterSkillHits.ToArray();
			monsterSkillHits.Clear();

			//
			// 몬스터보유스킬 목록
			//
			List<WPDMonsterOwnSkill> monsterOwnSkills = new List<WPDMonsterOwnSkill>();
			foreach (DataRow dr in drcMonsterOwnSkills)
			{
				WPDMonsterOwnSkill data = new WPDMonsterOwnSkill();
				data.monsterId = Convert.ToInt32(dr["monsterId"]);
				data.skillId = Convert.ToInt32(dr["skillId"]);

				monsterOwnSkills.Add(data);
			}
			gameDatas.monsterOwnSkills = monsterOwnSkills.ToArray();
			monsterOwnSkills.Clear();

			//
			// 상태이상 목록
			//
			List<WPDAbnormalState> abnormalStates = new List<WPDAbnormalState>();
			foreach (DataRow dr in drcAbnormalStates)
			{
				WPDAbnormalState data = new WPDAbnormalState();
				data.abnormalStateId = Convert.ToInt32(dr["abnormalStateId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.isOverlap = Convert.ToBoolean(dr["isOverlap"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.sourceType = Convert.ToInt32(dr["sourceType"]);

				abnormalStates.Add(data);
			}
			gameDatas.abnormalStates = abnormalStates.ToArray();
			abnormalStates.Clear();

			//
			// 상태이상레벨 목록
			//
			List<WPDAbnormalStateLevel> abnormalStateLevels = new List<WPDAbnormalStateLevel>();
			foreach (DataRow dr in drcAbnormalStateLevels)
			{
				WPDAbnormalStateLevel data = new WPDAbnormalStateLevel();
				data.abnormalStateId = Convert.ToInt32(dr["abnormalStateId"]);
				data.jobId = Convert.ToInt32(dr["jobId"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.duration = Convert.ToInt32(dr["duration"]);
				data.value1 = Convert.ToInt32(dr["value1"]);
				data.value2 = Convert.ToInt32(dr["value2"]);
				data.value3 = Convert.ToInt32(dr["value3"]);
				data.value4 = Convert.ToInt32(dr["value4"]);
				data.value5 = Convert.ToInt32(dr["value5"]);
				data.value6 = Convert.ToInt32(dr["value6"]);

				abnormalStateLevels.Add(data);
			}
			gameDatas.abnormalStateLevels = abnormalStateLevels.ToArray();
			abnormalStateLevels.Clear();

			//
			// 직업레벨마스터 목록
			//
			List<WPDJobLevelMaster> jobLevelMasters = new List<WPDJobLevelMaster>();
			foreach (DataRow dr in drcJobLevelMasters)
			{
				WPDJobLevelMaster data = new WPDJobLevelMaster();
				data.level = Convert.ToInt32(dr["level"]);
				data.nextLevelUpExp = Convert.ToInt64(dr["nextLevelUpExp"]);
				data.inventorySlotAccCount = Convert.ToInt32(dr["inventorySlotAccCount"]);
				data.restMaxExpRewardId = Convert.ToInt64(dr["restMaxExpRewardId"]);
				data.potionAttrMaxCount = Convert.ToInt32(dr["potionAttrMaxCount"]);

				jobLevelMasters.Add(data);
			}
			gameDatas.jobLevelMasters = jobLevelMasters.ToArray();
			jobLevelMasters.Clear();

			//
			// 직업레벨 목록
			//
			List<WPDJobLevel> jobLevels = new List<WPDJobLevel>();
			foreach (DataRow dr in drcJobLevels)
			{
				WPDJobLevel data = new WPDJobLevel();
				data.jobId = Convert.ToInt32(dr["jobId"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.maxHpAttrValueId = Convert.ToInt64(dr["maxHpAttrValueId"]);
				data.physicalOffenseAttrValueId = Convert.ToInt64(dr["physicalOffenseAttrValueId"]);
				data.magicalOffenseAttrValueId = Convert.ToInt64(dr["magicalOffenseAttrValueId"]);
				data.physicalDefenseAttrValueId = Convert.ToInt64(dr["physicalDefenseAttrValueId"]);
				data.magicalDefenseAttrValueId = Convert.ToInt64(dr["magicalDefenseAttrValueId"]);

				jobLevels.Add(data);
			}
			gameDatas.jobLevels = jobLevels.ToArray();
			jobLevels.Clear();

			//
			// 경험치보상 목록
			//
			List<WPDExpReward> expRewards = new List<WPDExpReward>();
			foreach (DataRow dr in drcExpRewards)
			{
				WPDExpReward data = new WPDExpReward();
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);
				data.value = Convert.ToInt64(dr["value"]);

				expRewards.Add(data);
			}
			gameDatas.expRewards = expRewards.ToArray();
			expRewards.Clear();

			//
			// 골드보상 목록
			//
			List<WPDGoldReward> goldRewards = new List<WPDGoldReward>();
			foreach (DataRow dr in drcGoldRewards)
			{
				WPDGoldReward data = new WPDGoldReward();
				data.goldRewardId = Convert.ToInt64(dr["goldRewardId"]);
				data.value = Convert.ToInt64(dr["value"]);

				goldRewards.Add(data);
			}
			gameDatas.goldRewards = goldRewards.ToArray();
			goldRewards.Clear();


			//
			// 아이템보상 목록
			//
			List<WPDItemReward> itemRewards = new List<WPDItemReward>();
			foreach (DataRow dr in drcItemRewards)
			{
				WPDItemReward data = new WPDItemReward();
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);
				data.itemCount = Convert.ToInt32(dr["itemCount"]); 
				data.itemOwned = Convert.ToBoolean(dr["itemOwned"]);

				itemRewards.Add(data);
			}
			gameDatas.itemRewards = itemRewards.ToArray();
			itemRewards.Clear();

			//
			// 속성값 목록
			//
			List<WPDAttrValue> attrValues = new List<WPDAttrValue>();
			foreach (DataRow dr in drcAttrValues)
			{
				WPDAttrValue data = new WPDAttrValue();
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);
				data.value = Convert.ToInt32(dr["value"]);

				attrValues.Add(data);
			}
			gameDatas.attrValues = attrValues.ToArray();
			attrValues.Clear();

			//
			// 몬스터배치 목록
			//
			List<WPDMonsterArrange> monsterArranges = new List<WPDMonsterArrange>();
			foreach (DataRow dr in drcMonsterArranges)
			{
				WPDMonsterArrange data = new WPDMonsterArrange();
				data.monsterArrangeId = Convert.ToInt64(dr["monsterArrangeId"]);
				data.monsterId = Convert.ToInt32(dr["monsterId"]);

				monsterArranges.Add(data);
			}
			gameDatas.monsterArranges = monsterArranges.ToArray();
			monsterArranges.Clear();

			//
			// 간편상점 목록
			//
			List<WPDSimpleShopProduct> simpleShopProducts = new List<WPDSimpleShopProduct>();
			foreach (DataRow dr in drcSimpleShopProducts)
			{
				WPDSimpleShopProduct data = new WPDSimpleShopProduct();
				data.productId = Convert.ToInt32(dr["productId"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);
				data.itemOwned = Convert.ToBoolean(dr["itemOwned"]);
				data.saleGold = Convert.ToInt32(dr["saleGold"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);

				simpleShopProducts.Add(data);
			}
			gameDatas.simpleShopProducts = simpleShopProducts.ToArray();
			simpleShopProducts.Clear();

			//
			// VIP레벨 목록
			//
			List<WPDVipLevel> vipLevels = new List<WPDVipLevel>();
			foreach (DataRow dr in drcVipLevels)
			{
				WPDVipLevel data = new WPDVipLevel();
				data.vipLevel = Convert.ToInt32(dr["vipLevel"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.requiredAccVipPoint = Convert.ToInt32(dr["requiredAccVipPoint"]);
				data.mainGearEnchantMaxCount = Convert.ToInt32(dr["mainGearEnchantMaxCount"]);
				data.mainGearRefinementMaxCount = Convert.ToInt32(dr["mainGearRefinementMaxCount"]);
				data.mountGearRefinementMaxCount = Convert.ToInt32(dr["mountGearRefinementMaxCount"]);
				data.expPotionUseMaxCount = Convert.ToInt32(dr["expPotionUseMaxCount"]);
				data.staminaBuyMaxCount = Convert.ToInt32(dr["staminaBuyMaxCount"]);
				data.expDungeonEnterCount = Convert.ToInt32(dr["expDungeonEnterCount"]);
				data.goldDungeonEnterCount = Convert.ToInt32(dr["goldDungeonEnterCount"]);
				data.osirisRoomEnterCount = Convert.ToInt32(dr["osirisRoomEnterCount"]);
				data.expScrollUseMaxCount = Convert.ToInt32(dr["expScrollUseMaxCount"]);
				data.dailyMaxExploitPoint = Convert.ToInt32(dr["dailyMaxExploitPoint"]);
				data.artifactRoomInitMaxCount = Convert.ToInt32(dr["artifactRoomInitMaxCount"]);
				data.ancientRelicEnterCount = Convert.ToInt32(dr["ancientRelicEnterCount"]);
				data.fieldOfHonorEnterCount = Convert.ToInt32(dr["fieldOfHonorEnterCount"]);
				data.distortionScrollUseMaxCount = Convert.ToInt32(dr["distortionScrollUseMaxCount"]);
				data.guildDonationMaxCount = Convert.ToInt32(dr["guildDonationMaxCount"]);
				data.nationDonationmaxCount = Convert.ToInt32(dr["nationDonationmaxCount"]);
				data.soulCoveterWeeklyEnterCount = Convert.ToInt32(dr["soulCoveterWeeklyEnterCount"]);
				data.creatureCardCompositionEnabled = Convert.ToBoolean(dr["creatureCardCompositionEnabled"]);
				data.creatureCardShopPaidRefreshMaxCount = Convert.ToInt32(dr["creatureCardShopPaidRefreshMaxCount"]);
				data.proofOfValorEnterCount = Convert.ToInt32(dr["proofOfValorEnterCount"]);
				data.trueHeroQuestStepNo = Convert.ToInt32(dr["trueHeroQuestStepNo"]);
				data.fearAltarEnterCount = Convert.ToInt32(dr["fearAltarEnterCount"]);
				data.expDungeonAdditionalExpRewardFactor = Convert.ToSingle(dr["expDungeonAdditionalExpRewardFactor"]);
				data.luckyShopPickMaxCount = Convert.ToInt32(dr["luckyShopPickMaxCount"]);
				data.creatureVariationMaxCount = Convert.ToInt32(dr["creatureVariationMaxCount"]);
				data.tradeShipEnterCount = Convert.ToInt32(dr["tradeShipEnterCount"]);

				vipLevels.Add(data);
			}
			gameDatas.vipLevels = vipLevels.ToArray();
			vipLevels.Clear();

			//
			// 인벤토리 확장 레시피 목록
			//
			List<WPDInventorySlotExtendRecipe> inventorySlotExtendRecipes = new List<WPDInventorySlotExtendRecipe>();
			foreach (DataRow dr in drcInventorySlotExtendRecipes)
			{
				WPDInventorySlotExtendRecipe data = new WPDInventorySlotExtendRecipe();
				data.slotCount = Convert.ToInt32(dr["slotCount"]);
				data.dia = Convert.ToInt32(dr["dia"]);

				inventorySlotExtendRecipes.Add(data);
			}
			gameDatas.inventorySlotExtendRecipes = inventorySlotExtendRecipes.ToArray();
			inventorySlotExtendRecipes.Clear();

			//
			// 메인장비 분해 획득가능 결과 항목 목록
			//
			List<WPDMainGearDisassembleAvailableResultEntry> mainGearDisassembleAvailableResultEntries = new List<WPDMainGearDisassembleAvailableResultEntry>();
			foreach (DataRow dr in drcMainGearDisassembleAvailableResultEntries)
			{
				WPDMainGearDisassembleAvailableResultEntry data = new WPDMainGearDisassembleAvailableResultEntry();
				data.tier = Convert.ToInt32(dr["tier"]);
				data.grade = Convert.ToInt32(dr["grade"]);
				data.entryNo = Convert.ToInt32(dr["entryNo"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);
				data.itemCount = Convert.ToInt32(dr["itemCount"]);
				data.itemOwned = Convert.ToBoolean(dr["itemOwned"]);

				mainGearDisassembleAvailableResultEntries.Add(data);
			}
			gameDatas.mainGearDisassembleAvailableResultEntries = mainGearDisassembleAvailableResultEntries.ToArray();
			mainGearDisassembleAvailableResultEntries.Clear();

			//
			// 아이템합성레시피 목록
			//
			List<WPDItemCompositionRecipe> itemCompositionRecipes = new List<WPDItemCompositionRecipe>();
			foreach (DataRow dr in drcItemCompositionRecipes)
			{
				WPDItemCompositionRecipe data = new WPDItemCompositionRecipe();
				data.itemId = Convert.ToInt32(dr["itemId"]);
				data.materialItemId = Convert.ToInt32(dr["materialItemId"]);
				data.materialItemCount = Convert.ToInt32(dr["materialItemCount"]);
				data.gold = Convert.ToInt32(dr["gold"]);

				itemCompositionRecipes.Add(data);
			}
			gameDatas.itemCompositionRecipes = itemCompositionRecipes.ToArray();
			itemCompositionRecipes.Clear();

			//
			// 휴식보상수령비용 목록
			//
			List<WPDRestRewardTime> restRewardTimes = new List<WPDRestRewardTime>();
			foreach (DataRow dr in drcRestRewardTimes)
			{
				WPDRestRewardTime data = new WPDRestRewardTime();
				data.restTime = Convert.ToInt32(dr["restTime"]);
				data.requiredGold = Convert.ToInt64(dr["requiredGold"]);
				data.requiredDia = Convert.ToInt32(dr["requiredDia"]);

				restRewardTimes.Add(data);
			}
			gameDatas.restRewardTimes = restRewardTimes.ToArray();
			restRewardTimes.Clear();

			//
			// 채팅타입 목록
			//
			List<WPDChattingType> chattingTypes = new List<WPDChattingType>();
			foreach (DataRow dr in drcChattingTypes)
			{
				WPDChattingType data = new WPDChattingType();
				data.chattingType = Convert.ToInt32(dr["chattingType"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.colorCode = Convert.ToString(dr["colorCode"]);

				chattingTypes.Add(data);
			}
			gameDatas.chattingTypes = chattingTypes.ToArray();
			chattingTypes.Clear();

			//
			// 메인퀘스트 던전 목록
			//
			List<WPDMainQuestDungeon> mainQuestDungeons = new List<WPDMainQuestDungeon>();
			foreach (DataRow dr in drcMainQuestDungeons)
			{
				WPDMainQuestDungeon data = new WPDMainQuestDungeon();
				data.dungeonId = Convert.ToInt32(dr["dungeonId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.sceneName = Convert.ToString(dr["sceneName"]);
				data.startDelayTime = Convert.ToInt32(dr["startDelayTime"]);
				data.limitTime = Convert.ToInt32(dr["limitTime"]);
				data.exitDelayTime = Convert.ToInt32(dr["exitDelayTime"]);
				data.startXPosition = Convert.ToSingle(dr["startXPosition"]);
				data.startYPosition = Convert.ToSingle(dr["startYPosition"]);
				data.startZPosition = Convert.ToSingle(dr["startZPosition"]);
				data.startRadius = Convert.ToSingle(dr["startRadius"]);
				data.startYRotation = Convert.ToSingle(dr["startYRotation"]);
				data.safeRevivalWaitingTime = Convert.ToInt32(dr["safeRevivalWaitingTime"]);
				data.guideDisplayInterval = Convert.ToInt32(dr["guideDisplayInterval"]);
				data.completionExitPositionEnabled = Convert.ToBoolean(dr["completionExitPositionEnabled"]);
				data.completionExitXPosition = Convert.ToSingle(dr["completionExitXPosition"]);
				data.completionExitYPosition = Convert.ToSingle(dr["completionExitYPosition"]);
				data.completionExitZPosition = Convert.ToSingle(dr["completionExitZPosition"]);
				data.completionExitYRotation = Convert.ToSingle(dr["completionExitYRotation"]);
				data.locationId = Convert.ToInt32(dr["locationId"]);
				data.x = Convert.ToSingle(dr["x"]);
				data.z = Convert.ToSingle(dr["z"]);
				data.xSize = Convert.ToSingle(dr["xSize"]);
				data.zSize = Convert.ToSingle(dr["zSize"]);

				mainQuestDungeons.Add(data);
			}
			gameDatas.mainQuestDungeons = mainQuestDungeons.ToArray();
			mainQuestDungeons.Clear();

			//
			// 메인퀘스트 던전 장애물 목록
			//
			List<WPDMainQuestDungeonObstacle> mainQuestDungeonObstacles = new List<WPDMainQuestDungeonObstacle>();
			foreach (DataRow dr in drcMainQuestDungeonObstacles)
			{
				WPDMainQuestDungeonObstacle data = new WPDMainQuestDungeonObstacle();
				data.dungeonId = Convert.ToInt32(dr["dungeonId"]);
				data.obstacleId = Convert.ToInt32(dr["obstacleId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);
				data.scale = Convert.ToSingle(dr["scale"]);

				mainQuestDungeonObstacles.Add(data);
			}
			gameDatas.mainQuestDungeonObstacles = mainQuestDungeonObstacles.ToArray();
			mainQuestDungeonObstacles.Clear();

			//
			// 메인퀘스트 던전 단계 목록
			//
			List<WPDMainQuestDungeonStep> mainQuestDungeonSteps = new List<WPDMainQuestDungeonStep>();
			foreach (DataRow dr in drcMainQuestDungeonSteps)
			{
				WPDMainQuestDungeonStep data = new WPDMainQuestDungeonStep();
				data.dungeonId = Convert.ToInt32(dr["dungeonId"]);
				data.step = Convert.ToInt32(dr["step"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);
				data.targetXPosition = Convert.ToSingle(dr["targetXPosition"]);
				data.targetYPosition = Convert.ToSingle(dr["targetYPosition"]);
				data.targetZPosition = Convert.ToSingle(dr["targetZPosition"]);
				data.targetRadius = Convert.ToSingle(dr["targetRadius"]);
				data.targetMonsterArrangeNo = Convert.ToInt32(dr["targetMonsterArrangeNo"]);
				data.directingDuration = Convert.ToInt32(dr["directingDuration"]);
				data.directingStartYRotation = Convert.ToSingle(dr["directingStartYRotation"]);
				data.removeObstacleId = Convert.ToInt32(dr["removeObstacleId"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);
				data.goldRewardId = Convert.ToInt64(dr["goldRewardId"]);

				mainQuestDungeonSteps.Add(data);
			}
			gameDatas.mainQuestDungeonSteps = mainQuestDungeonSteps.ToArray();
			mainQuestDungeonSteps.Clear();

			//
			// 메인퀘스트 던전 가이드 목록
			//
			List<WPDMainQuestDungeonGuide> mainQuestDungeonGuides = new List<WPDMainQuestDungeonGuide>();
			foreach (DataRow dr in drcMainQuestDungeonGuides)
			{
				WPDMainQuestDungeonGuide data = new WPDMainQuestDungeonGuide();
				data.dungeonId = Convert.ToInt32(dr["dungeonId"]);
				data.step = Convert.ToInt32(dr["step"]);
				data.no = Convert.ToInt32(dr["no"]);
				data.imageName = Convert.ToString(dr["imageName"]);
				data.titleKey = Convert.ToString(dr["titleKey"]);
				data.contentKey = Convert.ToString(dr["contentKey"]);

				mainQuestDungeonGuides.Add(data);
			}
			gameDatas.mainQuestDungeonGuides = mainQuestDungeonGuides.ToArray();
			mainQuestDungeonGuides.Clear();

			//
			// 레벨업 보상 항목 목록
			//
			List<WPDLevelUpRewardEntry> levelUpRewardEntries = new List<WPDLevelUpRewardEntry>();
			foreach (DataRow dr in drcLevelUpRewardEntries)
			{
				WPDLevelUpRewardEntry data = new WPDLevelUpRewardEntry();
				data.entryId = Convert.ToInt32(dr["entryId"]);
				data.level = Convert.ToInt32(dr["level"]);

				levelUpRewardEntries.Add(data);
			}
			gameDatas.levelUpRewardEntries = levelUpRewardEntries.ToArray();
			levelUpRewardEntries.Clear();

			//
			// 레벨업 보상 아이템 목록
			//
			List<WPDLevelUpRewardItem> levelUpRewardItems = new List<WPDLevelUpRewardItem>();
			foreach (DataRow dr in drcLevelUpRewardItems)
			{
				WPDLevelUpRewardItem data = new WPDLevelUpRewardItem();
				data.entryId = Convert.ToInt32(dr["entryId"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				levelUpRewardItems.Add(data);
			}
			gameDatas.levelUpRewardItems = levelUpRewardItems.ToArray();
			levelUpRewardItems.Clear();

			//
			// 일일출석 보상 항목 목록
			//
			List<WPDDailyAttendRewardEntry> dailyAttendRewardEntries = new List<WPDDailyAttendRewardEntry>();
			foreach (DataRow dr in drcDailyAttendRewardEntries)
			{
				WPDDailyAttendRewardEntry data = new WPDDailyAttendRewardEntry();
				data.day = Convert.ToInt32(dr["day"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				dailyAttendRewardEntries.Add(data);
			}
			gameDatas.dailyAttendRewardEntries = dailyAttendRewardEntries.ToArray();
			dailyAttendRewardEntries.Clear();

			//
			// 주말출석 보상 가능 요일 목록
			//
			List<WPDWeekendAttendRewardAvailableDayOfWeek> weekendAttendRewardAvailableDayOfWeeks = new List<WPDWeekendAttendRewardAvailableDayOfWeek>();
			foreach (DataRow dr in drcWeekendAttendRewardAvailableDayOfWeeks)
			{
				WPDWeekendAttendRewardAvailableDayOfWeek data = new WPDWeekendAttendRewardAvailableDayOfWeek();
				data.dayOfWeek = Convert.ToInt32(dr["dayOfWeek"]);

				weekendAttendRewardAvailableDayOfWeeks.Add(data);
			}
			gameDatas.weekendAttendRewardAvailableDayOfWeeks = weekendAttendRewardAvailableDayOfWeeks.ToArray();
			weekendAttendRewardAvailableDayOfWeeks.Clear();

			//
			// 접속 보상 항목 목록
			//
			List<WPDAccessRewardEntry> accessRewardEntries = new List<WPDAccessRewardEntry>();
			foreach (DataRow dr in drcAccessRewardEntries)
			{
				WPDAccessRewardEntry data = new WPDAccessRewardEntry();
				data.entryId = Convert.ToInt32(dr["entryId"]);
				data.accessTime = Convert.ToInt32(dr["accessTime"]);

				accessRewardEntries.Add(data);
			}
			gameDatas.accessRewardEntries = accessRewardEntries.ToArray();
			accessRewardEntries.Clear();

			//
			// 접속 보상 아이템 목록
			//
			List<WPDAccessRewardItem> accessRewardItems = new List<WPDAccessRewardItem>();
			foreach (DataRow dr in drcAccessRewardItems)
			{
				WPDAccessRewardItem data = new WPDAccessRewardItem();
				data.entryId = Convert.ToInt32(dr["entryId"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				accessRewardItems.Add(data);
			}
			gameDatas.accessRewardItems = accessRewardItems.ToArray();
			accessRewardItems.Clear();

			//
			// VIP레벨 보상 목록
			//
			List<WPDVipLevelReward> vipLevelRewards = new List<WPDVipLevelReward>();
			foreach (DataRow dr in drcVipLevelRewards)
			{
				WPDVipLevelReward data = new WPDVipLevelReward();
				data.vipLevel = Convert.ToInt32(dr["vipLevel"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				vipLevelRewards.Add(data);
			}
			gameDatas.vipLevelRewards = vipLevelRewards.ToArray();
			vipLevelRewards.Clear();

			//
			// 탈것 목록
			//
			List<WPDMount> mounts = new List<WPDMount>();
			foreach (DataRow dr in drcMounts)
			{
				WPDMount data = new WPDMount();
				data.mountId = Convert.ToInt32(dr["mountId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.acquisitionTextKey = Convert.ToString(dr["acquisitionTextKey"]);
				data.moveSpeed = Convert.ToSingle(dr["moveSpeed"]);

				mounts.Add(data);
			}
			gameDatas.mounts = mounts.ToArray();
			mounts.Clear();

			//
			// 탈것 품질 마스터 목록
			//
			List<WPDMountQualityMaster> mountQualityMasters = new List<WPDMountQualityMaster>();
			foreach (DataRow dr in drcMountQualityMasters)
			{
				WPDMountQualityMaster data = new WPDMountQualityMaster();
				data.quality = Convert.ToInt32(dr["quality"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.colorCode = Convert.ToString(dr["colorCode"]);

				mountQualityMasters.Add(data);
			}
			gameDatas.mountQualityMasters = mountQualityMasters.ToArray();
			mountQualityMasters.Clear();

			//
			// 탈것 레벨 마스터 목록
			//
			List<WPDMountLevelMaster> mountLevelMasters = new List<WPDMountLevelMaster>();
			foreach (DataRow dr in drcMountLevelMasters)
			{
				WPDMountLevelMaster data = new WPDMountLevelMaster();
				data.level = Convert.ToInt32(dr["level"]);
				data.quality = Convert.ToInt32(dr["quality"]);
				data.qualityLevel = Convert.ToInt32(dr["qualityLevel"]);
				data.nextLevelUpRequiredSatiety = Convert.ToInt32(dr["nextLevelUpRequiredSatiety"]);

				mountLevelMasters.Add(data);
			}
			gameDatas.mountLevelMasters = mountLevelMasters.ToArray();
			mountLevelMasters.Clear();

			//
			// 탈것 품질 목록
			//
			List<WPDMountQuality> mountQualities = new List<WPDMountQuality>();
			foreach (DataRow dr in drcMountQualities)
			{
				WPDMountQuality data = new WPDMountQuality();
				data.mountId = Convert.ToInt32(dr["mountId"]);
				data.quality = Convert.ToInt32(dr["quality"]);
				data.prefabName = Convert.ToString(dr["prefabName"]);
				data.potionAttrMaxCount = Convert.ToInt32(dr["potionAttrMaxCount"]);

				mountQualities.Add(data);
			}
			gameDatas.mountQualities = mountQualities.ToArray();
			mountQualities.Clear();

			//
			// 탈것 레벨 목록
			//
			List<WPDMountLevel> mountLevels = new List<WPDMountLevel>();
			foreach (DataRow dr in drcMountLevels)
			{
				WPDMountLevel data = new WPDMountLevel();
				data.mountId = Convert.ToInt32(dr["mountId"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.maxHpAttrValueId = Convert.ToInt64(dr["maxHpAttrValueId"]);
				data.physicalOffenseAttrValueId = Convert.ToInt64(dr["physicalOffenseAttrValueId"]);
				data.magicalOffenseAttrValueId = Convert.ToInt64(dr["magicalOffenseAttrValueId"]);
				data.physicalDefenseAttrValueId = Convert.ToInt64(dr["physicalDefenseAttrValueId"]);
				data.magicalDefenseAttrValueId = Convert.ToInt64(dr["magicalDefenseAttrValueId"]);

				mountLevels.Add(data);
			}
			gameDatas.mountLevels = mountLevels.ToArray();
			mountLevels.Clear();

			//
			// 탈것 장비 타입 목록
			//
			List<WPDMountGearType> mountGearTypes = new List<WPDMountGearType>();
			foreach (DataRow dr in drcMountGearTypes)
			{
				WPDMountGearType data = new WPDMountGearType();
				data.type = Convert.ToInt32(dr["type"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.slotIndex = Convert.ToInt32(dr["slotIndex"]);

				mountGearTypes.Add(data);
			}
			gameDatas.mountGearTypes = mountGearTypes.ToArray();
			mountGearTypes.Clear();

			//
			// 탈것 장비 슬롯 목록
			//
			List<WPDMountGearSlot> mountGearSlots = new List<WPDMountGearSlot>();
			foreach (DataRow dr in drcMountGearSlots)
			{
				WPDMountGearSlot data = new WPDMountGearSlot();
				data.slotIndex = Convert.ToInt32(dr["slotIndex"]);
				data.openHeroLevel = Convert.ToInt32(dr["openHeroLevel"]);

				mountGearSlots.Add(data);
			}
			gameDatas.mountGearSlots = mountGearSlots.ToArray();
			mountGearSlots.Clear();

			//
			// 탈것 장비 목록
			//
			List<WPDMountGear> mountGears = new List<WPDMountGear>();
			foreach (DataRow dr in drcMountGears)
			{
				WPDMountGear data = new WPDMountGear();
				data.mountGearId = Convert.ToInt32(dr["mountGearId"]);
				data.requiredHeroLevel = Convert.ToInt32(dr["requiredHeroLevel"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.grade = Convert.ToInt32(dr["grade"]);
				data.quality = Convert.ToInt32(dr["quality"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.imageName = Convert.ToString(dr["imageName"]);
				data.saleGold = Convert.ToInt32(dr["saleGold"]);
				data.maxHpAttrValueId = Convert.ToInt64(dr["maxHpAttrValueId"]);
				data.physicalOffenseAttrValueId = Convert.ToInt64(dr["physicalOffenseAttrValueId"]);
				data.magicalOffenseAttrValueId = Convert.ToInt64(dr["magicalOffenseAttrValueId"]);
				data.physicalDefenseAttrValueId = Convert.ToInt64(dr["physicalDefenseAttrValueId"]);
				data.magicalDefenseAttrValueId = Convert.ToInt64(dr["magicalDefenseAttrValueId"]);

				mountGears.Add(data);
			}
			gameDatas.mountGears = mountGears.ToArray();
			mountGears.Clear();

			//
			// 탈것 장비 등급 목록
			//
			List<WPDMountGearGrade> mountGearGrades = new List<WPDMountGearGrade>();
			foreach (DataRow dr in drcMountGearGrades)
			{
				WPDMountGearGrade data = new WPDMountGearGrade();
				data.grade = Convert.ToInt32(dr["grade"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.colorCode = Convert.ToString(dr["colorCode"]);

				mountGearGrades.Add(data);
			}
			gameDatas.mountGearGrades = mountGearGrades.ToArray();
			mountGearGrades.Clear();

			//
			// 탈것 장비 품질 목록
			//
			List<WPDMountGearQuality> mountGearQualities = new List<WPDMountGearQuality>();
			foreach (DataRow dr in drcMountGearQualities)
			{
				WPDMountGearQuality data = new WPDMountGearQuality();
				data.quality = Convert.ToInt32(dr["quality"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);

				mountGearQualities.Add(data);
			}
			gameDatas.mountGearQualities = mountGearQualities.ToArray();
			mountGearQualities.Clear();

			//
			// 탈것 장비 옵션 속성 등급 목록
			//
			List<WPDMountGearOptionAttrGrade> mountGearOptionAttrGrades = new List<WPDMountGearOptionAttrGrade>();
			foreach (DataRow dr in drcMountGearOptionAttrGrades)
			{
				WPDMountGearOptionAttrGrade data = new WPDMountGearOptionAttrGrade();
				data.attrGrade = Convert.ToInt32(dr["attrGrade"]);
				data.colorCode = Convert.ToString(dr["colorCode"]);

				mountGearOptionAttrGrades.Add(data);
			}
			gameDatas.mountGearOptionAttrGrades = mountGearOptionAttrGrades.ToArray();
			mountGearOptionAttrGrades.Clear();

			//
			// 탈것 장비 뽑기상자 레시피 목록
			//
			List<WPDMountGearPickBoxRecipe> mountGearPickBoxRecipes = new List<WPDMountGearPickBoxRecipe>();
			foreach (DataRow dr in drcMountGearPickBoxRecipes)
			{
				WPDMountGearPickBoxRecipe data = new WPDMountGearPickBoxRecipe();
				data.itemId = Convert.ToInt32(dr["itemId"]);
				data.requiredHeroLevel = Convert.ToInt32(dr["requiredHeroLevel"]);
				data.gold = Convert.ToInt32(dr["gold"]);
				data.owned = Convert.ToBoolean(dr["owned"]);
				data.materialItem1Id = Convert.ToInt32(dr["materialItem1Id"]);
				data.materialItem1Count = Convert.ToInt32(dr["materialItem1Count"]);
				data.materialItem2Id = Convert.ToInt32(dr["materialItem2Id"]);
				data.materialItem2Count = Convert.ToInt32(dr["materialItem2Count"]);
				data.materialItem3Id = Convert.ToInt32(dr["materialItem3Id"]);
				data.materialItem3Count = Convert.ToInt32(dr["materialItem3Count"]);
				data.materialItem4Id = Convert.ToInt32(dr["materialItem4Id"]);
				data.materialItem4Count = Convert.ToInt32(dr["materialItem4Count"]);

				mountGearPickBoxRecipes.Add(data);
			}
			gameDatas.mountGearPickBoxRecipes = mountGearPickBoxRecipes.ToArray();
			mountGearPickBoxRecipes.Clear();

			//
			// 스토리던전 목록
			//
			List<WPDStoryDungeon> storyDungeons = new List<WPDStoryDungeon>();
			foreach (DataRow dr in drcStoryDungeons)
			{
				WPDStoryDungeon data = new WPDStoryDungeon();
				data.dungeonNo = Convert.ToInt32(dr["dungeonNo"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.subNameKey = Convert.ToString(dr["subNameKey"]);
				data.enterCount = Convert.ToInt32(dr["enterCount"]);
				data.requiredConditionType = Convert.ToInt32(dr["requiredConditionType"]);
				data.requiredHeroMinLevel = Convert.ToInt32(dr["requiredHeroMinLevel"]);
				data.requiredHeroMaxLevel = Convert.ToInt32(dr["requiredHeroMaxLevel"]);
				data.requiredMainQuestNo = Convert.ToInt32(dr["requiredMainQuestNo"]);
				data.requiredStamina = Convert.ToInt32(dr["requiredStamina"]);
				data.limitTime = Convert.ToInt32(dr["limitTime"]);
				data.sceneName = Convert.ToString(dr["sceneName"]);
				data.startXPosition = Convert.ToSingle(dr["startXPosition"]);
				data.startYPosition = Convert.ToSingle(dr["startYPosition"]);
				data.startZPosition = Convert.ToSingle(dr["startZPosition"]);
				data.startRadius = Convert.ToSingle(dr["startRadius"]);
				data.startYRotation = Convert.ToSingle(dr["startYRotation"]);
				data.startDelayTime = Convert.ToInt32(dr["startDelayTime"]);
				data.exitDelayTime = Convert.ToInt32(dr["exitDelayTime"]);
				data.tamingXPosition = Convert.ToSingle(dr["tamingXPosition"]);
				data.tamingYPosition = Convert.ToSingle(dr["tamingYPosition"]);
				data.tamingZPosition = Convert.ToSingle(dr["tamingZPosition"]);
				data.tamingYRotation = Convert.ToSingle(dr["tamingYRotation"]);
				data.clearXPosition = Convert.ToSingle(dr["clearXPosition"]);
				data.clearYPosition = Convert.ToSingle(dr["clearYPosition"]);
				data.clearZPosition = Convert.ToSingle(dr["clearZPosition"]);
				data.clearYRotation = Convert.ToSingle(dr["clearYRotation"]);
				data.safeRevivalWaitingTime = Convert.ToInt32(dr["safeRevivalWaitingTime"]);
				data.guideDisplayInterval = Convert.ToInt32(dr["guideDisplayInterval"]);
				data.comboDuration = Convert.ToInt32(dr["comboDuration"]);
				data.locationId = Convert.ToInt32(dr["locationId"]);
				data.x = Convert.ToSingle(dr["x"]);
				data.z = Convert.ToSingle(dr["z"]);
				data.xSize = Convert.ToSingle(dr["xSize"]);
				data.zSize = Convert.ToSingle(dr["zSize"]);

				storyDungeons.Add(data);
			}
			gameDatas.storyDungeons = storyDungeons.ToArray();
			storyDungeons.Clear();

			//
			// 스토리던전 난이도 목록
			//
			List<WPDStoryDungeonDifficulty> storyDungeonDifficulties = new List<WPDStoryDungeonDifficulty>();
			foreach (DataRow dr in drcStoryDungeonDifficulties)
			{
				WPDStoryDungeonDifficulty data = new WPDStoryDungeonDifficulty();
				data.dungeonNo = Convert.ToInt32(dr["dungeonNo"]);
				data.difficulty = Convert.ToInt32(dr["difficulty"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.recommendBattlePower = Convert.ToInt64(dr["recommendBattlePower"]);

				storyDungeonDifficulties.Add(data);
			}
			gameDatas.storyDungeonDifficulties = storyDungeonDifficulties.ToArray();
			storyDungeonDifficulties.Clear();

			//
			// 스토리던전 장애물 목록
			//
			List<WPDStoryDungeonObstacle> storyDungeonObstacles = new List<WPDStoryDungeonObstacle>();
			foreach (DataRow dr in drcStoryDungeonObstacles)
			{
				WPDStoryDungeonObstacle data = new WPDStoryDungeonObstacle();
				data.dungeonNo = Convert.ToInt32(dr["dungeonNo"]);
				data.obstacleId = Convert.ToInt32(dr["obstacleId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);
				data.scale = Convert.ToSingle(dr["scale"]);

				storyDungeonObstacles.Add(data);
			}
			gameDatas.storyDungeonObstacles = storyDungeonObstacles.ToArray();
			storyDungeonObstacles.Clear();

			//
			// 스토리던전 획득가능 보상 목록
			//
			List<WPDStoryDungeonAvailableReward> storyDungeonAvailableRewards = new List<WPDStoryDungeonAvailableReward>();
			foreach (DataRow dr in drcStoryDungeonAvailableRewards)
			{
				WPDStoryDungeonAvailableReward data = new WPDStoryDungeonAvailableReward();
				data.dungeonNo = Convert.ToInt32(dr["dungeonNo"]);
				data.difficulty = Convert.ToInt32(dr["difficulty"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);

				storyDungeonAvailableRewards.Add(data);
			}
			gameDatas.storyDungeonAvailableRewards = storyDungeonAvailableRewards.ToArray();
			storyDungeonAvailableRewards.Clear();

			//
			// 스토리던전 단계 목록
			//
			List<WPDStoryDungeonStep> storyDungeonSteps = new List<WPDStoryDungeonStep>();
			foreach (DataRow dr in drcStoryDungeonSteps)
			{
				WPDStoryDungeonStep data = new WPDStoryDungeonStep();
				data.dungeonNo = Convert.ToInt32(dr["dungeonNo"]);
				data.difficulty = Convert.ToInt32(dr["difficulty"]);
				data.step = Convert.ToInt32(dr["step"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);
				data.targetXPosition = Convert.ToSingle(dr["targetXPosition"]);
				data.targetYPosition = Convert.ToSingle(dr["targetYPosition"]);
				data.targetZPosition = Convert.ToSingle(dr["targetZPosition"]);
				data.targetRadius = Convert.ToSingle(dr["targetRadius"]);
				data.removeObstacleId = Convert.ToInt32(dr["removeObstacleId"]);
				data.isCompletionRemoveTaming = Convert.ToBoolean(dr["isCompletionRemoveTaming"]);

				storyDungeonSteps.Add(data);
			}
			gameDatas.storyDungeonSteps = storyDungeonSteps.ToArray();
			storyDungeonSteps.Clear();

			//
			// 스토리던전 가이드 목록
			//
			List<WPDStoryDungeonGuide> storyDungeonGuides = new List<WPDStoryDungeonGuide>();
			foreach (DataRow dr in drcStoryDungeonGuides)
			{
				WPDStoryDungeonGuide data = new WPDStoryDungeonGuide();
				data.dungeonNo = Convert.ToInt32(dr["dungeonNo"]);
				data.difficulty = Convert.ToInt32(dr["difficulty"]);
				data.step = Convert.ToInt32(dr["step"]);
				data.no = Convert.ToInt32(dr["no"]);
				data.imageName = Convert.ToString(dr["imageName"]);
				data.titleKey = Convert.ToString(dr["titleKey"]);
				data.contentKey = Convert.ToString(dr["contentKey"]);

				storyDungeonGuides.Add(data);
			}
			gameDatas.storyDungeonGuides = storyDungeonGuides.ToArray();
			storyDungeonGuides.Clear();

			//
			// 스토리던전함정 목록
			//
			List<WPDStoryDungeonTrap> storyDungeonTraps = new List<WPDStoryDungeonTrap>();
			foreach (DataRow dr in drcStoryDungeonTraps)
			{
				WPDStoryDungeonTrap data = new WPDStoryDungeonTrap();
				data.dungeonNo = Convert.ToInt32(dr["dungeonNo"]);
				data.difficulty = Convert.ToInt32(dr["difficulty"]);
				data.trapId = Convert.ToInt32(dr["trapId"]);
				data.prefabName = Convert.ToString(dr["prefabName"]);
				data.prefabScale = Convert.ToSingle(dr["prefabScale"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);
				data.width = Convert.ToSingle(dr["width"]);
				data.height = Convert.ToSingle(dr["height"]);
				data.hitAreaOffset = Convert.ToSingle(dr["hitAreaOffset"]);
				data.startDelay = Convert.ToSingle(dr["startDelay"]);
				data.castingStartDelay = Convert.ToSingle(dr["castingStartDelay"]);
				data.castingDuration = Convert.ToInt32(dr["castingDuration"]);
				data.hitCount = Convert.ToInt32(dr["hitCount"]);
				data.castingTerm = Convert.ToSingle(dr["castingTerm"]);
				data.damage = Convert.ToSingle(dr["damage"]);

				storyDungeonTraps.Add(data);
			}
			gameDatas.storyDungeonTraps = storyDungeonTraps.ToArray();
			storyDungeonTraps.Clear();

			//
			// 날개단계 목록
			//
			List<WPDWingStep> wingSteps = new List<WPDWingStep>();
			foreach (DataRow dr in drcWingSteps)
			{
				WPDWingStep data = new WPDWingStep();
				data.step = Convert.ToInt32(dr["step"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.colorCode = Convert.ToString(dr["colorCode"]);
				data.enchantMaterialItemCount = Convert.ToInt32(dr["enchantMaterialItemCount"]);
				data.rewardWingId = Convert.ToInt32(dr["rewardWingId"]);

				wingSteps.Add(data);
			}
			gameDatas.wingSteps = wingSteps.ToArray();
			wingSteps.Clear();

			//
			// 날개단계 파트 목록
			//
			List<WPDWingStepPart> wingStepParts = new List<WPDWingStepPart>();
			foreach (DataRow dr in drcWingStepParts)
			{
				WPDWingStepPart data = new WPDWingStepPart();
				data.step = Convert.ToInt32(dr["step"]);
				data.partId = Convert.ToInt32(dr["partId"]);
				data.increaseAttrValueId = Convert.ToInt64(dr["increaseAttrValueId"]);

				wingStepParts.Add(data);
			}
			gameDatas.wingStepParts = wingStepParts.ToArray();
			wingStepParts.Clear();

			//
			// 날개 파트 목록
			//
			List<WPDWingPart> wingParts = new List<WPDWingPart>();
			foreach (DataRow dr in drcWingParts)
			{
				WPDWingPart data = new WPDWingPart();
				data.partId = Convert.ToInt32(dr["partId"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);

				wingParts.Add(data);
			}
			gameDatas.wingParts = wingParts.ToArray();
			wingParts.Clear();

			//
			// 날개단계 레벨 목록
			//
			List<WPDWingStepLevel> wingStepLevels = new List<WPDWingStepLevel>();
			foreach (DataRow dr in drcWingStepLevels)
			{
				WPDWingStepLevel data = new WPDWingStepLevel();
				data.step = Convert.ToInt32(dr["step"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.nextLevelUpRequiredExp = Convert.ToInt32(dr["nextLevelUpRequiredExp"]);
				data.accEnchantLimitCount = Convert.ToInt32(dr["accEnchantLimitCount"]);

				wingStepLevels.Add(data);
			}
			gameDatas.wingStepLevels = wingStepLevels.ToArray();
			wingStepLevels.Clear();

			//
			// 날개 목록
			//
			List<WPDWing> wings = new List<WPDWing>();
			foreach (DataRow dr in drcWings)
			{
				WPDWing data = new WPDWing();
				data.wingId = Convert.ToInt32(dr["wingId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.prefabName = Convert.ToString(dr["prefabName"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);
				data.acquisitionTextKey = Convert.ToString(dr["acquisitionTextKey"]);
				data.memoryPieceInstallationEnabled = Convert.ToBoolean(dr["memoryPieceInstallationEnabled"]);

				wings.Add(data);
			}
			gameDatas.wings = wings.ToArray();
			wings.Clear();

			//
			// 체력구입횟수 목록
			//
			List<WPDStaminaBuyCount> staminaBuyCounts = new List<WPDStaminaBuyCount>();
			foreach (DataRow dr in drcStaminaBuyCounts)
			{
				WPDStaminaBuyCount data = new WPDStaminaBuyCount();
				data.buyCount = Convert.ToInt32(dr["buyCount"]);
				data.stamina = Convert.ToInt32(dr["stamina"]);
				data.requiredDia = Convert.ToInt32(dr["requiredDia"]);

				staminaBuyCounts.Add(data);
			}
			gameDatas.staminaBuyCounts = staminaBuyCounts.ToArray();
			staminaBuyCounts.Clear();

			//
			// 경험치던전
			//
			WPDExpDungeon expDungeon = new WPDExpDungeon();
			if (drExpDungeon != null)
			{
				expDungeon.nameKey = Convert.ToString(drExpDungeon["nameKey"]);
				expDungeon.descriptionKey = Convert.ToString(drExpDungeon["descriptionKey"]);
				expDungeon.requiredStamina = Convert.ToInt32(drExpDungeon["requiredStamina"]);
				expDungeon.limitTime = Convert.ToInt32(drExpDungeon["limitTime"]);
				expDungeon.sceneName = Convert.ToString(drExpDungeon["sceneName"]);
				expDungeon.startXPosition = Convert.ToSingle(drExpDungeon["startXPosition"]);
				expDungeon.startYPosition = Convert.ToSingle(drExpDungeon["startYPosition"]);
				expDungeon.startZPosition = Convert.ToSingle(drExpDungeon["startZPosition"]);
				expDungeon.startYRotation = Convert.ToSingle(drExpDungeon["startYRotation"]);
				expDungeon.startDelayTime = Convert.ToInt32(drExpDungeon["startDelayTime"]);
				expDungeon.exitDelayTime = Convert.ToInt32(drExpDungeon["exitDelayTime"]);
				expDungeon.waveIntervalTime = Convert.ToInt32(drExpDungeon["waveIntervalTime"]);
				expDungeon.safeRevivalWaitingTime = Convert.ToInt32(drExpDungeon["safeRevivalWaitingTime"]);
				expDungeon.sweepExpRewardFactor = Convert.ToSingle(drExpDungeon["sweepExpRewardFactor"]);
				expDungeon.guideImageName = Convert.ToString(drExpDungeon["guideImageName"]);
				expDungeon.guideTitleKey = Convert.ToString(drExpDungeon["guideTitleKey"]);
				expDungeon.startGuideContentKey = Convert.ToString(drExpDungeon["startGuideContentKey"]);
				expDungeon.lakChargeMonsterAppearContentKey = Convert.ToString(drExpDungeon["lakChargeMonsterAppearContentKey"]);
				expDungeon.lakChargeMonsterKillContentKey = Convert.ToString(drExpDungeon["lakChargeMonsterKillContentKey"]);
				expDungeon.locationId = Convert.ToInt32(drExpDungeon["locationId"]);
				expDungeon.x = Convert.ToSingle(drExpDungeon["x"]);
				expDungeon.z = Convert.ToSingle(drExpDungeon["z"]);
				expDungeon.xSize = Convert.ToSingle(drExpDungeon["xSize"]);
				expDungeon.zSize = Convert.ToSingle(drExpDungeon["zSize"]);

			}
			gameDatas.expDungeon = expDungeon;

			//
			// 경험치던전 난이도 목록
			//
			List<WPDExpDungeonDifficulty> expDungeonDifficulties = new List<WPDExpDungeonDifficulty>();
			foreach (DataRow dr in drcExpDungeonDifficulties)
			{
				WPDExpDungeonDifficulty data = new WPDExpDungeonDifficulty();
				data.difficulty = Convert.ToInt32(dr["difficulty"]);
				data.requiredConditionType = Convert.ToInt32(dr["requiredConditionType"]);
				data.requiredHeroLevel = Convert.ToInt32(dr["requiredHeroLevel"]);
				data.requiredMainQuestNo = Convert.ToInt32(dr["requiredMainQuestNo"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);

				expDungeonDifficulties.Add(data);
			}
			gameDatas.expDungeonDifficulties = expDungeonDifficulties.ToArray();
			expDungeonDifficulties.Clear();

			//
			// 경험치던전 난이도 웨이브 목록
			//
			List<WPDExpDungeonDifficultyWave> expDungeonDifficultyWaves = new List<WPDExpDungeonDifficultyWave>();
			foreach (DataRow dr in drcExpDungeonDifficultyWaves)
			{
				WPDExpDungeonDifficultyWave data = new WPDExpDungeonDifficultyWave();
				data.difficulty = Convert.ToInt32(dr["difficulty"]);
				data.waveNo = Convert.ToInt32(dr["waveNo"]);
				data.waveLimitTime = Convert.ToInt32(dr["waveLimitTime"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);
				data.lakChargeAmount = Convert.ToInt32(dr["lakChargeAmount"]);

				expDungeonDifficultyWaves.Add(data);
			}
			gameDatas.expDungeonDifficultyWaves = expDungeonDifficultyWaves.ToArray();
			expDungeonDifficultyWaves.Clear();

			//
			// 골드던전
			//
			WPDGoldDungeon goldDungeon = new WPDGoldDungeon();
			if (drGoldDungeon != null)
			{
				goldDungeon.nameKey = Convert.ToString(drGoldDungeon["nameKey"]);
				goldDungeon.descriptionKey = Convert.ToString(drGoldDungeon["descriptionKey"]);
				goldDungeon.requiredStamina = Convert.ToInt32(drGoldDungeon["requiredStamina"]);
				goldDungeon.limitTime = Convert.ToInt32(drGoldDungeon["limitTime"]);
				goldDungeon.sceneName = Convert.ToString(drGoldDungeon["sceneName"]);
				goldDungeon.startXPosition = Convert.ToSingle(drGoldDungeon["startXPosition"]);
				goldDungeon.startYPosition = Convert.ToSingle(drGoldDungeon["startYPosition"]);
				goldDungeon.startZPosition = Convert.ToSingle(drGoldDungeon["startZPosition"]);
				goldDungeon.startYRotation = Convert.ToSingle(drGoldDungeon["startYRotation"]);
				goldDungeon.startDelayTime = Convert.ToInt32(drGoldDungeon["startDelayTime"]);
				goldDungeon.exitDelayTime = Convert.ToInt32(drGoldDungeon["exitDelayTime"]);
				goldDungeon.safeRevivalWaitingTime = Convert.ToInt32(drGoldDungeon["safeRevivalWaitingTime"]);
				goldDungeon.monsterEscapeXPosition = Convert.ToSingle(drGoldDungeon["monsterEscapeXPosition"]);
				goldDungeon.monsterEscapeYPosition = Convert.ToSingle(drGoldDungeon["monsterEscapeYPosition"]);
				goldDungeon.monsterEscapeZPosition = Convert.ToSingle(drGoldDungeon["monsterEscapeZPosition"]);
				goldDungeon.monsterEscapeRadius = Convert.ToSingle(drGoldDungeon["monsterEscapeRadius"]);
				goldDungeon.locationId = Convert.ToInt32(drGoldDungeon["locationId"]);
				goldDungeon.x = Convert.ToSingle(drGoldDungeon["x"]);
				goldDungeon.z = Convert.ToSingle(drGoldDungeon["z"]);
				goldDungeon.xSize = Convert.ToSingle(drGoldDungeon["xSize"]);
				goldDungeon.zSize = Convert.ToSingle(drGoldDungeon["zSize"]);
			}
			gameDatas.goldDungeon = goldDungeon;

			//
			// 골드던전 난이도 목록
			//
			List<WPDGoldDungeonDifficulty> goldDungeonDifficulties = new List<WPDGoldDungeonDifficulty>();
			foreach (DataRow dr in drcGoldDungeonDifficulties)
			{
				WPDGoldDungeonDifficulty data = new WPDGoldDungeonDifficulty();
				data.difficulty = Convert.ToInt32(dr["difficulty"]);
				data.requiredHeroLevel = Convert.ToInt32(dr["requiredHeroLevel"]);
				data.goldRewardId = Convert.ToInt64(dr["goldRewardId"]);

				goldDungeonDifficulties.Add(data);
			}
			gameDatas.goldDungeonDifficulties = goldDungeonDifficulties.ToArray();
			goldDungeonDifficulties.Clear();

			//
			// 골드던전 단계 목록
			//
			List<WPDGoldDungeonStep> goldDungeonSteps = new List<WPDGoldDungeonStep>();
			foreach (DataRow dr in drcGoldDungeonSteps)
			{
				WPDGoldDungeonStep data = new WPDGoldDungeonStep();
				data.difficulty = Convert.ToInt32(dr["difficulty"]);
				data.step = Convert.ToInt32(dr["step"]);
				data.goldRewardId = Convert.ToInt64(dr["goldRewardId"]);

				goldDungeonSteps.Add(data);
			}
			gameDatas.goldDungeonSteps = goldDungeonSteps.ToArray();
			goldDungeonSteps.Clear();

			//
			// 골드던전 단계 웨이브 목록
			//
			List<WPDGoldDungeonStepWave> goldDungeonStepWaves = new List<WPDGoldDungeonStepWave>();
			foreach (DataRow dr in drcGoldDungeonStepWaves)
			{
				WPDGoldDungeonStepWave data = new WPDGoldDungeonStepWave();
				data.difficulty = Convert.ToInt32(dr["difficulty"]);
				data.step = Convert.ToInt32(dr["step"]);
				data.waveNo = Convert.ToInt32(dr["waveNo"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);
				data.limitTime = Convert.ToInt32(dr["limitTime"]);
				data.nextWaveIntervalTime = Convert.ToInt32(dr["nextWaveIntervalTime"]);
				data.guideImageName = Convert.ToString(dr["guideImageName"]);
				data.guideTitleKey = Convert.ToString(dr["guideTitleKey"]);
				data.guideContentKey = Convert.ToString(dr["guideContentKey"]);

				goldDungeonStepWaves.Add(data);
			}
			gameDatas.goldDungeonStepWaves = goldDungeonStepWaves.ToArray();
			goldDungeonStepWaves.Clear();

			//
			// 골드던전 단계 몬스터 배치 목록
			//
			List<WPDGoldDungeonStepMonsterArrange> goldDungeonStepMonsterArranges = new List<WPDGoldDungeonStepMonsterArrange>();
			foreach (DataRow dr in drcGoldDungeonStepMonsterArranges)
			{
				WPDGoldDungeonStepMonsterArrange data = new WPDGoldDungeonStepMonsterArrange();
				data.difficulty = Convert.ToInt32(dr["difficulty"]);
				data.step = Convert.ToInt32(dr["step"]);
				data.arrangeNo = Convert.ToInt32(dr["arrangeNo"]);
				data.monsterArrangeId = Convert.ToInt64(dr["monsterArrangeId"]);
				data.monsterCount = Convert.ToInt32(dr["monsterCount"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.radius = Convert.ToSingle(dr["radius"]);
				data.yRotationType = Convert.ToInt32(dr["yRotationType"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);
				data.isFugitive = Convert.ToBoolean(dr["isFugitive"]);
				data.activationWaveNo = Convert.ToInt32(dr["activationWaveNo"]);

				goldDungeonStepMonsterArranges.Add(data);
			}
			gameDatas.goldDungeonStepMonsterArranges = goldDungeonStepMonsterArranges.ToArray();
			goldDungeonStepMonsterArranges.Clear();

			//
			// 메인장비 강화레벨 세트 목록
			//
			List<WPDMainGearEnchantLevelSet> mainGearEnchantLevelSets = new List<WPDMainGearEnchantLevelSet>();
			foreach (DataRow dr in drcMainGearEnchantLevelSets)
			{
				WPDMainGearEnchantLevelSet data = new WPDMainGearEnchantLevelSet();
				data.setNo = Convert.ToInt32(dr["setNo"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.requiredTotalEnchantLevel = Convert.ToInt32(dr["requiredTotalEnchantLevel"]);

				mainGearEnchantLevelSets.Add(data);
			}
			gameDatas.mainGearEnchantLevelSets = mainGearEnchantLevelSets.ToArray();
			mainGearEnchantLevelSets.Clear();

			//
			// 메인장비 강화레벨 세트 속성 목록
			//
			List<WPDMainGearEnchantLevelSetAttr> mainGearEnchantLevelSetAttrs = new List<WPDMainGearEnchantLevelSetAttr>();
			foreach (DataRow dr in drcMainGearEnchantLevelSetAttrs)
			{
				WPDMainGearEnchantLevelSetAttr data = new WPDMainGearEnchantLevelSetAttr();
				data.setNo = Convert.ToInt32(dr["setNo"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);

				mainGearEnchantLevelSetAttrs.Add(data);
			}
			gameDatas.mainGearEnchantLevelSetAttrs = mainGearEnchantLevelSetAttrs.ToArray();
			mainGearEnchantLevelSetAttrs.Clear();

			//
			// 메인장비 세트 목록
			//
			List<WPDMainGearSet> mainGearSets = new List<WPDMainGearSet>();
			foreach (DataRow dr in drcMainGearSets)
			{
				WPDMainGearSet data = new WPDMainGearSet();
				data.tier = Convert.ToInt32(dr["tier"]);
				data.grade = Convert.ToInt32(dr["grade"]);
				data.quality = Convert.ToInt32(dr["quality"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);

				mainGearSets.Add(data);
			}
			gameDatas.mainGearSets = mainGearSets.ToArray();
			mainGearSets.Clear();

			//
			// 메인장비 세트 속성 목록
			//
			List<WPDMainGearSetAttr> mainGearSetAttrs = new List<WPDMainGearSetAttr>();
			foreach (DataRow dr in drcMainGearSetAttrs)
			{
				WPDMainGearSetAttr data = new WPDMainGearSetAttr();
				data.tier = Convert.ToInt32(dr["tier"]);
				data.grade = Convert.ToInt32(dr["grade"]);
				data.quality = Convert.ToInt32(dr["quality"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);

				mainGearSetAttrs.Add(data);
			}
			gameDatas.mainGearSetAttrs = mainGearSetAttrs.ToArray();
			mainGearSetAttrs.Clear();

			//
			// 보조장비 소울스톤레벨 세트 목록
			//
			List<WPDSubGearSoulstoneLevelSet> subGearSoulstoneLevelSets = new List<WPDSubGearSoulstoneLevelSet>();
			foreach (DataRow dr in drcSubGearSoulstoneLevelSets)
			{
				WPDSubGearSoulstoneLevelSet data = new WPDSubGearSoulstoneLevelSet();
				data.setNo = Convert.ToInt32(dr["setNo"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.requiredTotalLevel = Convert.ToInt32(dr["requiredTotalLevel"]);

				subGearSoulstoneLevelSets.Add(data);
			}
			gameDatas.subGearSoulstoneLevelSets = subGearSoulstoneLevelSets.ToArray();
			subGearSoulstoneLevelSets.Clear();

			//
			// 보조장비 소울스톤레벨 세트 속성 목록
			//
			List<WPDSubGearSoulstoneLevelSetAttr> subGearSoulstoneLevelSetAttrs = new List<WPDSubGearSoulstoneLevelSetAttr>();
			foreach (DataRow dr in drcSubGearSoulstoneLevelSetAttrs)
			{
				WPDSubGearSoulstoneLevelSetAttr data = new WPDSubGearSoulstoneLevelSetAttr();
				data.setNo = Convert.ToInt32(dr["setNo"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);

				subGearSoulstoneLevelSetAttrs.Add(data);
			}
			gameDatas.subGearSoulstoneLevelSetAttrs = subGearSoulstoneLevelSetAttrs.ToArray();
			subGearSoulstoneLevelSetAttrs.Clear();

			//
			// 수레등급 목록
			//
			List<WPDCartGrade> cartGrades = new List<WPDCartGrade>();
			foreach (DataRow dr in drcCartGrades)
			{
				WPDCartGrade data = new WPDCartGrade();
				data.grade = Convert.ToInt32(dr["grade"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.colorCode = Convert.ToString(dr["colorCode"]);

				cartGrades.Add(data);
			}
			gameDatas.cartGrades = cartGrades.ToArray();
			cartGrades.Clear();

			//
			// 수레 목록
			//
			List<WPDCart> carts = new List<WPDCart>();
			foreach (DataRow dr in drcCarts)
			{
				WPDCart data = new WPDCart();
				data.cartId = Convert.ToInt32(dr["cartId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.prefabName = Convert.ToString(dr["prefabName"]);
				data.grade = Convert.ToInt32(dr["grade"]);
				data.ridableRange = Convert.ToSingle(dr["ridableRange"]);
				data.radius = Convert.ToSingle(dr["radius"]);

				carts.Add(data);
			}
			gameDatas.carts = carts.ToArray();
			carts.Clear();

			//
			// 세계레벨경험치계수 목록
			//
			List<WPDWorldLevelExpFactor> worldLevelExpFactors = new List<WPDWorldLevelExpFactor>();
			foreach (DataRow dr in drcWorldLevelExpFactors)
			{
				WPDWorldLevelExpFactor data = new WPDWorldLevelExpFactor();
				data.levelGap = Convert.ToInt32(dr["levelGap"]);
				data.expFactor = Convert.ToSingle(dr["expFactor"]);

				worldLevelExpFactors.Add(data);
			}
			gameDatas.worldLevelExpFactors = worldLevelExpFactors.ToArray();
			worldLevelExpFactors.Clear();

			//
			// 위치지역 목록
			//
			List<WPDLocationArea> locationAreas = new List<WPDLocationArea>();
			foreach (DataRow dr in drcLocationAreas)
			{
				WPDLocationArea data = new WPDLocationArea();
				data.locationId = Convert.ToInt32(dr["locationId"]);
				data.areaNo = Convert.ToInt32(dr["areaNo"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.isMinimapDisplay = Convert.ToBoolean(dr["isMinimapDisplay"]);
				data.minimapX = Convert.ToInt32(dr["minimapX"]);
				data.minimapY = Convert.ToInt32(dr["minimapY"]);
				data.minimapTextColorCode = Convert.ToString(dr["minimapTextColorCode"]);

				locationAreas.Add(data);
			}
			gameDatas.locationAreas = locationAreas.ToArray();
			locationAreas.Clear();

			//
			// 대륙맵몬스터 목록
			//
			List<WPDContinentMapMonster> continentMapMonsters = new List<WPDContinentMapMonster>();
			foreach (DataRow dr in drcContinentMapMonsters)
			{
				WPDContinentMapMonster data = new WPDContinentMapMonster();
				data.continentId = Convert.ToInt32(dr["continentId"]);
				data.monsterId = Convert.ToInt32(dr["monsterId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);

				continentMapMonsters.Add(data);
			}
			gameDatas.continentMapMonsters = continentMapMonsters.ToArray();
			continentMapMonsters.Clear();

			//
			// 농장의위협퀘스트
			//
			WPDTreatOfFarmQuest treatOfFarmQuest = new WPDTreatOfFarmQuest();
			if (drTreatOfFarmQuest != null)
			{
				treatOfFarmQuest.requiredHeroLevel = Convert.ToInt32(drTreatOfFarmQuest["requiredHeroLevel"]);
				treatOfFarmQuest.titleKey = Convert.ToString(drTreatOfFarmQuest["titleKey"]);
				treatOfFarmQuest.targetMovingTextKey = Convert.ToString(drTreatOfFarmQuest["targetMovingTextKey"]);
				treatOfFarmQuest.targetKillTextKey = Convert.ToString(drTreatOfFarmQuest["targetKillTextKey"]);
				treatOfFarmQuest.limitCount = Convert.ToInt32(drTreatOfFarmQuest["limitCount"]);
				treatOfFarmQuest.questNpcId = Convert.ToInt32(drTreatOfFarmQuest["questNpcId"]);
				treatOfFarmQuest.monsterKillLimitTime = Convert.ToInt32(drTreatOfFarmQuest["monsterKillLimitTime"]);
				treatOfFarmQuest.targetMovingDescriptionKey = Convert.ToString(drTreatOfFarmQuest["targetMovingDescriptionKey"]);
				treatOfFarmQuest.targetKillDescriptionKey = Convert.ToString(drTreatOfFarmQuest["targetKillDescriptionKey"]);
				treatOfFarmQuest.startDialogueKey = Convert.ToString(drTreatOfFarmQuest["startDialogueKey"]);
				treatOfFarmQuest.completionDialogueKey = Convert.ToString(drTreatOfFarmQuest["completionDialogueKey"]);
				treatOfFarmQuest.completionTextKey = Convert.ToString(drTreatOfFarmQuest["completionTextKey"]);
			}
			gameDatas.treatOfFarmQuest = treatOfFarmQuest;

			//
			// 농장의위협퀘스트미션 목록
			//
			List<WPDTreatOfFarmQuestMission> treatOfFarmQuestMissions = new List<WPDTreatOfFarmQuestMission>();
			foreach (DataRow dr in drcTreatOfFarmQuestMissions)
			{
				WPDTreatOfFarmQuestMission data = new WPDTreatOfFarmQuestMission();
				data.missionId = Convert.ToInt32(dr["missionId"]);
				data.targetPositionNameKey = Convert.ToString(dr["targetPositionNameKey"]);
				data.targetContinentId = Convert.ToInt32(dr["targetContinentId"]);
				data.targetXPosition = Convert.ToSingle(dr["targetXPosition"]);
				data.targetYPosition = Convert.ToSingle(dr["targetYPosition"]);
				data.targetZPosition = Convert.ToSingle(dr["targetZPosition"]);
				data.targetRadius = Convert.ToSingle(dr["targetRadius"]);
				data.monsterSpawnXPosition = Convert.ToSingle(dr["monsterSpawnXPosition"]);
				data.monsterSpawnYPosition = Convert.ToSingle(dr["monsterSpawnYPosition"]);
				data.monsterSpawnZPosition = Convert.ToSingle(dr["monsterSpawnZPosition"]);
				data.monsterYRotationType = Convert.ToInt32(dr["monsterYRotationType"]);
				data.monsterYRotation = Convert.ToSingle(dr["monsterYRotation"]);

				treatOfFarmQuestMissions.Add(data);
			}
			gameDatas.treatOfFarmQuestMissions = treatOfFarmQuestMissions.ToArray();
			treatOfFarmQuestMissions.Clear();

			//
			// 농장의위협퀘스트보상 목록
			//
			List<WPDTreatOfFarmQuestReward> treatOfFarmQuestRewards = new List<WPDTreatOfFarmQuestReward>();
			foreach (DataRow dr in drcTreatOfFarmQuestRewards)
			{
				WPDTreatOfFarmQuestReward data = new WPDTreatOfFarmQuestReward();
				data.level = Convert.ToInt32(dr["level"]);
				data.missionCompletionExpRewardId = Convert.ToInt64(dr["missionCompletionExpRewardId"]);
				data.missionCompletionItemRewardId = Convert.ToInt64(dr["missionCompletionItemRewardId"]);
				data.questCompletionItemRewardId = Convert.ToInt64(dr["questCompletionItemRewardId"]);

				treatOfFarmQuestRewards.Add(data);
			}
			gameDatas.treatOfFarmQuestRewards = treatOfFarmQuestRewards.ToArray();
			treatOfFarmQuestRewards.Clear();

			//
			// 대륙전송출구 목록
			//
			List<WPDContinentTransmissionExit> continentTransmissionExits = new List<WPDContinentTransmissionExit>();
			foreach (DataRow dr in drcContinentTransmissionExits)
			{
				WPDContinentTransmissionExit data = new WPDContinentTransmissionExit();
				data.npcId = Convert.ToInt32(dr["npcId"]);
				data.exitNo = Convert.ToInt32(dr["exitNo"]);
				data._name = Convert.ToString(dr["_name"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.continentId = Convert.ToInt32(dr["continentId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.radius = Convert.ToSingle(dr["radius"]);
				data.yRotationType = Convert.ToInt32(dr["yRotationType"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);

				continentTransmissionExits.Add(data);
			}
			gameDatas.continentTransmissionExits = continentTransmissionExits.ToArray();
			continentTransmissionExits.Clear();

			//
			// 지하미로
			//
			WPDUndergroundMaze undergroundMaze = new WPDUndergroundMaze();
			if (drUndergroundMaze != null)
			{
				undergroundMaze.nameKey = Convert.ToString(drUndergroundMaze["nameKey"]);
				undergroundMaze.descriptionKey = Convert.ToString(drUndergroundMaze["descriptionKey"]);
				undergroundMaze.targetTitleKey = Convert.ToString(drUndergroundMaze["targetTitleKey"]);
				undergroundMaze.targetContentKey = Convert.ToString(drUndergroundMaze["targetContentKey"]);
				undergroundMaze.sceneName = Convert.ToString(drUndergroundMaze["sceneName"]);
				undergroundMaze.requiredConditionType = Convert.ToInt32(drUndergroundMaze["requiredConditionType"]);
				undergroundMaze.requiredHeroLevel = Convert.ToInt32(drUndergroundMaze["requiredHeroLevel"]);
				undergroundMaze.requiredMainQuestNo = Convert.ToInt32(drUndergroundMaze["requiredMainQuestNo"]);
				undergroundMaze.limitTime = Convert.ToInt32(drUndergroundMaze["limitTime"]);
				undergroundMaze.startXPosition = Convert.ToSingle(drUndergroundMaze["startXPosition"]);
				undergroundMaze.startYPosition = Convert.ToSingle(drUndergroundMaze["startYPosition"]);
				undergroundMaze.startZPosition = Convert.ToSingle(drUndergroundMaze["startZPosition"]);
				undergroundMaze.startRadius = Convert.ToSingle(drUndergroundMaze["startRadius"]);
				undergroundMaze.startYRotationType = Convert.ToInt32(drUndergroundMaze["startYRotationType"]);
				undergroundMaze.startYRotation = Convert.ToSingle(drUndergroundMaze["startYRotation"]);
				undergroundMaze.locationId = Convert.ToInt32(drUndergroundMaze["locationId"]);
				undergroundMaze.x = Convert.ToSingle(drUndergroundMaze["x"]);
				undergroundMaze.z = Convert.ToSingle(drUndergroundMaze["z"]);
				undergroundMaze.xSize = Convert.ToSingle(drUndergroundMaze["xSize"]);
				undergroundMaze.zSize = Convert.ToSingle(drUndergroundMaze["zSize"]);

			}
			gameDatas.undergroundMaze = undergroundMaze;

			//
			// 지하미로입구 목록
			//
			List<WPDUndergroundMazeEntrance> undergroundMazeEntrances = new List<WPDUndergroundMazeEntrance>();
			foreach (DataRow dr in drcUndergroundMazeEntrances)
			{
				WPDUndergroundMazeEntrance data = new WPDUndergroundMazeEntrance();
				data.floor = Convert.ToInt32(dr["floor"]);
				data.requiredHeroLevel = Convert.ToInt32(dr["requiredHeroLevel"]);

				undergroundMazeEntrances.Add(data);
			}
			gameDatas.undergroundMazeEntrances = undergroundMazeEntrances.ToArray();
			undergroundMazeEntrances.Clear();

			//
			// 지하미로층 목록
			//
			List<WPDUndergroundMazeFloor> undergroundMazeFloors = new List<WPDUndergroundMazeFloor>();
			foreach (DataRow dr in drcUndergroundMazeFloors)
			{
				WPDUndergroundMazeFloor data = new WPDUndergroundMazeFloor();
				data.floor = Convert.ToInt32(dr["floor"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);

				undergroundMazeFloors.Add(data);
			}
			gameDatas.undergroundMazeFloors = undergroundMazeFloors.ToArray();
			undergroundMazeFloors.Clear();

			//
			// 지하미로포탈 목록
			//
			List<WPDUndergroundMazePortal> undergroundMazePortals = new List<WPDUndergroundMazePortal>();
			foreach (DataRow dr in drcUndergroundMazePortals)
			{
				WPDUndergroundMazePortal data = new WPDUndergroundMazePortal();
				data.portalId = Convert.ToInt32(dr["portalId"]);
				data.floor = Convert.ToInt32(dr["floor"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.radius = Convert.ToSingle(dr["radius"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);
				data.exitXPosition = Convert.ToSingle(dr["exitXPosition"]);
				data.exitYPosition = Convert.ToSingle(dr["exitYPosition"]);
				data.exitZPosition = Convert.ToSingle(dr["exitZPosition"]);
				data.exitRadius = Convert.ToSingle(dr["exitRadius"]);
				data.exitYRotationType = Convert.ToInt32(dr["exitYRotationType"]);
				data.exitYRotation = Convert.ToSingle(dr["exitYRotation"]);
				data.linkedPortalId = Convert.ToInt32(dr["linkedPortalId"]);

				undergroundMazePortals.Add(data);
			}
			gameDatas.undergroundMazePortals = undergroundMazePortals.ToArray();
			undergroundMazePortals.Clear();

            //
            // TODO: 地下迷宫地图怪物列表
            //
            List<WPDUndergroundMazeMapMonster> undergroundMazeMapMonsters = new List<WPDUndergroundMazeMapMonster>();
            foreach (DataRow dr in drcUndergroundMazeMapMonsters)
			{
				WPDUndergroundMazeMapMonster data = new WPDUndergroundMazeMapMonster();
				data.floor = Convert.ToInt32(dr["floor"]);
				data.monsterId = Convert.ToInt32(dr["monsterId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);

				undergroundMazeMapMonsters.Add(data);
			}
			gameDatas.undergroundMazeMapMonsters = undergroundMazeMapMonsters.ToArray();
			undergroundMazeMapMonsters.Clear();

			//
			// 지하미로NPC 목록
			//
			List<WPDUndergroundMazeNpc> undergroundMazeNpcs = new List<WPDUndergroundMazeNpc>();
			foreach (DataRow dr in drcUndergroundMazeNpcs)
			{
				WPDUndergroundMazeNpc data = new WPDUndergroundMazeNpc();
				data.npcId = Convert.ToInt32(dr["npcId"]);
				data.floor = Convert.ToInt32(dr["floor"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.dialogueKey = Convert.ToString(dr["dialogueKey"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);
				data.interactionMaxRange = Convert.ToSingle(dr["interactionMaxRange"]);
				data.prefabName = Convert.ToString(dr["prefabName"]);
				data.scale = Convert.ToSingle(dr["scale"]);
				data.height = Convert.ToInt32(dr["height"]);
				data.radius = Convert.ToSingle(dr["radius"]);

				undergroundMazeNpcs.Add(data);
			}
			gameDatas.undergroundMazeNpcs = undergroundMazeNpcs.ToArray();
			undergroundMazeNpcs.Clear();

			//
			// 지하미로NPC전송항목 목록
			//
			List<WPDUndergroundMazeNpcTransmissionEntry> undergroundMazeNpcTransmissionEntries = new List<WPDUndergroundMazeNpcTransmissionEntry>();
			foreach (DataRow dr in drcUndergroundMazeNpcTransmissionEntries)
			{
				WPDUndergroundMazeNpcTransmissionEntry data = new WPDUndergroundMazeNpcTransmissionEntry();
				data.npcId = Convert.ToInt32(dr["npcId"]);
				data.floor = Convert.ToInt32(dr["floor"]);

				undergroundMazeNpcTransmissionEntries.Add(data);
			}
			gameDatas.undergroundMazeNpcTransmissionEntries = undergroundMazeNpcTransmissionEntries.ToArray();
			undergroundMazeNpcTransmissionEntries.Clear();

			//
			// 지하미로몬스터배치 목록
			//
			List<WPDUndergroundMazeMonsterArrange> undergroundMazeMonsterArranges = new List<WPDUndergroundMazeMonsterArrange>();
			foreach (DataRow dr in drcUndergroundMazeMonsterArranges)
			{
				WPDUndergroundMazeMonsterArrange data = new WPDUndergroundMazeMonsterArrange();
				data.floor = Convert.ToInt32(dr["floor"]);
				data.arrangeNo = Convert.ToInt32(dr["arrangeNo"]);
				data.monsterArrangeId = Convert.ToInt64(dr["monsterArrangeId"]);
				data.monsterCount = Convert.ToInt32(dr["monsterCount"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.radius = Convert.ToSingle(dr["radius"]);

				undergroundMazeMonsterArranges.Add(data);
			}
			gameDatas.undergroundMazeMonsterArranges = undergroundMazeMonsterArranges.ToArray();
			undergroundMazeMonsterArranges.Clear();

			//
			// 현상금사냥퀘스트 목록
			//
			List<WPDBountyHunterQuest> bountyHunterQuests = new List<WPDBountyHunterQuest>();
			foreach (DataRow dr in drcBountyHunterQuests)
			{
				WPDBountyHunterQuest data = new WPDBountyHunterQuest();
				data.questId = Convert.ToInt32(dr["questId"]);
				data.titleKey = Convert.ToString(dr["titleKey"]);
				data.contentKey = Convert.ToString(dr["contentKey"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.targetMonsterMinLevel = Convert.ToInt32(dr["targetMonsterMinLevel"]);
				data.targetCount = Convert.ToInt32(dr["targetCount"]);
				data.targetContinentId = Convert.ToInt32(dr["targetContinentId"]);
				data.targetXPosition = Convert.ToSingle(dr["targetXPosition"]);
				data.targetYPosition = Convert.ToSingle(dr["targetYPosition"]);
				data.targetZPosition = Convert.ToSingle(dr["targetZPosition"]);
				data.targetRadius = Convert.ToSingle(dr["targetRadius"]);
				data.guideImageName = Convert.ToString(dr["guideImageName"]);
				data.guideTitleKey = Convert.ToString(dr["guideTitleKey"]);
				data.startGuideContentKey = Convert.ToString(dr["startGuideContentKey"]);
				data.completionGuideContentKey = Convert.ToString(dr["completionGuideContentKey"]);

				bountyHunterQuests.Add(data);
			}
			gameDatas.bountyHunterQuests = bountyHunterQuests.ToArray();
			bountyHunterQuests.Clear();

			//
			// 현상금사냥퀘스트보상 목록
			//
			List<WPDBountyHunterQuestReward> bountyHunterQuestRewards = new List<WPDBountyHunterQuestReward>();
			foreach (DataRow dr in drcBountyHunterQuestRewards)
			{
				WPDBountyHunterQuestReward data = new WPDBountyHunterQuestReward();
				data.questItemGrade = Convert.ToInt32(dr["questItemGrade"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);

				bountyHunterQuestRewards.Add(data);
			}
			gameDatas.bountyHunterQuestRewards = bountyHunterQuestRewards.ToArray();
			bountyHunterQuestRewards.Clear();

			//
			// 낚시퀘스트
			//
			WPDFishingQuest fishingQuest = new WPDFishingQuest();
			if (drFishingQuest != null)
			{
				fishingQuest.npcId = Convert.ToInt32(drFishingQuest["npcId"]);
				fishingQuest.requiredHeroLevel = Convert.ToInt32(drFishingQuest["requiredHeroLevel"]);
				fishingQuest.limitCount = Convert.ToInt32(drFishingQuest["limitCount"]);
				fishingQuest.castingCount = Convert.ToInt32(drFishingQuest["castingCount"]);
				fishingQuest.castingInterval = Convert.ToInt32(drFishingQuest["castingInterval"]);
				fishingQuest.partyRadius = Convert.ToSingle(drFishingQuest["partyRadius"]);
				fishingQuest.partyExpRewardFactor = Convert.ToSingle(drFishingQuest["partyExpRewardFactor"]);
				fishingQuest.partyRecommendPopUpDisplayDuration = Convert.ToInt32(drFishingQuest["partyRecommendPopUpDisplayDuration"]);
				fishingQuest.partyRecommendPopUpHideDuration = Convert.ToInt32(drFishingQuest["partyRecommendPopUpHideDuration"]);
				fishingQuest.guildExpRewardFactor = Convert.ToSingle(drFishingQuest["guildExpRewardFactor"]);

			}
			gameDatas.fishingQuest = fishingQuest;

			//
			// 낚시퀘스트지점 목록
			//
			List<WPDFishingQuestSpot> fishingQuestSpots = new List<WPDFishingQuestSpot>();
			foreach (DataRow dr in drcFishingQuestSpots)
			{
				WPDFishingQuestSpot data = new WPDFishingQuestSpot();
				data.spotId = Convert.ToInt32(dr["spotId"]);
				data.continentId = Convert.ToInt32(dr["continentId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.radius = Convert.ToSingle(dr["radius"]);

				fishingQuestSpots.Add(data);
			}
			gameDatas.fishingQuestSpots = fishingQuestSpots.ToArray();
			fishingQuestSpots.Clear();

			//
			// 낚시퀘스트길드영지지점 목록
			//
			List<WPDFishingQuestGuildTerritorySpot> fishingQuestGuildTerritorySpots = new List<WPDFishingQuestGuildTerritorySpot>();
			foreach (DataRow dr in drcFishingQuestGuildTerritorySpots)
			{
				WPDFishingQuestGuildTerritorySpot data = new WPDFishingQuestGuildTerritorySpot();
				data.spotId = Convert.ToInt32(dr["spotId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.radius = Convert.ToSingle(dr["radius"]);

				fishingQuestGuildTerritorySpots.Add(data);
			}
			gameDatas.fishingQuestGuildTerritorySpots = fishingQuestGuildTerritorySpots.ToArray();
			fishingQuestGuildTerritorySpots.Clear();

			//
			// 밀서유출퀘스트
			//
			WPDSecretLetterQuest secretLetterQuest = new WPDSecretLetterQuest();
			if (drSecretLetterQuest != null)
			{
				secretLetterQuest.targetTitleKey = Convert.ToString(drSecretLetterQuest["targetTitleKey"]);
				secretLetterQuest.targetContentKey = Convert.ToString(drSecretLetterQuest["targetContentKey"]);
				secretLetterQuest.requiredHeroLevel = Convert.ToInt32(drSecretLetterQuest["requiredHeroLevel"]);
				secretLetterQuest.questNpcId = Convert.ToInt32(drSecretLetterQuest["questNpcId"]);
				secretLetterQuest.targetNpcId = Convert.ToInt32(drSecretLetterQuest["targetNpcId"]);
				secretLetterQuest.limitCount = Convert.ToInt32(drSecretLetterQuest["limitCount"]);
				secretLetterQuest.interactionDuration = Convert.ToInt32(drSecretLetterQuest["interactionDuration"]);
				secretLetterQuest.descriptionKey = Convert.ToString(drSecretLetterQuest["descriptionKey"]);
				secretLetterQuest.startDialogueKey = Convert.ToString(drSecretLetterQuest["startDialogueKey"]);
				secretLetterQuest.completionDialogueKey = Convert.ToString(drSecretLetterQuest["completionDialogueKey"]);
				secretLetterQuest.completionTextKey = Convert.ToString(drSecretLetterQuest["completionTextKey"]);
			}
			gameDatas.secretLetterQuest = secretLetterQuest;

			//
			// 밀서유출퀘스트보상 목록
			//
			List<WPDSecretLetterQuestReward> secretLetterQuestRewards = new List<WPDSecretLetterQuestReward>();
			foreach (DataRow dr in drcSecretLetterQuestRewards)
			{
				WPDSecretLetterQuestReward data = new WPDSecretLetterQuestReward();
				data.grade = Convert.ToInt32(dr["grade"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);

				secretLetterQuestRewards.Add(data);
			}
			gameDatas.secretLetterQuestRewards = secretLetterQuestRewards.ToArray();
			secretLetterQuestRewards.Clear();

			//
			// 밀서등급 목록
			//
			List<WPDSecretLetterGrade> secretLetterGrades = new List<WPDSecretLetterGrade>();
			foreach (DataRow dr in drcSecretLetterGrades)
			{
				WPDSecretLetterGrade data = new WPDSecretLetterGrade();
				data.grade = Convert.ToInt32(dr["grade"]);
				data.exploitPointRewardId = Convert.ToInt64(dr["exploitPointRewardId"]);

				secretLetterGrades.Add(data);
			}
			gameDatas.secretLetterGrades = secretLetterGrades.ToArray();
			secretLetterGrades.Clear();

			//
			// 의문의상자퀘스트
			//
			WPDMysteryBoxQuest mysteryBoxQuest = new WPDMysteryBoxQuest();
			if (drMysteryBoxQuest != null)
			{
				mysteryBoxQuest.targetTitleKey = Convert.ToString(drMysteryBoxQuest["targetTitleKey"]);
				mysteryBoxQuest.targetContentKey = Convert.ToString(drMysteryBoxQuest["targetContentKey"]);
				mysteryBoxQuest.requiredHeroLevel = Convert.ToInt32(drMysteryBoxQuest["requiredHeroLevel"]);
				mysteryBoxQuest.questNpcId = Convert.ToInt32(drMysteryBoxQuest["questNpcId"]);
				mysteryBoxQuest.targetNpcId = Convert.ToInt32(drMysteryBoxQuest["targetNpcId"]);
				mysteryBoxQuest.limitCount = Convert.ToInt32(drMysteryBoxQuest["limitCount"]);
				mysteryBoxQuest.interactionDuration = Convert.ToInt32(drMysteryBoxQuest["interactionDuration"]);
				mysteryBoxQuest.descriptionKey = Convert.ToString(drMysteryBoxQuest["descriptionKey"]);
				mysteryBoxQuest.startDialogueKey = Convert.ToString(drMysteryBoxQuest["startDialogueKey"]);
				mysteryBoxQuest.completionDialogueKey = Convert.ToString(drMysteryBoxQuest["completionDialogueKey"]);
				mysteryBoxQuest.completionTextKey = Convert.ToString(drMysteryBoxQuest["completionTextKey"]);
			}
			gameDatas.mysteryBoxQuest = mysteryBoxQuest;

			//
			// 의문의상자퀘스트보상 목록
			//
			List<WPDMysteryBoxQuestReward> mysteryBoxQuestRewards = new List<WPDMysteryBoxQuestReward>();
			foreach (DataRow dr in drcMysteryBoxQuestRewards)
			{
				WPDMysteryBoxQuestReward data = new WPDMysteryBoxQuestReward();
				data.grade = Convert.ToInt32(dr["grade"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);

				mysteryBoxQuestRewards.Add(data);
			}
			gameDatas.mysteryBoxQuestRewards = mysteryBoxQuestRewards.ToArray();
			mysteryBoxQuestRewards.Clear();

			//
			// 의문의상자등급 목록
			//
			List<WPDMysteryBoxGrade> mysteryBoxGrades = new List<WPDMysteryBoxGrade>();
			foreach (DataRow dr in drcMysteryBoxGrades)
			{
				WPDMysteryBoxGrade data = new WPDMysteryBoxGrade();
				data.grade = Convert.ToInt32(dr["grade"]);
				data.exploitPointRewardId = Convert.ToInt64(dr["exploitPointRewardId"]);

				mysteryBoxGrades.Add(data);
			}
			gameDatas.mysteryBoxGrades = mysteryBoxGrades.ToArray();
			mysteryBoxGrades.Clear();

			//
			// 공적점수보상 목록
			//
			List<WPDExploitPointReward> exploitPointRewards = new List<WPDExploitPointReward>();
			foreach (DataRow dr in drcExploitPointRewards)
			{
				WPDExploitPointReward data = new WPDExploitPointReward();
				data.exploitPointRewardId = Convert.ToInt64(dr["exploitPointRewardId"]);
				data.value = Convert.ToInt32(dr["value"]);

				exploitPointRewards.Add(data);
			}
			gameDatas.exploitPointRewards = exploitPointRewards.ToArray();
			exploitPointRewards.Clear();

			//
			// 고대유물의방
			//
			WPDArtifactRoom artifactRoom = new WPDArtifactRoom();
			if (drArtifactRoom != null)
			{
				artifactRoom.nameKey = Convert.ToString(drArtifactRoom["nameKey"]);
				artifactRoom.descriptionKey = Convert.ToString(drArtifactRoom["descriptionKey"]);
				artifactRoom.targetTitleKey = Convert.ToString(drArtifactRoom["targetTitleKey"]);
				artifactRoom.targetContentKey = Convert.ToString(drArtifactRoom["targetContentKey"]);
				artifactRoom.sceneName = Convert.ToString(drArtifactRoom["sceneName"]);
				artifactRoom.requiredConditionType = Convert.ToInt32(drArtifactRoom["requiredConditionType"]);
				artifactRoom.requiredHeroLevel = Convert.ToInt32(drArtifactRoom["requiredHeroLevel"]);
				artifactRoom.requiredMainQuestNo = Convert.ToInt32(drArtifactRoom["requiredMainQuestNo"]);
				artifactRoom.limitTime = Convert.ToInt32(drArtifactRoom["limitTime"]);
				artifactRoom.continuationChallengeWaitingTime = Convert.ToInt32(drArtifactRoom["continuationChallengeWaitingTime"]);
				artifactRoom.startDelayTime = Convert.ToInt32(drArtifactRoom["startDelayTime"]);
				artifactRoom.exitDelayTime = Convert.ToInt32(drArtifactRoom["exitDelayTime"]);
				artifactRoom.startXPosition = Convert.ToSingle(drArtifactRoom["startXPosition"]);
				artifactRoom.startYPosition = Convert.ToSingle(drArtifactRoom["startYPosition"]);
				artifactRoom.startZPosition = Convert.ToSingle(drArtifactRoom["startZPosition"]);
				artifactRoom.startYRotation = Convert.ToSingle(drArtifactRoom["startYRotation"]);
				artifactRoom.locationId = Convert.ToInt32(drArtifactRoom["locationId"]);
				artifactRoom.x = Convert.ToSingle(drArtifactRoom["x"]);
				artifactRoom.z = Convert.ToSingle(drArtifactRoom["z"]);
				artifactRoom.xSize = Convert.ToSingle(drArtifactRoom["xSize"]);
				artifactRoom.zSize = Convert.ToSingle(drArtifactRoom["zSize"]);

			}
			gameDatas.artifactRoom = artifactRoom;

			//
			// 고대유물의방층 목록
			//
			List<WPDArtifactRoomFloor> artifactRoomFloors = new List<WPDArtifactRoomFloor>();
			foreach (DataRow dr in drcArtifactRoomFloors)
			{
				WPDArtifactRoomFloor data = new WPDArtifactRoomFloor();
				data.floor = Convert.ToInt32(dr["floor"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.requiredHeroLevel = Convert.ToInt32(dr["requiredHeroLevel"]);
				data.recommendBattlePower = Convert.ToInt64(dr["recommendBattlePower"]);
				data.sweepDuration = Convert.ToInt32(dr["sweepDuration"]);
				data.sweepDia = Convert.ToInt32(dr["sweepDia"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				artifactRoomFloors.Add(data);
			}
			gameDatas.artifactRoomFloors = artifactRoomFloors.ToArray();
			artifactRoomFloors.Clear();

			//
			// 오늘의미션 목록
			//
			List<WPDTodayMission> todayMissions = new List<WPDTodayMission>();
			foreach (DataRow dr in drcTodayMissions)
			{
				WPDTodayMission data = new WPDTodayMission();
				data.missionId = Convert.ToInt32(dr["missionId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.targetCount = Convert.ToInt32(dr["targetCount"]);

				todayMissions.Add(data);
			}
			gameDatas.todayMissions = todayMissions.ToArray();
			todayMissions.Clear();

			//
			// 오늘의미션보상 목록
			//
			List<WPDTodayMissionReward> todayMissionRewards = new List<WPDTodayMissionReward>();
			foreach (DataRow dr in drcTodayMissionRewards)
			{
				WPDTodayMissionReward data = new WPDTodayMissionReward();
				data.missionId = Convert.ToInt32(dr["missionId"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				todayMissionRewards.Add(data);
			}
			gameDatas.todayMissionRewards = todayMissionRewards.ToArray();
			todayMissionRewards.Clear();

			//
			// 연속미션 목록
			//
			List<WPDSeriesMission> seriesMissions = new List<WPDSeriesMission>();
			foreach (DataRow dr in drcSeriesMissions)
			{
				WPDSeriesMission data = new WPDSeriesMission();
				data.missionId = Convert.ToInt32(dr["missionId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);

				seriesMissions.Add(data);
			}
			gameDatas.seriesMissions = seriesMissions.ToArray();
			seriesMissions.Clear();

			//
			// 연속미션단계 목록
			//
			List<WPDSeriesMissionStep> seriesMissionSteps = new List<WPDSeriesMissionStep>();
			foreach (DataRow dr in drcSeriesMissionSteps)
			{
				WPDSeriesMissionStep data = new WPDSeriesMissionStep();
				data.missionId = Convert.ToInt32(dr["missionId"]);
				data.step = Convert.ToInt32(dr["step"]);
				data.targetCount = Convert.ToInt32(dr["targetCount"]);

				seriesMissionSteps.Add(data);
			}
			gameDatas.seriesMissionSteps = seriesMissionSteps.ToArray();
			seriesMissionSteps.Clear();

			//
			// 연속미션단계보상 목록
			//
			List<WPDSeriesMissionStepReward> seriesMissionStepRewards = new List<WPDSeriesMissionStepReward>();
			foreach (DataRow dr in drcSeriesMissionStepRewards)
			{
				WPDSeriesMissionStepReward data = new WPDSeriesMissionStepReward();
				data.missionId = Convert.ToInt32(dr["missionId"]);
				data.step = Convert.ToInt32(dr["step"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				seriesMissionStepRewards.Add(data);
			}
			gameDatas.seriesMissionStepRewards = seriesMissionStepRewards.ToArray();
			seriesMissionStepRewards.Clear();

			//
			// 고대인의유적
			//
			WPDAncientRelic ancientRelic = new WPDAncientRelic();
			if (drAncientRelic != null)
			{
				ancientRelic.nameKey = Convert.ToString(drAncientRelic["nameKey"]);
				ancientRelic.descriptionKey = Convert.ToString(drAncientRelic["descriptionKey"]);
				ancientRelic.sceneName = Convert.ToString(drAncientRelic["sceneName"]);
				ancientRelic.requiredConditionType = Convert.ToInt32(drAncientRelic["requiredConditionType"]);
				ancientRelic.requiredHeroLevel = Convert.ToInt32(drAncientRelic["requiredHeroLevel"]);
				ancientRelic.requiredMainQuestNo = Convert.ToInt32(drAncientRelic["requiredMainQuestNo"]);
				ancientRelic.requiredStamina = Convert.ToInt32(drAncientRelic["requiredStamina"]);
				ancientRelic.enterMinMemberCount = Convert.ToInt32(drAncientRelic["enterMinMemberCount"]);
				ancientRelic.enterMaxMemberCount = Convert.ToInt32(drAncientRelic["enterMaxMemberCount"]);
				ancientRelic.matchingWaitingTime = Convert.ToInt32(drAncientRelic["matchingWaitingTime"]);
				ancientRelic.enterWaitingTime = Convert.ToInt32(drAncientRelic["enterWaitingTime"]);
				ancientRelic.startDelayTime = Convert.ToInt32(drAncientRelic["startDelayTime"]);
				ancientRelic.limitTime = Convert.ToInt32(drAncientRelic["limitTime"]);
				ancientRelic.exitDelayTime = Convert.ToInt32(drAncientRelic["exitDelayTime"]);
				ancientRelic.waveIntervalTime = Convert.ToInt32(drAncientRelic["waveIntervalTime"]);
				ancientRelic.startXPosition = Convert.ToSingle(drAncientRelic["startXPosition"]);
				ancientRelic.startYPosition = Convert.ToSingle(drAncientRelic["startYPosition"]);
				ancientRelic.startZPosition = Convert.ToSingle(drAncientRelic["startZPosition"]);
				ancientRelic.startRadius = Convert.ToSingle(drAncientRelic["startRadius"]);
				ancientRelic.startYRotationType = Convert.ToInt32(drAncientRelic["startYRotationType"]);
				ancientRelic.startYRotation = Convert.ToSingle(drAncientRelic["startYRotation"]);
				ancientRelic.safeRevivalWaitingTime = Convert.ToInt32(drAncientRelic["safeRevivalWaitingTime"]);
				ancientRelic.trapActivateStartStep = Convert.ToInt32(drAncientRelic["trapActivateStartStep"]);
				ancientRelic.trapPenaltyMoveSpeed = Convert.ToInt32(drAncientRelic["trapPenaltyMoveSpeed"]);
				ancientRelic.trapPenaltyDuration = Convert.ToInt32(drAncientRelic["trapPenaltyDuration"]);
				ancientRelic.trapDamage = Convert.ToInt32(drAncientRelic["trapDamage"]);
				ancientRelic.locationId = Convert.ToInt32(drAncientRelic["locationId"]);
				ancientRelic.x = Convert.ToSingle(drAncientRelic["x"]);
				ancientRelic.z = Convert.ToSingle(drAncientRelic["z"]);
				ancientRelic.xSize = Convert.ToSingle(drAncientRelic["xSize"]);
				ancientRelic.zSize = Convert.ToSingle(drAncientRelic["zSize"]);
			}
			gameDatas.ancientRelic = ancientRelic;

			//
			// 고대인의유적장애물 목록
			//
			List<WPDAncientRelicObstacle> ancientRelicObstacles = new List<WPDAncientRelicObstacle>();
			foreach (DataRow dr in drcAncientRelicObstacles)
			{
				WPDAncientRelicObstacle data = new WPDAncientRelicObstacle();
				data.obstacleId = Convert.ToInt32(dr["obstacleId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);
				data.scale = Convert.ToSingle(dr["scale"]);

				ancientRelicObstacles.Add(data);
			}
			gameDatas.ancientRelicObstacles = ancientRelicObstacles.ToArray();
			ancientRelicObstacles.Clear();

			//
			// 고대인의유적획득가능보상 목록
			//
			List<WPDAncientRelicAvailableReward> ancientRelicAvailableRewards = new List<WPDAncientRelicAvailableReward>();
			foreach (DataRow dr in drcAncientRelicAvailableRewards)
			{
				WPDAncientRelicAvailableReward data = new WPDAncientRelicAvailableReward();
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);

				ancientRelicAvailableRewards.Add(data);
			}
			gameDatas.ancientRelicAvailableRewards = ancientRelicAvailableRewards.ToArray();
			ancientRelicAvailableRewards.Clear();

			//
			// 고대인의유적함정 목록
			//
			List<WPDAncientRelicTrap> ancientRelicTraps = new List<WPDAncientRelicTrap>();
			foreach (DataRow dr in drcAncientRelicTraps)
			{
				WPDAncientRelicTrap data = new WPDAncientRelicTrap();
				data.trapId = Convert.ToInt32(dr["trapId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.width = Convert.ToSingle(dr["width"]);
				data.height = Convert.ToSingle(dr["height"]);
				data.startDelayTime = Convert.ToInt32(dr["startDelayTime"]);
				data.regenInterval = Convert.ToInt32(dr["regenInterval"]);
				data.duration = Convert.ToInt32(dr["duration"]);

				ancientRelicTraps.Add(data);
			}
			gameDatas.ancientRelicTraps = ancientRelicTraps.ToArray();
			ancientRelicTraps.Clear();

			//
			// 고대인의유적단계 목록
			//
			List<WPDAncientRelicStep> ancientRelicSteps = new List<WPDAncientRelicStep>();
			foreach (DataRow dr in drcAncientRelicSteps)
			{
				WPDAncientRelicStep data = new WPDAncientRelicStep();
				data.step = Convert.ToInt32(dr["step"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);
				data.targetPoint = Convert.ToInt32(dr["targetPoint"]);
				data.guideImageName = Convert.ToString(dr["guideImageName"]);
				data.guideTitleKey = Convert.ToString(dr["guideTitleKey"]);
				data.guideContentKey = Convert.ToString(dr["guideContentKey"]);

				ancientRelicSteps.Add(data);
			}
			gameDatas.ancientRelicSteps = ancientRelicSteps.ToArray();
			ancientRelicSteps.Clear();

			//
			// 고대인의유적단계웨이브 목록
			//
			List<WPDAncientRelicStepWave> ancientRelicStepWaves = new List<WPDAncientRelicStepWave>();
			foreach (DataRow dr in drcAncientRelicStepWaves)
			{
				WPDAncientRelicStepWave data = new WPDAncientRelicStepWave();
				data.step = Convert.ToInt32(dr["step"]);
				data.waveNo = Convert.ToInt32(dr["waveNo"]);
				data.isGuideDisplay = Convert.ToBoolean(dr["isGuideDisplay"]);
				data.guideImageName = Convert.ToString(dr["guideImageName"]);
				data.guideTitleKey = Convert.ToString(dr["guideTitleKey"]);
				data.guideContentKey = Convert.ToString(dr["guideContentKey"]);

				ancientRelicStepWaves.Add(data);
			}
			gameDatas.ancientRelicStepWaves = ancientRelicStepWaves.ToArray();
			ancientRelicStepWaves.Clear();

			//
			// 고대인의유적단계이동경로 목록
			//
			List<WPDAncientRelicStepRoute> ancientRelicStepRoutes = new List<WPDAncientRelicStepRoute>();
			foreach (DataRow dr in drcAncientRelicStepRoutes)
			{
				WPDAncientRelicStepRoute data = new WPDAncientRelicStepRoute();
				data.step = Convert.ToInt32(dr["step"]);
				data.routeId = Convert.ToInt32(dr["routeId"]);
				data.targetXPosition = Convert.ToSingle(dr["targetXPosition"]);
				data.targetYPosition = Convert.ToSingle(dr["targetYPosition"]);
				data.targetZPosition = Convert.ToSingle(dr["targetZPosition"]);
				data.targetRadius = Convert.ToSingle(dr["targetRadius"]);
				data.removeObstacleId = Convert.ToInt32(dr["removeObstacleId"]);

				ancientRelicStepRoutes.Add(data);
			}
			gameDatas.ancientRelicStepRoutes = ancientRelicStepRoutes.ToArray();
			ancientRelicStepRoutes.Clear();

            //
            // TODO: 古老的废墟怪物技能激活指南列表
            //
            List<WPDAncientRelicMonsterSkillCastingGuide> ancientRelicMonsterSkillCastingGuides = new List<WPDAncientRelicMonsterSkillCastingGuide>();
            foreach (DataRow dr in drcAncientRelicMonsterSkillCastingGuides)
			{
				WPDAncientRelicMonsterSkillCastingGuide data = new WPDAncientRelicMonsterSkillCastingGuide();
				data.step = Convert.ToInt32(dr["step"]);
				data.waveNo = Convert.ToInt32(dr["waveNo"]);
				data.arrangeNo = Convert.ToInt32(dr["arrangeNo"]);
				data.monsterSkillId = Convert.ToInt32(dr["monsterSkillId"]);
				data.guideImageName = Convert.ToString(dr["guideImageName"]);
				data.guideTitleKey = Convert.ToString(dr["guideTitleKey"]);
				data.guideContentKey = Convert.ToString(dr["guideContentKey"]);

				ancientRelicMonsterSkillCastingGuides.Add(data);
			}
			gameDatas.ancientRelicMonsterSkillCastingGuides = ancientRelicMonsterSkillCastingGuides.ToArray();
			ancientRelicMonsterSkillCastingGuides.Clear();

			//
			// 오늘의할일카테고리 목록
			//
			List<WPDTodayTaskCategory> todayTaskCategories = new List<WPDTodayTaskCategory>();
			foreach (DataRow dr in drcTodayTaskCategories)
			{
				WPDTodayTaskCategory data = new WPDTodayTaskCategory();
				data.categoryId = Convert.ToInt32(dr["categoryId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);

				todayTaskCategories.Add(data);
			}
			gameDatas.todayTaskCategories = todayTaskCategories.ToArray();
			todayTaskCategories.Clear();

			//
			// 오늘의할일 목록
			//
			List<WPDTodayTask> todayTasks = new List<WPDTodayTask>();
			foreach (DataRow dr in drcTodayTasks)
			{
				WPDTodayTask data = new WPDTodayTask();
				data.taskId = Convert.ToInt32(dr["taskId"]);
				data.categoryId = Convert.ToInt32(dr["categoryId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.rewardTextKey = Convert.ToString(dr["rewardTextKey"]);
				data.eventTimeTextKey = Convert.ToString(dr["eventTimeTextKey"]);
				data.lockTextKey = Convert.ToString(dr["lockTextKey"]);
				data.rank = Convert.ToInt32(dr["rank"]);
				data.achievementPoint = Convert.ToInt32(dr["achievementPoint"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);
				data.isRecommend = Convert.ToBoolean(dr["isRecommend"]);

				todayTasks.Add(data);
			}
			gameDatas.todayTasks = todayTasks.ToArray();
			todayTasks.Clear();

			//
			// 오늘의할일획득가능보상 목록
			//
			List<WPDTodayTaskAvailableReward> todayTaskAvailableRewards = new List<WPDTodayTaskAvailableReward>();
			foreach (DataRow dr in drcTodayTaskAvailableRewards)
			{
				WPDTodayTaskAvailableReward data = new WPDTodayTaskAvailableReward();
				data.taskId = Convert.ToInt32(dr["taskId"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);

				todayTaskAvailableRewards.Add(data);
			}
			gameDatas.todayTaskAvailableRewards = todayTaskAvailableRewards.ToArray();
			todayTaskAvailableRewards.Clear();

			//
			// 달성보상 목록
			//
			List<WPDAchievementReward> achievementRewards = new List<WPDAchievementReward>();
			foreach (DataRow dr in drcAchievementRewards)
			{
				WPDAchievementReward data = new WPDAchievementReward();
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.requiredAchievementPoint = Convert.ToInt32(dr["requiredAchievementPoint"]);

				achievementRewards.Add(data);
			}
			gameDatas.achievementRewards = achievementRewards.ToArray();
			achievementRewards.Clear();

			//
			// 달성보상항목 목록
			//
			List<WPDAchievementRewardEntry> achievementRewardEntries = new List<WPDAchievementRewardEntry>();
			foreach (DataRow dr in drcAchievementRewardEntries)
			{
				WPDAchievementRewardEntry data = new WPDAchievementRewardEntry();
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.rewardEntryNo = Convert.ToInt32(dr["rewardEntryNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				achievementRewardEntries.Add(data);
			}
			gameDatas.achievementRewardEntries = achievementRewardEntries.ToArray();
			achievementRewardEntries.Clear();

			//
			// 차원잠입
			//
			WPDDimensionInfiltrationEvent dimensionInfiltrationEvent = new WPDDimensionInfiltrationEvent();
			if (drDimensionInfiltrationEvent != null)
			{
				dimensionInfiltrationEvent.startTime = Convert.ToInt32(drDimensionInfiltrationEvent["startTime"]);
				dimensionInfiltrationEvent.endTime = Convert.ToInt32(drDimensionInfiltrationEvent["endTime"]);

			}
			gameDatas.dimensionInfiltrationEvent = dimensionInfiltrationEvent;

			//
			// 차원습격퀘스트
			//
			WPDDimensionRaidQuest dimensionRaidQuest = new WPDDimensionRaidQuest();
			if (drDimensionRaidQuest != null)
			{
				dimensionRaidQuest.contentKey = Convert.ToString(drDimensionRaidQuest["contentKey"]);
				dimensionRaidQuest.requiredHeroLevel = Convert.ToInt32(drDimensionRaidQuest["requiredHeroLevel"]);
				dimensionRaidQuest.questNpcId = Convert.ToInt32(drDimensionRaidQuest["questNpcId"]);
				dimensionRaidQuest.limitCount = Convert.ToInt32(drDimensionRaidQuest["limitCount"]);
				dimensionRaidQuest.targetInteractionDuration = Convert.ToInt32(drDimensionRaidQuest["targetInteractionDuration"]);
				dimensionRaidQuest.startDialogueKey = Convert.ToString(drDimensionRaidQuest["startDialogueKey"]);
				dimensionRaidQuest.completionDialogueKey = Convert.ToString(drDimensionRaidQuest["completionDialogueKey"]);
				dimensionRaidQuest.completionTextKey = Convert.ToString(drDimensionRaidQuest["completionTextKey"]);
			}
			gameDatas.dimensionRaidQuest = dimensionRaidQuest;

			//
			// 차원습격퀘스트단계 목록
			//
			List<WPDDimensionRaidQuestStep> dimensionRaidQuestSteps = new List<WPDDimensionRaidQuestStep>();
			foreach (DataRow dr in drcDimensionRaidQuestSteps)
			{
				WPDDimensionRaidQuestStep data = new WPDDimensionRaidQuestStep();
				data.step = Convert.ToInt32(dr["step"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);
				data.targetNpcId = Convert.ToInt32(dr["targetNpcId"]);
				data.targetInteractionTextKey = Convert.ToString(dr["targetInteractionTextKey"]);

				dimensionRaidQuestSteps.Add(data);
			}
			gameDatas.dimensionRaidQuestSteps = dimensionRaidQuestSteps.ToArray();
			dimensionRaidQuestSteps.Clear();

			//
			// 차원습격퀘스트완료보상 목록
			//
			List<WPDDimensionRaidQuestReward> dimensionRaidQuestRewards = new List<WPDDimensionRaidQuestReward>();
			foreach (DataRow dr in drcDimensionRaidQuestRewards)
			{
				WPDDimensionRaidQuestReward data = new WPDDimensionRaidQuestReward();
				data.level = Convert.ToInt32(dr["level"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);
				data.exploitPointRewardId = Convert.ToInt64(dr["exploitPointRewardId"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				dimensionRaidQuestRewards.Add(data);
			}
			gameDatas.dimensionRaidQuestRewards = dimensionRaidQuestRewards.ToArray();
			dimensionRaidQuestRewards.Clear();

			//
			// 위대한성전퀘스트
			//
			WPDHolyWarQuest holyWarQuest = new WPDHolyWarQuest();
			if (drHolyWarQuest != null)
			{
				holyWarQuest.targetTitleKey = Convert.ToString(drHolyWarQuest["targetTitleKey"]);
				holyWarQuest.targetContentKey = Convert.ToString(drHolyWarQuest["targetContentKey"]);
				holyWarQuest.descriptionKey = Convert.ToString(drHolyWarQuest["descriptionKey"]);
				holyWarQuest.requiredHeroLevel = Convert.ToInt32(drHolyWarQuest["requiredHeroLevel"]);
				holyWarQuest.questNpcId = Convert.ToInt32(drHolyWarQuest["questNpcId"]);
				holyWarQuest.limitTime = Convert.ToInt32(drHolyWarQuest["limitTime"]);
				holyWarQuest.startDialogueKey = Convert.ToString(drHolyWarQuest["startDialogueKey"]);
				holyWarQuest.completionDialogueKey = Convert.ToString(drHolyWarQuest["completionDialogueKey"]);
				holyWarQuest.completionTextKey = Convert.ToString(drHolyWarQuest["completionTextKey"]);
			}
			gameDatas.holyWarQuest = holyWarQuest;

			//
			// 위대한성전퀘스트스케줄 목록
			//
			List<WPDHolyWarQuestSchedule> holyWarQuestSchedules = new List<WPDHolyWarQuestSchedule>();
			foreach (DataRow dr in drcHolyWarQuestSchedules)
			{
				WPDHolyWarQuestSchedule data = new WPDHolyWarQuestSchedule();
				data.scheduleId = Convert.ToInt32(dr["scheduleId"]);
				data.startTime = Convert.ToInt32(dr["startTime"]);
				data.endTime = Convert.ToInt32(dr["endTime"]);

				holyWarQuestSchedules.Add(data);
			}
			gameDatas.holyWarQuestSchedules = holyWarQuestSchedules.ToArray();
			holyWarQuestSchedules.Clear();

			//
			// 위대한성전퀘스트영광레벨 목록
			//
			List<WPDHolyWarQuestGloryLevel> holyWarQuestGloryLevels = new List<WPDHolyWarQuestGloryLevel>();
			foreach (DataRow dr in drcHolyWarQuestGloryLevels)
			{
				WPDHolyWarQuestGloryLevel data = new WPDHolyWarQuestGloryLevel();
				data.gloryLevel = Convert.ToInt32(dr["gloryLevel"]);
				data.requiredKillCount = Convert.ToInt32(dr["requiredKillCount"]);
				data.exploitPointRewardId = Convert.ToInt64(dr["exploitPointRewardId"]);

				holyWarQuestGloryLevels.Add(data);
			}
			gameDatas.holyWarQuestGloryLevels = holyWarQuestGloryLevels.ToArray();
			holyWarQuestGloryLevels.Clear();

			//
			// 명예점수보상 목록
			//
			List<WPDHonorPointReward> honorPointRewards = new List<WPDHonorPointReward>();
			foreach (DataRow dr in drcHonorPointRewards)
			{
				WPDHonorPointReward data = new WPDHonorPointReward();
				data.honorPointRewardId = Convert.ToInt64(dr["honorPointRewardId"]);
				data.value = Convert.ToInt32(dr["value"]);

				honorPointRewards.Add(data);
			}
			gameDatas.honorPointRewards = honorPointRewards.ToArray();
			honorPointRewards.Clear();

			//
			// 결투장
			//
			WPDFieldOfHonor fieldOfHonor = new WPDFieldOfHonor();
			if (drFieldOfHonor != null)
			{
				fieldOfHonor.nameKey = Convert.ToString(drFieldOfHonor["nameKey"]);
				fieldOfHonor.descriptionKey = Convert.ToString(drFieldOfHonor["descriptionKey"]);
				fieldOfHonor.targetTitleKey = Convert.ToString(drFieldOfHonor["targetTitleKey"]);
				fieldOfHonor.targetContentKey = Convert.ToString(drFieldOfHonor["targetContentKey"]);
				fieldOfHonor.sceneName = Convert.ToString(drFieldOfHonor["sceneName"]);
				fieldOfHonor.requiredConditionType = Convert.ToInt32(drFieldOfHonor["requiredConditionType"]);
				fieldOfHonor.requiredHeroLevel = Convert.ToInt32(drFieldOfHonor["requiredHeroLevel"]);
				fieldOfHonor.requiredMainQuestNo = Convert.ToInt32(drFieldOfHonor["requiredMainQuestNo"]);
				fieldOfHonor.startDelayTime = Convert.ToInt32(drFieldOfHonor["startDelayTime"]);
				fieldOfHonor.limitTime = Convert.ToInt32(drFieldOfHonor["limitTime"]);
				fieldOfHonor.exitDelayTime = Convert.ToInt32(drFieldOfHonor["exitDelayTime"]);
				fieldOfHonor.startXPosition = Convert.ToSingle(drFieldOfHonor["startXPosition"]);
				fieldOfHonor.startYPosition = Convert.ToSingle(drFieldOfHonor["startYPosition"]);
				fieldOfHonor.startZPosition = Convert.ToSingle(drFieldOfHonor["startZPosition"]);
				fieldOfHonor.startYRotation = Convert.ToSingle(drFieldOfHonor["startYRotation"]);
				fieldOfHonor.targetXPosition = Convert.ToSingle(drFieldOfHonor["targetXPosition"]);
				fieldOfHonor.targetYPosition = Convert.ToSingle(drFieldOfHonor["targetYPosition"]);
				fieldOfHonor.targetZPosition = Convert.ToSingle(drFieldOfHonor["targetZPosition"]);
				fieldOfHonor.targetYRotation = Convert.ToSingle(drFieldOfHonor["targetYRotation"]);
				fieldOfHonor.winnerHonorPointRewardId = Convert.ToInt64(drFieldOfHonor["winnerHonorPointRewardId"]);
				fieldOfHonor.loserHonorPointRewardId = Convert.ToInt64(drFieldOfHonor["loserHonorPointRewardId"]);
				fieldOfHonor.locationId = Convert.ToInt32(drFieldOfHonor["locationId"]);
				fieldOfHonor.x = Convert.ToSingle(drFieldOfHonor["x"]);
				fieldOfHonor.z = Convert.ToSingle(drFieldOfHonor["z"]);
				fieldOfHonor.xSize = Convert.ToSingle(drFieldOfHonor["xSize"]);
				fieldOfHonor.zSize = Convert.ToSingle(drFieldOfHonor["zSize"]);

			}
			gameDatas.fieldOfHonor = fieldOfHonor;

			//
			// 결투장랭킹보상 목록
			//
			List<WPDFieldOfHonorRankingReward> fieldOfHonorRankingRewards = new List<WPDFieldOfHonorRankingReward>();
			foreach (DataRow dr in drcFieldOfHonorRankingRewards)
			{
				WPDFieldOfHonorRankingReward data = new WPDFieldOfHonorRankingReward();
				data.highRanking = Convert.ToInt32(dr["highRanking"]);
				data.lowRanking = Convert.ToInt32(dr["lowRanking"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				fieldOfHonorRankingRewards.Add(data);
			}
			gameDatas.fieldOfHonorRankingRewards = fieldOfHonorRankingRewards.ToArray();
			fieldOfHonorRankingRewards.Clear();

			//
			// 명예상점상품 목록
			//
			List<WPDHonorShopProduct> honorShopProducts = new List<WPDHonorShopProduct>();
			foreach (DataRow dr in drcHonorShopProducts)
			{
				WPDHonorShopProduct data = new WPDHonorShopProduct();
				data.productId = Convert.ToInt32(dr["productId"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);
				data.itemOwned = Convert.ToBoolean(dr["itemOwned"]);
				data.requiredHonorPoint = Convert.ToInt32(dr["requiredHonorPoint"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);

				honorShopProducts.Add(data);
			}
			gameDatas.honorShopProducts = honorShopProducts.ToArray();
			honorShopProducts.Clear();

			//
			// 계급 목록
			//
			List<WPDRank> ranks = new List<WPDRank>();
			foreach (DataRow dr in drcRanks)
			{
				WPDRank data = new WPDRank();
				data.rankNo = Convert.ToInt32(dr["rankNo"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.colorCode = Convert.ToString(dr["colorCode"]);
				data.requiredExploitPoint = Convert.ToInt32(dr["requiredExploitPoint"]);
				data.goldRewardId = Convert.ToInt64(dr["goldRewardId"]);

				ranks.Add(data);
			}
			gameDatas.ranks = ranks.ToArray();
			ranks.Clear();

			//
			// 계급속성 목록
			//
			List<WPDRankAttr> rankAttrs = new List<WPDRankAttr>();
			foreach (DataRow dr in drcRankAttrs)
			{
				WPDRankAttr data = new WPDRankAttr();
				data.rankNo = Convert.ToInt32(dr["rankNo"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);

				rankAttrs.Add(data);
			}
			gameDatas.rankAttrs = rankAttrs.ToArray();
			rankAttrs.Clear();

			//
			// 계급보상 목록
			//
			List<WPDRankReward> rankRewards = new List<WPDRankReward>();
			foreach (DataRow dr in drcRankRewards)
			{
				WPDRankReward data = new WPDRankReward();
				data.rankNo = Convert.ToInt32(dr["rankNo"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				rankRewards.Add(data);
			}
			gameDatas.rankRewards = rankRewards.ToArray();
			rankRewards.Clear();

			//
			// 전장지원이벤트
			//
			WPDBattlefieldSupportEvent battlefieldSupportEvent = new WPDBattlefieldSupportEvent();
			if (drBattlefieldSupportEvent != null)
			{
				battlefieldSupportEvent.startTime = Convert.ToInt32(drBattlefieldSupportEvent["startTime"]);
				battlefieldSupportEvent.endTime = Convert.ToInt32(drBattlefieldSupportEvent["endTime"]);

			}
			gameDatas.battlefieldSupportEvent = battlefieldSupportEvent;

			//
			// 레벨랭킹보상 목록
			//
			List<WPDLevelRankingReward> levelRankingRewards = new List<WPDLevelRankingReward>();
			foreach (DataRow dr in drcLevelRankingRewards)
			{
				WPDLevelRankingReward data = new WPDLevelRankingReward();
				data.highRanking = Convert.ToInt32(dr["highRanking"]);
				data.lowRanking = Convert.ToInt32(dr["lowRanking"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				levelRankingRewards.Add(data);
			}
			gameDatas.levelRankingRewards = levelRankingRewards.ToArray();
			levelRankingRewards.Clear();

            //
            // TODO: 内容开放清单
            //
            List<WPDContentOpenEntry> contentOpenEntries = new List<WPDContentOpenEntry>();
            foreach (DataRow dr in drcContentOpenEntries)
			{
				WPDContentOpenEntry data = new WPDContentOpenEntry();
				data.entryId = Convert.ToInt32(dr["entryId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.requiredHeroLevel = Convert.ToInt32(dr["requiredHeroLevel"]);
				data.requiredMainQuestNo = Convert.ToInt32(dr["requiredMainQuestNo"]);
				data.isDisplay = Convert.ToBoolean(dr["isDisplay"]);

				contentOpenEntries.Add(data);
			}
			gameDatas.contentOpenEntries = contentOpenEntries.ToArray();
			contentOpenEntries.Clear();

			//
			// 도달항목 목록
			//
			List<WPDAttainmentEntry> attainmentEntries = new List<WPDAttainmentEntry>();
			foreach (DataRow dr in drcAttainmentEntries)
			{
				WPDAttainmentEntry data = new WPDAttainmentEntry();
				data.entryNo = Convert.ToInt32(dr["entryNo"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.requiredHeroLevel = Convert.ToInt32(dr["requiredHeroLevel"]);
				data.requiredMainQuestNo = Convert.ToInt32(dr["requiredMainQuestNo"]);

				attainmentEntries.Add(data);
			}
			gameDatas.attainmentEntries = attainmentEntries.ToArray();
			attainmentEntries.Clear();

			//
			// 도달항목보상 목록
			//
			List<WPDAttainmentEntryReward> attainmentEntryRewards = new List<WPDAttainmentEntryReward>();
			foreach (DataRow dr in drcAttainmentEntryRewards)
			{
				WPDAttainmentEntryReward data = new WPDAttainmentEntryReward();
				data.entryNo = Convert.ToInt32(dr["entryNo"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.mainGearId = Convert.ToInt32(dr["mainGearId"]);
				data.mainGearOwned = Convert.ToBoolean(dr["mainGearOwned"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				attainmentEntryRewards.Add(data);
			}
			gameDatas.attainmentEntryRewards = attainmentEntryRewards.ToArray();
			attainmentEntryRewards.Clear();

			//
			// 메뉴 목록
			//
			List<WPDMenu> menus = new List<WPDMenu>();
			foreach (DataRow dr in drcMenus)
			{
				WPDMenu data = new WPDMenu();
				data.menuId = Convert.ToInt32(dr["menuId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.imageName = Convert.ToString(dr["imageName"]);
				data.requiredHeroLevel = Convert.ToInt32(dr["requiredHeroLevel"]);
				data.requiredMainQuestNo = Convert.ToInt32(dr["requiredMainQuestNo"]);
				data.menuGroup = Convert.ToInt32(dr["menuGroup"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);

				menus.Add(data);
			}
			gameDatas.menus = menus.ToArray();
			menus.Clear();

			//
			// 메뉴컨텐츠 목록
			//
			List<WPDMenuContent> menuContents = new List<WPDMenuContent>();
			foreach (DataRow dr in drcMenuContents)
			{
				WPDMenuContent data = new WPDMenuContent();
				data.contentId = Convert.ToInt32(dr["contentId"]);
				data.menuId = Convert.ToInt32(dr["menuId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.imageName = Convert.ToString(dr["imageName"]);
				data.requiredHeroLevel = Convert.ToInt32(dr["requiredHeroLevel"]);
				data.requiredMainQuestNo = Convert.ToInt32(dr["requiredMainQuestNo"]);
				data.isDisplay = Convert.ToBoolean(dr["isDisplay"]);

				menuContents.Add(data);
			}
			gameDatas.menuContents = menuContents.ToArray();
			menuContents.Clear();

			//
			// 길드레벨 목록
			//
			List<WPDGuildLevel> guildLevels = new List<WPDGuildLevel>();
			foreach (DataRow dr in drcGuildLevels)
			{
				WPDGuildLevel data = new WPDGuildLevel();
				data.level = Convert.ToInt32(dr["level"]);
				data.maxMemberCount = Convert.ToInt32(dr["maxMemberCount"]);
				data.dailyItemRewardId = Convert.ToInt64(dr["dailyItemRewardId"]);
				data.altarItemRewardId = Convert.ToInt64(dr["altarItemRewardId"]);

				guildLevels.Add(data);
			}
			gameDatas.guildLevels = guildLevels.ToArray();
			guildLevels.Clear();

			//
			// 길드멤버등급 목록
			//
			List<WPDGuildMemberGrade> guildMemberGrades = new List<WPDGuildMemberGrade>();
			foreach (DataRow dr in drcGuildMemberGrades)
			{
				WPDGuildMemberGrade data = new WPDGuildMemberGrade();
				data.memberGrade = Convert.ToInt32(dr["memberGrade"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.invitationEnabled = Convert.ToBoolean(dr["invitationEnabled"]);
				data.applicationAcceptanceEnabled = Convert.ToBoolean(dr["applicationAcceptanceEnabled"]);
				data.guildFoodWarehouseRewardCollectionEnabled = Convert.ToBoolean(dr["guildFoodWarehouseRewardCollectionEnabled"]);
				data.guildSupplySupportQuestEnabled = Convert.ToBoolean(dr["guildSupplySupportQuestEnabled"]);
				data.guildBuildingLevelUpEnabled = Convert.ToBoolean(dr["guildBuildingLevelUpEnabled"]);
				data.guildCallEnabled = Convert.ToBoolean(dr["guildCallEnabled"]);
				data.weeklyObjectiveSettingEnabled = Convert.ToBoolean(dr["weeklyObjectiveSettingEnabled"]);
				data.guildBlessingBuffEnabled = Convert.ToBoolean(dr["guildBlessingBuffEnabled"]);

				guildMemberGrades.Add(data);
			}
			gameDatas.guildMemberGrades = guildMemberGrades.ToArray();
			guildMemberGrades.Clear();

			//
			// 보급지원퀘스트
			//
			WPDSupplySupportQuest supplySupportQuest = new WPDSupplySupportQuest();
			if (drSupplySupportQuest != null)
			{
				supplySupportQuest.targetTitleKey = Convert.ToString(drSupplySupportQuest["targetTitleKey"]);
				supplySupportQuest.targetContentKey = Convert.ToString(drSupplySupportQuest["targetContentKey"]);
				supplySupportQuest.requiredHeroLevel = Convert.ToInt32(drSupplySupportQuest["requiredHeroLevel"]);
				supplySupportQuest.startNpcId = Convert.ToInt32(drSupplySupportQuest["startNpcId"]);
				supplySupportQuest.completionNpcId = Convert.ToInt32(drSupplySupportQuest["completionNpcId"]);
				supplySupportQuest.limitCount = Convert.ToInt32(drSupplySupportQuest["limitCount"]);
				supplySupportQuest.guaranteeGold = Convert.ToInt32(drSupplySupportQuest["guaranteeGold"]);
				supplySupportQuest.limitTime = Convert.ToInt32(drSupplySupportQuest["limitTime"]);
				supplySupportQuest.startDialogueKey = Convert.ToString(drSupplySupportQuest["startDialogueKey"]);
				supplySupportQuest.completionDialogueKey = Convert.ToString(drSupplySupportQuest["completionDialogueKey"]);
				supplySupportQuest.completionTextKey = Convert.ToString(drSupplySupportQuest["completionTextKey"]);
				supplySupportQuest.failGuideImageName = Convert.ToString(drSupplySupportQuest["failGuideImageName"]);
				supplySupportQuest.failGuideTitleKey = Convert.ToString(drSupplySupportQuest["failGuideTitleKey"]);
				supplySupportQuest.failGuideContentKey = Convert.ToString(drSupplySupportQuest["failGuideContentKey"]);
			}
			gameDatas.supplySupportQuest = supplySupportQuest;

			//
			// 보급지원퀘스트지령 목록
			//
			List<WPDSupplySupportQuestOrder> supplySupportQuestOrders = new List<WPDSupplySupportQuestOrder>();
			foreach (DataRow dr in drcSupplySupportQuestOrders)
			{
				WPDSupplySupportQuestOrder data = new WPDSupplySupportQuestOrder();
				data.orderId = Convert.ToInt32(dr["orderId"]);
				data.orderItemId = Convert.ToInt32(dr["orderItemId"]);
				data.failRefundGoldRewardId = Convert.ToInt64(dr["failRefundGoldRewardId"]);

				supplySupportQuestOrders.Add(data);
			}
			gameDatas.supplySupportQuestOrders = supplySupportQuestOrders.ToArray();
			supplySupportQuestOrders.Clear();

			//
			// 보급지원퀘스트중간지점 목록
			//
			List<WPDSupplySupportQuestWayPoint> supplySupportQuestWayPoints = new List<WPDSupplySupportQuestWayPoint>();
			foreach (DataRow dr in drcSupplySupportQuestWayPoints)
			{
				WPDSupplySupportQuestWayPoint data = new WPDSupplySupportQuestWayPoint();
				data.wayPoint = Convert.ToInt32(dr["wayPoint"]);
				data.cartChangeNpcId = Convert.ToInt32(dr["cartChangeNpcId"]);

				supplySupportQuestWayPoints.Add(data);
			}
			gameDatas.supplySupportQuestWayPoints = supplySupportQuestWayPoints.ToArray();
			supplySupportQuestWayPoints.Clear();

			//
			// 보급지원퀘스트수레 목록
			//
			List<WPDSupplySupportQuestCart> supplySupportQuestCarts = new List<WPDSupplySupportQuestCart>();
			foreach (DataRow dr in drcSupplySupportQuestCarts)
			{
				WPDSupplySupportQuestCart data = new WPDSupplySupportQuestCart();
				data.cartId = Convert.ToInt32(dr["cartId"]);
				data.destructionItemRewardId = Convert.ToInt64(dr["destructionItemRewardId"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);

				supplySupportQuestCarts.Add(data);
			}
			gameDatas.supplySupportQuestCarts = supplySupportQuestCarts.ToArray();
			supplySupportQuestCarts.Clear();

			//
			// 위대한성전퀘스트보상 목록
			//
			List<WPDHolyWarQuestReward> holyWarQuestRewards = new List<WPDHolyWarQuestReward>();
			foreach (DataRow dr in drcHolyWarQuestRewards)
			{
				WPDHolyWarQuestReward data = new WPDHolyWarQuestReward();
				data.level = Convert.ToInt32(dr["level"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);

				holyWarQuestRewards.Add(data);
			}
			gameDatas.holyWarQuestRewards = holyWarQuestRewards.ToArray();
			holyWarQuestRewards.Clear();

			//
			// 보급지원퀘스트보상 목록
			//
			List<WPDSupplySupportQuestReward> supplySupportQuestRewards = new List<WPDSupplySupportQuestReward>();
			foreach (DataRow dr in drcSupplySupportQuestRewards)
			{
				WPDSupplySupportQuestReward data = new WPDSupplySupportQuestReward();
				data.cartId = Convert.ToInt32(dr["cartId"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);
				data.goldRewardId = Convert.ToInt64(dr["goldRewardId"]);
				data.exploitPointRewardId = Convert.ToInt64(dr["exploitPointRewardId"]);

				supplySupportQuestRewards.Add(data);
			}
			gameDatas.supplySupportQuestRewards = supplySupportQuestRewards.ToArray();
			supplySupportQuestRewards.Clear();

			//
			// 국가기부항목 목록
			//
			List<WPDNationDonationEntry> nationDonationEntries = new List<WPDNationDonationEntry>();
			foreach (DataRow dr in drcNationDonationEntries)
			{
				WPDNationDonationEntry data = new WPDNationDonationEntry();
				data.entryId = Convert.ToInt32(dr["entryId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.moneyType = Convert.ToInt32(dr["moneyType"]);
				data.moneyAmount = Convert.ToInt64(dr["moneyAmount"]);
				data.exploitPointRewardId = Convert.ToInt64(dr["exploitPointRewardId"]);
				data.nationFundRewardId = Convert.ToInt64(dr["nationFundRewardId"]);

				nationDonationEntries.Add(data);
			}
			gameDatas.nationDonationEntries = nationDonationEntries.ToArray();
			nationDonationEntries.Clear();

			//
			// 국가관직 목록
			//
			List<WPDNationNoblesse> nationNoblesses = new List<WPDNationNoblesse>();
			foreach (DataRow dr in drcNationNoblesses)
			{
				WPDNationNoblesse data = new WPDNationNoblesse();
				data.noblesseId = Convert.ToInt32(dr["noblesseId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.nationWarDeclarationEnabled = Convert.ToBoolean(dr["nationWarDeclarationEnabled"]);
				data.nationCallEnabled = Convert.ToBoolean(dr["nationCallEnabled"]);
				data.nationWarCallEnabled = Convert.ToBoolean(dr["nationWarCallEnabled"]);
				data.nationWarConvergingAttackEnabled = Convert.ToBoolean(dr["nationWarConvergingAttackEnabled"]);
				data.nationAllianceEnabled = Convert.ToBoolean(dr["nationAllianceEnabled"]);

				nationNoblesses.Add(data);
			}
			gameDatas.nationNoblesses = nationNoblesses.ToArray();
			nationNoblesses.Clear();

			//
			// 국가관직속성 목록
			//
			List<WPDNationNoblesseAttr> nationNoblesseAttrs = new List<WPDNationNoblesseAttr>();
			foreach (DataRow dr in drcNationNoblesseAttrs)
			{
				WPDNationNoblesseAttr data = new WPDNationNoblesseAttr();
				data.noblesseId = Convert.ToInt32(dr["noblesseId"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);

				nationNoblesseAttrs.Add(data);
			}
			gameDatas.nationNoblesseAttrs = nationNoblesseAttrs.ToArray();
			nationNoblesseAttrs.Clear();

			//
			// 국고자금보상 목록
			//
			List<WPDNationFundReward> nationFundRewards = new List<WPDNationFundReward>();
			foreach (DataRow dr in drcNationFundRewards)
			{
				WPDNationFundReward data = new WPDNationFundReward();
				data.nationFundRewardId = Convert.ToInt64(dr["nationFundRewardId"]);
				data.value = Convert.ToInt32(dr["value"]);

				nationFundRewards.Add(data);
			}
			gameDatas.nationFundRewards = nationFundRewards.ToArray();
			nationFundRewards.Clear();

			//
			// 길드공헌점수보상 목록
			//
			List<WPDGuildContributionPointReward> guildContributionPointRewards = new List<WPDGuildContributionPointReward>();
			foreach (DataRow dr in drcGuildContributionPointRewards)
			{
				WPDGuildContributionPointReward data = new WPDGuildContributionPointReward();
				data.guildContributionPointRewardId = Convert.ToInt64(dr["guildContributionPointRewardId"]);
				data.value = Convert.ToInt32(dr["value"]);

				guildContributionPointRewards.Add(data);
			}
			gameDatas.guildContributionPointRewards = guildContributionPointRewards.ToArray();
			guildContributionPointRewards.Clear();

			//
			// 길드건설점수보상 목록
			//
			List<WPDGuildBuildingPointReward> guildBuildingPointRewards = new List<WPDGuildBuildingPointReward>();
			foreach (DataRow dr in drcGuildBuildingPointRewards)
			{
				WPDGuildBuildingPointReward data = new WPDGuildBuildingPointReward();
				data.guildBuildingPointRewardId = Convert.ToInt64(dr["guildBuildingPointRewardId"]);
				data.value = Convert.ToInt32(dr["value"]);

				guildBuildingPointRewards.Add(data);
			}
			gameDatas.guildBuildingPointRewards = guildBuildingPointRewards.ToArray();
			guildBuildingPointRewards.Clear();

			//
			// 길드자금보상 목록
			//
			List<WPDGuildFundReward> guildFundRewards = new List<WPDGuildFundReward>();
			foreach (DataRow dr in drcGuildFundRewards)
			{
				WPDGuildFundReward data = new WPDGuildFundReward();
				data.guildFundRewardId = Convert.ToInt64(dr["guildFundRewardId"]);
				data.value = Convert.ToInt32(dr["value"]);

				guildFundRewards.Add(data);
			}
			gameDatas.guildFundRewards = guildFundRewards.ToArray();
			guildFundRewards.Clear();

			//
			// 길드점수보상 목록
			//
			List<WPDGuildPointReward> guildPointRewards = new List<WPDGuildPointReward>();
			foreach (DataRow dr in drcGuildPointRewards)
			{
				WPDGuildPointReward data = new WPDGuildPointReward();
				data.guildPointRewardId = Convert.ToInt64(dr["guildPointRewardId"]);
				data.value = Convert.ToInt32(dr["value"]);

				guildPointRewards.Add(data);
			}
			gameDatas.guildPointRewards = guildPointRewards.ToArray();
			guildPointRewards.Clear();

			//
			// 길드기부항목 목록
			//
			List<WPDGuildDonationEntry> guildDonationEntries = new List<WPDGuildDonationEntry>();
			foreach (DataRow dr in drcGuildDonationEntries)
			{
				WPDGuildDonationEntry data = new WPDGuildDonationEntry();
				data.entryId = Convert.ToInt32(dr["entryId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.moneyType = Convert.ToInt32(dr["moneyType"]);
				data.moneyAmount = Convert.ToInt64(dr["moneyAmount"]);
				data.guildContributionPointRewardId = Convert.ToInt64(dr["guildContributionPointRewardId"]);
				data.guildFundRewardId = Convert.ToInt64(dr["guildFundRewardId"]);

				guildDonationEntries.Add(data);
			}
			gameDatas.guildDonationEntries = guildDonationEntries.ToArray();
			guildDonationEntries.Clear();

			//
			// 국가전
			//
			WPDNationWar nationWar = new WPDNationWar();
			if (drNationWar != null)
			{
				nationWar.declarationAvailableServerOpenDayCount = Convert.ToInt32(drNationWar["declarationAvailableServerOpenDayCount"]);
				nationWar.declarationStartTime = Convert.ToInt32(drNationWar["declarationStartTime"]);
				nationWar.declarationEndTime = Convert.ToInt32(drNationWar["declarationEndTime"]);
				nationWar.declarationRequiredNationFund = Convert.ToInt32(drNationWar["declarationRequiredNationFund"]);
				nationWar.weeklyDeclarationMaxCount = Convert.ToInt32(drNationWar["weeklyDeclarationMaxCount"]);
				nationWar.startTime = Convert.ToInt32(drNationWar["startTime"]);
				nationWar.endTime = Convert.ToInt32(drNationWar["endTime"]);
				nationWar.resultDisplayEndTime = Convert.ToInt32(drNationWar["resultDisplayEndTime"]);
				nationWar.joinPopupDisplayDuration = Convert.ToInt32(drNationWar["joinPopupDisplayDuration"]);
				nationWar.offenseStartContinentId = Convert.ToInt32(drNationWar["offenseStartContinentId"]);
				nationWar.offenseStartXPosition = Convert.ToSingle(drNationWar["offenseStartXPosition"]);
				nationWar.offenseStartYPosition = Convert.ToSingle(drNationWar["offenseStartYPosition"]);
				nationWar.offenseStartZPosition = Convert.ToSingle(drNationWar["offenseStartZPosition"]);
				nationWar.offenseStartYRotationType = Convert.ToInt32(drNationWar["offenseStartYRotationType"]);
				nationWar.offenseStartYRotation = Convert.ToSingle(drNationWar["offenseStartYRotation"]);
				nationWar.offenseStartRadius = Convert.ToSingle(drNationWar["offenseStartRadius"]);
				nationWar.defenseStartContinentId = Convert.ToInt32(drNationWar["defenseStartContinentId"]);
				nationWar.defenseStartXPosition = Convert.ToSingle(drNationWar["defenseStartXPosition"]);
				nationWar.defenseStartYPosition = Convert.ToSingle(drNationWar["defenseStartYPosition"]);
				nationWar.defenseStartZPosition = Convert.ToSingle(drNationWar["defenseStartZPosition"]);
				nationWar.defenseStartYRotationType = Convert.ToInt32(drNationWar["defenseStartYRotationType"]);
				nationWar.defenseStartYRotation = Convert.ToSingle(drNationWar["defenseStartYRotation"]);
				nationWar.defenseStartRadius = Convert.ToSingle(drNationWar["defenseStartRadius"]);
				nationWar.freeTransmissionCount = Convert.ToInt32(drNationWar["freeTransmissionCount"]);
				nationWar.nationCallCount = Convert.ToInt32(drNationWar["nationCallCount"]);
				nationWar.nationCallCoolTime = Convert.ToInt32(drNationWar["nationCallCoolTime"]);
				nationWar.nationCallLifetime = Convert.ToInt32(drNationWar["nationCallLifetime"]);
				nationWar.nationCallRadius = Convert.ToSingle(drNationWar["nationCallRadius"]);
				nationWar.convergingAttackCount = Convert.ToInt32(drNationWar["convergingAttackCount"]);
				nationWar.convergingAttackCoolTime = Convert.ToInt32(drNationWar["convergingAttackCoolTime"]);
				nationWar.convergingAttackLifetime = Convert.ToInt32(drNationWar["convergingAttackLifetime"]);
				nationWar.winNationItemRewardId1 = Convert.ToInt64(drNationWar["winNationItemRewardId1"]);
				nationWar.winNationItemRewardId2 = Convert.ToInt64(drNationWar["winNationItemRewardId2"]);
				nationWar.winNationAllianceItemRewardId = Convert.ToInt64(drNationWar["winNationAllianceItemRewardId"]);
				nationWar.loseNationItemRewardId1 = Convert.ToInt64(drNationWar["loseNationItemRewardId1"]);
				nationWar.loseNationItemRewardId2 = Convert.ToInt64(drNationWar["loseNationItemRewardId2"]);
				nationWar.loseNationAllianceItemRewardId = Convert.ToInt64(drNationWar["loseNationAllianceItemRewardId"]);
				nationWar.winNationExploitPointRewardId = Convert.ToInt64(drNationWar["winNationExploitPointRewardId"]);
				nationWar.loseNationExploitPointRewardId = Convert.ToInt64(drNationWar["loseNationExploitPointRewardId"]);

			}
			gameDatas.nationWar = nationWar;

			//
			// 국가전가능요일 목록
			//
			List<WPDNationWarAvailableDayOfWeek> nationWarAvailableDayOfWeeks = new List<WPDNationWarAvailableDayOfWeek>();
			foreach (DataRow dr in drcNationWarAvailableDayOfWeeks)
			{
				WPDNationWarAvailableDayOfWeek data = new WPDNationWarAvailableDayOfWeek();
				data.dayOfWeek = Convert.ToInt32(dr["dayOfWeek"]);

				nationWarAvailableDayOfWeeks.Add(data);
			}
			gameDatas.nationWarAvailableDayOfWeeks = nationWarAvailableDayOfWeeks.ToArray();
			nationWarAvailableDayOfWeeks.Clear();

			//
			// 국가전부활포인트 목록
			//
			List<WPDNationWarRevivalPoint> nationWarRevivalPoints = new List<WPDNationWarRevivalPoint>();
			foreach (DataRow dr in drcNationWarRevivalPoints)
			{
				WPDNationWarRevivalPoint data = new WPDNationWarRevivalPoint();
				data.revivalPointId = Convert.ToInt32(dr["revivalPointId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.continentId = Convert.ToInt32(dr["continentId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.radius = Convert.ToSingle(dr["radius"]);
				data.yRotationType = Convert.ToInt32(dr["yRotationType"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);
				data.priority = Convert.ToInt32(dr["priority"]);

				nationWarRevivalPoints.Add(data);
			}
			gameDatas.nationWarRevivalPoints = nationWarRevivalPoints.ToArray();
			nationWarRevivalPoints.Clear();

			//
			// 국가전부활포인트활성조건 목록
			//
			List<WPDNationWarRevivalPointActivationCondition> nationWarRevivalPointActivationConditions = new List<WPDNationWarRevivalPointActivationCondition>();
			foreach (DataRow dr in drcNationWarRevivalPointActivationConditions)
			{
				WPDNationWarRevivalPointActivationCondition data = new WPDNationWarRevivalPointActivationCondition();
				data.revivalPointId = Convert.ToInt32(dr["revivalPointId"]);
				data.arrangeId = Convert.ToInt32(dr["arrangeId"]);

				nationWarRevivalPointActivationConditions.Add(data);
			}
			gameDatas.nationWarRevivalPointActivationConditions = nationWarRevivalPointActivationConditions.ToArray();
			nationWarRevivalPointActivationConditions.Clear();

			//
			// 국가전몬스터배치 목록
			//
			List<WPDNationWarMonsterArrange> nationWarMonsterArranges = new List<WPDNationWarMonsterArrange>();
			foreach (DataRow dr in drcNationWarMonsterArranges)
			{
				WPDNationWarMonsterArrange data = new WPDNationWarMonsterArrange();
				data.arrangeId = Convert.ToInt32(dr["arrangeId"]);
				data.monsterArrangeId = Convert.ToInt64(dr["monsterArrangeId"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.continentId = Convert.ToInt32(dr["continentId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);
				data.nationWarNpcId = Convert.ToInt32(dr["nationWarNpcId"]);
				data.regenTime = Convert.ToInt32(dr["regenTime"]);
				data.transmissionXPosition = Convert.ToSingle(dr["transmissionXPosition"]);
				data.transmissionYPosition = Convert.ToSingle(dr["transmissionYPosition"]);
				data.transmissionZPosition = Convert.ToSingle(dr["transmissionZPosition"]);
				data.transmissionRadius = Convert.ToSingle(dr["transmissionRadius"]);
				data.transmissionYRotationType = Convert.ToInt32(dr["transmissionYRotationType"]);
				data.transmissionYRotation = Convert.ToSingle(dr["transmissionYRotation"]);

				nationWarMonsterArranges.Add(data);
			}
			gameDatas.nationWarMonsterArranges = nationWarMonsterArranges.ToArray();
			nationWarMonsterArranges.Clear();

			//
			// 국가전NPC 목록
			//
			List<WPDNationWarNpc> nationWarNpcs = new List<WPDNationWarNpc>();
			foreach (DataRow dr in drcNationWarNpcs)
			{
				WPDNationWarNpc data = new WPDNationWarNpc();
				data.npcId = Convert.ToInt32(dr["npcId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.nickKey = Convert.ToString(dr["nickKey"]);
				data.dialogueKey = Convert.ToString(dr["dialogueKey"]);
				data.continentId = Convert.ToInt32(dr["continentId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);
				data.interactionMaxRange = Convert.ToSingle(dr["interactionMaxRange"]);
				data.prefabName = Convert.ToString(dr["prefabName"]);
				data.scale = Convert.ToSingle(dr["scale"]);
				data.height = Convert.ToInt32(dr["height"]);
				data.radius = Convert.ToSingle(dr["radius"]);

				nationWarNpcs.Add(data);
			}
			gameDatas.nationWarNpcs = nationWarNpcs.ToArray();
			nationWarNpcs.Clear();

			//
			// 국가전전송출구 목록
			//
			List<WPDNationWarTransmissionExit> nationWarTransmissionExits = new List<WPDNationWarTransmissionExit>();
			foreach (DataRow dr in drcNationWarTransmissionExits)
			{
				WPDNationWarTransmissionExit data = new WPDNationWarTransmissionExit();
				data.npcId = Convert.ToInt32(dr["npcId"]);
				data.exitNo = Convert.ToInt32(dr["exitNo"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.continentId = Convert.ToInt32(dr["continentId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.radius = Convert.ToSingle(dr["radius"]);
				data.yRotationType = Convert.ToInt32(dr["yRotationType"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);

				nationWarTransmissionExits.Add(data);
			}
			gameDatas.nationWarTransmissionExits = nationWarTransmissionExits.ToArray();
			nationWarTransmissionExits.Clear();

			//
			// 국가전유료전송 목록
			//
			List<WPDNationWarPaidTransmission> nationWarPaidTransmissions = new List<WPDNationWarPaidTransmission>();
			foreach (DataRow dr in drcNationWarPaidTransmissions)
			{
				WPDNationWarPaidTransmission data = new WPDNationWarPaidTransmission();
				data.transmissionCount = Convert.ToInt32(dr["transmissionCount"]);
				data.requiredDia = Convert.ToInt32(dr["requiredDia"]);

				nationWarPaidTransmissions.Add(data);
			}
			gameDatas.nationWarPaidTransmissions = nationWarPaidTransmissions.ToArray();
			nationWarPaidTransmissions.Clear();

			//
			// 국가전영웅목표항목 목록
			//
			List<WPDNationWarHeroObjectiveEntry> nationWarHeroObjectiveEntries = new List<WPDNationWarHeroObjectiveEntry>();
			foreach (DataRow dr in drcNationWarHeroObjectiveEntries)
			{
				WPDNationWarHeroObjectiveEntry data = new WPDNationWarHeroObjectiveEntry();
				data.entryNo = Convert.ToInt32(dr["entryNo"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.objectiveCount = Convert.ToInt32(dr["objectiveCount"]);
				data.rewardType = Convert.ToInt32(dr["rewardType"]);
				data.ownDiaRewardId = Convert.ToInt64(dr["ownDiaRewardId"]);
				data.exploitPointRewardId = Convert.ToInt64(dr["exploitPointRewardId"]);

				nationWarHeroObjectiveEntries.Add(data);
			}
			gameDatas.nationWarHeroObjectiveEntries = nationWarHeroObjectiveEntries.ToArray();
			nationWarHeroObjectiveEntries.Clear();

			//
			// 국가전경험치보상 목록
			//
			List<WPDNationWarExpReward> nationWarExpRewards = new List<WPDNationWarExpReward>();
			foreach (DataRow dr in drcNationWarExpRewards)
			{
				WPDNationWarExpReward data = new WPDNationWarExpReward();
				data.level = Convert.ToInt32(dr["level"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);

				nationWarExpRewards.Add(data);
			}
			gameDatas.nationWarExpRewards = nationWarExpRewards.ToArray();
			nationWarExpRewards.Clear();

			//
			// 길드건물 목록
			//
			List<WPDGuildBuilding> guildBuildings = new List<WPDGuildBuilding>();
			foreach (DataRow dr in drcGuildBuildings)
			{
				WPDGuildBuilding data = new WPDGuildBuilding();
				data.buildingId = Convert.ToInt32(dr["buildingId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);

				guildBuildings.Add(data);
			}
			gameDatas.guildBuildings = guildBuildings.ToArray();
			guildBuildings.Clear();

			//
			// 길드건물레벨 목록
			//
			List<WPDGuildBuildingLevel> guildBuildingLevels = new List<WPDGuildBuildingLevel>();
			foreach (DataRow dr in drcGuildBuildingLevels)
			{
				WPDGuildBuildingLevel data = new WPDGuildBuildingLevel();
				data.buildingId = Convert.ToInt32(dr["buildingId"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.nextLevelUpGuildBuildingPoint = Convert.ToInt32(dr["nextLevelUpGuildBuildingPoint"]);
				data.nextLevelUpGuildFund = Convert.ToInt32(dr["nextLevelUpGuildFund"]);

				guildBuildingLevels.Add(data);
			}
			gameDatas.guildBuildingLevels = guildBuildingLevels.ToArray();
			guildBuildingLevels.Clear();

			//
			// 길드스킬 목록
			//
			List<WPDGuildSkill> guildSkills = new List<WPDGuildSkill>();
			foreach (DataRow dr in drcGuildSkills)
			{
				WPDGuildSkill data = new WPDGuildSkill();
				data.guildSkillId = Convert.ToInt32(dr["guildSkillId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);

				guildSkills.Add(data);
			}
			gameDatas.guildSkills = guildSkills.ToArray();
			guildSkills.Clear();

			//
			// 길드스킬속성 목록
			//
			List<WPDGuildSkillAttr> guildSkillAttrs = new List<WPDGuildSkillAttr>();
			foreach (DataRow dr in drcGuildSkillAttrs)
			{
				WPDGuildSkillAttr data = new WPDGuildSkillAttr();
				data.guildSkillId = Convert.ToInt32(dr["guildSkillId"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);

				guildSkillAttrs.Add(data);
			}
			gameDatas.guildSkillAttrs = guildSkillAttrs.ToArray();
			guildSkillAttrs.Clear();

			//
			// 길드스킬레벨 목록
			//
			List<WPDGuildSkillLevel> guildSkillLevels = new List<WPDGuildSkillLevel>();
			foreach (DataRow dr in drcGuildSkillLevels)
			{
				WPDGuildSkillLevel data = new WPDGuildSkillLevel();
				data.guildSkillId = Convert.ToInt32(dr["guildSkillId"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.requiredGuildContributionPoint = Convert.ToInt32(dr["requiredGuildContributionPoint"]);
				data.requiredLaboratoryLevel = Convert.ToInt32(dr["requiredLaboratoryLevel"]);

				guildSkillLevels.Add(data);
			}
			gameDatas.guildSkillLevels = guildSkillLevels.ToArray();
			guildSkillLevels.Clear();

			//
			// 길드스킬레벨속성값 목록
			//
			List<WPDGuildSkillLevelAttrValue> guildSkillLevelAttrValues = new List<WPDGuildSkillLevelAttrValue>();
			foreach (DataRow dr in drcGuildSkillLevelAttrValues)
			{
				WPDGuildSkillLevelAttrValue data = new WPDGuildSkillLevelAttrValue();
				data.guildSkillId = Convert.ToInt32(dr["guildSkillId"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);

				guildSkillLevelAttrValues.Add(data);
			}
			gameDatas.guildSkillLevelAttrValues = guildSkillLevelAttrValues.ToArray();
			guildSkillLevelAttrValues.Clear();

			//
			// 길드제단
			//
			WPDGuildAltar guildAltar = new WPDGuildAltar();
			if (drGuildAltar != null)
			{
				guildAltar.guildTerritoryNpcId = Convert.ToInt32(drGuildAltar["guildTerritoryNpcId"]);
				guildAltar.dailyHeroMaxMoralPoint = Convert.ToInt32(drGuildAltar["dailyHeroMaxMoralPoint"]);
				guildAltar.dailyGuildMaxMoralPoint = Convert.ToInt32(drGuildAltar["dailyGuildMaxMoralPoint"]);
				guildAltar.donationGold = Convert.ToInt32(drGuildAltar["donationGold"]);
				guildAltar.donationRewardMoralPoint = Convert.ToInt32(drGuildAltar["donationRewardMoralPoint"]);
				guildAltar.spellInjectionDuration = Convert.ToInt32(drGuildAltar["spellInjectionDuration"]);
				guildAltar.spellInjectionRewardMoralPoint = Convert.ToInt32(drGuildAltar["spellInjectionRewardMoralPoint"]);
				guildAltar.defenseMonsterArrangeId = Convert.ToInt64(drGuildAltar["defenseMonsterArrangeId"]);
				guildAltar.defenseRewardMoralPoint = Convert.ToInt32(drGuildAltar["defenseRewardMoralPoint"]);
				guildAltar.defenseCooltime = Convert.ToInt32(drGuildAltar["defenseCooltime"]);
				guildAltar.defenseLimitTime = Convert.ToInt32(drGuildAltar["defenseLimitTime"]);
			}
			gameDatas.guildAltar = guildAltar;

			//
			// 길드제단수비몬스터속성계수 목록
			//
			List<WPDGuildAltarDefenseMonsterAttrFactor> guildAltarDefenseMonsterAttrFactors = new List<WPDGuildAltarDefenseMonsterAttrFactor>();
			foreach (DataRow dr in drcGuildAltarDefenseMonsterAttrFactors)
			{
				WPDGuildAltarDefenseMonsterAttrFactor data = new WPDGuildAltarDefenseMonsterAttrFactor();
				data.heroLevel = Convert.ToInt32(dr["heroLevel"]);
				data.maxHpFactor = Convert.ToSingle(dr["maxHpFactor"]);
				data.offenseFactor = Convert.ToSingle(dr["offenseFactor"]);

				guildAltarDefenseMonsterAttrFactors.Add(data);
			}
			gameDatas.guildAltarDefenseMonsterAttrFactors = guildAltarDefenseMonsterAttrFactors.ToArray();
			guildAltarDefenseMonsterAttrFactors.Clear();

			//
			// 길드영지
			//
			WPDGuildTerritory guildTerritory = new WPDGuildTerritory();
			if (drGuildTerritory != null)
			{
				guildTerritory.sceneName = Convert.ToString(drGuildTerritory["sceneName"]);
				guildTerritory.startXPosition = Convert.ToSingle(drGuildTerritory["startXPosition"]);
				guildTerritory.startYPosition = Convert.ToSingle(drGuildTerritory["startYPosition"]);
				guildTerritory.startZPosition = Convert.ToSingle(drGuildTerritory["startZPosition"]);
				guildTerritory.startRadius = Convert.ToSingle(drGuildTerritory["startRadius"]);
				guildTerritory.startYRotationType = Convert.ToInt32(drGuildTerritory["startYRotationType"]);
				guildTerritory.startYRotation = Convert.ToSingle(drGuildTerritory["startYRotation"]);
				guildTerritory.locationId = Convert.ToInt32(drGuildTerritory["locationId"]);
				guildTerritory.x = Convert.ToSingle(drGuildTerritory["x"]);
				guildTerritory.z = Convert.ToSingle(drGuildTerritory["z"]);
				guildTerritory.xSize = Convert.ToSingle(drGuildTerritory["xSize"]);
				guildTerritory.zSize = Convert.ToSingle(drGuildTerritory["zSize"]);

			}
			gameDatas.guildTerritory = guildTerritory;

			//
			// 길드영지NPC 목록
			//
			List<WPDGuildTerritoryNpc> guildTerritoryNpcs = new List<WPDGuildTerritoryNpc>();
			foreach (DataRow dr in drcGuildTerritoryNpcs)
			{
				WPDGuildTerritoryNpc data = new WPDGuildTerritoryNpc();
				data.npcId = Convert.ToInt32(dr["npcId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.dialogueKey = Convert.ToString(dr["dialogueKey"]);
				data.dialogueEnabled = Convert.ToBoolean(dr["dialogueEnabled"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);
				data.interactionMaxRange = Convert.ToSingle(dr["interactionMaxRange"]);
				data.prefabName = Convert.ToString(dr["prefabName"]);
				data.scale = Convert.ToSingle(dr["scale"]);
				data.height = Convert.ToInt32(dr["height"]);
				data.radius = Convert.ToSingle(dr["radius"]);

				guildTerritoryNpcs.Add(data);
			}
			gameDatas.guildTerritoryNpcs = guildTerritoryNpcs.ToArray();
			guildTerritoryNpcs.Clear();

			//
			// 길드농장퀘스트
			//
			WPDGuildFarmQuest guildFarmQuest = new WPDGuildFarmQuest();
			if (drGuildFarmQuest != null)
			{
				guildFarmQuest.nameKey = Convert.ToString(drGuildFarmQuest["nameKey"]);
				guildFarmQuest.descriptionKey = Convert.ToString(drGuildFarmQuest["descriptionKey"]);
				guildFarmQuest.targetTitleKey = Convert.ToString(drGuildFarmQuest["targetTitleKey"]);
				guildFarmQuest.targetContentKey = Convert.ToString(drGuildFarmQuest["targetContentKey"]);
				guildFarmQuest.targetCompletionKey = Convert.ToString(drGuildFarmQuest["targetCompletionKey"]);
				guildFarmQuest.startTime = Convert.ToInt32(drGuildFarmQuest["startTime"]);
				guildFarmQuest.endTime = Convert.ToInt32(drGuildFarmQuest["endTime"]);
				guildFarmQuest.limitCount = Convert.ToInt32(drGuildFarmQuest["limitCount"]);
				guildFarmQuest.questGuildTerritoryNpcId = Convert.ToInt32(drGuildFarmQuest["questGuildTerritoryNpcId"]);
				guildFarmQuest.targetGuildTerritoryNpcId = Convert.ToInt32(drGuildFarmQuest["targetGuildTerritoryNpcId"]);
				guildFarmQuest.interactionDuration = Convert.ToInt32(drGuildFarmQuest["interactionDuration"]);
				guildFarmQuest.interactionTextKey = Convert.ToString(drGuildFarmQuest["interactionTextKey"]);
				guildFarmQuest.completionItemRewardId = Convert.ToInt64(drGuildFarmQuest["completionItemRewardId"]);
				guildFarmQuest.completionGuildContributionPointRewardId = Convert.ToInt64(drGuildFarmQuest["completionGuildContributionPointRewardId"]);
				guildFarmQuest.completionGuildBuildingPointRewardId = Convert.ToInt64(drGuildFarmQuest["completionGuildBuildingPointRewardId"]);
				guildFarmQuest.questStartDialogueKey = Convert.ToString(drGuildFarmQuest["questStartDialogueKey"]);
				guildFarmQuest.questCompletionDialogueKey = Convert.ToString(drGuildFarmQuest["questCompletionDialogueKey"]);

			}
			gameDatas.guildFarmQuest = guildFarmQuest;

			//
			// 길드농장퀘스트보상 목록
			//
			List<WPDGuildFarmQuestReward> guildFarmQuestRewards = new List<WPDGuildFarmQuestReward>();
			foreach (DataRow dr in drcGuildFarmQuestRewards)
			{
				WPDGuildFarmQuestReward data = new WPDGuildFarmQuestReward();
				data.level = Convert.ToInt32(dr["level"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);

				guildFarmQuestRewards.Add(data);
			}
			gameDatas.guildFarmQuestRewards = guildFarmQuestRewards.ToArray();
			guildFarmQuestRewards.Clear();

			//
			// 길드군량창고
			//
			WPDGuildFoodWarehouse guildFoodWarehouse = new WPDGuildFoodWarehouse();
			if (drGuildFoodWarehouse != null)
			{
				guildFoodWarehouse.nameKey = Convert.ToString(drGuildFoodWarehouse["nameKey"]);
				guildFoodWarehouse.limitCount = Convert.ToInt32(drGuildFoodWarehouse["limitCount"]);
				guildFoodWarehouse.guildTerritoryNpcId = Convert.ToInt32(drGuildFoodWarehouse["guildTerritoryNpcId"]);
				guildFoodWarehouse.levelUpRequiredItemType = Convert.ToInt32(drGuildFoodWarehouse["levelUpRequiredItemType"]);
				guildFoodWarehouse.fullLevelItemRewardId = Convert.ToInt64(drGuildFoodWarehouse["fullLevelItemRewardId"]);

			}
			gameDatas.guildFoodWarehouse = guildFoodWarehouse;

			//
			// 길드군량창고레벨 목록
			//
			List<WPDGuildFoodWarehouseLevel> guildFoodWarehouseLevels = new List<WPDGuildFoodWarehouseLevel>();
			foreach (DataRow dr in drcGuildFoodWarehouseLevels)
			{
				WPDGuildFoodWarehouseLevel data = new WPDGuildFoodWarehouseLevel();
				data.level = Convert.ToInt32(dr["level"]);
				data.nextLevelUpRequiredExp = Convert.ToInt32(dr["nextLevelUpRequiredExp"]);

				guildFoodWarehouseLevels.Add(data);
			}
			gameDatas.guildFoodWarehouseLevels = guildFoodWarehouseLevels.ToArray();
			guildFoodWarehouseLevels.Clear();

			//
			// 길드미션퀘스트
			//
			WPDGuildMissionQuest guildMissionQuest = new WPDGuildMissionQuest();
			if (drGuildMissionQuest != null)
			{
				guildMissionQuest.nameKey = Convert.ToString(drGuildMissionQuest["nameKey"]);
				guildMissionQuest.limitCount = Convert.ToInt32(drGuildMissionQuest["limitCount"]);
				guildMissionQuest.startNpcId = Convert.ToInt32(drGuildMissionQuest["startNpcId"]);
				guildMissionQuest.completionItemRewardId = Convert.ToInt64(drGuildMissionQuest["completionItemRewardId"]);

			}
			gameDatas.guildMissionQuest = guildMissionQuest;

			//
			// 길드미션퀘스트보상 목록
			//
			List<WPDGuildMissionQuestReward> guildMissionQuestRewards = new List<WPDGuildMissionQuestReward>();
			foreach (DataRow dr in drcGuildMissionQuestRewards)
			{
				WPDGuildMissionQuestReward data = new WPDGuildMissionQuestReward();
				data.level = Convert.ToInt32(dr["level"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);

				guildMissionQuestRewards.Add(data);
			}
			gameDatas.guildMissionQuestRewards = guildMissionQuestRewards.ToArray();
			guildMissionQuestRewards.Clear();

			//
			// 길드미션 목록
			//
			List<WPDGuildMission> guildMissions = new List<WPDGuildMission>();
			foreach (DataRow dr in drcGuildMissions)
			{
				WPDGuildMission data = new WPDGuildMission();
				data.missionId = Convert.ToInt32(dr["missionId"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);
				data.targetDescriptionKey = Convert.ToString(dr["targetDescriptionKey"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.targetContinentId = Convert.ToInt32(dr["targetContinentId"]);
				data.targetXPosition = Convert.ToSingle(dr["targetXPosition"]);
				data.targetYPosition = Convert.ToSingle(dr["targetYPosition"]);
				data.targetZPosition = Convert.ToSingle(dr["targetZPosition"]);
				data.targetRadius = Convert.ToSingle(dr["targetRadius"]);
				data.targetNpcId = Convert.ToInt32(dr["targetNpcId"]);
				data.targetContinentObjectId = Convert.ToInt32(dr["targetContinentObjectId"]);
				data.targetMonsterId = Convert.ToInt32(dr["targetMonsterId"]);
				data.targetSummonMonsterArrangeId = Convert.ToInt64(dr["targetSummonMonsterArrangeId"]);
				data.targetSummonMonsterRadius = Convert.ToSingle(dr["targetSummonMonsterRadius"]);
				data.targetSummonMonsterKillLimitTime = Convert.ToInt32(dr["targetSummonMonsterKillLimitTime"]);
				data.targetCount = Convert.ToInt32(dr["targetCount"]);
				data.guildContributionPointRewardId = Convert.ToInt64(dr["guildContributionPointRewardId"]);
				data.guildFundRewardId = Convert.ToInt64(dr["guildFundRewardId"]);
				data.guildBuildingPointRewardId = Convert.ToInt64(dr["guildBuildingPointRewardId"]);

				guildMissions.Add(data);
			}
			gameDatas.guildMissions = guildMissions.ToArray();
			guildMissions.Clear();

			//
			// 길드물자지원퀘스트
			//
			WPDGuildSupplySupportQuest guildSupplySupportQuest = new WPDGuildSupplySupportQuest();
			if (drGuildSupplySupportQuest != null)
			{
				guildSupplySupportQuest.nameKey = Convert.ToString(drGuildSupplySupportQuest["nameKey"]);
				guildSupplySupportQuest.descriptionKey = Convert.ToString(drGuildSupplySupportQuest["descriptionKey"]);
				guildSupplySupportQuest.limitTime = Convert.ToInt32(drGuildSupplySupportQuest["limitTime"]);
				guildSupplySupportQuest.startNpcId = Convert.ToInt32(drGuildSupplySupportQuest["startNpcId"]);
				guildSupplySupportQuest.cartId = Convert.ToInt32(drGuildSupplySupportQuest["cartId"]);
				guildSupplySupportQuest.completionNpcId = Convert.ToInt32(drGuildSupplySupportQuest["completionNpcId"]);
				guildSupplySupportQuest.startDialogueKey = Convert.ToString(drGuildSupplySupportQuest["startDialogueKey"]);
				guildSupplySupportQuest.completionDialogueKey = Convert.ToString(drGuildSupplySupportQuest["completionDialogueKey"]);
				guildSupplySupportQuest.guildBuildingPointRewardId = Convert.ToInt64(drGuildSupplySupportQuest["guildBuildingPointRewardId"]);
				guildSupplySupportQuest.guildFundRewardId = Convert.ToInt64(drGuildSupplySupportQuest["guildFundRewardId"]);
				guildSupplySupportQuest.completionRewardableRadius = Convert.ToSingle(drGuildSupplySupportQuest["completionRewardableRadius"]);
				guildSupplySupportQuest.completionGuildContributionPointRewardId = Convert.ToInt64(drGuildSupplySupportQuest["completionGuildContributionPointRewardId"]);

			}
			gameDatas.guildSupplySupportQuest = guildSupplySupportQuest;

			//
			// 길드물자지원퀘스트보상 목록
			//
			List<WPDGuildSupplySupportQuestReward> guildSupplySupportQuestRewards = new List<WPDGuildSupplySupportQuestReward>();
			foreach (DataRow dr in drcGuildSupplySupportQuestRewards)
			{
				WPDGuildSupplySupportQuestReward data = new WPDGuildSupplySupportQuestReward();
				data.level = Convert.ToInt32(dr["level"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);

				guildSupplySupportQuestRewards.Add(data);
			}
			gameDatas.guildSupplySupportQuestRewards = guildSupplySupportQuestRewards.ToArray();
			guildSupplySupportQuestRewards.Clear();

			//
			// 국가관직임명권한 목록
			//
			List<WPDNationNoblesseAppointmentAuthority> nationNoblesseAppointmentAuthorities = new List<WPDNationNoblesseAppointmentAuthority>();
			foreach (DataRow dr in drcNationNoblesseAppointmentAuthorities)
			{
				WPDNationNoblesseAppointmentAuthority data = new WPDNationNoblesseAppointmentAuthority();
				data.noblesseId = Convert.ToInt32(dr["noblesseId"]);
				data.targetNoblesseId = Convert.ToInt32(dr["targetNoblesseId"]);

				nationNoblesseAppointmentAuthorities.Add(data);
			}
			gameDatas.nationNoblesseAppointmentAuthorities = nationNoblesseAppointmentAuthorities.ToArray();
			nationNoblesseAppointmentAuthorities.Clear();

			//
			// 메뉴컨텐츠튜토리얼단계 목록
			//
			List<WPDMenuContentTutorialStep> menuContentTutorialSteps = new List<WPDMenuContentTutorialStep>();
			foreach (DataRow dr in drcMenuContentTutorialSteps)
			{
				WPDMenuContentTutorialStep data = new WPDMenuContentTutorialStep();
				data.contentId = Convert.ToInt32(dr["contentId"]);
				data.step = Convert.ToInt32(dr["step"]);
				data.textKey = Convert.ToString(dr["textKey"]);
				data.textXPosition = Convert.ToSingle(dr["textXPosition"]);
				data.textYPosition = Convert.ToSingle(dr["textYPosition"]);
				data.arrowXPosition = Convert.ToSingle(dr["arrowXPosition"]);
				data.arrowYPosition = Convert.ToSingle(dr["arrowYPosition"]);
				data.arrowZRotation = Convert.ToSingle(dr["arrowZRotation"]);
				data.clickXPosition = Convert.ToSingle(dr["clickXPosition"]);
				data.clickYPosition = Convert.ToSingle(dr["clickYPosition"]);
				data.clickWidth = Convert.ToInt32(dr["clickWidth"]);
				data.clickHeight = Convert.ToInt32(dr["clickHeight"]);
				data.effectName = Convert.ToString(dr["effectName"]);
				data.effectXPosition = Convert.ToSingle(dr["effectXPosition"]);
				data.effectYPosition = Convert.ToSingle(dr["effectYPosition"]);
				data.effectWidth = Convert.ToInt32(dr["effectWidth"]);
				data.effectHeight = Convert.ToInt32(dr["effectHeight"]);

				menuContentTutorialSteps.Add(data);
			}
			gameDatas.menuContentTutorialSteps = menuContentTutorialSteps.ToArray();
			menuContentTutorialSteps.Clear();

			//
			// 길드컨텐츠 목록
			//
			List<WPDGuildContent> guildContents = new List<WPDGuildContent>();
			foreach (DataRow dr in drcGuildContents)
			{
				WPDGuildContent data = new WPDGuildContent();
				data.guildContentId = Convert.ToInt32(dr["guildContentId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.rewardTextKey = Convert.ToString(dr["rewardTextKey"]);
				data.eventTimeTextKey = Convert.ToString(dr["eventTimeTextKey"]);
				data.lockTextKey = Convert.ToString(dr["lockTextKey"]);
				data.achievementPoint = Convert.ToInt32(dr["achievementPoint"]);
				data.isDailyObjective = Convert.ToBoolean(dr["isDailyObjective"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);
				data.taskId = Convert.ToInt32(dr["taskId"]);

				guildContents.Add(data);
			}
			gameDatas.guildContents = guildContents.ToArray();
			guildContents.Clear();

			//
			// 길드일일목표보상 목록
			//
			List<WPDGuildDailyObjectiveReward> guildDailyObjectiveRewards = new List<WPDGuildDailyObjectiveReward>();
			foreach (DataRow dr in drcGuildDailyObjectiveRewards)
			{
				WPDGuildDailyObjectiveReward data = new WPDGuildDailyObjectiveReward();
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.completionMemberCount = Convert.ToInt32(dr["completionMemberCount"]);
				data.itemReward1Id = Convert.ToInt64(dr["itemReward1Id"]);
				data.itemReward2Id = Convert.ToInt64(dr["itemReward2Id"]);
				data.itemReward3Id = Convert.ToInt64(dr["itemReward3Id"]);

				guildDailyObjectiveRewards.Add(data);
			}
			gameDatas.guildDailyObjectiveRewards = guildDailyObjectiveRewards.ToArray();
			guildDailyObjectiveRewards.Clear();

			//
			// 길드헌팅퀘스트
			//
			WPDGuildHuntingQuest guildHuntingQuest = new WPDGuildHuntingQuest();
			if (drGuildHuntingQuest != null)
			{
				guildHuntingQuest.limitCount = Convert.ToInt32(drGuildHuntingQuest["limitCount"]);
				guildHuntingQuest.questNpcId = Convert.ToInt32(drGuildHuntingQuest["questNpcId"]);
				guildHuntingQuest.completionDialogueKey = Convert.ToString(drGuildHuntingQuest["completionDialogueKey"]);
				guildHuntingQuest.itemRewardId = Convert.ToInt64(drGuildHuntingQuest["itemRewardId"]);
			}
			gameDatas.guildHuntingQuest = guildHuntingQuest;

			//
			// 길드헌팅퀘스트목표 목록
			//
			List<WPDGuildHuntingQuestObjective> guildHuntingQuestObjectives = new List<WPDGuildHuntingQuestObjective>();
			foreach (DataRow dr in drcGuildHuntingQuestObjectives)
			{
				WPDGuildHuntingQuestObjective data = new WPDGuildHuntingQuestObjective();
				data.objectiveId = Convert.ToInt32(dr["objectiveId"]);
				data.minHeroLevel = Convert.ToInt32(dr["minHeroLevel"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);
				data.targetDescriptionKey = Convert.ToString(dr["targetDescriptionKey"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.targetContinentId = Convert.ToInt32(dr["targetContinentId"]);
				data.targetXPosition = Convert.ToSingle(dr["targetXPosition"]);
				data.targetYPosition = Convert.ToSingle(dr["targetYPosition"]);
				data.targetZPosition = Convert.ToSingle(dr["targetZPosition"]);
				data.targetRadius = Convert.ToSingle(dr["targetRadius"]);
				data.targetContinentObjectId = Convert.ToInt32(dr["targetContinentObjectId"]);
				data.targetMonsterId = Convert.ToInt32(dr["targetMonsterId"]);
				data.targetCount = Convert.ToInt32(dr["targetCount"]);

				guildHuntingQuestObjectives.Add(data);
			}
			gameDatas.guildHuntingQuestObjectives = guildHuntingQuestObjectives.ToArray();
			guildHuntingQuestObjectives.Clear();

			//
			// 영혼을탐하는자
			//
			WPDSoulCoveter soulCoveter = new WPDSoulCoveter();
			if (drSoulCoveter != null)
			{
				soulCoveter.nameKey = Convert.ToString(drSoulCoveter["nameKey"]);
				soulCoveter.descriptionKey = Convert.ToString(drSoulCoveter["descriptionKey"]);
				soulCoveter.sceneName = Convert.ToString(drSoulCoveter["sceneName"]);
				soulCoveter.requiredConditionType = Convert.ToInt32(drSoulCoveter["requiredConditionType"]);
				soulCoveter.requiredHeroLevel = Convert.ToInt32(drSoulCoveter["requiredHeroLevel"]);
				soulCoveter.requiredMainQuestNo = Convert.ToInt32(drSoulCoveter["requiredMainQuestNo"]);
				soulCoveter.requiredStamina = Convert.ToInt32(drSoulCoveter["requiredStamina"]);
				soulCoveter.enterMinMemberCount = Convert.ToInt32(drSoulCoveter["enterMinMemberCount"]);
				soulCoveter.enterMaxMemberCount = Convert.ToInt32(drSoulCoveter["enterMaxMemberCount"]);
				soulCoveter.matchingWaitingTime = Convert.ToInt32(drSoulCoveter["matchingWaitingTime"]);
				soulCoveter.enterWaitingTime = Convert.ToInt32(drSoulCoveter["enterWaitingTime"]);
				soulCoveter.startDelayTime = Convert.ToInt32(drSoulCoveter["startDelayTime"]);
				soulCoveter.limitTime = Convert.ToInt32(drSoulCoveter["limitTime"]);
				soulCoveter.exitDelayTime = Convert.ToInt32(drSoulCoveter["exitDelayTime"]);
				soulCoveter.waveIntervalTime = Convert.ToInt32(drSoulCoveter["waveIntervalTime"]);
				soulCoveter.startXPosition = Convert.ToSingle(drSoulCoveter["startXPosition"]);
				soulCoveter.startYPosition = Convert.ToSingle(drSoulCoveter["startYPosition"]);
				soulCoveter.startZPosition = Convert.ToSingle(drSoulCoveter["startZPosition"]);
				soulCoveter.startRadius = Convert.ToSingle(drSoulCoveter["startRadius"]);
				soulCoveter.startYRotationType = Convert.ToInt32(drSoulCoveter["startYRotationType"]);
				soulCoveter.startYRotation = Convert.ToSingle(drSoulCoveter["startYRotation"]);
				soulCoveter.safeRevivalWaitingTime = Convert.ToInt32(drSoulCoveter["safeRevivalWaitingTime"]);
				soulCoveter.locationId = Convert.ToInt32(drSoulCoveter["locationId"]);
				soulCoveter.x = Convert.ToSingle(drSoulCoveter["x"]);
				soulCoveter.z = Convert.ToSingle(drSoulCoveter["z"]);
				soulCoveter.xSize = Convert.ToSingle(drSoulCoveter["xSize"]);
				soulCoveter.zSize = Convert.ToSingle(drSoulCoveter["zSize"]);

			}
			gameDatas.soulCoveter = soulCoveter;

			//
			// 영혼을탐하는자획득가능보상 목록
			//
			List<WPDSoulCoveterAvailableReward> soulCoveterAvailableRewards = new List<WPDSoulCoveterAvailableReward>();
			foreach (DataRow dr in drcSoulCoveterAvailableRewards)
			{
				WPDSoulCoveterAvailableReward data = new WPDSoulCoveterAvailableReward();
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);

				soulCoveterAvailableRewards.Add(data);
			}
			gameDatas.soulCoveterAvailableRewards = soulCoveterAvailableRewards.ToArray();
			soulCoveterAvailableRewards.Clear();

			//
			// 영혼을탐하는자장애물 목록
			//
			List<WPDSoulCoveterObstacle> soulCoveterObstacles = new List<WPDSoulCoveterObstacle>();
			foreach (DataRow dr in drcSoulCoveterObstacles)
			{
				WPDSoulCoveterObstacle data = new WPDSoulCoveterObstacle();
				data.obstacleId = Convert.ToInt32(dr["obstacleId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);
				data.scale = Convert.ToSingle(dr["scale"]);

				soulCoveterObstacles.Add(data);
			}
			gameDatas.soulCoveterObstacles = soulCoveterObstacles.ToArray();
			soulCoveterObstacles.Clear();

			//
			// 영혼을탐하는자난이도 목록
			//
			List<WPDSoulCoveterDifficulty> soulCoveterDifficulties = new List<WPDSoulCoveterDifficulty>();
			foreach (DataRow dr in drcSoulCoveterDifficulties)
			{
				WPDSoulCoveterDifficulty data = new WPDSoulCoveterDifficulty();
				data.difficulty = Convert.ToInt32(dr["difficulty"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);

				soulCoveterDifficulties.Add(data);
			}
			gameDatas.soulCoveterDifficulties = soulCoveterDifficulties.ToArray();
			soulCoveterDifficulties.Clear();

			//
			// 영혼을탐하는자난이도웨이브 목록
			//
			List<WPDSoulCoveterDifficultyWave> soulCoveterDifficultyWaves = new List<WPDSoulCoveterDifficultyWave>();
			foreach (DataRow dr in drcSoulCoveterDifficultyWaves)
			{
				WPDSoulCoveterDifficultyWave data = new WPDSoulCoveterDifficultyWave();
				data.difficulty = Convert.ToInt32(dr["difficulty"]);
				data.waveNo = Convert.ToInt32(dr["waveNo"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);
				data.targetArrangeNo = Convert.ToInt32(dr["targetArrangeNo"]);
				data.guideImageName = Convert.ToString(dr["guideImageName"]);
				data.guideTitleKey = Convert.ToString(dr["guideTitleKey"]);
				data.guideContentKey = Convert.ToString(dr["guideContentKey"]);

				soulCoveterDifficultyWaves.Add(data);
			}
			gameDatas.soulCoveterDifficultyWaves = soulCoveterDifficultyWaves.ToArray();
			soulCoveterDifficultyWaves.Clear();

			//
			// 클라이언트튜토리얼단계 목록
			//
			List<WPDClientTutorialStep> clientTutorialSteps = new List<WPDClientTutorialStep>();
			foreach (DataRow dr in drcClientTutorialSteps)
			{
				WPDClientTutorialStep data = new WPDClientTutorialStep();
				data.tutorialId = Convert.ToInt32(dr["tutorialId"]);
				data.step = Convert.ToInt32(dr["step"]);
				data.textKey = Convert.ToString(dr["textKey"]);
				data.textXPosition = Convert.ToSingle(dr["textXPosition"]);
				data.textYPosition = Convert.ToSingle(dr["textYPosition"]);
				data.arrowXPosition = Convert.ToSingle(dr["arrowXPosition"]);
				data.arrowYPosition = Convert.ToSingle(dr["arrowYPosition"]);
				data.arrowYRotation = Convert.ToSingle(dr["arrowYRotation"]);
				data.clickXPosition = Convert.ToSingle(dr["clickXPosition"]);
				data.clickYPosition = Convert.ToSingle(dr["clickYPosition"]);
				data.clickWidth = Convert.ToInt32(dr["clickWidth"]);
				data.clickHeight = Convert.ToInt32(dr["clickHeight"]);
				data.effectName = Convert.ToString(dr["effectName"]);
				data.effectXPosition = Convert.ToSingle(dr["effectXPosition"]);
				data.effectYPosition = Convert.ToSingle(dr["effectYPosition"]);
				data.effectWidth = Convert.ToInt32(dr["effectWidth"]);
				data.effectHeight = Convert.ToInt32(dr["effectHeight"]);

				clientTutorialSteps.Add(data);
			}
			gameDatas.clientTutorialSteps = clientTutorialSteps.ToArray();
			clientTutorialSteps.Clear();

			//
			// 길드주간목표 목록
			//
			List<WPDGuildWeeklyObjective> guildWeeklyObjectives = new List<WPDGuildWeeklyObjective>();
			foreach (DataRow dr in drcGuildWeeklyObjectives)
			{
				WPDGuildWeeklyObjective data = new WPDGuildWeeklyObjective();
				data.objectiveId = Convert.ToInt32(dr["objectiveId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.completionMemberCount = Convert.ToInt32(dr["completionMemberCount"]);
				data.itemReward1Id = Convert.ToInt64(dr["itemReward1Id"]);
				data.itemReward2Id = Convert.ToInt64(dr["itemReward2Id"]);
				data.itemReward3Id = Convert.ToInt64(dr["itemReward3Id"]);

				guildWeeklyObjectives.Add(data);
			}
			gameDatas.guildWeeklyObjectives = guildWeeklyObjectives.ToArray();
			guildWeeklyObjectives.Clear();

			//
			// 귀속다이아보상 목록
			//
			List<WPDOwnDiaReward> ownDiaRewards = new List<WPDOwnDiaReward>();
			foreach (DataRow dr in drcOwnDiaRewards)
			{
				WPDOwnDiaReward data = new WPDOwnDiaReward();
				data.ownDiaRewardId = Convert.ToInt64(dr["ownDiaRewardId"]);
				data.value = Convert.ToInt32(dr["value"]);

				ownDiaRewards.Add(data);
			}
			gameDatas.ownDiaRewards = ownDiaRewards.ToArray();
			ownDiaRewards.Clear();

			//
			// 업적카테고리 목록
			//
			List<WPDAccomplishmentCategory> accomplishmentCategories = new List<WPDAccomplishmentCategory>();
			foreach (DataRow dr in drcAccomplishmentCategories)
			{
				WPDAccomplishmentCategory data = new WPDAccomplishmentCategory();
				data.categoryId = Convert.ToInt32(dr["categoryId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);

				accomplishmentCategories.Add(data);
			}
			gameDatas.accomplishmentCategories = accomplishmentCategories.ToArray();
			accomplishmentCategories.Clear();

			//
			// 업적 목록
			//
			List<WPDAccomplishment> accomplishments = new List<WPDAccomplishment>();
			foreach (DataRow dr in drcAccomplishments)
			{
				WPDAccomplishment data = new WPDAccomplishment();
				data.accomplishmentId = Convert.ToInt32(dr["accomplishmentId"]);
				data.categoryId = Convert.ToInt32(dr["categoryId"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.objectiveTextKey = Convert.ToString(dr["objectiveTextKey"]);
				data.objectiveValue = Convert.ToInt64(dr["objectiveValue"]);
				data.point = Convert.ToInt32(dr["point"]);
				data.rewardType = Convert.ToInt32(dr["rewardType"]);
				data.rewardTitleId = Convert.ToInt32(dr["rewardTitleId"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);

				accomplishments.Add(data);
			}
			gameDatas.accomplishments = accomplishments.ToArray();
			accomplishments.Clear();

			//
			// 칭호카테고리 목록
			//
			List<WPDTitleCategory> titleCategories = new List<WPDTitleCategory>();
			foreach (DataRow dr in drcTitleCategories)
			{
				WPDTitleCategory data = new WPDTitleCategory();
				data.categoryId = Convert.ToInt32(dr["categoryId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);

				titleCategories.Add(data);
			}
			gameDatas.titleCategories = titleCategories.ToArray();
			titleCategories.Clear();

			//
			// 칭호타입 목록
			//
			List<WPDTitleType> titleTypes = new List<WPDTitleType>();
			foreach (DataRow dr in drcTitleTypes)
			{
				WPDTitleType data = new WPDTitleType();
				data.type = Convert.ToInt32(dr["type"]);
				data.categoryId = Convert.ToInt32(dr["categoryId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);

				titleTypes.Add(data);
			}
			gameDatas.titleTypes = titleTypes.ToArray();
			titleTypes.Clear();

			//
			// 칭호 목록
			//
			List<WPDTitle> titles = new List<WPDTitle>();
			foreach (DataRow dr in drcTitles)
			{
				WPDTitle data = new WPDTitle();
				data.titleId = Convert.ToInt32(dr["titleId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.grade = Convert.ToInt32(dr["grade"]);
				data.acquisitionTextKey = Convert.ToString(dr["acquisitionTextKey"]);
				data.backgroundImageName = Convert.ToString(dr["backgroundImageName"]);
				data.lifetime = Convert.ToInt32(dr["lifetime"]);

				titles.Add(data);
			}
			gameDatas.titles = titles.ToArray();
			titles.Clear();

			//
			// 칭호등급 목록
			//
			List<WPDTitleGrade> titleGrades = new List<WPDTitleGrade>();
			foreach (DataRow dr in drcTitleGrades)
			{
				WPDTitleGrade data = new WPDTitleGrade();
				data.grade = Convert.ToInt32(dr["grade"]);
				data.colorCode = Convert.ToString(dr["colorCode"]);

				titleGrades.Add(data);
			}
			gameDatas.titleGrades = titleGrades.ToArray();
			titleGrades.Clear();

			//
			// 칭호액티브속성 목록
			//
			List<WPDTitleActiveAttr> titleActiveAttrs = new List<WPDTitleActiveAttr>();
			foreach (DataRow dr in drcTitleActiveAttrs)
			{
				WPDTitleActiveAttr data = new WPDTitleActiveAttr();
				data.titleId = Convert.ToInt32(dr["titleId"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);

				titleActiveAttrs.Add(data);
			}
			gameDatas.titleActiveAttrs = titleActiveAttrs.ToArray();
			titleActiveAttrs.Clear();

			//
			// 칭호패시브속성 목록
			//
			List<WPDTitlePassiveAttr> titlePassiveAttrs = new List<WPDTitlePassiveAttr>();
			foreach (DataRow dr in drcTitlePassiveAttrs)
			{
				WPDTitlePassiveAttr data = new WPDTitlePassiveAttr();
				data.titleId = Convert.ToInt32(dr["titleId"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);

				titlePassiveAttrs.Add(data);
			}
			gameDatas.titlePassiveAttrs = titlePassiveAttrs.ToArray();
			titlePassiveAttrs.Clear();

			//
			// 도감카테고리 목록
			//
			List<WPDIllustratedBookCategory> illustratedBookCategories = new List<WPDIllustratedBookCategory>();
			foreach (DataRow dr in drcIllustratedBookCategories)
			{
				WPDIllustratedBookCategory data = new WPDIllustratedBookCategory();
				data.categoryId = Convert.ToInt32(dr["categoryId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);

				illustratedBookCategories.Add(data);
			}
			gameDatas.illustratedBookCategories = illustratedBookCategories.ToArray();
			illustratedBookCategories.Clear();

			//
			// 도감타입 목록
			//
			List<WPDIllustratedBookType> illustratedBookTypes = new List<WPDIllustratedBookType>();
			foreach (DataRow dr in drcIllustratedBookTypes)
			{
				WPDIllustratedBookType data = new WPDIllustratedBookType();
				data.type = Convert.ToInt32(dr["type"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.categoryId = Convert.ToInt32(dr["categoryId"]);

				illustratedBookTypes.Add(data);
			}
			gameDatas.illustratedBookTypes = illustratedBookTypes.ToArray();
			illustratedBookTypes.Clear();

			//
			// 도감 목록
			//
			List<WPDIllustratedBook> illustratedBooks = new List<WPDIllustratedBook>();
			foreach (DataRow dr in drcIllustratedBooks)
			{
				WPDIllustratedBook data = new WPDIllustratedBook();
				data.illustratedBookId = Convert.ToInt32(dr["illustratedBookId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.imageName = Convert.ToString(dr["imageName"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.explorationPoint = Convert.ToInt32(dr["explorationPoint"]);

				illustratedBooks.Add(data);
			}
			gameDatas.illustratedBooks = illustratedBooks.ToArray();
			illustratedBooks.Clear();

			//
			// 도감속성 목록
			//
			List<WPDIllustratedBookAttr> illustratedBookAttrs = new List<WPDIllustratedBookAttr>();
			foreach (DataRow dr in drcIllustratedBookAttrs)
			{
				WPDIllustratedBookAttr data = new WPDIllustratedBookAttr();
				data.illustratedBookId = Convert.ToInt32(dr["illustratedBookId"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);
				data.grade = Convert.ToInt32(dr["grade"]);

				illustratedBookAttrs.Add(data);
			}
			gameDatas.illustratedBookAttrs = illustratedBookAttrs.ToArray();
			illustratedBookAttrs.Clear();

			//
			// 도감속성등급 목록
			//
			List<WPDIllustratedBookAttrGrade> illustratedBookAttrGrades = new List<WPDIllustratedBookAttrGrade>();
			foreach (DataRow dr in drcIllustratedBookAttrGrades)
			{
				WPDIllustratedBookAttrGrade data = new WPDIllustratedBookAttrGrade();
				data.grade = Convert.ToInt32(dr["grade"]);
				data.colorCode = Convert.ToString(dr["colorCode"]);

				illustratedBookAttrGrades.Add(data);
			}
			gameDatas.illustratedBookAttrGrades = illustratedBookAttrGrades.ToArray();
			illustratedBookAttrGrades.Clear();

			//
			// 도감탐험단계 목록
			//
			List<WPDIllustratedBookExplorationStep> illustratedBookExplorationSteps = new List<WPDIllustratedBookExplorationStep>();
			foreach (DataRow dr in drcIllustratedBookExplorationSteps)
			{
				WPDIllustratedBookExplorationStep data = new WPDIllustratedBookExplorationStep();
				data.stepNo = Convert.ToInt32(dr["stepNo"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.activationExplorationPoint = Convert.ToInt32(dr["activationExplorationPoint"]);
				data.goldRewardId = Convert.ToInt64(dr["goldRewardId"]);

				illustratedBookExplorationSteps.Add(data);
			}
			gameDatas.illustratedBookExplorationSteps = illustratedBookExplorationSteps.ToArray();
			illustratedBookExplorationSteps.Clear();

			//
			// 도감탐험단계속성 목록
			//
			List<WPDIllustratedBookExplorationStepAttr> illustratedBookExplorationStepAttrs = new List<WPDIllustratedBookExplorationStepAttr>();
			foreach (DataRow dr in drcIllustratedBookExplorationStepAttrs)
			{
				WPDIllustratedBookExplorationStepAttr data = new WPDIllustratedBookExplorationStepAttr();
				data.stepNo = Convert.ToInt32(dr["stepNo"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);

				illustratedBookExplorationStepAttrs.Add(data);
			}
			gameDatas.illustratedBookExplorationStepAttrs = illustratedBookExplorationStepAttrs.ToArray();
			illustratedBookExplorationStepAttrs.Clear();

			//
			// 도감탐험단계보상 목록
			//
			List<WPDIllustratedBookExplorationStepReward> illustratedBookExplorationStepRewards = new List<WPDIllustratedBookExplorationStepReward>();
			foreach (DataRow dr in drcIllustratedBookExplorationStepRewards)
			{
				WPDIllustratedBookExplorationStepReward data = new WPDIllustratedBookExplorationStepReward();
				data.stepNo = Convert.ToInt32(dr["stepNo"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				illustratedBookExplorationStepRewards.Add(data);
			}
			gameDatas.illustratedBookExplorationStepRewards = illustratedBookExplorationStepRewards.ToArray();
			illustratedBookExplorationStepRewards.Clear();

			//
			// 풍광퀘스트 목록
			//
			List<WPDSceneryQuest> sceneryQuests = new List<WPDSceneryQuest>();
			foreach (DataRow dr in drcSceneryQuests)
			{
				WPDSceneryQuest data = new WPDSceneryQuest();
				data.questId = Convert.ToInt32(dr["questId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);
				data.continentId = Convert.ToInt32(dr["continentId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.radius = Convert.ToSingle(dr["radius"]);
				data.waitingTime = Convert.ToInt32(dr["waitingTime"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				sceneryQuests.Add(data);
			}
			gameDatas.sceneryQuests = sceneryQuests.ToArray();
			sceneryQuests.Clear();

			//
			// 정예몬스터카테고리 목록
			//
			List<WPDEliteMonsterCategory> eliteMonsterCategories = new List<WPDEliteMonsterCategory>();
			foreach (DataRow dr in drcEliteMonsterCategories)
			{
				WPDEliteMonsterCategory data = new WPDEliteMonsterCategory();
				data.categoryId = Convert.ToInt32(dr["categoryId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.recommendMinHeroLevel = Convert.ToInt32(dr["recommendMinHeroLevel"]);
				data.recommendMaxHeroLevel = Convert.ToInt32(dr["recommendMaxHeroLevel"]);
				data.continentId = Convert.ToInt32(dr["continentId"]);

				eliteMonsterCategories.Add(data);
			}
			gameDatas.eliteMonsterCategories = eliteMonsterCategories.ToArray();
			eliteMonsterCategories.Clear();

			//
			// 정예몬스터마스터 목록
			//
			List<WPDEliteMonsterMaster> eliteMonsterMasters = new List<WPDEliteMonsterMaster>();
			foreach (DataRow dr in drcEliteMonsterMasters)
			{
				WPDEliteMonsterMaster data = new WPDEliteMonsterMaster();
				data.eliteMonsterMasterId = Convert.ToInt32(dr["eliteMonsterMasterId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.displayMonsterId = Convert.ToInt32(dr["displayMonsterId"]);
				data.categoryId = Convert.ToInt32(dr["categoryId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.yRotationType = Convert.ToInt32(dr["yRotationType"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);

				eliteMonsterMasters.Add(data);
			}
			gameDatas.eliteMonsterMasters = eliteMonsterMasters.ToArray();
			eliteMonsterMasters.Clear();

			//
			// 정예몬스터 목록
			//
			List<WPDEliteMonster> eliteMonsters = new List<WPDEliteMonster>();
			foreach (DataRow dr in drcEliteMonsters)
			{
				WPDEliteMonster data = new WPDEliteMonster();
				data.eliteMonsterId = Convert.ToInt32(dr["eliteMonsterId"]);
				data.eliteMonsterMasterId = Convert.ToInt32(dr["eliteMonsterMasterId"]);
				data.starGrade = Convert.ToInt32(dr["starGrade"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.monsterArrangeId = Convert.ToInt64(dr["monsterArrangeId"]);

				eliteMonsters.Add(data);
			}
			gameDatas.eliteMonsters = eliteMonsters.ToArray();
			eliteMonsters.Clear();

			//
			// 정예몬스터처치속성 목록
			//
			List<WPDEliteMonsterKillAttrValue> eliteMonsterKillAttrValues = new List<WPDEliteMonsterKillAttrValue>();
			foreach (DataRow dr in drcEliteMonsterKillAttrValues)
			{
				WPDEliteMonsterKillAttrValue data = new WPDEliteMonsterKillAttrValue();
				data.eliteMonsterId = Convert.ToInt32(dr["eliteMonsterId"]);
				data.killCount = Convert.ToInt32(dr["killCount"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);

				eliteMonsterKillAttrValues.Add(data);
			}
			gameDatas.eliteMonsterKillAttrValues = eliteMonsterKillAttrValues.ToArray();
			eliteMonsterKillAttrValues.Clear();

			//
			// 정예몬스터출몰스케줄 목록
			//
			List<WPDEliteMonsterSpawnSchedule> eliteMonsterSpawnSchedules = new List<WPDEliteMonsterSpawnSchedule>();
			foreach (DataRow dr in drcEliteMonsterSpawnSchedules)
			{
				WPDEliteMonsterSpawnSchedule data = new WPDEliteMonsterSpawnSchedule();
				data.eliteMonsterMasterId = Convert.ToInt32(dr["eliteMonsterMasterId"]);
				data.scheduleNo = Convert.ToInt32(dr["scheduleNo"]);
				data.spawnTime = Convert.ToInt32(dr["spawnTime"]);

				eliteMonsterSpawnSchedules.Add(data);
			}
			gameDatas.eliteMonsterSpawnSchedules = eliteMonsterSpawnSchedules.ToArray();
			eliteMonsterSpawnSchedules.Clear();

			//
			// 정예던전
			//
			WPDEliteDungeon eliteDungeon = new WPDEliteDungeon();
			if (drEliteDungeon != null)
			{
				eliteDungeon.nameKey = Convert.ToString(drEliteDungeon["nameKey"]);
				eliteDungeon.descriptionKey = Convert.ToString(drEliteDungeon["descriptionKey"]);
				eliteDungeon.targetTitleKey = Convert.ToString(drEliteDungeon["targetTitleKey"]);
				eliteDungeon.targetContentKey = Convert.ToString(drEliteDungeon["targetContentKey"]);
				eliteDungeon.baseEnterCount = Convert.ToInt32(drEliteDungeon["baseEnterCount"]);
				eliteDungeon.enterCountAddInterval = Convert.ToInt32(drEliteDungeon["enterCountAddInterval"]);
				eliteDungeon.requiredStamina = Convert.ToInt32(drEliteDungeon["requiredStamina"]);
				eliteDungeon.sceneName = Convert.ToString(drEliteDungeon["sceneName"]);
				eliteDungeon.startDelayTime = Convert.ToInt32(drEliteDungeon["startDelayTime"]);
				eliteDungeon.limitTime = Convert.ToInt32(drEliteDungeon["limitTime"]);
				eliteDungeon.exitDelayTime = Convert.ToInt32(drEliteDungeon["exitDelayTime"]);
				eliteDungeon.safeRevivalWaitingTime = Convert.ToInt32(drEliteDungeon["safeRevivalWaitingTime"]);
				eliteDungeon.startXPosition = Convert.ToSingle(drEliteDungeon["startXPosition"]);
				eliteDungeon.startYPosition = Convert.ToSingle(drEliteDungeon["startYPosition"]);
				eliteDungeon.startZPosition = Convert.ToSingle(drEliteDungeon["startZPosition"]);
				eliteDungeon.startYRotation = Convert.ToSingle(drEliteDungeon["startYRotation"]);
				eliteDungeon.monsterXPosition = Convert.ToSingle(drEliteDungeon["monsterXPosition"]);
				eliteDungeon.monsterYPosition = Convert.ToSingle(drEliteDungeon["monsterYPosition"]);
				eliteDungeon.monsterZPosition = Convert.ToSingle(drEliteDungeon["monsterZPosition"]);
				eliteDungeon.monsterYRotation = Convert.ToSingle(drEliteDungeon["monsterYRotation"]);
				eliteDungeon.locationId = Convert.ToInt32(drEliteDungeon["locationId"]);
				eliteDungeon.x = Convert.ToSingle(drEliteDungeon["x"]);
				eliteDungeon.z = Convert.ToSingle(drEliteDungeon["z"]);
				eliteDungeon.xSize = Convert.ToSingle(drEliteDungeon["xSize"]);
				eliteDungeon.zSize = Convert.ToSingle(drEliteDungeon["zSize"]);
			}
			gameDatas.eliteDungeon = eliteDungeon;

			//
			// 크리처카드카테고리 목록
			//
			List<WPDCreatureCardCategory> creatureCardCategories = new List<WPDCreatureCardCategory>();
			foreach (DataRow dr in drcCreatureCardCategories)
			{
				WPDCreatureCardCategory data = new WPDCreatureCardCategory();
				data.categoryId = Convert.ToInt32(dr["categoryId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);

				creatureCardCategories.Add(data);
			}
			gameDatas.creatureCardCategories = creatureCardCategories.ToArray();
			creatureCardCategories.Clear();

			//
			// 크리처카드 목록
			//
			List<WPDCreatureCard> creatureCards = new List<WPDCreatureCard>();
			foreach (DataRow dr in drcCreatureCards)
			{
				WPDCreatureCard data = new WPDCreatureCard();
				data.creatureCardId = Convert.ToInt32(dr["creatureCardId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.categoryId = Convert.ToInt32(dr["categoryId"]);
				data.grade = Convert.ToInt32(dr["grade"]);
				data.attack = Convert.ToInt32(dr["attack"]);
				data.life = Convert.ToInt32(dr["life"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);

				creatureCards.Add(data);
			}
			gameDatas.creatureCards = creatureCards.ToArray();
			creatureCards.Clear();

			//
			// 크리처카드등급 목록
			//
			List<WPDCreatureCardGrade> creatureCardGrades = new List<WPDCreatureCardGrade>();
			foreach (DataRow dr in drcCreatureCardGrades)
			{
				WPDCreatureCardGrade data = new WPDCreatureCardGrade();
				data.grade = Convert.ToInt32(dr["grade"]);
				data.colorCode = Convert.ToString(dr["colorCode"]);
				data.saleSoulPowder = Convert.ToInt32(dr["saleSoulPowder"]);
				data.disassembleSoulPowder = Convert.ToInt32(dr["disassembleSoulPowder"]);
				data.compositionSoulPowder = Convert.ToInt32(dr["compositionSoulPowder"]);

				creatureCardGrades.Add(data);
			}
			gameDatas.creatureCardGrades = creatureCardGrades.ToArray();
			creatureCardGrades.Clear();

			//
			// 크리처카드콜렉션항목 목록
			//
			List<WPDCreatureCardCollectionEntry> creatureCardCollectionEntries = new List<WPDCreatureCardCollectionEntry>();
			foreach (DataRow dr in drcCreatureCardCollectionEntries)
			{
				WPDCreatureCardCollectionEntry data = new WPDCreatureCardCollectionEntry();
				data.collectionId = Convert.ToInt32(dr["collectionId"]);
				data.creatureCardId = Convert.ToInt32(dr["creatureCardId"]);

				creatureCardCollectionEntries.Add(data);
			}
			gameDatas.creatureCardCollectionEntries = creatureCardCollectionEntries.ToArray();
			creatureCardCollectionEntries.Clear();

			//
			// 크리처카드콜렉션카테고리 목록
			//
			List<WPDCreatureCardCollectionCategory> creatureCardCollectionCategories = new List<WPDCreatureCardCollectionCategory>();
			foreach (DataRow dr in drcCreatureCardCollectionCategories)
			{
				WPDCreatureCardCollectionCategory data = new WPDCreatureCardCollectionCategory();
				data.categoryId = Convert.ToInt32(dr["categoryId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);

				creatureCardCollectionCategories.Add(data);
			}
			gameDatas.creatureCardCollectionCategories = creatureCardCollectionCategories.ToArray();
			creatureCardCollectionCategories.Clear();

			//
			// 크리처카드콜렉션 목록
			//
			List<WPDCreatureCardCollection> creatureCardCollections = new List<WPDCreatureCardCollection>();
			foreach (DataRow dr in drcCreatureCardCollections)
			{
				WPDCreatureCardCollection data = new WPDCreatureCardCollection();
				data.collectionId = Convert.ToInt32(dr["collectionId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.categoryId = Convert.ToInt32(dr["categoryId"]);
				data.grade = Convert.ToInt32(dr["grade"]);

				creatureCardCollections.Add(data);
			}
			gameDatas.creatureCardCollections = creatureCardCollections.ToArray();
			creatureCardCollections.Clear();

			//
			// 크리처카드콜렉션속성 목록
			//
			List<WPDCreatureCardCollectionAttr> creatureCardCollectionAttrs = new List<WPDCreatureCardCollectionAttr>();
			foreach (DataRow dr in drcCreatureCardCollectionAttrs)
			{
				WPDCreatureCardCollectionAttr data = new WPDCreatureCardCollectionAttr();
				data.collectionId = Convert.ToInt32(dr["collectionId"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);

				creatureCardCollectionAttrs.Add(data);
			}
			gameDatas.creatureCardCollectionAttrs = creatureCardCollectionAttrs.ToArray();
			creatureCardCollectionAttrs.Clear();

			//
			// 크리처카드콜렉션등급 목록
			//
			List<WPDCreatureCardCollectionGrade> creatureCardCollectionGrades = new List<WPDCreatureCardCollectionGrade>();
			foreach (DataRow dr in drcCreatureCardCollectionGrades)
			{
				WPDCreatureCardCollectionGrade data = new WPDCreatureCardCollectionGrade();
				data.grade = Convert.ToInt32(dr["grade"]);
				data.colorCode = Convert.ToString(dr["colorCode"]);
				data.collectionFamePoint = Convert.ToInt32(dr["collectionFamePoint"]);

				creatureCardCollectionGrades.Add(data);
			}
			gameDatas.creatureCardCollectionGrades = creatureCardCollectionGrades.ToArray();
			creatureCardCollectionGrades.Clear();

			//
			// 크리처카드상점갱신스케줄 목록
			//
			List<WPDCreatureCardShopRefreshSchedule> creatureCardShopRefreshSchedules = new List<WPDCreatureCardShopRefreshSchedule>();
			foreach (DataRow dr in drcCreatureCardShopRefreshSchedules)
			{
				WPDCreatureCardShopRefreshSchedule data = new WPDCreatureCardShopRefreshSchedule();
				data.scheduleId = Convert.ToInt32(dr["scheduleId"]);
				data.refreshTime = Convert.ToInt32(dr["refreshTime"]);

				creatureCardShopRefreshSchedules.Add(data);
			}
			gameDatas.creatureCardShopRefreshSchedules = creatureCardShopRefreshSchedules.ToArray();
			creatureCardShopRefreshSchedules.Clear();

			//
			// 크리처카드상점고정상품 목록
			//
			List<WPDCreatureCardShopFixedProduct> creatureCardShopFixedProducts = new List<WPDCreatureCardShopFixedProduct>();
			foreach (DataRow dr in drcCreatureCardShopFixedProducts)
			{
				WPDCreatureCardShopFixedProduct data = new WPDCreatureCardShopFixedProduct();
				data.productId = Convert.ToInt32(dr["productId"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);
				data.itemOwned = Convert.ToBoolean(dr["itemOwned"]);
				data.saleSoulPowder = Convert.ToInt32(dr["saleSoulPowder"]);

				creatureCardShopFixedProducts.Add(data);
			}
			gameDatas.creatureCardShopFixedProducts = creatureCardShopFixedProducts.ToArray();
			creatureCardShopFixedProducts.Clear();

			//
			// 크리처카드상점랜덤상품 목록
			//
			List<WPDCreatureCardShopRandomProduct> creatureCardShopRandomProducts = new List<WPDCreatureCardShopRandomProduct>();
			foreach (DataRow dr in drcCreatureCardShopRandomProducts)
			{
				WPDCreatureCardShopRandomProduct data = new WPDCreatureCardShopRandomProduct();
				data.productId = Convert.ToInt32(dr["productId"]);
				data.creatureCardId = Convert.ToInt32(dr["creatureCardId"]);

				creatureCardShopRandomProducts.Add(data);
			}
			gameDatas.creatureCardShopRandomProducts = creatureCardShopRandomProducts.ToArray();
			creatureCardShopRandomProducts.Clear();

			//
			// 용맹의증명
			//
			WPDProofOfValor proofOfValor = new WPDProofOfValor();
			if (drProofOfValor != null)
			{
				proofOfValor.nameKey = Convert.ToString(drProofOfValor["nameKey"]);
				proofOfValor.descriptionKey = Convert.ToString(drProofOfValor["descriptionKey"]);
				proofOfValor.requiredConditionType = Convert.ToInt32(drProofOfValor["requiredConditionType"]);
				proofOfValor.requiredHeroLevel = Convert.ToInt32(drProofOfValor["requiredHeroLevel"]);
				proofOfValor.requiredMainQuestNo = Convert.ToInt32(drProofOfValor["requiredMainQuestNo"]);
				proofOfValor.requiredStamina = Convert.ToInt32(drProofOfValor["requiredStamina"]);
				proofOfValor.dailyFreeRefreshCount = Convert.ToInt32(drProofOfValor["dailyFreeRefreshCount"]);
				proofOfValor.dailyPaidRefreshCount = Convert.ToInt32(drProofOfValor["dailyPaidRefreshCount"]);
				proofOfValor.sceneName = Convert.ToString(drProofOfValor["sceneName"]);
				proofOfValor.startDelayTime = Convert.ToInt32(drProofOfValor["startDelayTime"]);
				proofOfValor.limitTime = Convert.ToInt32(drProofOfValor["limitTime"]);
				proofOfValor.exitDelayTime = Convert.ToInt32(drProofOfValor["exitDelayTime"]);
				proofOfValor.startXPosition = Convert.ToSingle(drProofOfValor["startXPosition"]);
				proofOfValor.startYPosition = Convert.ToSingle(drProofOfValor["startYPosition"]);
				proofOfValor.startZPosition = Convert.ToSingle(drProofOfValor["startZPosition"]);
				proofOfValor.startYRotation = Convert.ToSingle(drProofOfValor["startYRotation"]);
				proofOfValor.targetTitleKey = Convert.ToString(drProofOfValor["targetTitleKey"]);
				proofOfValor.targetContentKey = Convert.ToString(drProofOfValor["targetContentKey"]);
				proofOfValor.guideImageName = Convert.ToString(drProofOfValor["guideImageName"]);
				proofOfValor.startGuideTitleKey = Convert.ToString(drProofOfValor["startGuideTitleKey"]);
				proofOfValor.startGuideContentKey = Convert.ToString(drProofOfValor["startGuideContentKey"]);
				proofOfValor.buffBoxCreationGuideTitleKey = Convert.ToString(drProofOfValor["buffBoxCreationGuideTitleKey"]);
				proofOfValor.buffBoxCreationGuideContentKey = Convert.ToString(drProofOfValor["buffBoxCreationGuideContentKey"]);
				proofOfValor.buffBoxCreationTime = Convert.ToInt32(drProofOfValor["buffBoxCreationTime"]);
				proofOfValor.buffBoxCreationInterval = Convert.ToInt32(drProofOfValor["buffBoxCreationInterval"]);
				proofOfValor.buffBoxLifetime = Convert.ToInt32(drProofOfValor["buffBoxLifetime"]);
				proofOfValor.buffDuration = Convert.ToInt32(drProofOfValor["buffDuration"]);
				proofOfValor.failureRewardSoulPowder = Convert.ToInt32(drProofOfValor["failureRewardSoulPowder"]);
				proofOfValor.locationId = Convert.ToInt32(drProofOfValor["locationId"]);
				proofOfValor.x = Convert.ToSingle(drProofOfValor["x"]);
				proofOfValor.z = Convert.ToSingle(drProofOfValor["z"]);
				proofOfValor.xSize = Convert.ToSingle(drProofOfValor["xSize"]);
				proofOfValor.zSize = Convert.ToSingle(drProofOfValor["zSize"]);

			}
			gameDatas.proofOfValor = proofOfValor;

			//
			// 용맹의증명버프상자 목록
			//
			List<WPDProofOfValorBuffBox> proofOfValorBuffBoxs = new List<WPDProofOfValorBuffBox>();
			foreach (DataRow dr in drcProofOfValorBuffBoxs)
			{
				WPDProofOfValorBuffBox data = new WPDProofOfValorBuffBox();
				data.buffBoxId = Convert.ToInt32(dr["buffBoxId"]);
				data.prefabName = Convert.ToString(dr["prefabName"]);
				data.offenseFactor = Convert.ToSingle(dr["offenseFactor"]);
				data.physicalDefenseFactor = Convert.ToSingle(dr["physicalDefenseFactor"]);
				data.hpRecoveryFactor = Convert.ToSingle(dr["hpRecoveryFactor"]);
				data.useGuideTitleKey = Convert.ToString(dr["useGuideTitleKey"]);
				data.useGuideContentKey = Convert.ToString(dr["useGuideContentKey"]);

				proofOfValorBuffBoxs.Add(data);
			}
			gameDatas.proofOfValorBuffBoxs = proofOfValorBuffBoxs.ToArray();
			proofOfValorBuffBoxs.Clear();

			//
			// 용맹의증명버프배치 목록
			//
			List<WPDProofOfValorBuffBoxArrange> proofOfValorBuffBoxArranges = new List<WPDProofOfValorBuffBoxArrange>();
			foreach (DataRow dr in drcProofOfValorBuffBoxArranges)
			{
				WPDProofOfValorBuffBoxArrange data = new WPDProofOfValorBuffBoxArrange();
				data.arrangeId = Convert.ToInt32(dr["arrangeId"]);
				data.buffBoxId = Convert.ToInt32(dr["buffBoxId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.radius = Convert.ToSingle(dr["radius"]);
				data.yRotationType = Convert.ToInt32(dr["yRotationType"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);
				data.acquisitionRange = Convert.ToSingle(dr["acquisitionRange"]);

				proofOfValorBuffBoxArranges.Add(data);
			}
			gameDatas.proofOfValorBuffBoxArranges = proofOfValorBuffBoxArranges.ToArray();
			proofOfValorBuffBoxArranges.Clear();

			//
			// 용맹의증명보스몬스터배치 목록
			//
			List<WPDProofOfValorBossMonsterArrange> proofOfValorBossMonsterArranges = new List<WPDProofOfValorBossMonsterArrange>();
			foreach (DataRow dr in drcProofOfValorBossMonsterArranges)
			{
				WPDProofOfValorBossMonsterArrange data = new WPDProofOfValorBossMonsterArrange();
				data.proofOfValorBossMonsterArrangeId = Convert.ToInt32(dr["proofOfValorBossMonsterArrangeId"]);
				data.isSpecial = Convert.ToBoolean(dr["isSpecial"]);
				data.starGrade = Convert.ToInt32(dr["starGrade"]);
				data.monsterArrangeId = Convert.ToInt64(dr["monsterArrangeId"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.rewardSoulPowder = Convert.ToInt32(dr["rewardSoulPowder"]);
				data.specialRewardSoulPowder = Convert.ToInt32(dr["specialRewardSoulPowder"]);

				proofOfValorBossMonsterArranges.Add(data);
			}
			gameDatas.proofOfValorBossMonsterArranges = proofOfValorBossMonsterArranges.ToArray();
			proofOfValorBossMonsterArranges.Clear();

			//
			// 용맹의증명유료갱신 목록
			//
			List<WPDProofOfValorPaidRefresh> proofOfValorPaidRefreshs = new List<WPDProofOfValorPaidRefresh>();
			foreach (DataRow dr in drcProofOfValorPaidRefreshs)
			{
				WPDProofOfValorPaidRefresh data = new WPDProofOfValorPaidRefresh();
				data.refreshCount = Convert.ToInt32(dr["refreshCount"]);
				data.requiredDia = Convert.ToInt32(dr["requiredDia"]);

				proofOfValorPaidRefreshs.Add(data);
			}
			gameDatas.proofOfValorPaidRefreshs = proofOfValorPaidRefreshs.ToArray();
			proofOfValorPaidRefreshs.Clear();

			//
			// 용맹의증명갱신스케줄 목록
			//
			List<WPDProofOfValorRefreshSchedule> proofOfValorRefreshSchedules = new List<WPDProofOfValorRefreshSchedule>();
			foreach (DataRow dr in drcProofOfValorRefreshSchedules)
			{
				WPDProofOfValorRefreshSchedule data = new WPDProofOfValorRefreshSchedule();
				data.scheduleId = Convert.ToInt32(dr["scheduleId"]);
				data.refreshTime = Convert.ToInt32(dr["refreshTime"]);

				proofOfValorRefreshSchedules.Add(data);
			}
			gameDatas.proofOfValorRefreshSchedules = proofOfValorRefreshSchedules.ToArray();
			proofOfValorRefreshSchedules.Clear();

			//
			// 용맹의증명보상 목록
			//
			List<WPDProofOfValorReward> proofOfValorRewards = new List<WPDProofOfValorReward>();
			foreach (DataRow dr in drcProofOfValorRewards)
			{
				WPDProofOfValorReward data = new WPDProofOfValorReward();
				data.heroLevel = Convert.ToInt32(dr["heroLevel"]);
				data.successExpRewardId = Convert.ToInt64(dr["successExpRewardId"]);
				data.failureExpRewardId = Convert.ToInt64(dr["failureExpRewardId"]);

				proofOfValorRewards.Add(data);
			}
			gameDatas.proofOfValorRewards = proofOfValorRewards.ToArray();
			proofOfValorRewards.Clear();

			//
			// 용맹의증명클리어등급 목록
			//
			List<WPDProofOfValorClearGrade> proofOfValorClearGrades = new List<WPDProofOfValorClearGrade>();
			foreach (DataRow dr in drcProofOfValorClearGrades)
			{
				WPDProofOfValorClearGrade data = new WPDProofOfValorClearGrade();
				data.clearGrade = Convert.ToInt32(dr["clearGrade"]);
				data.minRemainTime = Convert.ToInt32(dr["minRemainTime"]);

				proofOfValorClearGrades.Add(data);
			}
			gameDatas.proofOfValorClearGrades = proofOfValorClearGrades.ToArray();
			proofOfValorClearGrades.Clear();

			//
			// 체력회복스케줄 목록
			//
			List<WPDStaminaRecoverySchedule> staminaRecoverySchedules = new List<WPDStaminaRecoverySchedule>();
			foreach (DataRow dr in drcStaminaRecoverySchedules)
			{
				WPDStaminaRecoverySchedule data = new WPDStaminaRecoverySchedule();
				data.scheduleId = Convert.ToInt32(dr["scheduleId"]);
				data.recoveryTime = Convert.ToInt32(dr["recoveryTime"]);
				data.recoveryStamina = Convert.ToInt32(dr["recoveryStamina"]);

				staminaRecoverySchedules.Add(data);
			}
			gameDatas.staminaRecoverySchedules = staminaRecoverySchedules.ToArray();
			staminaRecoverySchedules.Clear();

			//
			// 금지어 목록
			//
			List<WPDBanWord> banWords = new List<WPDBanWord>();
			foreach (DataRow dr in drcBanWords)
			{
				WPDBanWord data = new WPDBanWord();
				data.type = Convert.ToInt32(dr["type"]);
				data.word = Convert.ToString(dr["word"]);

				banWords.Add(data);
			}
			gameDatas.banWords = banWords.ToArray();
			banWords.Clear();

			//
			// 길드컨텐츠획득가능보상 목록
			//
			List<WPDGuildContentAvailableReward> guildContentAvailableRewards = new List<WPDGuildContentAvailableReward>();
			foreach (DataRow dr in drcGuildContentAvailableRewards)
			{
				WPDGuildContentAvailableReward data = new WPDGuildContentAvailableReward();
				data.guildContentId = Convert.ToInt32(dr["guildContentId"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);

				guildContentAvailableRewards.Add(data);
			}
			gameDatas.guildContentAvailableRewards = guildContentAvailableRewards.ToArray();
			guildContentAvailableRewards.Clear();

			//
			// 메뉴컨텐츠개방미리보기 목록
			//
			List<WPDMenuContentOpenPreview> menuContentOpenPreviews = new List<WPDMenuContentOpenPreview>();
			foreach (DataRow dr in drcMenuContentOpenPreviews)
			{
				WPDMenuContentOpenPreview data = new WPDMenuContentOpenPreview();
				data.previewNo = Convert.ToInt32(dr["previewNo"]);
				data.contentId = Convert.ToInt32(dr["contentId"]);

				menuContentOpenPreviews.Add(data);
			}
			gameDatas.menuContentOpenPreviews = menuContentOpenPreviews.ToArray();
			menuContentOpenPreviews.Clear();

			//
			// 직업공통스킬 목록
			//
			List<WPDJobCommonSkill> jobCommonSkills = new List<WPDJobCommonSkill>();
			foreach (DataRow dr in drcJobCommonSkills)
			{
				WPDJobCommonSkill data = new WPDJobCommonSkill();
				data.skillId = Convert.ToInt32(dr["skillId"]);
				data.openRequiredMainQuestNo = Convert.ToInt32(dr["openRequiredMainQuestNo"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.formType = Convert.ToInt32(dr["formType"]);
				data.isRequireTarget = Convert.ToBoolean(dr["isRequireTarget"]);
				data.castRange = Convert.ToSingle(dr["castRange"]);
				data.hitRange = Convert.ToSingle(dr["hitRange"]);
				data.coolTime = Convert.ToSingle(dr["coolTime"]);
				data.hitAreaType = Convert.ToInt32(dr["hitAreaType"]);
				data.hitAreaValue1 = Convert.ToSingle(dr["hitAreaValue1"]);
				data.hitAreaValue2 = Convert.ToSingle(dr["hitAreaValue2"]);
				data.hitAreaOffsetType = Convert.ToInt32(dr["hitAreaOffsetType"]);
				data.hitAreaOffset = Convert.ToSingle(dr["hitAreaOffset"]);
				data.slotIndex = Convert.ToInt32(dr["slotIndex"]);
				data.clientSkillIndex = Convert.ToInt32(dr["clientSkillIndex"]);
				data.mentalStrengthDamage = Convert.ToInt32(dr["mentalStrengthDamage"]);
				data.buffAbnormalStateId = Convert.ToInt32(dr["buffAbnormalStateId"]);

				jobCommonSkills.Add(data);
			}
			gameDatas.jobCommonSkills = jobCommonSkills.ToArray();
			jobCommonSkills.Clear();

			//
			// NPC상점 목록
			//
			List<WPDNpcShop> npcShops = new List<WPDNpcShop>();
			foreach (DataRow dr in drcNpcShops)
			{
				WPDNpcShop data = new WPDNpcShop();
				data.shopId = Convert.ToInt32(dr["shopId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.npcId = Convert.ToInt32(dr["npcId"]);

				npcShops.Add(data);
			}
			gameDatas.npcShops = npcShops.ToArray();
			npcShops.Clear();

			//
			// NPC상점카테고리 목록
			//
			List<WPDNpcShopCategory> npcShopCategories = new List<WPDNpcShopCategory>();
			foreach (DataRow dr in drcNpcShopCategories)
			{
				WPDNpcShopCategory data = new WPDNpcShopCategory();
				data.shopId = Convert.ToInt32(dr["shopId"]);
				data.categoryId = Convert.ToInt32(dr["categoryId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.requiredItemId = Convert.ToInt32(dr["requiredItemId"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);

				npcShopCategories.Add(data);
			}
			gameDatas.npcShopCategories = npcShopCategories.ToArray();
			npcShopCategories.Clear();

			//
			// NPC상점상품 목록
			//
			List<WPDNpcShopProduct> npcShopProducts = new List<WPDNpcShopProduct>();
			foreach (DataRow dr in drcNpcShopProducts)
			{
				WPDNpcShopProduct data = new WPDNpcShopProduct();
				data.productId = Convert.ToInt32(dr["productId"]);
				data.shopId = Convert.ToInt32(dr["shopId"]);
				data.categoryId = Convert.ToInt32(dr["categoryId"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);
				data.itemOwned = Convert.ToBoolean(dr["itemOwned"]);
				data.requiredItemCount = Convert.ToInt32(dr["requiredItemCount"]);
				data.limitCount = Convert.ToInt32(dr["limitCount"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);

				npcShopProducts.Add(data);
			}
			gameDatas.npcShopProducts = npcShopProducts.ToArray();
			npcShopProducts.Clear();

			//
			// 상태이상계급스킬레벨 목록
			//
			List<WPDAbnormalStateRankSkillLevel> abnormalStateRankSkillLevels = new List<WPDAbnormalStateRankSkillLevel>();
			foreach (DataRow dr in drcAbnormalStateRankSkillLevels)
			{
				WPDAbnormalStateRankSkillLevel data = new WPDAbnormalStateRankSkillLevel();
				data.abnormalStateId = Convert.ToInt32(dr["abnormalStateId"]);
				data.skillLevel = Convert.ToInt32(dr["skillLevel"]);
				data.duration = Convert.ToInt32(dr["duration"]);
				data.value1 = Convert.ToInt32(dr["value1"]);
				data.value2 = Convert.ToInt32(dr["value2"]);
				data.value3 = Convert.ToInt32(dr["value3"]);
				data.value4 = Convert.ToInt32(dr["value4"]);
				data.value5 = Convert.ToInt32(dr["value5"]);
				data.value6 = Convert.ToInt32(dr["value6"]);

				abnormalStateRankSkillLevels.Add(data);
			}
			gameDatas.abnormalStateRankSkillLevels = abnormalStateRankSkillLevels.ToArray();
			abnormalStateRankSkillLevels.Clear();

			//
			// 계급액티브스킬 목록
			//
			List<WPDRankActiveSkill> rankActiveSkills = new List<WPDRankActiveSkill>();
			foreach (DataRow dr in drcRankActiveSkills)
			{
				WPDRankActiveSkill data = new WPDRankActiveSkill();
				data.skillId = Convert.ToInt32(dr["skillId"]);
				data.requiredRankNo = Convert.ToInt32(dr["requiredRankNo"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.imageName = Convert.ToString(dr["imageName"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.coolTime = Convert.ToSingle(dr["coolTime"]);
				data.castRange = Convert.ToSingle(dr["castRange"]);
				data.abnormalStateId = Convert.ToInt32(dr["abnormalStateId"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);

				rankActiveSkills.Add(data);
			}
			gameDatas.rankActiveSkills = rankActiveSkills.ToArray();
			rankActiveSkills.Clear();

			//
			// 계급액티브스킬레벨 목록
			//
			List<WPDRankActiveSkillLevel> rankActiveSkillLevels = new List<WPDRankActiveSkillLevel>();
			foreach (DataRow dr in drcRankActiveSkillLevels)
			{
				WPDRankActiveSkillLevel data = new WPDRankActiveSkillLevel();
				data.skillId = Convert.ToInt32(dr["skillId"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.effectDescriptionKey = Convert.ToString(dr["effectDescriptionKey"]);
				data.nextLevelUpRequiredGold = Convert.ToInt64(dr["nextLevelUpRequiredGold"]);
				data.nextLevelUpRequiredItemId = Convert.ToInt32(dr["nextLevelUpRequiredItemId"]);
				data.nextLevelUpRequiredItemCount = Convert.ToInt32(dr["nextLevelUpRequiredItemCount"]);

				rankActiveSkillLevels.Add(data);
			}
			gameDatas.rankActiveSkillLevels = rankActiveSkillLevels.ToArray();
			rankActiveSkillLevels.Clear();

			//
			// 계급패시브스킬 목록
			//
			List<WPDRankPassiveSkill> rankPassiveSkills = new List<WPDRankPassiveSkill>();
			foreach (DataRow dr in drcRankPassiveSkills)
			{
				WPDRankPassiveSkill data = new WPDRankPassiveSkill();
				data.skillId = Convert.ToInt32(dr["skillId"]);
				data.requiredRankNo = Convert.ToInt32(dr["requiredRankNo"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.imageName = Convert.ToString(dr["imageName"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);

				rankPassiveSkills.Add(data);
			}
			gameDatas.rankPassiveSkills = rankPassiveSkills.ToArray();
			rankPassiveSkills.Clear();

			//
			// 계급패시브스킬속성 목록
			//
			List<WPDRankPassiveSkillAttr> rankPassiveSkillAttrs = new List<WPDRankPassiveSkillAttr>();
			foreach (DataRow dr in drcRankPassiveSkillAttrs)
			{
				WPDRankPassiveSkillAttr data = new WPDRankPassiveSkillAttr();
				data.skillId = Convert.ToInt32(dr["skillId"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);

				rankPassiveSkillAttrs.Add(data);
			}
			gameDatas.rankPassiveSkillAttrs = rankPassiveSkillAttrs.ToArray();
			rankPassiveSkillAttrs.Clear();

			//
			// 계급패시브스킬레벨 목록
			//
			List<WPDRankPassiveSkillLevel> rankPassiveSkillLevels = new List<WPDRankPassiveSkillLevel>();
			foreach (DataRow dr in drcRankPassiveSkillLevels)
			{
				WPDRankPassiveSkillLevel data = new WPDRankPassiveSkillLevel();
				data.skillId = Convert.ToInt32(dr["skillId"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.effectDescriptionKey = Convert.ToString(dr["effectDescriptionKey"]);
				data.nextLevelUpRequiredGold = Convert.ToInt64(dr["nextLevelUpRequiredGold"]);
				data.nextLevelUpRequiredSpiritStone = Convert.ToInt32(dr["nextLevelUpRequiredSpiritStone"]);

				rankPassiveSkillLevels.Add(data);
			}
			gameDatas.rankPassiveSkillLevels = rankPassiveSkillLevels.ToArray();
			rankPassiveSkillLevels.Clear();

			//
			// 계급패시브스킬속성레벨 목록
			//
			List<WPDRankPassiveSkillAttrLevel> rankPassiveSkillAttrLevels = new List<WPDRankPassiveSkillAttrLevel>();
			foreach (DataRow dr in drcRankPassiveSkillAttrLevels)
			{
				WPDRankPassiveSkillAttrLevel data = new WPDRankPassiveSkillAttrLevel();
				data.skillId = Convert.ToInt32(dr["skillId"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);

				rankPassiveSkillAttrLevels.Add(data);
			}
			gameDatas.rankPassiveSkillAttrLevels = rankPassiveSkillAttrLevels.ToArray();
			rankPassiveSkillAttrLevels.Clear();

			//
			// 지혜의신전
			//
			WPDWisdomTemple wisdomTemple = new WPDWisdomTemple();
			if (drWisdomTemple != null)
			{
				wisdomTemple.nameKey = Convert.ToString(drWisdomTemple["nameKey"]);
				wisdomTemple.descriptionKey = Convert.ToString(drWisdomTemple["descriptionKey"]);
				wisdomTemple.sceneName = Convert.ToString(drWisdomTemple["sceneName"]);
				wisdomTemple.requiredConditionType = Convert.ToInt32(drWisdomTemple["requiredConditionType"]);
				wisdomTemple.requiredHeroLevel = Convert.ToInt32(drWisdomTemple["requiredHeroLevel"]);
				wisdomTemple.requiredMainQuestNo = Convert.ToInt32(drWisdomTemple["requiredMainQuestNo"]);
				wisdomTemple.requiredStamina = Convert.ToInt32(drWisdomTemple["requiredStamina"]);
				wisdomTemple.startDelayTime = Convert.ToInt32(drWisdomTemple["startDelayTime"]);
				wisdomTemple.limitTime = Convert.ToInt32(drWisdomTemple["limitTime"]);
				wisdomTemple.exitDelayTime = Convert.ToInt32(drWisdomTemple["exitDelayTime"]);
				wisdomTemple.startXPosition = Convert.ToSingle(drWisdomTemple["startXPosition"]);
				wisdomTemple.startYPosition = Convert.ToSingle(drWisdomTemple["startYPosition"]);
				wisdomTemple.startZPosition = Convert.ToSingle(drWisdomTemple["startZPosition"]);
				wisdomTemple.startYRotation = Convert.ToSingle(drWisdomTemple["startYRotation"]);
				wisdomTemple.availableRewardItemId = Convert.ToInt32(drWisdomTemple["availableRewardItemId"]);
				wisdomTemple.guideImageName = Convert.ToString(drWisdomTemple["guideImageName"]);
				wisdomTemple.colorMatchingPoint = Convert.ToInt32(drWisdomTemple["colorMatchingPoint"]);
				wisdomTemple.colorMatchingObjectivePoint = Convert.ToInt32(drWisdomTemple["colorMatchingObjectivePoint"]);
				wisdomTemple.colorMatchingMonsterSpawnInterval = Convert.ToInt32(drWisdomTemple["colorMatchingMonsterSpawnInterval"]);
				wisdomTemple.colorMatchingMonsterArrangeId = Convert.ToInt64(drWisdomTemple["colorMatchingMonsterArrangeId"]);
				wisdomTemple.colorMatchingMonsterXPosition = Convert.ToSingle(drWisdomTemple["colorMatchingMonsterXPosition"]);
				wisdomTemple.colorMatchingMonsterYPosition = Convert.ToSingle(drWisdomTemple["colorMatchingMonsterYPosition"]);
				wisdomTemple.colorMatchingMonsterZPosition = Convert.ToSingle(drWisdomTemple["colorMatchingMonsterZPosition"]);
				wisdomTemple.colorMatchingMonsterYRotationType = Convert.ToInt32(drWisdomTemple["colorMatchingMonsterYRotationType"]);
				wisdomTemple.colorMatchingMonsterYRotation = Convert.ToSingle(drWisdomTemple["colorMatchingMonsterYRotation"]);
				wisdomTemple.colorMatchingMonsterKillPoint = Convert.ToInt32(drWisdomTemple["colorMatchingMonsterKillPoint"]);
				wisdomTemple.colorMatchingMonsterKillObjectId = Convert.ToInt32(drWisdomTemple["colorMatchingMonsterKillObjectId"]);
				wisdomTemple.colorMatchingMonsterSpawnGuideTitleKey = Convert.ToString(drWisdomTemple["colorMatchingMonsterSpawnGuideTitleKey"]);
				wisdomTemple.colorMatchingMonsterSpawnGuideContentKey = Convert.ToString(drWisdomTemple["colorMatchingMonsterSpawnGuideContentKey"]);
				wisdomTemple.findTreasureBoxMonsterArrangeId = Convert.ToInt64(drWisdomTemple["findTreasureBoxMonsterArrangeId"]);
				wisdomTemple.findTreasureBoxSuccessGuideTitleKey = Convert.ToString(drWisdomTemple["findTreasureBoxSuccessGuideTitleKey"]);
				wisdomTemple.findTreasureBoxSuccessGuideContentKey = Convert.ToString(drWisdomTemple["findTreasureBoxSuccessGuideContentKey"]);
				wisdomTemple.puzzleRewardTargetTitleKey = Convert.ToString(drWisdomTemple["puzzleRewardTargetTitleKey"]);
				wisdomTemple.puzzleRewardTargetContentKey = Convert.ToString(drWisdomTemple["puzzleRewardTargetContentKey"]);
				wisdomTemple.puzzleRewardGuideTitleKey = Convert.ToString(drWisdomTemple["puzzleRewardGuideTitleKey"]);
				wisdomTemple.puzzleRewardGuideContentKey = Convert.ToString(drWisdomTemple["puzzleRewardGuideContentKey"]);
				wisdomTemple.puzzleRewardObjectPrefabName = Convert.ToString(drWisdomTemple["puzzleRewardObjectPrefabName"]);
				wisdomTemple.puzzleRewardObjectInteractionDuration = Convert.ToSingle(drWisdomTemple["puzzleRewardObjectInteractionDuration"]);
				wisdomTemple.puzzleRewardObjectInteractionMaxRange = Convert.ToSingle(drWisdomTemple["puzzleRewardObjectInteractionMaxRange"]);
				wisdomTemple.puzzleRewardObjectScale = Convert.ToSingle(drWisdomTemple["puzzleRewardObjectScale"]);
				wisdomTemple.puzzleRewardObjectHeight = Convert.ToInt32(drWisdomTemple["puzzleRewardObjectHeight"]);
				wisdomTemple.puzzleRewardObjectRadius = Convert.ToSingle(drWisdomTemple["puzzleRewardObjectRadius"]);
				wisdomTemple.quizRightAnswerGuideTitleKey = Convert.ToString(drWisdomTemple["quizRightAnswerGuideTitleKey"]);
				wisdomTemple.quizRightAnswerGuideContentKey = Convert.ToString(drWisdomTemple["quizRightAnswerGuideContentKey"]);
				wisdomTemple.quizWrongAnswerGuideTitleKey = Convert.ToString(drWisdomTemple["quizWrongAnswerGuideTitleKey"]);
				wisdomTemple.quizWrongAnswerGuideContentKey = Convert.ToString(drWisdomTemple["quizWrongAnswerGuideContentKey"]);
				wisdomTemple.bossMonsterSpawnDelayTime = Convert.ToInt32(drWisdomTemple["bossMonsterSpawnDelayTime"]);
				wisdomTemple.bossMonsterArrangeId = Convert.ToInt64(drWisdomTemple["bossMonsterArrangeId"]);
				wisdomTemple.bossMonsterXPosition = Convert.ToSingle(drWisdomTemple["bossMonsterXPosition"]);
				wisdomTemple.bossMonsterYPosition = Convert.ToSingle(drWisdomTemple["bossMonsterYPosition"]);
				wisdomTemple.bossMonsterZPosition = Convert.ToSingle(drWisdomTemple["bossMonsterZPosition"]);
				wisdomTemple.bossMonsterYRotation = Convert.ToSingle(drWisdomTemple["bossMonsterYRotation"]);
				wisdomTemple.bossMonsterTargetTitleKey = Convert.ToString(drWisdomTemple["bossMonsterTargetTitleKey"]);
				wisdomTemple.bossMonsterTargetContentKey = Convert.ToString(drWisdomTemple["bossMonsterTargetContentKey"]);
				wisdomTemple.bossMonsterSpawnGuideTitleKey = Convert.ToString(drWisdomTemple["bossMonsterSpawnGuideTitleKey"]);
				wisdomTemple.bossMonsterSpawnGuideContentKey = Convert.ToString(drWisdomTemple["bossMonsterSpawnGuideContentKey"]);
				wisdomTemple.bossMonsterKillItemRewardId = Convert.ToInt64(drWisdomTemple["bossMonsterKillItemRewardId"]);
				wisdomTemple.sweepItemRewardId = Convert.ToInt64(drWisdomTemple["sweepItemRewardId"]);
				wisdomTemple.locationId = Convert.ToInt32(drWisdomTemple["locationId"]);
				wisdomTemple.x = Convert.ToSingle(drWisdomTemple["x"]);
				wisdomTemple.z = Convert.ToSingle(drWisdomTemple["z"]);
				wisdomTemple.xSize = Convert.ToSingle(drWisdomTemple["xSize"]);
				wisdomTemple.zSize = Convert.ToSingle(drWisdomTemple["zSize"]);

			}
			gameDatas.wisdomTemple = wisdomTemple;

			//
			// 지혜의신전몬스터속성계수 목록
			//
			List<WPDWisdomTempleMonsterAttrFactor> wisdomTempleMonsterAttrFactors = new List<WPDWisdomTempleMonsterAttrFactor>();
			foreach (DataRow dr in drcWisdomTempleMonsterAttrFactors)
			{
				WPDWisdomTempleMonsterAttrFactor data = new WPDWisdomTempleMonsterAttrFactor();
				data.level = Convert.ToInt32(dr["level"]);
				data.maxHpFactor = Convert.ToSingle(dr["maxHpFactor"]);
				data.offenseFactor = Convert.ToSingle(dr["offenseFactor"]);

				wisdomTempleMonsterAttrFactors.Add(data);
			}
			gameDatas.wisdomTempleMonsterAttrFactors = wisdomTempleMonsterAttrFactors.ToArray();
			wisdomTempleMonsterAttrFactors.Clear();

			//
			// 지혜의신전색맞추기오브젝트 목록
			//
			List<WPDWisdomTempleColorMatchingObject> wisdomTempleColorMatchingObjects = new List<WPDWisdomTempleColorMatchingObject>();
			foreach (DataRow dr in drcWisdomTempleColorMatchingObjects)
			{
				WPDWisdomTempleColorMatchingObject data = new WPDWisdomTempleColorMatchingObject();
				data.objectId = Convert.ToInt32(dr["objectId"]);
				data.prefabName = Convert.ToString(dr["prefabName"]);
				data.interactionDuration = Convert.ToSingle(dr["interactionDuration"]);
				data.interactionMaxRange = Convert.ToSingle(dr["interactionMaxRange"]);
				data.scale = Convert.ToSingle(dr["scale"]);
				data.height = Convert.ToInt32(dr["height"]);
				data.radius = Convert.ToSingle(dr["radius"]);

				wisdomTempleColorMatchingObjects.Add(data);
			}
			gameDatas.wisdomTempleColorMatchingObjects = wisdomTempleColorMatchingObjects.ToArray();
			wisdomTempleColorMatchingObjects.Clear();

			//
			// 지혜의신전배치위치 목록
			//
			List<WPDWisdomTempleArrangePosition> wisdomTempleArrangePositions = new List<WPDWisdomTempleArrangePosition>();
			foreach (DataRow dr in drcWisdomTempleArrangePositions)
			{
				WPDWisdomTempleArrangePosition data = new WPDWisdomTempleArrangePosition();
				data.row = Convert.ToInt32(dr["row"]);
				data.col = Convert.ToInt32(dr["col"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);

				wisdomTempleArrangePositions.Add(data);
			}
			gameDatas.wisdomTempleArrangePositions = wisdomTempleArrangePositions.ToArray();
			wisdomTempleArrangePositions.Clear();

			//
			// 지혜의신전소탕보상 목록
			//
			List<WPDWisdomTempleSweepReward> wisdomTempleSweepRewards = new List<WPDWisdomTempleSweepReward>();
			foreach (DataRow dr in drcWisdomTempleSweepRewards)
			{
				WPDWisdomTempleSweepReward data = new WPDWisdomTempleSweepReward();
				data.level = Convert.ToInt32(dr["level"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);

				wisdomTempleSweepRewards.Add(data);
			}
			gameDatas.wisdomTempleSweepRewards = wisdomTempleSweepRewards.ToArray();
			wisdomTempleSweepRewards.Clear();

			//
			// 지혜의신전단계 목록
			//
			List<WPDWisdomTempleStep> wisdomTempleSteps = new List<WPDWisdomTempleStep>();
			foreach (DataRow dr in drcWisdomTempleSteps)
			{
				WPDWisdomTempleStep data = new WPDWisdomTempleStep();
				data.stepNo = Convert.ToInt32(dr["stepNo"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);
				data.guideTitleKey = Convert.ToString(dr["guideTitleKey"]);
				data.guideContentKey = Convert.ToString(dr["guideContentKey"]);
				data.startDelayTime = Convert.ToInt32(dr["startDelayTime"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				wisdomTempleSteps.Add(data);
			}
			gameDatas.wisdomTempleSteps = wisdomTempleSteps.ToArray();
			wisdomTempleSteps.Clear();

			//
			// 지혜의신전단계퀴즈위치 목록
			//
			List<WPDWisdomTempleQuizMonsterPosition> wisdomTempleQuizMonsterPositions = new List<WPDWisdomTempleQuizMonsterPosition>();
			foreach (DataRow dr in drcWisdomTempleQuizMonsterPositions)
			{
				WPDWisdomTempleQuizMonsterPosition data = new WPDWisdomTempleQuizMonsterPosition();
				data.stepNo = Convert.ToInt32(dr["stepNo"]);
				data.row = Convert.ToInt32(dr["row"]);
				data.col = Convert.ToInt32(dr["col"]);

				wisdomTempleQuizMonsterPositions.Add(data);
			}
			gameDatas.wisdomTempleQuizMonsterPositions = wisdomTempleQuizMonsterPositions.ToArray();
			wisdomTempleQuizMonsterPositions.Clear();

			//
			// 지혜의신전퀴즈풀항목 목록
			//
			List<WPDWisdomTempleQuizPoolEntry> wisdomTempleQuizPoolEntries = new List<WPDWisdomTempleQuizPoolEntry>();
			foreach (DataRow dr in drcWisdomTempleQuizPoolEntries)
			{
				WPDWisdomTempleQuizPoolEntry data = new WPDWisdomTempleQuizPoolEntry();
				data.stepNo = Convert.ToInt32(dr["stepNo"]);
				data.quizNo = Convert.ToInt32(dr["quizNo"]);
				data.questionKey = Convert.ToString(dr["questionKey"]);

				wisdomTempleQuizPoolEntries.Add(data);
			}
			gameDatas.wisdomTempleQuizPoolEntries = wisdomTempleQuizPoolEntries.ToArray();
			wisdomTempleQuizPoolEntries.Clear();

			//
			// 지혜의신전퍼즐 목록
			//
			List<WPDWisdomTemplePuzzle> wisdomTemplePuzzles = new List<WPDWisdomTemplePuzzle>();
			foreach (DataRow dr in drcWisdomTemplePuzzles)
			{
				WPDWisdomTemplePuzzle data = new WPDWisdomTemplePuzzle();
				data.puzzleId = Convert.ToInt32(dr["puzzleId"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);

				wisdomTemplePuzzles.Add(data);
			}
			gameDatas.wisdomTemplePuzzles = wisdomTemplePuzzles.ToArray();
			wisdomTemplePuzzles.Clear();

			//
			// 지혜의신전단계보상 목록
			//
			List<WPDWisdomTempleStepReward> wisdomTempleStepRewards = new List<WPDWisdomTempleStepReward>();
			foreach (DataRow dr in drcWisdomTempleStepRewards)
			{
				WPDWisdomTempleStepReward data = new WPDWisdomTempleStepReward();
				data.level = Convert.ToInt32(dr["level"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);

				wisdomTempleStepRewards.Add(data);
			}
			gameDatas.wisdomTempleStepRewards = wisdomTempleStepRewards.ToArray();
			wisdomTempleStepRewards.Clear();

			//
			// 신병선물 목록
			//
			List<WPDRookieGift> rookieGifts = new List<WPDRookieGift>();
			foreach (DataRow dr in drcRookieGifts)
			{
				WPDRookieGift data = new WPDRookieGift();
				data.giftNo = Convert.ToInt32(dr["giftNo"]);
				data.waitingTime = Convert.ToInt32(dr["waitingTime"]);

				rookieGifts.Add(data);
			}
			gameDatas.rookieGifts = rookieGifts.ToArray();
			rookieGifts.Clear();

			//
			// 신병선물보상 목록
			//
			List<WPDRookieGiftReward> rookieGiftRewards = new List<WPDRookieGiftReward>();
			foreach (DataRow dr in drcRookieGiftRewards)
			{
				WPDRookieGiftReward data = new WPDRookieGiftReward();
				data.giftNo = Convert.ToInt32(dr["giftNo"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				rookieGiftRewards.Add(data);
			}
			gameDatas.rookieGiftRewards = rookieGiftRewards.ToArray();
			rookieGiftRewards.Clear();

			//
			// 오픈선물보상 목록
			//
			List<WPDOpenGiftReward> openGiftRewards = new List<WPDOpenGiftReward>();
			foreach (DataRow dr in drcOpenGiftRewards)
			{
				WPDOpenGiftReward data = new WPDOpenGiftReward();
				data.day = Convert.ToInt32(dr["day"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				openGiftRewards.Add(data);
			}
			gameDatas.openGiftRewards = openGiftRewards.ToArray();
			openGiftRewards.Clear();

			//
			// 퀵메뉴 목록
			//
			List<WPDQuickMenu> quickMenus = new List<WPDQuickMenu>();
			foreach (DataRow dr in drcQuickMenus)
			{
				WPDQuickMenu data = new WPDQuickMenu();
				data.menuId = Convert.ToInt32(dr["menuId"]);
				data.imageName = Convert.ToString(dr["imageName"]);
				data.itemType = Convert.ToInt32(dr["itemType"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);

				quickMenus.Add(data);
			}
			gameDatas.quickMenus = quickMenus.ToArray();
			quickMenus.Clear();

			//
			// 일일퀘스트
			//
			WPDDailyQuest dailyQuest = new WPDDailyQuest();
			if (drDailyQuest != null)
			{
				dailyQuest.titleKey = Convert.ToString(drDailyQuest["titleKey"]);
				dailyQuest.playCount = Convert.ToInt32(drDailyQuest["playCount"]);
				dailyQuest.requiredHeroLevel = Convert.ToInt32(drDailyQuest["requiredHeroLevel"]);
				dailyQuest.freeRefreshCount = Convert.ToInt32(drDailyQuest["freeRefreshCount"]);
				dailyQuest.refreshRequiredGold = Convert.ToInt32(drDailyQuest["refreshRequiredGold"]);
				dailyQuest.slotCount = Convert.ToInt32(drDailyQuest["slotCount"]);

			}
			gameDatas.dailyQuest = dailyQuest;

			//
			// 일일퀘스트보상 목록
			//
			List<WPDDailyQuestReward> dailyQuestRewards = new List<WPDDailyQuestReward>();
			foreach (DataRow dr in drcDailyQuestRewards)
			{
				WPDDailyQuestReward data = new WPDDailyQuestReward();
				data.level = Convert.ToInt32(dr["level"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);

				dailyQuestRewards.Add(data);
			}
			gameDatas.dailyQuestRewards = dailyQuestRewards.ToArray();
			dailyQuestRewards.Clear();

			//
			// 일일퀘스트등급 목록
			//
			List<WPDDailyQuestGrade> dailyQuestGrades = new List<WPDDailyQuestGrade>();
			foreach (DataRow dr in drcDailyQuestGrades)
			{
				WPDDailyQuestGrade data = new WPDDailyQuestGrade();
				data.grade = Convert.ToInt32(dr["grade"]);
				data.point = Convert.ToInt32(dr["point"]);
				data.colorCode = Convert.ToString(dr["colorCode"]);
				data.immediateCompletionRequiredGold = Convert.ToInt32(dr["immediateCompletionRequiredGold"]);
				data.autoCompletionRequiredTime = Convert.ToInt32(dr["autoCompletionRequiredTime"]);
				data.rewardVipPoint = Convert.ToInt32(dr["rewardVipPoint"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);
				data.availableItemRewardId1 = Convert.ToInt64(dr["availableItemRewardId1"]);
				data.availableItemRewardId2 = Convert.ToInt64(dr["availableItemRewardId2"]);

				dailyQuestGrades.Add(data);
			}
			gameDatas.dailyQuestGrades = dailyQuestGrades.ToArray();
			dailyQuestGrades.Clear();

			//
			// 일일퀘스트미션 목록
			//
			List<WPDDailyQuestMission> dailyQuestMissions = new List<WPDDailyQuestMission>();
			foreach (DataRow dr in drcDailyQuestMissions)
			{
				WPDDailyQuestMission data = new WPDDailyQuestMission();
				data.missionId = Convert.ToInt32(dr["missionId"]);
				data.titleKey = Convert.ToString(dr["titleKey"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);
				data.targetDescriptionKey = Convert.ToString(dr["targetDescriptionKey"]);
				data.requiredHeroLevel = Convert.ToInt32(dr["requiredHeroLevel"]);
				data.grade = Convert.ToInt32(dr["grade"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.targetContinentId = Convert.ToInt32(dr["targetContinentId"]);
				data.targetXPosotion = Convert.ToSingle(dr["targetXPosotion"]);
				data.targetYPosition = Convert.ToSingle(dr["targetYPosition"]);
				data.targetZPosition = Convert.ToSingle(dr["targetZPosition"]);
				data.targetRadius = Convert.ToSingle(dr["targetRadius"]);
				data.targetMonsterId = Convert.ToInt32(dr["targetMonsterId"]);
				data.targetContinentObjectId = Convert.ToInt32(dr["targetContinentObjectId"]);
				data.targetCount = Convert.ToInt32(dr["targetCount"]);

				dailyQuestMissions.Add(data);
			}
			gameDatas.dailyQuestMissions = dailyQuestMissions.ToArray();
			dailyQuestMissions.Clear();

			//
			// 주간퀘스트
			//
			WPDWeeklyQuest weeklyQuest = new WPDWeeklyQuest();
			if (drWeeklyQuest != null)
			{
				weeklyQuest.titleKey = Convert.ToString(drWeeklyQuest["titleKey"]);
				weeklyQuest.roundCount = Convert.ToInt32(drWeeklyQuest["roundCount"]);
				weeklyQuest.requiredHeroLevel = Convert.ToInt32(drWeeklyQuest["requiredHeroLevel"]);
				weeklyQuest.roundRefreshRequiredGold = Convert.ToInt32(drWeeklyQuest["roundRefreshRequiredGold"]);
				weeklyQuest.roundImmediateCompletionRequiredItemId = Convert.ToInt32(drWeeklyQuest["roundImmediateCompletionRequiredItemId"]);
				weeklyQuest.tenRoundCompletionRequiredVipLevel = Convert.ToInt32(drWeeklyQuest["tenRoundCompletionRequiredVipLevel"]);
				weeklyQuest.tenRoundCompletionRewardFactor = Convert.ToSingle(drWeeklyQuest["tenRoundCompletionRewardFactor"]);
			}
			gameDatas.weeklyQuest = weeklyQuest;

			//
			// 주간퀘스트라운드보상 목록
			//
			List<WPDWeeklyQuestRoundReward> weeklyQuestRoundRewards = new List<WPDWeeklyQuestRoundReward>();
			foreach (DataRow dr in drcWeeklyQuestRoundRewards)
			{
				WPDWeeklyQuestRoundReward data = new WPDWeeklyQuestRoundReward();
				data.roundNo = Convert.ToInt32(dr["roundNo"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);
				data.goldRewardId = Convert.ToInt64(dr["goldRewardId"]);

				weeklyQuestRoundRewards.Add(data);
			}
			gameDatas.weeklyQuestRoundRewards = weeklyQuestRoundRewards.ToArray();
			weeklyQuestRoundRewards.Clear();

			//
			// 주간퀘스트미션 목록
			//
			List<WPDWeeklyQuestMission> weeklyQuestMissions = new List<WPDWeeklyQuestMission>();
			foreach (DataRow dr in drcWeeklyQuestMissions)
			{
				WPDWeeklyQuestMission data = new WPDWeeklyQuestMission();
				data.missionId = Convert.ToInt32(dr["missionId"]);
				data.minHeroLevel = Convert.ToInt32(dr["minHeroLevel"]);
				data.maxHeroLevel = Convert.ToInt32(dr["maxHeroLevel"]);
				data.titleKey = Convert.ToString(dr["titleKey"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);
				data.targetDescriptionKey = Convert.ToString(dr["targetDescriptionKey"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.targetContinentId = Convert.ToInt32(dr["targetContinentId"]);
				data.targetXPosition = Convert.ToSingle(dr["targetXPosition"]);
				data.targetYPosition = Convert.ToSingle(dr["targetYPosition"]);
				data.targetZPosition = Convert.ToSingle(dr["targetZPosition"]);
				data.targetRadius = Convert.ToSingle(dr["targetRadius"]);
				data.targetMonsterId = Convert.ToInt32(dr["targetMonsterId"]);
				data.targetContinentObjectId = Convert.ToInt32(dr["targetContinentObjectId"]);
				data.targetCount = Convert.ToInt32(dr["targetCount"]);

				weeklyQuestMissions.Add(data);
			}
			gameDatas.weeklyQuestMissions = weeklyQuestMissions.ToArray();
			weeklyQuestMissions.Clear();

			//
			// 주간퀘스트10라운드보상 목록
			//
			List<WPDWeeklyQuestTenRoundReward> weeklyQuestTenRoundRewards = new List<WPDWeeklyQuestTenRoundReward>();
			foreach (DataRow dr in drcWeeklyQuestTenRoundRewards)
			{
				WPDWeeklyQuestTenRoundReward data = new WPDWeeklyQuestTenRoundReward();
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				weeklyQuestTenRoundRewards.Add(data);
			}
			gameDatas.weeklyQuestTenRoundRewards = weeklyQuestTenRoundRewards.ToArray();
			weeklyQuestTenRoundRewards.Clear();

			//
			// 유적탈환
			//
			WPDRuinsReclaim ruinsReclaim = new WPDRuinsReclaim();
			if (drRuinsReclaim != null)
			{
				ruinsReclaim.nameKey = Convert.ToString(drRuinsReclaim["nameKey"]);
				ruinsReclaim.descriptionKey = Convert.ToString(drRuinsReclaim["descriptionKey"]);
				ruinsReclaim.sceneName = Convert.ToString(drRuinsReclaim["sceneName"]);
				ruinsReclaim.requiredConditionType = Convert.ToInt32(drRuinsReclaim["requiredConditionType"]);
				ruinsReclaim.requiredHeroLevel = Convert.ToInt32(drRuinsReclaim["requiredHeroLevel"]);
				ruinsReclaim.requiredMainQuestNo = Convert.ToInt32(drRuinsReclaim["requiredMainQuestNo"]);
				ruinsReclaim.freeEnterCount = Convert.ToInt32(drRuinsReclaim["freeEnterCount"]);
				ruinsReclaim.enterRequiredItemId = Convert.ToInt32(drRuinsReclaim["enterRequiredItemId"]);
				ruinsReclaim.enterMinMemberCount = Convert.ToInt32(drRuinsReclaim["enterMinMemberCount"]);
				ruinsReclaim.enterMaxMemberCount = Convert.ToInt32(drRuinsReclaim["enterMaxMemberCount"]);
				ruinsReclaim.matchingWaitingTime = Convert.ToInt32(drRuinsReclaim["matchingWaitingTime"]);
				ruinsReclaim.enterWaitingTime = Convert.ToInt32(drRuinsReclaim["enterWaitingTime"]);
				ruinsReclaim.startDelayTime = Convert.ToInt32(drRuinsReclaim["startDelayTime"]);
				ruinsReclaim.limitTime = Convert.ToInt32(drRuinsReclaim["limitTime"]);
				ruinsReclaim.exitDelayTime = Convert.ToInt32(drRuinsReclaim["exitDelayTime"]);
				ruinsReclaim.startXPosition = Convert.ToSingle(drRuinsReclaim["startXPosition"]);
				ruinsReclaim.startYPosition = Convert.ToSingle(drRuinsReclaim["startYPosition"]);
				ruinsReclaim.startZPosition = Convert.ToSingle(drRuinsReclaim["startZPosition"]);
				ruinsReclaim.startRadius = Convert.ToSingle(drRuinsReclaim["startRadius"]);
				ruinsReclaim.startYRotationType = Convert.ToInt32(drRuinsReclaim["startYRotationType"]);
				ruinsReclaim.startYRotation = Convert.ToSingle(drRuinsReclaim["startYRotation"]);
				ruinsReclaim.debuffAreaActivationStepNo = Convert.ToInt32(drRuinsReclaim["debuffAreaActivationStepNo"]);
				ruinsReclaim.debuffAreaDeactivationStepNo = Convert.ToInt32(drRuinsReclaim["debuffAreaDeactivationStepNo"]);
				ruinsReclaim.debuffAreaXPosition = Convert.ToSingle(drRuinsReclaim["debuffAreaXPosition"]);
				ruinsReclaim.debuffAreaYPosition = Convert.ToSingle(drRuinsReclaim["debuffAreaYPosition"]);
				ruinsReclaim.debuffAreaZPosition = Convert.ToSingle(drRuinsReclaim["debuffAreaZPosition"]);
				ruinsReclaim.debuffAreaYRotation = Convert.ToSingle(drRuinsReclaim["debuffAreaYRotation"]);
				ruinsReclaim.debuffAreaWidth = Convert.ToInt32(drRuinsReclaim["debuffAreaWidth"]);
				ruinsReclaim.debuffAreaHeight = Convert.ToInt32(drRuinsReclaim["debuffAreaHeight"]);
				ruinsReclaim.debuffAreaOffenseFactor = Convert.ToSingle(drRuinsReclaim["debuffAreaOffenseFactor"]);
				ruinsReclaim.summonMonsterHpRecoveryInterval = Convert.ToInt32(drRuinsReclaim["summonMonsterHpRecoveryInterval"]);
				ruinsReclaim.summonMonsterHpRecoveryGuideImageName = Convert.ToString(drRuinsReclaim["summonMonsterHpRecoveryGuideImageName"]);
				ruinsReclaim.summonMonsterHpRecoveryGuideTitleKey = Convert.ToString(drRuinsReclaim["summonMonsterHpRecoveryGuideTitleKey"]);
				ruinsReclaim.summonMonsterHpRecoveryGuideContentKey = Convert.ToString(drRuinsReclaim["summonMonsterHpRecoveryGuideContentKey"]);
				ruinsReclaim.safeRevivalWaitingTime = Convert.ToInt32(drRuinsReclaim["safeRevivalWaitingTime"]);
				ruinsReclaim.locationId = Convert.ToInt32(drRuinsReclaim["locationId"]);
				ruinsReclaim.x = Convert.ToSingle(drRuinsReclaim["x"]);
				ruinsReclaim.z = Convert.ToSingle(drRuinsReclaim["z"]);
				ruinsReclaim.xSize = Convert.ToSingle(drRuinsReclaim["xSize"]);
				ruinsReclaim.zSize = Convert.ToSingle(drRuinsReclaim["zSize"]);

			}
			gameDatas.ruinsReclaim = ruinsReclaim;

			//
			// 유적탈환몬스터속성계수 목록
			//
			List<WPDRuinsReclaimMonsterAttrFactor> ruinsReclaimMonsterAttrFactors = new List<WPDRuinsReclaimMonsterAttrFactor>();
			foreach (DataRow dr in drcRuinsReclaimMonsterAttrFactors)
			{
				WPDRuinsReclaimMonsterAttrFactor data = new WPDRuinsReclaimMonsterAttrFactor();
				data.level = Convert.ToInt32(dr["level"]);
				data.maxHpFactor = Convert.ToSingle(dr["maxHpFactor"]);
				data.offenseFactor = Convert.ToSingle(dr["offenseFactor"]);

				ruinsReclaimMonsterAttrFactors.Add(data);
			}
			gameDatas.ruinsReclaimMonsterAttrFactors = ruinsReclaimMonsterAttrFactors.ToArray();
			ruinsReclaimMonsterAttrFactors.Clear();

			//
			// 유적탈환획득가능보상 목록
			//
			List<WPDRuinsReclaimAvailableReward> ruinsReclaimAvailableRewards = new List<WPDRuinsReclaimAvailableReward>();
			foreach (DataRow dr in drcRuinsReclaimAvailableRewards)
			{
				WPDRuinsReclaimAvailableReward data = new WPDRuinsReclaimAvailableReward();
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);

				ruinsReclaimAvailableRewards.Add(data);
			}
			gameDatas.ruinsReclaimAvailableRewards = ruinsReclaimAvailableRewards.ToArray();
			ruinsReclaimAvailableRewards.Clear();

			//
			// 유적탈환부활포인트 목록
			//
			List<WPDRuinsReclaimRevivalPoint> ruinsReclaimRevivalPoints = new List<WPDRuinsReclaimRevivalPoint>();
			foreach (DataRow dr in drcRuinsReclaimRevivalPoints)
			{
				WPDRuinsReclaimRevivalPoint data = new WPDRuinsReclaimRevivalPoint();
				data.revivalPointId = Convert.ToInt32(dr["revivalPointId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.radius = Convert.ToSingle(dr["radius"]);
				data.yRotationType = Convert.ToInt32(dr["yRotationType"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);

				ruinsReclaimRevivalPoints.Add(data);
			}
			gameDatas.ruinsReclaimRevivalPoints = ruinsReclaimRevivalPoints.ToArray();
			ruinsReclaimRevivalPoints.Clear();

			//
			// 유적탈환장애물 목록
			//
			List<WPDRuinsReclaimObstacle> ruinsReclaimObstacles = new List<WPDRuinsReclaimObstacle>();
			foreach (DataRow dr in drcRuinsReclaimObstacles)
			{
				WPDRuinsReclaimObstacle data = new WPDRuinsReclaimObstacle();
				data.obstacleId = Convert.ToInt32(dr["obstacleId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);
				data.scale = Convert.ToSingle(dr["scale"]);

				ruinsReclaimObstacles.Add(data);
			}
			gameDatas.ruinsReclaimObstacles = ruinsReclaimObstacles.ToArray();
			ruinsReclaimObstacles.Clear();

			//
			// 유적탈환함정 목록
			//
			List<WPDRuinsReclaimTrap> ruinsReclaimTraps = new List<WPDRuinsReclaimTrap>();
			foreach (DataRow dr in drcRuinsReclaimTraps)
			{
				WPDRuinsReclaimTrap data = new WPDRuinsReclaimTrap();
				data.trapId = Convert.ToInt32(dr["trapId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.radius = Convert.ToSingle(dr["radius"]);
				data.damage = Convert.ToInt32(dr["damage"]);

				ruinsReclaimTraps.Add(data);
			}
			gameDatas.ruinsReclaimTraps = ruinsReclaimTraps.ToArray();
			ruinsReclaimTraps.Clear();

			//
			// 유적탈환포털 목록
			//
			List<WPDRuinsReclaimPortal> ruinsReclaimPortals = new List<WPDRuinsReclaimPortal>();
			foreach (DataRow dr in drcRuinsReclaimPortals)
			{
				WPDRuinsReclaimPortal data = new WPDRuinsReclaimPortal();
				data.portalId = Convert.ToInt32(dr["portalId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.radius = Convert.ToSingle(dr["radius"]);
				data.exitXPosition = Convert.ToSingle(dr["exitXPosition"]);
				data.exitYPosition = Convert.ToSingle(dr["exitYPosition"]);
				data.exitZPosition = Convert.ToSingle(dr["exitZPosition"]);
				data.exitRadius = Convert.ToSingle(dr["exitRadius"]);
				data.exitYRotationType = Convert.ToInt32(dr["exitYRotationType"]);
				data.exitYRotation = Convert.ToSingle(dr["exitYRotation"]);

				ruinsReclaimPortals.Add(data);
			}
			gameDatas.ruinsReclaimPortals = ruinsReclaimPortals.ToArray();
			ruinsReclaimPortals.Clear();

			//
			// 유적탈환오픈스케줄 목록
			//
			List<WPDRuinsReclaimOpenSchedule> ruinsReclaimOpenSchedules = new List<WPDRuinsReclaimOpenSchedule>();
			foreach (DataRow dr in drcRuinsReclaimOpenSchedules)
			{
				WPDRuinsReclaimOpenSchedule data = new WPDRuinsReclaimOpenSchedule();
				data.scheduleId = Convert.ToInt32(dr["scheduleId"]);
				data.startTime = Convert.ToInt32(dr["startTime"]);
				data.endTime = Convert.ToInt32(dr["endTime"]);

				ruinsReclaimOpenSchedules.Add(data);
			}
			gameDatas.ruinsReclaimOpenSchedules = ruinsReclaimOpenSchedules.ToArray();
			ruinsReclaimOpenSchedules.Clear();

			//
			// 유적탈환단계 목록
			//
			List<WPDRuinsReclaimStep> ruinsReclaimSteps = new List<WPDRuinsReclaimStep>();
			foreach (DataRow dr in drcRuinsReclaimSteps)
			{
				WPDRuinsReclaimStep data = new WPDRuinsReclaimStep();
				data.stepNo = Convert.ToInt32(dr["stepNo"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);
				data.targetXPosition = Convert.ToSingle(dr["targetXPosition"]);
				data.targetYPosition = Convert.ToSingle(dr["targetYPosition"]);
				data.targetZPosition = Convert.ToSingle(dr["targetZPosition"]);
				data.targetRadius = Convert.ToSingle(dr["targetRadius"]);
				data.removeObstacleId = Convert.ToInt32(dr["removeObstacleId"]);
				data.activationPortalId = Convert.ToInt32(dr["activationPortalId"]);
				data.deactivationPortalId = Convert.ToInt32(dr["deactivationPortalId"]);
				data.revivalPointId = Convert.ToInt32(dr["revivalPointId"]);

				ruinsReclaimSteps.Add(data);
			}
			gameDatas.ruinsReclaimSteps = ruinsReclaimSteps.ToArray();
			ruinsReclaimSteps.Clear();

			//
			// 유적탈환오브젝트배치 목록
			//
			List<WPDRuinsReclaimObjectArrange> ruinsReclaimObjectArranges = new List<WPDRuinsReclaimObjectArrange>();
			foreach (DataRow dr in drcRuinsReclaimObjectArranges)
			{
				WPDRuinsReclaimObjectArrange data = new WPDRuinsReclaimObjectArrange();
				data.stepNo = Convert.ToInt32(dr["stepNo"]);
				data.arrangeNo = Convert.ToInt32(dr["arrangeNo"]);
				data.prefabName = Convert.ToString(dr["prefabName"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.radius = Convert.ToSingle(dr["radius"]);
				data.objectInteractionDuration = Convert.ToSingle(dr["objectInteractionDuration"]);
				data.objectInteractionMaxRange = Convert.ToSingle(dr["objectInteractionMaxRange"]);
				data.objectScale = Convert.ToSingle(dr["objectScale"]);
				data.objectHeight = Convert.ToInt32(dr["objectHeight"]);
				data.objectRadius = Convert.ToSingle(dr["objectRadius"]);
				data.objectInteractionTextKey = Convert.ToString(dr["objectInteractionTextKey"]);
				data.goldRewardId = Convert.ToInt64(dr["goldRewardId"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				ruinsReclaimObjectArranges.Add(data);
			}
			gameDatas.ruinsReclaimObjectArranges = ruinsReclaimObjectArranges.ToArray();
			ruinsReclaimObjectArranges.Clear();

			//
			// 유적탈환단계보상 목록
			//
			List<WPDRuinsReclaimStepReward> ruinsReclaimStepRewards = new List<WPDRuinsReclaimStepReward>();
			foreach (DataRow dr in drcRuinsReclaimStepRewards)
			{
				WPDRuinsReclaimStepReward data = new WPDRuinsReclaimStepReward();
				data.stepNo = Convert.ToInt32(dr["stepNo"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				ruinsReclaimStepRewards.Add(data);
			}
			gameDatas.ruinsReclaimStepRewards = ruinsReclaimStepRewards.ToArray();
			ruinsReclaimStepRewards.Clear();

			//
			// 유적탈환단계웨이브 목록
			//
			List<WPDRuinsReclaimStepWave> ruinsReclaimStepWaves = new List<WPDRuinsReclaimStepWave>();
			foreach (DataRow dr in drcRuinsReclaimStepWaves)
			{
				WPDRuinsReclaimStepWave data = new WPDRuinsReclaimStepWave();
				data.stepNo = Convert.ToInt32(dr["stepNo"]);
				data.waveNo = Convert.ToInt32(dr["waveNo"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);
				data.targetType = Convert.ToInt32(dr["targetType"]);
				data.targetArrangeKey = Convert.ToInt32(dr["targetArrangeKey"]);

				ruinsReclaimStepWaves.Add(data);
			}
			gameDatas.ruinsReclaimStepWaves = ruinsReclaimStepWaves.ToArray();
			ruinsReclaimStepWaves.Clear();

			//
			// 유적탈환단계웨이브스킬 목록
			//
			List<WPDRuinsReclaimStepWaveSkill> ruinsReclaimStepWaveSkills = new List<WPDRuinsReclaimStepWaveSkill>();
			foreach (DataRow dr in drcRuinsReclaimStepWaveSkills)
			{
				WPDRuinsReclaimStepWaveSkill data = new WPDRuinsReclaimStepWaveSkill();
				data.stepNo = Convert.ToInt32(dr["stepNo"]);
				data.waveNo = Convert.ToInt32(dr["waveNo"]);
				data.castingInterval = Convert.ToInt32(dr["castingInterval"]);
				data.guideImageName = Convert.ToString(dr["guideImageName"]);
				data.guideTitleKey = Convert.ToString(dr["guideTitleKey"]);
				data.guideContentKey = Convert.ToString(dr["guideContentKey"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.radius = Convert.ToSingle(dr["radius"]);
				data.transformationMonsterId = Convert.ToInt32(dr["transformationMonsterId"]);
				data.transformationLifetime = Convert.ToInt32(dr["transformationLifetime"]);
				data.objectPrefabName = Convert.ToString(dr["objectPrefabName"]);
				data.objectInteractionDuration = Convert.ToSingle(dr["objectInteractionDuration"]);
				data.objectInteractionMaxRange = Convert.ToSingle(dr["objectInteractionMaxRange"]);
				data.objectScale = Convert.ToSingle(dr["objectScale"]);
				data.objectHeight = Convert.ToInt32(dr["objectHeight"]);
				data.objectRadius = Convert.ToSingle(dr["objectRadius"]);
				data.objectInteractionTextKey = Convert.ToString(dr["objectInteractionTextKey"]);
				data.objectLifetime = Convert.ToInt32(dr["objectLifetime"]);

				ruinsReclaimStepWaveSkills.Add(data);
			}
			gameDatas.ruinsReclaimStepWaveSkills = ruinsReclaimStepWaveSkills.ToArray();
			ruinsReclaimStepWaveSkills.Clear();

			//
			// 오픈7일이벤트일차 목록
			//
			List<WPDOpen7DayEventDay> open7DayEventDaies = new List<WPDOpen7DayEventDay>();
			foreach (DataRow dr in drcOpen7DayEventDaies)
			{
				WPDOpen7DayEventDay data = new WPDOpen7DayEventDay();
				data.day = Convert.ToInt32(dr["day"]);

				open7DayEventDaies.Add(data);
			}
			gameDatas.open7DayEventDaies = open7DayEventDaies.ToArray();
			open7DayEventDaies.Clear();

			//
			// 오픈7일이벤트미션 목록
			//
			List<WPDOpen7DayEventMission> open7DayEventMissions = new List<WPDOpen7DayEventMission>();
			foreach (DataRow dr in drcOpen7DayEventMissions)
			{
				WPDOpen7DayEventMission data = new WPDOpen7DayEventMission();
				data.missionId = Convert.ToInt32(dr["missionId"]);
				data.day = Convert.ToInt32(dr["day"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.targetValue = Convert.ToInt64(dr["targetValue"]);

				open7DayEventMissions.Add(data);
			}
			gameDatas.open7DayEventMissions = open7DayEventMissions.ToArray();
			open7DayEventMissions.Clear();

			//
			// 오픈7일이벤트미션보상 목록
			//
			List<WPDOpen7DayEventMissionReward> open7DayEventMissionRewards = new List<WPDOpen7DayEventMissionReward>();
			foreach (DataRow dr in drcOpen7DayEventMissionRewards)
			{
				WPDOpen7DayEventMissionReward data = new WPDOpen7DayEventMissionReward();
				data.missionId = Convert.ToInt32(dr["missionId"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				open7DayEventMissionRewards.Add(data);
			}
			gameDatas.open7DayEventMissionRewards = open7DayEventMissionRewards.ToArray();
			open7DayEventMissionRewards.Clear();

			//
			// 오픈7일이벤트상품 목록
			//
			List<WPDOpen7DayEventProduct> open7DayEventProducts = new List<WPDOpen7DayEventProduct>();
			foreach (DataRow dr in drcOpen7DayEventProducts)
			{
				WPDOpen7DayEventProduct data = new WPDOpen7DayEventProduct();
				data.productId = Convert.ToInt32(dr["productId"]);
				data.day = Convert.ToInt32(dr["day"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);
				data.itemOwned = Convert.ToBoolean(dr["itemOwned"]);
				data.itemCount = Convert.ToInt32(dr["itemCount"]);
				data.requiredDia = Convert.ToInt32(dr["requiredDia"]);

				open7DayEventProducts.Add(data);
			}
			gameDatas.open7DayEventProducts = open7DayEventProducts.ToArray();
			open7DayEventProducts.Clear();

			//
			// 회수 목록
			//
			List<WPDRetrieval> retrievals = new List<WPDRetrieval>();
			foreach (DataRow dr in drcRetrievals)
			{
				WPDRetrieval data = new WPDRetrieval();
				data.retrievalId = Convert.ToInt32(dr["retrievalId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.rewardDisplayType = Convert.ToInt32(dr["rewardDisplayType"]);
				data.goldRetrievalTextKey = Convert.ToString(dr["goldRetrievalTextKey"]);
				data.goldRetrievalRequiredGold = Convert.ToInt64(dr["goldRetrievalRequiredGold"]);
				data.diaRetrievalTextKey = Convert.ToString(dr["diaRetrievalTextKey"]);
				data.diaRetrievalRequiredDia = Convert.ToInt32(dr["diaRetrievalRequiredDia"]);

				retrievals.Add(data);
			}
			gameDatas.retrievals = retrievals.ToArray();
			retrievals.Clear();

			//
			// 회수보상 목록
			//
			List<WPDRetrievalReward> retrievalRewards = new List<WPDRetrievalReward>();
			foreach (DataRow dr in drcRetrievalRewards)
			{
				WPDRetrievalReward data = new WPDRetrievalReward();
				data.retrievalId = Convert.ToInt32(dr["retrievalId"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.goldExpRewardId = Convert.ToInt64(dr["goldExpRewardId"]);
				data.goldItemRewardId = Convert.ToInt64(dr["goldItemRewardId"]);
				data.diaExpRewardId = Convert.ToInt64(dr["diaExpRewardId"]);
				data.diaItemRewardId = Convert.ToInt64(dr["diaItemRewardId"]);

				retrievalRewards.Add(data);
			}
			gameDatas.retrievalRewards = retrievalRewards.ToArray();
			retrievalRewards.Clear();

			//
			// 할일위탁 목록
			//
			List<WPDTaskConsignment> taskConsignments = new List<WPDTaskConsignment>();
			foreach (DataRow dr in drcTaskConsignments)
			{
				WPDTaskConsignment data = new WPDTaskConsignment();
				data.consignmentId = Convert.ToInt32(dr["consignmentId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.requiredItemId = Convert.ToInt32(dr["requiredItemId"]);
				data.requiredItemCount = Convert.ToInt32(dr["requiredItemCount"]);
				data.completionRequiredTime = Convert.ToInt32(dr["completionRequiredTime"]);
				data.immediateCompletionRequiredGold = Convert.ToInt32(dr["immediateCompletionRequiredGold"]);
				data.immediateCompletionRequiredGoldReduceInterval = Convert.ToInt32(dr["immediateCompletionRequiredGoldReduceInterval"]);
				data.todayTaskId = Convert.ToInt32(dr["todayTaskId"]);

				taskConsignments.Add(data);
			}
			gameDatas.taskConsignments = taskConsignments.ToArray();
			taskConsignments.Clear();

			//
			// 할일위탁획득가능보상 목록
			//
			List<WPDTaskConsignmentAvailableReward> taskConsignmentAvailableRewards = new List<WPDTaskConsignmentAvailableReward>();
			foreach (DataRow dr in drcTaskConsignmentAvailableRewards)
			{
				WPDTaskConsignmentAvailableReward data = new WPDTaskConsignmentAvailableReward();
				data.consignmentId = Convert.ToInt32(dr["consignmentId"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);

				taskConsignmentAvailableRewards.Add(data);
			}
			gameDatas.taskConsignmentAvailableRewards = taskConsignmentAvailableRewards.ToArray();
			taskConsignmentAvailableRewards.Clear();

			//
			// 할일위탁경험치보상 목록
			//
			List<WPDTaskConsignmentExpReward> taskConsignmentExpRewards = new List<WPDTaskConsignmentExpReward>();
			foreach (DataRow dr in drcTaskConsignmentExpRewards)
			{
				WPDTaskConsignmentExpReward data = new WPDTaskConsignmentExpReward();
				data.consignmentId = Convert.ToInt32(dr["consignmentId"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);

				taskConsignmentExpRewards.Add(data);
			}
			gameDatas.taskConsignmentExpRewards = taskConsignmentExpRewards.ToArray();
			taskConsignmentExpRewards.Clear();

			//
			// 무한대전
			//
			WPDInfiniteWar infiniteWar = new WPDInfiniteWar();
			if (drInfiniteWar != null)
			{
				infiniteWar.nameKey = Convert.ToString(drInfiniteWar["nameKey"]);
				infiniteWar.descriptionKey = Convert.ToString(drInfiniteWar["descriptionKey"]);
				infiniteWar.enterCount = Convert.ToInt32(drInfiniteWar["enterCount"]);
				infiniteWar.sceneName = Convert.ToString(drInfiniteWar["sceneName"]);
				infiniteWar.requiredConditionType = Convert.ToInt32(drInfiniteWar["requiredConditionType"]);
				infiniteWar.requiredHeroLevel = Convert.ToInt32(drInfiniteWar["requiredHeroLevel"]);
				infiniteWar.requiredMainQuestNo = Convert.ToInt32(drInfiniteWar["requiredMainQuestNo"]);
				infiniteWar.requiredStamina = Convert.ToInt32(drInfiniteWar["requiredStamina"]);
				infiniteWar.enterMinMemberCount = Convert.ToInt32(drInfiniteWar["enterMinMemberCount"]);
				infiniteWar.enterMaxMemberCount = Convert.ToInt32(drInfiniteWar["enterMaxMemberCount"]);
				infiniteWar.matchingWaitingTime = Convert.ToInt32(drInfiniteWar["matchingWaitingTime"]);
				infiniteWar.enterWaitingTime = Convert.ToInt32(drInfiniteWar["enterWaitingTime"]);
				infiniteWar.startDelayTime = Convert.ToInt32(drInfiniteWar["startDelayTime"]);
				infiniteWar.limitTime = Convert.ToInt32(drInfiniteWar["limitTime"]);
				infiniteWar.exitDelayTime = Convert.ToInt32(drInfiniteWar["exitDelayTime"]);
				infiniteWar.guideImageName = Convert.ToString(drInfiniteWar["guideImageName"]);
				infiniteWar.startGuideTitleKey = Convert.ToString(drInfiniteWar["startGuideTitleKey"]);
				infiniteWar.startGuideContentKey = Convert.ToString(drInfiniteWar["startGuideContentKey"]);
				infiniteWar.monsterSpawnDelayTime = Convert.ToInt32(drInfiniteWar["monsterSpawnDelayTime"]);
				infiniteWar.monsterSpawnGuideTitleKey = Convert.ToString(drInfiniteWar["monsterSpawnGuideTitleKey"]);
				infiniteWar.monsterSpawnGuideContentKey = Convert.ToString(drInfiniteWar["monsterSpawnGuideContentKey"]);
				infiniteWar.heroKillPoint = Convert.ToInt32(drInfiniteWar["heroKillPoint"]);
				infiniteWar.buffBoxCreationInterval = Convert.ToInt32(drInfiniteWar["buffBoxCreationInterval"]);
				infiniteWar.buffBoxCreationCount = Convert.ToInt32(drInfiniteWar["buffBoxCreationCount"]);
				infiniteWar.buffBoxXPosition = Convert.ToSingle(drInfiniteWar["buffBoxXPosition"]);
				infiniteWar.buffBoxYPosition = Convert.ToSingle(drInfiniteWar["buffBoxYPosition"]);
				infiniteWar.buffBoxZPosition = Convert.ToSingle(drInfiniteWar["buffBoxZPosition"]);
				infiniteWar.buffBoxRadius = Convert.ToSingle(drInfiniteWar["buffBoxRadius"]);
				infiniteWar.buffBoxLifetime = Convert.ToInt32(drInfiniteWar["buffBoxLifetime"]);
				infiniteWar.buffBoxAcquisitionRange = Convert.ToSingle(drInfiniteWar["buffBoxAcquisitionRange"]);
				infiniteWar.buffDuration = Convert.ToInt32(drInfiniteWar["buffDuration"]);
				infiniteWar.buffCreationGuideTitleKey = Convert.ToString(drInfiniteWar["buffCreationGuideTitleKey"]);
				infiniteWar.buffCreationGuideContentKey = Convert.ToString(drInfiniteWar["buffCreationGuideContentKey"]);
				infiniteWar.safeRevivalWaitingTime = Convert.ToInt32(drInfiniteWar["safeRevivalWaitingTime"]);
				infiniteWar.locationId = Convert.ToInt32(drInfiniteWar["locationId"]);
				infiniteWar.x = Convert.ToSingle(drInfiniteWar["x"]);
				infiniteWar.z = Convert.ToSingle(drInfiniteWar["z"]);
				infiniteWar.xSize = Convert.ToSingle(drInfiniteWar["xSize"]);
				infiniteWar.zSize = Convert.ToSingle(drInfiniteWar["zSize"]);

			}
			gameDatas.infiniteWar = infiniteWar;

			//
			// 무한대전버프상자 목록
			//
			List<WPDInfiniteWarBuffBox> infiniteWarBuffBoxs = new List<WPDInfiniteWarBuffBox>();
			foreach (DataRow dr in drcInfiniteWarBuffBoxs)
			{
				WPDInfiniteWarBuffBox data = new WPDInfiniteWarBuffBox();
				data.buffBoxId = Convert.ToInt32(dr["buffBoxId"]);
				data.prefabName = Convert.ToString(dr["prefabName"]);
				data.offenseFactor = Convert.ToSingle(dr["offenseFactor"]);
				data.defenseFactor = Convert.ToSingle(dr["defenseFactor"]);
				data.hpRecoveryFactor = Convert.ToSingle(dr["hpRecoveryFactor"]);

				infiniteWarBuffBoxs.Add(data);
			}
			gameDatas.infiniteWarBuffBoxs = infiniteWarBuffBoxs.ToArray();
			infiniteWarBuffBoxs.Clear();

			//
			// 무한대전몬스터속성계수 목록
			//
			List<WPDInfiniteWarMonsterAttrFactor> infiniteWarMonsterAttrFactors = new List<WPDInfiniteWarMonsterAttrFactor>();
			foreach (DataRow dr in drcInfiniteWarMonsterAttrFactors)
			{
				WPDInfiniteWarMonsterAttrFactor data = new WPDInfiniteWarMonsterAttrFactor();
				data.level = Convert.ToInt32(dr["level"]);
				data.maxHpFactor = Convert.ToSingle(dr["maxHpFactor"]);
				data.offenseFactor = Convert.ToSingle(dr["offenseFactor"]);

				infiniteWarMonsterAttrFactors.Add(data);
			}
			gameDatas.infiniteWarMonsterAttrFactors = infiniteWarMonsterAttrFactors.ToArray();
			infiniteWarMonsterAttrFactors.Clear();

			//
			// 무한대전오픈스케줄 목록
			//
			List<WPDInfiniteWarOpenSchedule> infiniteWarOpenSchedules = new List<WPDInfiniteWarOpenSchedule>();
			foreach (DataRow dr in drcInfiniteWarOpenSchedules)
			{
				WPDInfiniteWarOpenSchedule data = new WPDInfiniteWarOpenSchedule();
				data.scheduleId = Convert.ToInt32(dr["scheduleId"]);
				data.startTime = Convert.ToInt32(dr["startTime"]);
				data.endTime = Convert.ToInt32(dr["endTime"]);

				infiniteWarOpenSchedules.Add(data);
			}
			gameDatas.infiniteWarOpenSchedules = infiniteWarOpenSchedules.ToArray();
			infiniteWarOpenSchedules.Clear();

			//
			// 무한대전획득가능보상 목록
			//
			List<WPDInfiniteWarAvailableReward> infiniteWarAvailableRewards = new List<WPDInfiniteWarAvailableReward>();
			foreach (DataRow dr in drcInfiniteWarAvailableRewards)
			{
				WPDInfiniteWarAvailableReward data = new WPDInfiniteWarAvailableReward();
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);

				infiniteWarAvailableRewards.Add(data);
			}
			gameDatas.infiniteWarAvailableRewards = infiniteWarAvailableRewards.ToArray();
			infiniteWarAvailableRewards.Clear();

			//
			// 진정한영웅퀘스트
			//
			WPDTrueHeroQuest trueHeroQuest = new WPDTrueHeroQuest();
			if (drTrueHeroQuest != null)
			{
				trueHeroQuest.nameKey = Convert.ToString(drTrueHeroQuest["nameKey"]);
				trueHeroQuest.descriptionKey = Convert.ToString(drTrueHeroQuest["descriptionKey"]);
				trueHeroQuest.targetTitleKey = Convert.ToString(drTrueHeroQuest["targetTitleKey"]);
				trueHeroQuest.targetContentKey = Convert.ToString(drTrueHeroQuest["targetContentKey"]);
				trueHeroQuest.requiredVipLevel = Convert.ToInt32(drTrueHeroQuest["requiredVipLevel"]);
				trueHeroQuest.requiredHeroLevel = Convert.ToInt32(drTrueHeroQuest["requiredHeroLevel"]);
				trueHeroQuest.questNpcId = Convert.ToInt32(drTrueHeroQuest["questNpcId"]);
				trueHeroQuest.startDialogueKey = Convert.ToString(drTrueHeroQuest["startDialogueKey"]);
				trueHeroQuest.completionDialogueKey = Convert.ToString(drTrueHeroQuest["completionDialogueKey"]);
				trueHeroQuest.completionTextKey = Convert.ToString(drTrueHeroQuest["completionTextKey"]);
				trueHeroQuest.targetObjectPrefabName = Convert.ToString(drTrueHeroQuest["targetObjectPrefabName"]);
				trueHeroQuest.targetObjectInteractionDuration = Convert.ToSingle(drTrueHeroQuest["targetObjectInteractionDuration"]);
				trueHeroQuest.targetObjectInteractionMaxRange = Convert.ToSingle(drTrueHeroQuest["targetObjectInteractionMaxRange"]);
				trueHeroQuest.targetObjectScale = Convert.ToSingle(drTrueHeroQuest["targetObjectScale"]);
				trueHeroQuest.targetObjectHeight = Convert.ToInt32(drTrueHeroQuest["targetObjectHeight"]);
				trueHeroQuest.targetObjectRadius = Convert.ToSingle(drTrueHeroQuest["targetObjectRadius"]);
				trueHeroQuest.targetObjectInteractionTextKey = Convert.ToString(drTrueHeroQuest["targetObjectInteractionTextKey"]);
				trueHeroQuest.chattingMessageKey = Convert.ToString(drTrueHeroQuest["chattingMessageKey"]);

			}
			gameDatas.trueHeroQuest = trueHeroQuest;

			//
			// 진정한영웅퀘스트단계 목록
			//
			List<WPDTrueHeroQuestStep> trueHeroQuestSteps = new List<WPDTrueHeroQuestStep>();
			foreach (DataRow dr in drcTrueHeroQuestSteps)
			{
				WPDTrueHeroQuestStep data = new WPDTrueHeroQuestStep();
				data.stepNo = Convert.ToInt32(dr["stepNo"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);
				data.targetContinentId = Convert.ToInt32(dr["targetContinentId"]);
				data.targetObjectXPosition = Convert.ToSingle(dr["targetObjectXPosition"]);
				data.targetObjectYPosition = Convert.ToSingle(dr["targetObjectYPosition"]);
				data.targetObjectZPosition = Convert.ToSingle(dr["targetObjectZPosition"]);
				data.objectiveWaitingTime = Convert.ToInt32(dr["objectiveWaitingTime"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				trueHeroQuestSteps.Add(data);
			}
			gameDatas.trueHeroQuestSteps = trueHeroQuestSteps.ToArray();
			trueHeroQuestSteps.Clear();

			//
			// 진정한영웅퀘스트보상 목록
			//
			List<WPDTrueHeroQuestReward> trueHeroQuestRewards = new List<WPDTrueHeroQuestReward>();
			foreach (DataRow dr in drcTrueHeroQuestRewards)
			{
				WPDTrueHeroQuestReward data = new WPDTrueHeroQuestReward();
				data.level = Convert.ToInt32(dr["level"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);
				data.exploitPointRewardId = Convert.ToInt64(dr["exploitPointRewardId"]);

				trueHeroQuestRewards.Add(data);
			}
			gameDatas.trueHeroQuestRewards = trueHeroQuestRewards.ToArray();
			trueHeroQuestRewards.Clear();

			//
			// 유적탈환랜덤보상풀항목 목록
			//
			List<WPDRuinsReclaimRandomRewardPoolEntry> ruinsReclaimRandomRewardPoolEntries = new List<WPDRuinsReclaimRandomRewardPoolEntry>();
			foreach (DataRow dr in drcRuinsReclaimRandomRewardPoolEntries)
			{
				WPDRuinsReclaimRandomRewardPoolEntry data = new WPDRuinsReclaimRandomRewardPoolEntry();
				data.entryNo = Convert.ToInt32(dr["entryNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				ruinsReclaimRandomRewardPoolEntries.Add(data);
			}
			gameDatas.ruinsReclaimRandomRewardPoolEntries = ruinsReclaimRandomRewardPoolEntries.ToArray();
			ruinsReclaimRandomRewardPoolEntries.Clear();

			//
			// 한정선물
			//
			WPDLimitationGift limitationGift = new WPDLimitationGift();
			if (drLimitationGift != null)
			{
				limitationGift.nameKey = Convert.ToString(drLimitationGift["nameKey"]);
				limitationGift.scheduleTextKey = Convert.ToString(drLimitationGift["scheduleTextKey"]);
				limitationGift.requiredHeroLevel = Convert.ToInt32(drLimitationGift["requiredHeroLevel"]);

			}
			gameDatas.limitationGift = limitationGift;

			//
			// 한정선물보상요일 목록
			//
			List<WPDLimitationGiftRewardDayOfWeek> limitationGiftRewardDayOfWeeks = new List<WPDLimitationGiftRewardDayOfWeek>();
			foreach (DataRow dr in drcLimitationGiftRewardDayOfWeeks)
			{
				WPDLimitationGiftRewardDayOfWeek data = new WPDLimitationGiftRewardDayOfWeek();
				data.dayOfWeek = Convert.ToInt32(dr["dayOfWeek"]);

				limitationGiftRewardDayOfWeeks.Add(data);
			}
			gameDatas.limitationGiftRewardDayOfWeeks = limitationGiftRewardDayOfWeeks.ToArray();
			limitationGiftRewardDayOfWeeks.Clear();

			//
			// 한정선물보상스케줄 목록
			//
			List<WPDLimitationGiftRewardSchedule> limitationGiftRewardSchedules = new List<WPDLimitationGiftRewardSchedule>();
			foreach (DataRow dr in drcLimitationGiftRewardSchedules)
			{
				WPDLimitationGiftRewardSchedule data = new WPDLimitationGiftRewardSchedule();
				data.scheduleId = Convert.ToInt32(dr["scheduleId"]);
				data.startTime = Convert.ToInt32(dr["startTime"]);
				data.endTime = Convert.ToInt32(dr["endTime"]);

				limitationGiftRewardSchedules.Add(data);
			}
			gameDatas.limitationGiftRewardSchedules = limitationGiftRewardSchedules.ToArray();
			limitationGiftRewardSchedules.Clear();

			//
			// 한정선물획득가능보상 목록
			//
			List<WPDLimitationGiftAvailableReward> limitationGiftAvailableRewards = new List<WPDLimitationGiftAvailableReward>();
			foreach (DataRow dr in drcLimitationGiftAvailableRewards)
			{
				WPDLimitationGiftAvailableReward data = new WPDLimitationGiftAvailableReward();
				data.scheduleId = Convert.ToInt32(dr["scheduleId"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);

				limitationGiftAvailableRewards.Add(data);
			}
			gameDatas.limitationGiftAvailableRewards = limitationGiftAvailableRewards.ToArray();
			limitationGiftAvailableRewards.Clear();

			//
			// 주말보상
			//
			WPDWeekendReward weekendReward = new WPDWeekendReward();
			if (drWeekendReward != null)
			{
				weekendReward.nameKey = Convert.ToString(drWeekendReward["nameKey"]);
				weekendReward.scheduleTextKey = Convert.ToString(drWeekendReward["scheduleTextKey"]);
				weekendReward.descriptionKey = Convert.ToString(drWeekendReward["descriptionKey"]);
				weekendReward.requiredHeroLevel = Convert.ToInt32(drWeekendReward["requiredHeroLevel"]);

			}
			gameDatas.weekendReward = weekendReward;

			//
			// 필드보스이벤트
			//
			WPDFieldBossEvent fieldBossEvent = new WPDFieldBossEvent();
			if (drFieldBossEvent != null)
			{
				fieldBossEvent.nameKey = Convert.ToString(drFieldBossEvent["nameKey"]);
				fieldBossEvent.descriptionKey = Convert.ToString(drFieldBossEvent["descriptionKey"]);
				fieldBossEvent.requiredHeroLevel = Convert.ToInt32(drFieldBossEvent["requiredHeroLevel"]);
				fieldBossEvent.rewardRadius = Convert.ToSingle(drFieldBossEvent["rewardRadius"]);

			}
			gameDatas.fieldBossEvent = fieldBossEvent;

			//
			// 필드보스스케줄 목록
			//
			List<WPDFieldBossEventSchedule> fieldBossEventSchedules = new List<WPDFieldBossEventSchedule>();
			foreach (DataRow dr in drcFieldBossEventSchedules)
			{
				WPDFieldBossEventSchedule data = new WPDFieldBossEventSchedule();
				data.scheduleId = Convert.ToInt32(dr["scheduleId"]);
				data.startTime = Convert.ToInt32(dr["startTime"]);
				data.endTime = Convert.ToInt32(dr["endTime"]);

				fieldBossEventSchedules.Add(data);
			}
			gameDatas.fieldBossEventSchedules = fieldBossEventSchedules.ToArray();
			fieldBossEventSchedules.Clear();

			//
			// 필드보스획득가능보상 목록
			//
			List<WPDFieldBossEventAvailableReward> fieldBossEventAvailableRewards = new List<WPDFieldBossEventAvailableReward>();
			foreach (DataRow dr in drcFieldBossEventAvailableRewards)
			{
				WPDFieldBossEventAvailableReward data = new WPDFieldBossEventAvailableReward();
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);

				fieldBossEventAvailableRewards.Add(data);
			}
			gameDatas.fieldBossEventAvailableRewards = fieldBossEventAvailableRewards.ToArray();
			fieldBossEventAvailableRewards.Clear();

			//
			// 필드보스 목록
			//
			List<WPDFieldBoss> fieldBosss = new List<WPDFieldBoss>();
			foreach (DataRow dr in drcFieldBosss)
			{
				WPDFieldBoss data = new WPDFieldBoss();
				data.fieldBossId = Convert.ToInt32(dr["fieldBossId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.imageName = Convert.ToString(dr["imageName"]);
				data.monsterArrangeId = Convert.ToInt64(dr["monsterArrangeId"]);
				data.continentId = Convert.ToInt32(dr["continentId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);

				fieldBosss.Add(data);
			}
			gameDatas.fieldBosss = fieldBosss.ToArray();
			fieldBosss.Clear();

			//
			// 창고슬롯확장레시피 목록
			//
			List<WPDWarehouseSlotExtendRecipe> warehouseSlotExtendRecipes = new List<WPDWarehouseSlotExtendRecipe>();
			foreach (DataRow dr in drcWarehouseSlotExtendRecipes)
			{
				WPDWarehouseSlotExtendRecipe data = new WPDWarehouseSlotExtendRecipe();
				data.slotCount = Convert.ToInt32(dr["slotCount"]);
				data.dia = Convert.ToInt32(dr["dia"]);

				warehouseSlotExtendRecipes.Add(data);
			}
			gameDatas.warehouseSlotExtendRecipes = warehouseSlotExtendRecipes.ToArray();
			warehouseSlotExtendRecipes.Clear();

			//
			// 공포의제단
			//
			WPDFearAltar fearAltar = new WPDFearAltar();
			if (drFearAltar != null)
			{
				fearAltar.nameKey = Convert.ToString(drFearAltar["nameKey"]);
				fearAltar.descriptionKey = Convert.ToString(drFearAltar["descriptionKey"]);
				fearAltar.requiredConditionType = Convert.ToInt32(drFearAltar["requiredConditionType"]);
				fearAltar.requiredHeroLevel = Convert.ToInt32(drFearAltar["requiredHeroLevel"]);
				fearAltar.requiredMainQuestNo = Convert.ToInt32(drFearAltar["requiredMainQuestNo"]);
				fearAltar.requiredStamina = Convert.ToInt32(drFearAltar["requiredStamina"]);
				fearAltar.enterMinMemberCount = Convert.ToInt32(drFearAltar["enterMinMemberCount"]);
				fearAltar.enterMaxMemberCount = Convert.ToInt32(drFearAltar["enterMaxMemberCount"]);
				fearAltar.matchingWaitingTime = Convert.ToInt32(drFearAltar["matchingWaitingTime"]);
				fearAltar.enterWaitingTime = Convert.ToInt32(drFearAltar["enterWaitingTime"]);
				fearAltar.startDelayTime = Convert.ToInt32(drFearAltar["startDelayTime"]);
				fearAltar.limitTime = Convert.ToInt32(drFearAltar["limitTime"]);
				fearAltar.exitDelayTime = Convert.ToInt32(drFearAltar["exitDelayTime"]);
				fearAltar.safeRevivalWaitingTime = Convert.ToInt32(drFearAltar["safeRevivalWaitingTime"]);
				fearAltar.halidomMonsterLifetime = Convert.ToInt32(drFearAltar["halidomMonsterLifetime"]);
				fearAltar.halidomMonsterSpawnTextKey = Convert.ToString(drFearAltar["halidomMonsterSpawnTextKey"]);
				fearAltar.halidomDisplayDuration = Convert.ToInt32(drFearAltar["halidomDisplayDuration"]);
				fearAltar.halidomAcquisitionRate = Convert.ToInt32(drFearAltar["halidomAcquisitionRate"]);

			}
			gameDatas.fearAltar = fearAltar;

			//
			// 공포의제단보상 목록
			//
			List<WPDFearAltarReward> fearAltarRewards = new List<WPDFearAltarReward>();
			foreach (DataRow dr in drcFearAltarRewards)
			{
				WPDFearAltarReward data = new WPDFearAltarReward();
				data.level = Convert.ToInt32(dr["level"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);

				fearAltarRewards.Add(data);
			}
			gameDatas.fearAltarRewards = fearAltarRewards.ToArray();
			fearAltarRewards.Clear();

			//
			// 공포의제단성물수집보상 목록
			//
			List<WPDFearAltarHalidomCollectionReward> fearAltarHalidomCollectionRewards = new List<WPDFearAltarHalidomCollectionReward>();
			foreach (DataRow dr in drcFearAltarHalidomCollectionRewards)
			{
				WPDFearAltarHalidomCollectionReward data = new WPDFearAltarHalidomCollectionReward();
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.collectionCount = Convert.ToInt32(dr["collectionCount"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				fearAltarHalidomCollectionRewards.Add(data);
			}
			gameDatas.fearAltarHalidomCollectionRewards = fearAltarHalidomCollectionRewards.ToArray();
			fearAltarHalidomCollectionRewards.Clear();

			//
			// 공포의제단성물원소 목록
			//
			List<WPDFearAltarHalidomElemental> fearAltarHalidomElementals = new List<WPDFearAltarHalidomElemental>();
			foreach (DataRow dr in drcFearAltarHalidomElementals)
			{
				WPDFearAltarHalidomElemental data = new WPDFearAltarHalidomElemental();
				data.halidomElementalId = Convert.ToInt32(dr["halidomElementalId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.collectionItemRewardId = Convert.ToInt64(dr["collectionItemRewardId"]);

				fearAltarHalidomElementals.Add(data);
			}
			gameDatas.fearAltarHalidomElementals = fearAltarHalidomElementals.ToArray();
			fearAltarHalidomElementals.Clear();

			//
			// 공포의제단성물레벨 목록
			//
			List<WPDFearAltarHalidomLevel> fearAltarHalidomLevels = new List<WPDFearAltarHalidomLevel>();
			foreach (DataRow dr in drcFearAltarHalidomLevels)
			{
				WPDFearAltarHalidomLevel data = new WPDFearAltarHalidomLevel();
				data.halidomLevel = Convert.ToInt32(dr["halidomLevel"]);

				fearAltarHalidomLevels.Add(data);
			}
			gameDatas.fearAltarHalidomLevels = fearAltarHalidomLevels.ToArray();
			fearAltarHalidomLevels.Clear();

			//
			// 공포의제단성물 목록
			//
			List<WPDFearAltarHalidom> fearAltarHalidoms = new List<WPDFearAltarHalidom>();
			foreach (DataRow dr in drcFearAltarHalidoms)
			{
				WPDFearAltarHalidom data = new WPDFearAltarHalidom();
				data.halidomId = Convert.ToInt32(dr["halidomId"]);
				data.halidomElementalId = Convert.ToInt32(dr["halidomElementalId"]);
				data.halidomLevel = Convert.ToInt32(dr["halidomLevel"]);
				data.imageName = Convert.ToString(dr["imageName"]);

				fearAltarHalidoms.Add(data);
			}
			gameDatas.fearAltarHalidoms = fearAltarHalidoms.ToArray();
			fearAltarHalidoms.Clear();

			//
			// 공포의제단스테이지 목록
			//
			List<WPDFearAltarStage> fearAltarStages = new List<WPDFearAltarStage>();
			foreach (DataRow dr in drcFearAltarStages)
			{
				WPDFearAltarStage data = new WPDFearAltarStage();
				data.stageId = Convert.ToInt32(dr["stageId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);
				data.sceneName = Convert.ToString(dr["sceneName"]);
				data.startXPosition = Convert.ToSingle(dr["startXPosition"]);
				data.startYPosition = Convert.ToSingle(dr["startYPosition"]);
				data.startZPosition = Convert.ToSingle(dr["startZPosition"]);
				data.startRadius = Convert.ToSingle(dr["startRadius"]);
				data.startYRotationType = Convert.ToInt32(dr["startYRotationType"]);
				data.startYRotation = Convert.ToSingle(dr["startYRotation"]);
				data.locationId = Convert.ToInt32(dr["locationId"]);
				data.x = Convert.ToSingle(dr["x"]);
				data.z = Convert.ToSingle(dr["z"]);
				data.xSize = Convert.ToSingle(dr["xSize"]);
				data.zSize = Convert.ToSingle(dr["zSize"]);

				fearAltarStages.Add(data);
			}
			gameDatas.fearAltarStages = fearAltarStages.ToArray();
			fearAltarStages.Clear();

			//
			// 공포의제단스테이지웨이브 목록
			//
			List<WPDFearAltarStageWave> fearAltarStageWaves = new List<WPDFearAltarStageWave>();
			foreach (DataRow dr in drcFearAltarStageWaves)
			{
				WPDFearAltarStageWave data = new WPDFearAltarStageWave();
				data.stageId = Convert.ToInt32(dr["stageId"]);
				data.waveNo = Convert.ToInt32(dr["waveNo"]);
				data.guideImageName = Convert.ToString(dr["guideImageName"]);
				data.guideTitleKey = Convert.ToString(dr["guideTitleKey"]);
				data.guideContentKey = Convert.ToString(dr["guideContentKey"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.halidomMonsterXPosition = Convert.ToSingle(dr["halidomMonsterXPosition"]);
				data.halidomMonsterYPosition = Convert.ToSingle(dr["halidomMonsterYPosition"]);
				data.halidomMonsterZPosition = Convert.ToSingle(dr["halidomMonsterZPosition"]);
				data.halidomMonsterYRotationType = Convert.ToInt32(dr["halidomMonsterYRotationType"]);
				data.halidomMonsterYRotation = Convert.ToSingle(dr["halidomMonsterYRotation"]);

				fearAltarStageWaves.Add(data);
			}
			gameDatas.fearAltarStageWaves = fearAltarStageWaves.ToArray();
			fearAltarStageWaves.Clear();

			//
			// 다이아상점카테고리 목록
			//
			List<WPDDiaShopCategory> diaShopCategories = new List<WPDDiaShopCategory>();
			foreach (DataRow dr in drcDiaShopCategories)
			{
				WPDDiaShopCategory data = new WPDDiaShopCategory();
				data.categoryId = Convert.ToInt32(dr["categoryId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.requiredVipLevel = Convert.ToInt32(dr["requiredVipLevel"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);

				diaShopCategories.Add(data);
			}
			gameDatas.diaShopCategories = diaShopCategories.ToArray();
			diaShopCategories.Clear();

			//
			// 다이아상점상품 목록
			//
			List<WPDDiaShopProduct> diaShopProducts = new List<WPDDiaShopProduct>();
			foreach (DataRow dr in drcDiaShopProducts)
			{
				WPDDiaShopProduct data = new WPDDiaShopProduct();
				data.productId = Convert.ToInt32(dr["productId"]);
				data.categoryId = Convert.ToInt32(dr["categoryId"]);
				data.costumeProductType = Convert.ToInt32(dr["costumeProductType"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);
				data.itemOwned = Convert.ToBoolean(dr["itemOwned"]);
				data.tagType = Convert.ToInt32(dr["tagType"]);
				data.moneyType = Convert.ToInt32(dr["moneyType"]);
				data.moneyItemId = Convert.ToInt32(dr["moneyItemId"]);
				data.originalPrice = Convert.ToInt32(dr["originalPrice"]);
				data.price = Convert.ToInt32(dr["price"]);
				data.buyLimitType = Convert.ToInt32(dr["buyLimitType"]);
				data.buyLimitCount = Convert.ToInt32(dr["buyLimitCount"]);
				data.periodType = Convert.ToInt32(dr["periodType"]);
				data.periodStartTime = (dr["periodStartTime"] != DBNull.Value) ? DateTime.Parse(dr["periodStartTime"].ToString()) : DateTime.MinValue;
				data.periodEndTime = (dr["periodEndTime"] != DBNull.Value) ? DateTime.Parse(dr["periodEndTime"].ToString()) : DateTime.MinValue;
				data.periodDayOfWeek = Convert.ToInt32(dr["periodDayOfWeek"]);
				data.recommended = Convert.ToBoolean(dr["recommended"]);
				data.isLimitEdition = Convert.ToBoolean(dr["isLimitEdition"]);
				data.categorySortNo = Convert.ToInt32(dr["categorySortNo"]);
				data.limitEditionSortNo = Convert.ToInt32(dr["limitEditionSortNo"]);

				diaShopProducts.Add(data);
			}
			gameDatas.diaShopProducts = diaShopProducts.ToArray();
			diaShopProducts.Clear();

			//
			// 날개기억조각슬롯 목록
			//
			List<WPDWingMemoryPieceSlot> wingMemoryPieceSlots = new List<WPDWingMemoryPieceSlot>();
			foreach (DataRow dr in drcWingMemoryPieceSlots)
			{
				WPDWingMemoryPieceSlot data = new WPDWingMemoryPieceSlot();
				data.wingId = Convert.ToInt32(dr["wingId"]);
				data.slotIndex = Convert.ToInt32(dr["slotIndex"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.openStep = Convert.ToInt32(dr["openStep"]);

				wingMemoryPieceSlots.Add(data);
			}
			gameDatas.wingMemoryPieceSlots = wingMemoryPieceSlots.ToArray();
			wingMemoryPieceSlots.Clear();

			//
			// 날개기억조각단계 목록
			//
			List<WPDWingMemoryPieceStep> wingMemoryPieceSteps = new List<WPDWingMemoryPieceStep>();
			foreach (DataRow dr in drcWingMemoryPieceSteps)
			{
				WPDWingMemoryPieceStep data = new WPDWingMemoryPieceStep();
				data.wingId = Convert.ToInt32(dr["wingId"]);
				data.step = Convert.ToInt32(dr["step"]);
				data.requiredMemoryPieceCount = Convert.ToInt32(dr["requiredMemoryPieceCount"]);

				wingMemoryPieceSteps.Add(data);
			}
			gameDatas.wingMemoryPieceSteps = wingMemoryPieceSteps.ToArray();
			wingMemoryPieceSteps.Clear();

			//
			// 날개기억조각슬롯단계 목록
			//
			List<WPDWingMemoryPieceSlotStep> wingMemoryPieceSlotSteps = new List<WPDWingMemoryPieceSlotStep>();
			foreach (DataRow dr in drcWingMemoryPieceSlotSteps)
			{
				WPDWingMemoryPieceSlotStep data = new WPDWingMemoryPieceSlotStep();
				data.wingId = Convert.ToInt32(dr["wingId"]);
				data.slotIndex = Convert.ToInt32(dr["slotIndex"]);
				data.step = Convert.ToInt32(dr["step"]);
				data.attrMaxValue = Convert.ToInt32(dr["attrMaxValue"]);
				data.attrIncBaseValue = Convert.ToInt32(dr["attrIncBaseValue"]);
				data.attrDecValue = Convert.ToInt32(dr["attrDecValue"]);

				wingMemoryPieceSlotSteps.Add(data);
			}
			gameDatas.wingMemoryPieceSlotSteps = wingMemoryPieceSlotSteps.ToArray();
			wingMemoryPieceSlotSteps.Clear();

			//
			// 날개기억조각타입 목록
			//
			List<WPDWingMemoryPieceType> wingMemoryPieceTypes = new List<WPDWingMemoryPieceType>();
			foreach (DataRow dr in drcWingMemoryPieceTypes)
			{
				WPDWingMemoryPieceType data = new WPDWingMemoryPieceType();
				data.type = Convert.ToInt32(dr["type"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.requiredItemId = Convert.ToInt32(dr["requiredItemId"]);

				wingMemoryPieceTypes.Add(data);
			}
			gameDatas.wingMemoryPieceTypes = wingMemoryPieceTypes.ToArray();
			wingMemoryPieceTypes.Clear();

			//
			// 전쟁의기억
			//
			WPDWarMemory warMemory = new WPDWarMemory();
			if (drWarMemory != null)
			{
				warMemory.nameKey = Convert.ToString(drWarMemory["nameKey"]);
				warMemory.descriptionKey = Convert.ToString(drWarMemory["descriptionKey"]);
				warMemory.sceneName = Convert.ToString(drWarMemory["sceneName"]);
				warMemory.requiredConditionType = Convert.ToInt32(drWarMemory["requiredConditionType"]);
				warMemory.requiredHeroLevel = Convert.ToInt32(drWarMemory["requiredHeroLevel"]);
				warMemory.requiredMainQuestNo = Convert.ToInt32(drWarMemory["requiredMainQuestNo"]);
				warMemory.freeEnterCount = Convert.ToInt32(drWarMemory["freeEnterCount"]);
				warMemory.enterRequiredItemId = Convert.ToInt32(drWarMemory["enterRequiredItemId"]);
				warMemory.enterMinMemberCount = Convert.ToInt32(drWarMemory["enterMinMemberCount"]);
				warMemory.enterMaxMemberCount = Convert.ToInt32(drWarMemory["enterMaxMemberCount"]);
				warMemory.matchingWaitingTime = Convert.ToInt32(drWarMemory["matchingWaitingTime"]);
				warMemory.enterWaitingTime = Convert.ToInt32(drWarMemory["enterWaitingTime"]);
				warMemory.startDelayTime = Convert.ToInt32(drWarMemory["startDelayTime"]);
				warMemory.limitTime = Convert.ToInt32(drWarMemory["limitTime"]);
				warMemory.exitDelayTime = Convert.ToInt32(drWarMemory["exitDelayTime"]);
				warMemory.transformationGuideImageName = Convert.ToString(drWarMemory["transformationGuideImageName"]);
				warMemory.transformationGuideTitleKey = Convert.ToString(drWarMemory["transformationGuideTitleKey"]);
				warMemory.transformationGuideContentKey = Convert.ToString(drWarMemory["transformationGuideContentKey"]);
				warMemory.monsterSummonGuideTitleKey = Convert.ToString(drWarMemory["monsterSummonGuideTitleKey"]);
				warMemory.monsterSummonGuideContentKey = Convert.ToString(drWarMemory["monsterSummonGuideContentKey"]);
				warMemory.safeRevivalWaitingTime = Convert.ToInt32(drWarMemory["safeRevivalWaitingTime"]);
				warMemory.locationId = Convert.ToInt32(drWarMemory["locationId"]);
				warMemory.x = Convert.ToSingle(drWarMemory["x"]);
				warMemory.z = Convert.ToSingle(drWarMemory["z"]);
				warMemory.xSize = Convert.ToSingle(drWarMemory["xSize"]);
				warMemory.zSize = Convert.ToSingle(drWarMemory["zSize"]);

			}
			gameDatas.warMemory = warMemory;
			 
			//
			// 전쟁의기억몬스터속성계수 목록
			//
			List<WPDWarMemoryMonsterAttrFactor> warMemoryMonsterAttrFactors = new List<WPDWarMemoryMonsterAttrFactor>();
			foreach (DataRow dr in drcWarMemoryMonsterAttrFactors)
			{
				WPDWarMemoryMonsterAttrFactor data = new WPDWarMemoryMonsterAttrFactor();
				data.level = Convert.ToInt32(dr["level"]);
				data.maxHpFactor = Convert.ToSingle(dr["maxHpFactor"]);
				data.offenseFactor = Convert.ToSingle(dr["offenseFactor"]);

				warMemoryMonsterAttrFactors.Add(data);
			}
			gameDatas.warMemoryMonsterAttrFactors = warMemoryMonsterAttrFactors.ToArray();
			warMemoryMonsterAttrFactors.Clear();

			//
			// 전쟁의기억시작지점 목록
			//
			List<WPDWarMemoryStartPosition> warMemoryStartPositions = new List<WPDWarMemoryStartPosition>();
			foreach (DataRow dr in drcWarMemoryStartPositions)
			{
				WPDWarMemoryStartPosition data = new WPDWarMemoryStartPosition();
				data.positionId = Convert.ToInt32(dr["positionId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.radius = Convert.ToSingle(dr["radius"]);
				data.yRotationType = Convert.ToInt32(dr["yRotationType"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);

				warMemoryStartPositions.Add(data);
			}
			gameDatas.warMemoryStartPositions = warMemoryStartPositions.ToArray();
			warMemoryStartPositions.Clear();

			//
			// 전쟁의기억스케줄 목록
			//
			List<WPDWarMemorySchedule> warMemorySchedules = new List<WPDWarMemorySchedule>();
			foreach (DataRow dr in drcWarMemorySchedules)
			{
				WPDWarMemorySchedule data = new WPDWarMemorySchedule();
				data.scheduleId = Convert.ToInt32(dr["scheduleId"]);
				data.startTime = Convert.ToInt32(dr["startTime"]);
				data.endTime = Convert.ToInt32(dr["endTime"]);

				warMemorySchedules.Add(data);
			}
			gameDatas.warMemorySchedules = warMemorySchedules.ToArray();
			warMemorySchedules.Clear();

			//
			// 전쟁의기억획득가능보상 목록
			//
			List<WPDWarMemoryAvailableReward> warMemoryAvailableRewards = new List<WPDWarMemoryAvailableReward>();
			foreach (DataRow dr in drcWarMemoryAvailableRewards)
			{
				WPDWarMemoryAvailableReward data = new WPDWarMemoryAvailableReward();
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);

				warMemoryAvailableRewards.Add(data);
			}
			gameDatas.warMemoryAvailableRewards = warMemoryAvailableRewards.ToArray();
			warMemoryAvailableRewards.Clear();

            //
            // TODO: 战争纪念活动奖励名单
            //
            List<WPDWarMemoryReward> warMemoryRewards = new List<WPDWarMemoryReward>();
            foreach (DataRow dr in drcWarMemoryRewards)
			{
				WPDWarMemoryReward data = new WPDWarMemoryReward();
				data.level = Convert.ToInt32(dr["level"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);

				warMemoryRewards.Add(data);
			}
			gameDatas.warMemoryRewards = warMemoryRewards.ToArray();
			warMemoryRewards.Clear();

			//
			// 전쟁의기억랭킹보상 목록
			//
			List<WPDWarMemoryRankingReward> warMemoryRankingRewards = new List<WPDWarMemoryRankingReward>();
			foreach (DataRow dr in drcWarMemoryRankingRewards)
			{
				WPDWarMemoryRankingReward data = new WPDWarMemoryRankingReward();
				data.highRanking = Convert.ToInt32(dr["highRanking"]);
				data.lowRanking = Convert.ToInt32(dr["lowRanking"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				warMemoryRankingRewards.Add(data);
			}
			gameDatas.warMemoryRankingRewards = warMemoryRankingRewards.ToArray();
			warMemoryRankingRewards.Clear();

			//
			// 전쟁의기억웨이브 목록
			//
			List<WPDWarMemoryWave> warMemoryWaves = new List<WPDWarMemoryWave>();
			foreach (DataRow dr in drcWarMemoryWaves)
			{
				WPDWarMemoryWave data = new WPDWarMemoryWave();
				data.waveNo = Convert.ToInt32(dr["waveNo"]);
				data.startDelayTime = Convert.ToInt32(dr["startDelayTime"]);
				data.clearPoint = Convert.ToInt32(dr["clearPoint"]);
				data.targetType = Convert.ToInt32(dr["targetType"]);
				data.targetArrangeKey = Convert.ToInt32(dr["targetArrangeKey"]);
				data.guideImageName = Convert.ToString(dr["guideImageName"]);
				data.guideTitleKey = Convert.ToString(dr["guideTitleKey"]);
				data.guideContentKey = Convert.ToString(dr["guideContentKey"]);

				warMemoryWaves.Add(data);
			}
			gameDatas.warMemoryWaves = warMemoryWaves.ToArray();
			warMemoryWaves.Clear();

			//
			// 전쟁의기억변신오브젝트 목록
			//
			List<WPDWarMemoryTransformationObject> warMemoryTransformationObjects = new List<WPDWarMemoryTransformationObject>();
			foreach (DataRow dr in drcWarMemoryTransformationObjects)
			{
				WPDWarMemoryTransformationObject data = new WPDWarMemoryTransformationObject();
				data.waveNo = Convert.ToInt32(dr["waveNo"]);
				data.transformationObjectId = Convert.ToInt32(dr["transformationObjectId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.radius = Convert.ToSingle(dr["radius"]);
				data.objectPrefabName = Convert.ToString(dr["objectPrefabName"]);
				data.objectInteractionDuration = Convert.ToSingle(dr["objectInteractionDuration"]);
				data.objectInteractionMaxRange = Convert.ToSingle(dr["objectInteractionMaxRange"]);
				data.objectScale = Convert.ToSingle(dr["objectScale"]);
				data.objectHeight = Convert.ToInt32(dr["objectHeight"]);
				data.objectRadius = Convert.ToSingle(dr["objectRadius"]);
				data.objectInteractionTextKey = Convert.ToString(dr["objectInteractionTextKey"]);
				data.objectLifetime = Convert.ToInt32(dr["objectLifetime"]);
				data.transformationMonsterId = Convert.ToInt32(dr["transformationMonsterId"]);
				data.transformationLifetime = Convert.ToInt32(dr["transformationLifetime"]);

				warMemoryTransformationObjects.Add(data);
			}
			gameDatas.warMemoryTransformationObjects = warMemoryTransformationObjects.ToArray();
			warMemoryTransformationObjects.Clear();

			//
			// 서브퀘스트 목록
			//
			List<WPDSubQuest> subQuests = new List<WPDSubQuest>();
			foreach (DataRow dr in drcSubQuests)
			{
				WPDSubQuest data = new WPDSubQuest();
				data.questId = Convert.ToInt32(dr["questId"]);
				data.requiredConditionType = Convert.ToInt32(dr["requiredConditionType"]);
				data.requiredConditionValue = Convert.ToInt32(dr["requiredConditionValue"]);
				data.titleKey = Convert.ToString(dr["titleKey"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.startNpcId = Convert.ToInt32(dr["startNpcId"]);
				data.startDialogueKey = Convert.ToString(dr["startDialogueKey"]);
				data.targetTextKey = Convert.ToString(dr["targetTextKey"]);
				data.targetContinentId = Convert.ToInt32(dr["targetContinentId"]);
				data.targetXPosition = Convert.ToSingle(dr["targetXPosition"]);
				data.targetYPosition = Convert.ToSingle(dr["targetYPosition"]);
				data.targetZPosition = Convert.ToSingle(dr["targetZPosition"]);
				data.targetRadius = Convert.ToSingle(dr["targetRadius"]);
				data.targetContinentObjectId = Convert.ToInt32(dr["targetContinentObjectId"]);
				data.targetMonsterId = Convert.ToInt32(dr["targetMonsterId"]);
				data.targetAcquisitionRate = Convert.ToInt32(dr["targetAcquisitionRate"]);
				data.targetContentId = Convert.ToInt32(dr["targetContentId"]);
				data.targetCount = Convert.ToInt32(dr["targetCount"]);
				data.completionNpcId = Convert.ToInt32(dr["completionNpcId"]);
				data.completionKey = Convert.ToString(dr["completionKey"]);
				data.completionDialogueKey = Convert.ToString(dr["completionDialogueKey"]);
				data.abandonmentEnabled = Convert.ToBoolean(dr["abandonmentEnabled"]);
				data.reacceptanceEnabled = Convert.ToBoolean(dr["reacceptanceEnabled"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);
				data.goldRewardId = Convert.ToInt64(dr["goldRewardId"]);

				subQuests.Add(data);
			}
			gameDatas.subQuests = subQuests.ToArray();
			subQuests.Clear();

			//
			// 서브퀘스트보상 목록
			//
			List<WPDSubQuestReward> subQuestRewards = new List<WPDSubQuestReward>();
			foreach (DataRow dr in drcSubQuestRewards)
			{
				WPDSubQuestReward data = new WPDSubQuestReward();
				data.questId = Convert.ToInt32(dr["questId"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				subQuestRewards.Add(data);
			}
			gameDatas.subQuestRewards = subQuestRewards.ToArray();
			subQuestRewards.Clear();

			//
			// 오시리스의방
			//
			WPDOsirisRoom osirisRoom = new WPDOsirisRoom();
			if (drOsirisRoom != null)
			{
				osirisRoom.nameKey = Convert.ToString(drOsirisRoom["nameKey"]);
				osirisRoom.descriptionKey = Convert.ToString(drOsirisRoom["descriptionKey"]);
				osirisRoom.requiredStamina = Convert.ToInt32(drOsirisRoom["requiredStamina"]);
				osirisRoom.sceneName = Convert.ToString(drOsirisRoom["sceneName"]);
				osirisRoom.startDelayTime = Convert.ToInt32(drOsirisRoom["startDelayTime"]);
				osirisRoom.limitTime = Convert.ToInt32(drOsirisRoom["limitTime"]);
				osirisRoom.exitDelayTime = Convert.ToInt32(drOsirisRoom["exitDelayTime"]);
				osirisRoom.startXPosition = Convert.ToSingle(drOsirisRoom["startXPosition"]);
				osirisRoom.startYPosition = Convert.ToSingle(drOsirisRoom["startYPosition"]);
				osirisRoom.startZPosition = Convert.ToSingle(drOsirisRoom["startZPosition"]);
				osirisRoom.startYRotation = Convert.ToSingle(drOsirisRoom["startYRotation"]);
				osirisRoom.waveInterval = Convert.ToInt32(drOsirisRoom["waveInterval"]);
				osirisRoom.monsterSpawnInterval = Convert.ToInt32(drOsirisRoom["monsterSpawnInterval"]);
				osirisRoom.monsterSpawnXPosition = Convert.ToSingle(drOsirisRoom["monsterSpawnXPosition"]);
				osirisRoom.monsterSpawnYPosition = Convert.ToSingle(drOsirisRoom["monsterSpawnYPosition"]);
				osirisRoom.monsterSpawnZPosition = Convert.ToSingle(drOsirisRoom["monsterSpawnZPosition"]);
				osirisRoom.monsterSpawnYRotation = Convert.ToSingle(drOsirisRoom["monsterSpawnYRotation"]);
				osirisRoom.targetXPosition = Convert.ToSingle(drOsirisRoom["targetXPosition"]);
				osirisRoom.targetYPosition = Convert.ToSingle(drOsirisRoom["targetYPosition"]);
				osirisRoom.targetZPosition = Convert.ToSingle(drOsirisRoom["targetZPosition"]);
				osirisRoom.targetRadius = Convert.ToSingle(drOsirisRoom["targetRadius"]);
				osirisRoom.locationId = Convert.ToInt32(drOsirisRoom["locationId"]);
				osirisRoom.x = Convert.ToSingle(drOsirisRoom["x"]);
				osirisRoom.z = Convert.ToSingle(drOsirisRoom["z"]);
				osirisRoom.xSize = Convert.ToSingle(drOsirisRoom["xSize"]);
				osirisRoom.zSize = Convert.ToSingle(drOsirisRoom["zSize"]);

			}
			gameDatas.osirisRoom = osirisRoom;

			//
			// 오시리스의방획득가능보상 목록
			//
			List<WPDOsirisRoomAvailableReward> osirisRoomAvailableRewards = new List<WPDOsirisRoomAvailableReward>();
			foreach (DataRow dr in drcOsirisRoomAvailableRewards)
			{
				WPDOsirisRoomAvailableReward data = new WPDOsirisRoomAvailableReward();
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);

				osirisRoomAvailableRewards.Add(data);
			}
			gameDatas.osirisRoomAvailableRewards = osirisRoomAvailableRewards.ToArray();
			osirisRoomAvailableRewards.Clear();

			//
			// 오시리스의방난이도 목록
			//
			List<WPDOsirisRoomDifficulty> osirisRoomDifficulties = new List<WPDOsirisRoomDifficulty>();
			foreach (DataRow dr in drcOsirisRoomDifficulties)
			{
				WPDOsirisRoomDifficulty data = new WPDOsirisRoomDifficulty();
				data.difficulty = Convert.ToInt32(dr["difficulty"]);
				data.requiredConditionType = Convert.ToInt32(dr["requiredConditionType"]);
				data.requiredHeroLevel = Convert.ToInt32(dr["requiredHeroLevel"]);
				data.requiredMainQuestNo = Convert.ToInt32(dr["requiredMainQuestNo"]);

				osirisRoomDifficulties.Add(data);
			}
			gameDatas.osirisRoomDifficulties = osirisRoomDifficulties.ToArray();
			osirisRoomDifficulties.Clear();

			//
			// 오시리스의방난이도웨이브 목록
			//
			List<WPDOsirisRoomDifficultyWave> osirisRoomDifficultyWaves = new List<WPDOsirisRoomDifficultyWave>();
			foreach (DataRow dr in drcOsirisRoomDifficultyWaves)
			{
				WPDOsirisRoomDifficultyWave data = new WPDOsirisRoomDifficultyWave();
				data.difficulty = Convert.ToInt32(dr["difficulty"]);
				data.waveNo = Convert.ToInt32(dr["waveNo"]);

				osirisRoomDifficultyWaves.Add(data);
			}
			gameDatas.osirisRoomDifficultyWaves = osirisRoomDifficultyWaves.ToArray();
			osirisRoomDifficultyWaves.Clear();

			//
			// 시련퀘스트 목록
			//
			List<WPDOrdealQuest> ordealQuests = new List<WPDOrdealQuest>();
			foreach (DataRow dr in drcOrdealQuests)
			{
				WPDOrdealQuest data = new WPDOrdealQuest();
				data.questNo = Convert.ToInt32(dr["questNo"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.requiredHeroLevel = Convert.ToInt32(dr["requiredHeroLevel"]);
				data.availableRewardItemId = Convert.ToInt32(dr["availableRewardItemId"]);

				ordealQuests.Add(data);
			}
			gameDatas.ordealQuests = ordealQuests.ToArray();
			ordealQuests.Clear();

			//
			// 시련퀘스트미션 목록
			//
			List<WPDOrdealQuestMission> ordealQuestMissions = new List<WPDOrdealQuestMission>();
			foreach (DataRow dr in drcOrdealQuestMissions)
			{
				WPDOrdealQuestMission data = new WPDOrdealQuestMission();
				data.questNo = Convert.ToInt32(dr["questNo"]);
				data.slotIndex = Convert.ToInt32(dr["slotIndex"]);
				data.missionNo = Convert.ToInt32(dr["missionNo"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.targetCount = Convert.ToInt32(dr["targetCount"]);
				data.autoCompletionRequiredTime = Convert.ToInt32(dr["autoCompletionRequiredTime"]);
				data.availableRewardItemId = Convert.ToInt32(dr["availableRewardItemId"]);

				ordealQuestMissions.Add(data);
			}
			gameDatas.ordealQuestMissions = ordealQuestMissions.ToArray();
			ordealQuestMissions.Clear();

			//
			// 재화버프 목록
			//
			List<WPDMoneyBuff> moneyBuffs = new List<WPDMoneyBuff>();
			foreach (DataRow dr in drcMoneyBuffs)
			{
				WPDMoneyBuff data = new WPDMoneyBuff();
				data.buffId = Convert.ToInt32(dr["buffId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.lifetime = Convert.ToInt32(dr["lifetime"]);
				data.moneyType = Convert.ToInt32(dr["moneyType"]);
				data.moneyAmount = Convert.ToInt32(dr["moneyAmount"]);

				moneyBuffs.Add(data);
			}
			gameDatas.moneyBuffs = moneyBuffs.ToArray();
			moneyBuffs.Clear();

			//
			// 재화버프속성 목록
			//
			List<WPDMoneyBuffAttr> moneyBuffAttrs = new List<WPDMoneyBuffAttr>();
			foreach (DataRow dr in drcMoneyBuffAttrs)
			{
				WPDMoneyBuffAttr data = new WPDMoneyBuffAttr();
				data.buffId = Convert.ToInt32(dr["buffId"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.attrFactor = Convert.ToSingle(dr["attrFactor"]);

				moneyBuffAttrs.Add(data);
			}
			gameDatas.moneyBuffAttrs = moneyBuffAttrs.ToArray();
			moneyBuffAttrs.Clear();

			//
			// 전기 목록
			//
			List<WPDBiography> biographies = new List<WPDBiography>();
			foreach (DataRow dr in drcBiographies)
			{
				WPDBiography data = new WPDBiography();
				data.biographyId = Convert.ToInt32(dr["biographyId"]);
				data.titleKey = Convert.ToString(dr["titleKey"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.openConditionTextKey = Convert.ToString(dr["openConditionTextKey"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.requiredItemId = Convert.ToInt32(dr["requiredItemId"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);

				biographies.Add(data);
			}
			gameDatas.biographies = biographies.ToArray();
			biographies.Clear();

			//
			// 전기보상 목록
			//
			List<WPDBiographyReward> biographyRewards = new List<WPDBiographyReward>();
			foreach (DataRow dr in drcBiographyRewards)
			{
				WPDBiographyReward data = new WPDBiographyReward();
				data.biographyId = Convert.ToInt32(dr["biographyId"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				biographyRewards.Add(data);
			}
			gameDatas.biographyRewards = biographyRewards.ToArray();
			biographyRewards.Clear();

			//
			// 전기퀘스트 목록
			//
			List<WPDBiographyQuest> biographyQuests = new List<WPDBiographyQuest>();
			foreach (DataRow dr in drcBiographyQuests)
			{
				WPDBiographyQuest data = new WPDBiographyQuest();
				data.biographyId = Convert.ToInt32(dr["biographyId"]);
				data.questNo = Convert.ToInt32(dr["questNo"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.startNpcId = Convert.ToInt32(dr["startNpcId"]);
				data.startDialogueKey = Convert.ToString(dr["startDialogueKey"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);
				data.completionNpcId = Convert.ToInt32(dr["completionNpcId"]);
				data.completionDialogueKey = Convert.ToString(dr["completionDialogueKey"]);
				data.targetContinentId = Convert.ToInt32(dr["targetContinentId"]);
				data.targetXPosition = Convert.ToSingle(dr["targetXPosition"]);
				data.targetYPosition = Convert.ToSingle(dr["targetYPosition"]);
				data.targetZPosition = Convert.ToSingle(dr["targetZPosition"]);
				data.targetRadius = Convert.ToSingle(dr["targetRadius"]);
				data.targetMonsterId = Convert.ToInt32(dr["targetMonsterId"]);
				data.targetNpcId = Convert.ToInt32(dr["targetNpcId"]);
				data.targetContinentObjectId = Convert.ToInt32(dr["targetContinentObjectId"]);
				data.targetDungeonId = Convert.ToInt32(dr["targetDungeonId"]);
				data.targetCount = Convert.ToInt32(dr["targetCount"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);

				biographyQuests.Add(data);
			}
			gameDatas.biographyQuests = biographyQuests.ToArray();
			biographyQuests.Clear();

			//
			// 전기퀘스트시작대화 목록
			//
			List<WPDBiographyQuestStartDialogue> biographyQuestStartDialogues = new List<WPDBiographyQuestStartDialogue>();
			foreach (DataRow dr in drcBiographyQuestStartDialogues)
			{
				WPDBiographyQuestStartDialogue data = new WPDBiographyQuestStartDialogue();
				data.biographyId = Convert.ToInt32(dr["biographyId"]);
				data.questNo = Convert.ToInt32(dr["questNo"]);
				data.dialogueNo = Convert.ToInt32(dr["dialogueNo"]);
				data.npcId = Convert.ToInt32(dr["npcId"]);
				data.dialogueKey = Convert.ToString(dr["dialogueKey"]);

				biographyQuestStartDialogues.Add(data);
			}
			gameDatas.biographyQuestStartDialogues = biographyQuestStartDialogues.ToArray();
			biographyQuestStartDialogues.Clear();

			//
			// 전기퀘스트던전 목록
			//
			List<WPDBiographyQuestDungeon> biographyQuestDungeons = new List<WPDBiographyQuestDungeon>();
			foreach (DataRow dr in drcBiographyQuestDungeons)
			{
				WPDBiographyQuestDungeon data = new WPDBiographyQuestDungeon();
				data.dungeonId = Convert.ToInt32(dr["dungeonId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.sceneName = Convert.ToString(dr["sceneName"]);
				data.startDelayTime = Convert.ToInt32(dr["startDelayTime"]);
				data.limitTime = Convert.ToInt32(dr["limitTime"]);
				data.exitDelayTime = Convert.ToInt32(dr["exitDelayTime"]);
				data.startXPosition = Convert.ToSingle(dr["startXPosition"]);
				data.startYPosition = Convert.ToSingle(dr["startYPosition"]);
				data.startZPosition = Convert.ToSingle(dr["startZPosition"]);
				data.startRadius = Convert.ToSingle(dr["startRadius"]);
				data.startYRotation = Convert.ToSingle(dr["startYRotation"]);
				data.safeRevivalWaitingTime = Convert.ToInt32(dr["safeRevivalWaitingTime"]);
				data.locationId = Convert.ToInt32(dr["locationId"]);
				data.x = Convert.ToSingle(dr["x"]);
				data.z = Convert.ToSingle(dr["z"]);
				data.xSize = Convert.ToSingle(dr["xSize"]);
				data.zSize = Convert.ToSingle(dr["zSize"]);

				biographyQuestDungeons.Add(data);
			}
			gameDatas.biographyQuestDungeons = biographyQuestDungeons.ToArray();
			biographyQuestDungeons.Clear();

			//
			// 전기퀘스트던전웨이브 목록
			//
			List<WPDBiographyQuestDungeonWave> biographyQuestDungeonWaves = new List<WPDBiographyQuestDungeonWave>();
			foreach (DataRow dr in drcBiographyQuestDungeonWaves)
			{
				WPDBiographyQuestDungeonWave data = new WPDBiographyQuestDungeonWave();
				data.dungeonId = Convert.ToInt32(dr["dungeonId"]);
				data.waveNo = Convert.ToInt32(dr["waveNo"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);
				data.targetType = Convert.ToInt32(dr["targetType"]);
				data.targetArrangeKey = Convert.ToInt32(dr["targetArrangeKey"]);

				biographyQuestDungeonWaves.Add(data);
			}
			gameDatas.biographyQuestDungeonWaves = biographyQuestDungeonWaves.ToArray();
			biographyQuestDungeonWaves.Clear();

			//
			// 축복 목록
			//
			List<WPDBlessing> blessings = new List<WPDBlessing>();
			foreach (DataRow dr in drcBlessings)
			{
				WPDBlessing data = new WPDBlessing();
				data.blessingId = Convert.ToInt32(dr["blessingId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.moneyType = Convert.ToInt32(dr["moneyType"]);
				data.moneyAmount = Convert.ToInt32(dr["moneyAmount"]);
				data.senderItemRewardId = Convert.ToInt64(dr["senderItemRewardId"]);
				data.receiverGoldRewardId = Convert.ToInt64(dr["receiverGoldRewardId"]);

				blessings.Add(data);
			}
			gameDatas.blessings = blessings.ToArray();
			blessings.Clear();

			//
			// 축복대상레벨 목록
			//
			List<WPDBlessingTargetLevel> blessingTargetLevels = new List<WPDBlessingTargetLevel>();
			foreach (DataRow dr in drcBlessingTargetLevels)
			{
				WPDBlessingTargetLevel data = new WPDBlessingTargetLevel();
				data.targetLevelId = Convert.ToInt32(dr["targetLevelId"]);
				data.targetHeroLevel = Convert.ToInt32(dr["targetHeroLevel"]);
				data.prospectQuestObjectiveLevel = Convert.ToInt32(dr["prospectQuestObjectiveLevel"]);
				data.prospectQuestObjectiveLimitTime = Convert.ToInt32(dr["prospectQuestObjectiveLimitTime"]);

				blessingTargetLevels.Add(data);
			}
			gameDatas.blessingTargetLevels = blessingTargetLevels.ToArray();
			blessingTargetLevels.Clear();

			//
			// 유망자퀘스트소유자보상 목록
			//
			List<WPDProspectQuestOwnerReward> prospectQuestOwnerRewards = new List<WPDProspectQuestOwnerReward>();
			foreach (DataRow dr in drcProspectQuestOwnerRewards)
			{
				WPDProspectQuestOwnerReward data = new WPDProspectQuestOwnerReward();
				data.targetLevelId = Convert.ToInt32(dr["targetLevelId"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				prospectQuestOwnerRewards.Add(data);
			}
			gameDatas.prospectQuestOwnerRewards = prospectQuestOwnerRewards.ToArray();
			prospectQuestOwnerRewards.Clear();

			//
			// 유망자퀘스트대상보상 목록
			//
			List<WPDProspectQuestTargetReward> prospectQuestTargetRewards = new List<WPDProspectQuestTargetReward>();
			foreach (DataRow dr in drcProspectQuestTargetRewards)
			{
				WPDProspectQuestTargetReward data = new WPDProspectQuestTargetReward();
				data.targetLevelId = Convert.ToInt32(dr["targetLevelId"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				prospectQuestTargetRewards.Add(data);
			}
			gameDatas.prospectQuestTargetRewards = prospectQuestTargetRewards.ToArray();
			prospectQuestTargetRewards.Clear();

			//
			// 아이템행운상점
			//
			WPDItemLuckyShop itemLuckyShop = new WPDItemLuckyShop();
			if (drItemLuckyShop != null)
			{
				itemLuckyShop.nameKey = Convert.ToString(drItemLuckyShop["nameKey"]);
				itemLuckyShop.freePickCount = Convert.ToInt32(drItemLuckyShop["freePickCount"]);
				itemLuckyShop.freePickWaitingTime = Convert.ToInt32(drItemLuckyShop["freePickWaitingTime"]);
				itemLuckyShop.pick1TimeDia = Convert.ToInt32(drItemLuckyShop["pick1TimeDia"]);
				itemLuckyShop.pick5TimeDia = Convert.ToInt32(drItemLuckyShop["pick5TimeDia"]);
				itemLuckyShop.pick1TimeGoldRewardId = Convert.ToInt64(drItemLuckyShop["pick1TimeGoldRewardId"]);
				itemLuckyShop.pick5TimeGoldRewardId = Convert.ToInt64(drItemLuckyShop["pick5TimeGoldRewardId"]);

			}
			gameDatas.itemLuckyShop = itemLuckyShop;

			//
			// 크리처카드행운상점
			//
			WPDCreatureCardLuckyShop creatureCardLuckyShop = new WPDCreatureCardLuckyShop();
			if (drCreatureCardLuckyShop != null)
			{
				creatureCardLuckyShop.nameKey = Convert.ToString(drCreatureCardLuckyShop["nameKey"]);
				creatureCardLuckyShop.freePickCount = Convert.ToInt32(drCreatureCardLuckyShop["freePickCount"]);
				creatureCardLuckyShop.freePickWaitingTime = Convert.ToInt32(drCreatureCardLuckyShop["freePickWaitingTime"]);
				creatureCardLuckyShop.pick1TimeDia = Convert.ToInt32(drCreatureCardLuckyShop["pick1TimeDia"]);
				creatureCardLuckyShop.pick5TimeDia = Convert.ToInt32(drCreatureCardLuckyShop["pick5TimeDia"]);
				creatureCardLuckyShop.pick1TimeGoldRewardId = Convert.ToInt64(drCreatureCardLuckyShop["pick1TimeGoldRewardId"]);
				creatureCardLuckyShop.pick5TimeGoldRewardId = Convert.ToInt64(drCreatureCardLuckyShop["pick5TimeGoldRewardId"]);

			}
			gameDatas.creatureCardLuckyShop = creatureCardLuckyShop;

			//
			// 크리처캐릭터 목록
			//
			List<WPDCreatureCharacter> creatureCharacters = new List<WPDCreatureCharacter>();
			foreach (DataRow dr in drcCreatureCharacters)
			{
				WPDCreatureCharacter data = new WPDCreatureCharacter();
				data.creatureCharacterId = Convert.ToInt32(dr["creatureCharacterId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.requiredHeroLevel = Convert.ToInt32(dr["requiredHeroLevel"]);
				data.prefabName = Convert.ToString(dr["prefabName"]);
				data.imageName = Convert.ToString(dr["imageName"]);

				creatureCharacters.Add(data);
			}
			gameDatas.creatureCharacters = creatureCharacters.ToArray();
			creatureCharacters.Clear();

			//
			// 크리처등급 목록
			//
			List<WPDCreatureGrade> creatureGrades = new List<WPDCreatureGrade>();
			foreach (DataRow dr in drcCreatureGrades)
			{
				WPDCreatureGrade data = new WPDCreatureGrade();
				data.grade = Convert.ToInt32(dr["grade"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.colorCode = Convert.ToString(dr["colorCode"]);

				creatureGrades.Add(data);
			}
			gameDatas.creatureGrades = creatureGrades.ToArray();
			creatureGrades.Clear();

			//
			// 크리처 목록
			//
			List<WPDCreature> creatures = new List<WPDCreature>();
			foreach (DataRow dr in drcCreatures)
			{
				WPDCreature data = new WPDCreature();
				data.creatureId = Convert.ToInt32(dr["creatureId"]);
				data.creatureCharacterId = Convert.ToInt32(dr["creatureCharacterId"]);
				data.grade = Convert.ToInt32(dr["grade"]);
				data.minQuality = Convert.ToInt32(dr["minQuality"]);
				data.maxQuality = Convert.ToInt32(dr["maxQuality"]);

				creatures.Add(data);
			}
			gameDatas.creatures = creatures.ToArray();
			creatures.Clear();

			//
			// 크리처스킬등급 목록
			//
			List<WPDCreatureSkillGrade> creatureSkillGrades = new List<WPDCreatureSkillGrade>();
			foreach (DataRow dr in drcCreatureSkillGrades)
			{
				WPDCreatureSkillGrade data = new WPDCreatureSkillGrade();
				data.skillGrade = Convert.ToInt32(dr["skillGrade"]);
				data.colorCode = Convert.ToString(dr["colorCode"]);

				creatureSkillGrades.Add(data);
			}
			gameDatas.creatureSkillGrades = creatureSkillGrades.ToArray();
			creatureSkillGrades.Clear();

			//
			// 크리처스킬 목록
			//
			List<WPDCreatureSkill> creatureSkills = new List<WPDCreatureSkill>();
			foreach (DataRow dr in drcCreatureSkills)
			{
				WPDCreatureSkill data = new WPDCreatureSkill();
				data.skillId = Convert.ToInt32(dr["skillId"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.imageName = Convert.ToString(dr["imageName"]);
				data.effectTextKey = Convert.ToString(dr["effectTextKey"]);

				creatureSkills.Add(data);
			}
			gameDatas.creatureSkills = creatureSkills.ToArray();
			creatureSkills.Clear();

			//
			// 크리처스킬속성 목록
			//
			List<WPDCreatureSkillAttr> creatureSkillAttrs = new List<WPDCreatureSkillAttr>();
			foreach (DataRow dr in drcCreatureSkillAttrs)
			{
				WPDCreatureSkillAttr data = new WPDCreatureSkillAttr();
				data.skillId = Convert.ToInt32(dr["skillId"]);
				data.skillGrade = Convert.ToInt32(dr["skillGrade"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);

				creatureSkillAttrs.Add(data);
			}
			gameDatas.creatureSkillAttrs = creatureSkillAttrs.ToArray();
			creatureSkillAttrs.Clear();

			//
			// 크리처기본속성 목록
			//
			List<WPDCreatureBaseAttr> creatureBaseAttrs = new List<WPDCreatureBaseAttr>();
			foreach (DataRow dr in drcCreatureBaseAttrs)
			{
				WPDCreatureBaseAttr data = new WPDCreatureBaseAttr();
				data.attrId = Convert.ToInt32(dr["attrId"]);

				creatureBaseAttrs.Add(data);
			}
			gameDatas.creatureBaseAttrs = creatureBaseAttrs.ToArray();
			creatureBaseAttrs.Clear();

			//
			// 크리처레벨 목록
			//
			List<WPDCreatureLevel> creatureLevels = new List<WPDCreatureLevel>();
			foreach (DataRow dr in drcCreatureLevels)
			{
				WPDCreatureLevel data = new WPDCreatureLevel();
				data.level = Convert.ToInt32(dr["level"]);
				data.nextLevelUpRequiredExp = Convert.ToInt32(dr["nextLevelUpRequiredExp"]);
				data.maxInjectionLevel = Convert.ToInt32(dr["maxInjectionLevel"]);

				creatureLevels.Add(data);
			}
			gameDatas.creatureLevels = creatureLevels.ToArray();
			creatureLevels.Clear();

			//
			// 크리처기본속성값 목록
			//
			List<WPDCreatureBaseAttrValue> creatureBaseAttrValues = new List<WPDCreatureBaseAttrValue>();
			foreach (DataRow dr in drcCreatureBaseAttrValues)
			{
				WPDCreatureBaseAttrValue data = new WPDCreatureBaseAttrValue();
				data.creatureId = Convert.ToInt32(dr["creatureId"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.minAttrValue = Convert.ToInt32(dr["minAttrValue"]);
				data.maxAttrValue = Convert.ToInt32(dr["maxAttrValue"]);
				data.incAttrValue = Convert.ToInt32(dr["incAttrValue"]);

				creatureBaseAttrValues.Add(data);
			}
			gameDatas.creatureBaseAttrValues = creatureBaseAttrValues.ToArray();
			creatureBaseAttrValues.Clear();

			//
			// 크리처추가속성 목록
			//
			List<WPDCreatureAdditionalAttr> creatureAdditionalAttrs = new List<WPDCreatureAdditionalAttr>();
			foreach (DataRow dr in drcCreatureAdditionalAttrs)
			{
				WPDCreatureAdditionalAttr data = new WPDCreatureAdditionalAttr();
				data.attrId = Convert.ToInt32(dr["attrId"]);

				creatureAdditionalAttrs.Add(data);
			}
			gameDatas.creatureAdditionalAttrs = creatureAdditionalAttrs.ToArray();
			creatureAdditionalAttrs.Clear();

			//
			// 크리처주입레벨 목록
			//
			List<WPDCreatureInjectionLevel> creatureInjectionLevels = new List<WPDCreatureInjectionLevel>();
			foreach (DataRow dr in drcCreatureInjectionLevels)
			{
				WPDCreatureInjectionLevel data = new WPDCreatureInjectionLevel();
				data.injectionLevel = Convert.ToInt32(dr["injectionLevel"]);
				data.nextLevelUpRequiredExp = Convert.ToInt32(dr["nextLevelUpRequiredExp"]);
				data.requiredItemCount = Convert.ToInt32(dr["requiredItemCount"]);
				data.requiredGold = Convert.ToInt64(dr["requiredGold"]);

				creatureInjectionLevels.Add(data);
			}
			gameDatas.creatureInjectionLevels = creatureInjectionLevels.ToArray();
			creatureInjectionLevels.Clear();

			//
			// 크리처추가속성값 목록
			//
			List<WPDCreatureAdditionalAttrValue> creatureAdditionalAttrValues = new List<WPDCreatureAdditionalAttrValue>();
			foreach (DataRow dr in drcCreatureAdditionalAttrValues)
			{
				WPDCreatureAdditionalAttrValue data = new WPDCreatureAdditionalAttrValue();
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.injectionLevel = Convert.ToInt32(dr["injectionLevel"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);

				creatureAdditionalAttrValues.Add(data);
			}
			gameDatas.creatureAdditionalAttrValues = creatureAdditionalAttrValues.ToArray();
			creatureAdditionalAttrValues.Clear();

			//
			// 크리처스킬슬롯개방레시피 목록
			//
			List<WPDCreatureSkillSlotOpenRecipe> creatureSkillSlotOpenRecipes = new List<WPDCreatureSkillSlotOpenRecipe>();
			foreach (DataRow dr in drcCreatureSkillSlotOpenRecipes)
			{
				WPDCreatureSkillSlotOpenRecipe data = new WPDCreatureSkillSlotOpenRecipe();
				data.slotCount = Convert.ToInt32(dr["slotCount"]);
				data.requiredItemId = Convert.ToInt32(dr["requiredItemId"]);
				data.requiredItemCount = Convert.ToInt32(dr["requiredItemCount"]);

				creatureSkillSlotOpenRecipes.Add(data);
			}
			gameDatas.creatureSkillSlotOpenRecipes = creatureSkillSlotOpenRecipes.ToArray();
			creatureSkillSlotOpenRecipes.Clear();

			//
			// 크리처스킬슬롯보호 목록
			//
			List<WPDCreatureSkillSlotProtection> creatureSkillSlotProtections = new List<WPDCreatureSkillSlotProtection>();
			foreach (DataRow dr in drcCreatureSkillSlotProtections)
			{
				WPDCreatureSkillSlotProtection data = new WPDCreatureSkillSlotProtection();
				data.protectionCount = Convert.ToInt32(dr["protectionCount"]);
				data.requiredSkillCount = Convert.ToInt32(dr["requiredSkillCount"]);
				data.requiredItemCount = Convert.ToInt32(dr["requiredItemCount"]);

				creatureSkillSlotProtections.Add(data);
			}
			gameDatas.creatureSkillSlotProtections = creatureSkillSlotProtections.ToArray();
			creatureSkillSlotProtections.Clear();

			//
			// 용의둥지
			//
			WPDDragonNest dragonNest = new WPDDragonNest();
			if (drDragonNest != null)
			{
				dragonNest.nameKey = Convert.ToString(drDragonNest["nameKey"]);
				dragonNest.descriptionKey = Convert.ToString(drDragonNest["descriptionKey"]);
				dragonNest.sceneName = Convert.ToString(drDragonNest["sceneName"]);
				dragonNest.requiredConditionType = Convert.ToInt32(drDragonNest["requiredConditionType"]);
				dragonNest.requiredHeroLevel = Convert.ToInt32(drDragonNest["requiredHeroLevel"]);
				dragonNest.requiredMainQuestNo = Convert.ToInt32(drDragonNest["requiredMainQuestNo"]);
				dragonNest.enterRequiredItemId = Convert.ToInt32(drDragonNest["enterRequiredItemId"]);
				dragonNest.enterMinMemberCount = Convert.ToInt32(drDragonNest["enterMinMemberCount"]);
				dragonNest.enterMaxMemberCount = Convert.ToInt32(drDragonNest["enterMaxMemberCount"]);
				dragonNest.matchingWaitingTime = Convert.ToInt32(drDragonNest["matchingWaitingTime"]);
				dragonNest.enterWaitingTime = Convert.ToInt32(drDragonNest["enterWaitingTime"]);
				dragonNest.startDelayTime = Convert.ToInt32(drDragonNest["startDelayTime"]);
				dragonNest.limitTime = Convert.ToInt32(drDragonNest["limitTime"]);
				dragonNest.exitDelayTime = Convert.ToInt32(drDragonNest["exitDelayTime"]);
				dragonNest.startXPosition = Convert.ToSingle(drDragonNest["startXPosition"]);
				dragonNest.startYPosition = Convert.ToSingle(drDragonNest["startYPosition"]);
				dragonNest.startZPosition = Convert.ToSingle(drDragonNest["startZPosition"]);
				dragonNest.startRadius = Convert.ToSingle(drDragonNest["startRadius"]);
				dragonNest.startYRotationType = Convert.ToInt32(drDragonNest["startYRotationType"]);
				dragonNest.startYRotation = Convert.ToSingle(drDragonNest["startYRotation"]);
				dragonNest.safeRevivalWaitingTime = Convert.ToInt32(drDragonNest["safeRevivalWaitingTime"]);
				dragonNest.baseMaxStep = Convert.ToInt32(drDragonNest["baseMaxStep"]);
				dragonNest.areaEffectPrefabName = Convert.ToString(drDragonNest["areaEffectPrefabName"]);
				dragonNest.areaEffectScale = Convert.ToSingle(drDragonNest["areaEffectScale"]);
				dragonNest.trapPenaltyMoveSpeed = Convert.ToInt32(drDragonNest["trapPenaltyMoveSpeed"]);
				dragonNest.trapPenaltyDuration = Convert.ToInt32(drDragonNest["trapPenaltyDuration"]);
				dragonNest.locationId = Convert.ToInt32(drDragonNest["locationId"]);
				dragonNest.x = Convert.ToSingle(drDragonNest["x"]);
				dragonNest.z = Convert.ToSingle(drDragonNest["z"]);
				dragonNest.xSize = Convert.ToSingle(drDragonNest["xSize"]);
				dragonNest.zSize = Convert.ToSingle(drDragonNest["zSize"]);

			}
			gameDatas.dragonNest = dragonNest;

			//
			// 용의둥지획득가능보상 목록
			//
			List<WPDDragonNestAvailableReward> dragonNestAvailableRewards = new List<WPDDragonNestAvailableReward>();
			foreach (DataRow dr in drcDragonNestAvailableRewards)
			{
				WPDDragonNestAvailableReward data = new WPDDragonNestAvailableReward();
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);

				dragonNestAvailableRewards.Add(data);
			}
			gameDatas.dragonNestAvailableRewards = dragonNestAvailableRewards.ToArray();
			dragonNestAvailableRewards.Clear();

			//
			// 용의둥지장애물 목록
			//
			List<WPDDragonNestObstacle> dragonNestObstacles = new List<WPDDragonNestObstacle>();
			foreach (DataRow dr in drcDragonNestObstacles)
			{
				WPDDragonNestObstacle data = new WPDDragonNestObstacle();
				data.obstacleId = Convert.ToInt32(dr["obstacleId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);
				data.scale = Convert.ToSingle(dr["scale"]);

				dragonNestObstacles.Add(data);
			}
			gameDatas.dragonNestObstacles = dragonNestObstacles.ToArray();
			dragonNestObstacles.Clear();

			//
			// 용의둥지함정 목록
			//
			List<WPDDragonNestTrap> dragonNestTraps = new List<WPDDragonNestTrap>();
			foreach (DataRow dr in drcDragonNestTraps)
			{
				WPDDragonNestTrap data = new WPDDragonNestTrap();
				data.trapId = Convert.ToInt32(dr["trapId"]);
				data.prefabName = Convert.ToString(dr["prefabName"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.radius = Convert.ToSingle(dr["radius"]);
				data.damage = Convert.ToInt32(dr["damage"]);
				data.activationStepNo = Convert.ToInt32(dr["activationStepNo"]);
				data.deactivationStepNo = Convert.ToInt32(dr["deactivationStepNo"]);

				dragonNestTraps.Add(data);
			}
			gameDatas.dragonNestTraps = dragonNestTraps.ToArray();
			dragonNestTraps.Clear();


			//
			// 용의둥지단계 목록
			//
			List<WPDDragonNestStep> dragonNestSteps = new List<WPDDragonNestStep>();
			foreach (DataRow dr in drcDragonNestSteps)
			{
				WPDDragonNestStep data = new WPDDragonNestStep();
				data.stepNo = Convert.ToInt32(dr["stepNo"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);
				data.startDelayTime = Convert.ToInt32(dr["startDelayTime"]);
				data.targetAreaDisplayed = Convert.ToBoolean(dr["targetAreaDisplayed"]);
				data.targetXPosition = Convert.ToSingle(dr["targetXPosition"]);
				data.targetYPosition = Convert.ToSingle(dr["targetYPosition"]);
				data.targetZPosition = Convert.ToSingle(dr["targetZPosition"]);
				data.targetRadius = Convert.ToSingle(dr["targetRadius"]);
				data.removeObstacleId = Convert.ToInt32(dr["removeObstacleId"]);
				data.guideImageName = Convert.ToString(dr["guideImageName"]);
				data.guideTitleKey = Convert.ToString(dr["guideTitleKey"]);
				data.guideContentKey = Convert.ToString(dr["guideContentKey"]);

				dragonNestSteps.Add(data);
			}
			gameDatas.dragonNestSteps = dragonNestSteps.ToArray();
			dragonNestSteps.Clear();

			//
			// 용의둥지단계보상 목록
			//
			List<WPDDragonNestStepReward> dragonNestStepRewards = new List<WPDDragonNestStepReward>();
			foreach (DataRow dr in drcDragonNestStepRewards)
			{
				WPDDragonNestStepReward data = new WPDDragonNestStepReward();
				data.stepNo = Convert.ToInt32(dr["stepNo"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				dragonNestStepRewards.Add(data);
			}
			gameDatas.dragonNestStepRewards = dragonNestStepRewards.ToArray();
			dragonNestStepRewards.Clear();

			//
			// 증정 목록
			//
			List<WPDPresent> presents = new List<WPDPresent>();
			foreach (DataRow dr in drcPresents)
			{
				WPDPresent data = new WPDPresent();
				data.presentId = Convert.ToInt32(dr["presentId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.requiredVipLevel = Convert.ToInt32(dr["requiredVipLevel"]);
				data.imageName = Convert.ToString(dr["imageName"]);
				data.displayCount = Convert.ToInt32(dr["displayCount"]);
				data.requiredDia = Convert.ToInt32(dr["requiredDia"]);
				data.popularityPoint = Convert.ToInt32(dr["popularityPoint"]);
				data.contributionPoint = Convert.ToInt32(dr["contributionPoint"]);
				data.isMessageSend = Convert.ToBoolean(dr["isMessageSend"]);
				data.messageTextKey = Convert.ToString(dr["messageTextKey"]);
				data.isEffectDisplay = Convert.ToBoolean(dr["isEffectDisplay"]);
				data.effectPrefabName = Convert.ToString(dr["effectPrefabName"]);

				presents.Add(data);
			}
			gameDatas.presents = presents.ToArray();
			presents.Clear();

			//
			// 주간증정인기점수랭킹보상그룹 목록
			//
			List<WPDWeeklyPresentPopularityPointRankingRewardGroup> weeklyPresentPopularityPointRankingRewardGroups = new List<WPDWeeklyPresentPopularityPointRankingRewardGroup>();
			foreach (DataRow dr in drcWeeklyPresentPopularityPointRankingRewardGroups)
			{
				WPDWeeklyPresentPopularityPointRankingRewardGroup data = new WPDWeeklyPresentPopularityPointRankingRewardGroup();
				data.groupNo = Convert.ToInt32(dr["groupNo"]);
				data.highRanking = Convert.ToInt32(dr["highRanking"]);
				data.lowRanking = Convert.ToInt32(dr["lowRanking"]);

				weeklyPresentPopularityPointRankingRewardGroups.Add(data);
			}
			gameDatas.weeklyPresentPopularityPointRankingRewardGroups = weeklyPresentPopularityPointRankingRewardGroups.ToArray();
			weeklyPresentPopularityPointRankingRewardGroups.Clear();

			//
			// 주간증정인기점수랭킹보상 목록
			//
			List<WPDWeeklyPresentPopularityPointRankingReward> weeklyPresentPopularityPointRankingRewards = new List<WPDWeeklyPresentPopularityPointRankingReward>();
			foreach (DataRow dr in drcWeeklyPresentPopularityPointRankingRewards)
			{
				WPDWeeklyPresentPopularityPointRankingReward data = new WPDWeeklyPresentPopularityPointRankingReward();
				data.groupNo = Convert.ToInt32(dr["groupNo"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				weeklyPresentPopularityPointRankingRewards.Add(data);
			}
			gameDatas.weeklyPresentPopularityPointRankingRewards = weeklyPresentPopularityPointRankingRewards.ToArray();
			weeklyPresentPopularityPointRankingRewards.Clear();

			//
			// 주간증정공헌점수랭킹보상그룹 목록
			//
			List<WPDWeeklyPresentContributionPointRankingRewardGroup> weeklyPresentContributionPointRankingRewardGroups = new List<WPDWeeklyPresentContributionPointRankingRewardGroup>();
			foreach (DataRow dr in drcWeeklyPresentContributionPointRankingRewardGroups)
			{
				WPDWeeklyPresentContributionPointRankingRewardGroup data = new WPDWeeklyPresentContributionPointRankingRewardGroup();
				data.groupNo = Convert.ToInt32(dr["groupNo"]);
				data.highRanking = Convert.ToInt32(dr["highRanking"]);
				data.lowRanking = Convert.ToInt32(dr["lowRanking"]);

				weeklyPresentContributionPointRankingRewardGroups.Add(data);
			}
			gameDatas.weeklyPresentContributionPointRankingRewardGroups = weeklyPresentContributionPointRankingRewardGroups.ToArray();
			weeklyPresentContributionPointRankingRewardGroups.Clear();

			//
			// 주간증정공헌점수랭킹보상 목록
			//
			List<WPDWeeklyPresentContributionPointRankingReward> weeklyPresentContributionPointRankingRewards = new List<WPDWeeklyPresentContributionPointRankingReward>();
			foreach (DataRow dr in drcWeeklyPresentContributionPointRankingRewards)
			{
				WPDWeeklyPresentContributionPointRankingReward data = new WPDWeeklyPresentContributionPointRankingReward();
				data.groupNo = Convert.ToInt32(dr["groupNo"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				weeklyPresentContributionPointRankingRewards.Add(data);
			}
			gameDatas.weeklyPresentContributionPointRankingRewards = weeklyPresentContributionPointRankingRewards.ToArray();
			weeklyPresentContributionPointRankingRewards.Clear();

			//
			// 메인퀘스트시작대화 목록
			//
			List<WPDMainQuestStartDialogue> mainQuestStartDialogues = new List<WPDMainQuestStartDialogue>();
			foreach (DataRow dr in drcMainQuestStartDialogues)
			{
				WPDMainQuestStartDialogue data = new WPDMainQuestStartDialogue();
				data.mainQuestNo = Convert.ToInt32(dr["mainQuestNo"]);
				data.dialogueNo = Convert.ToInt32(dr["dialogueNo"]);
				data.npcId = Convert.ToInt32(dr["npcId"]);
				data.dialogueKey = Convert.ToString(dr["dialogueKey"]);

				mainQuestStartDialogues.Add(data);
			}
			gameDatas.mainQuestStartDialogues = mainQuestStartDialogues.ToArray();
			mainQuestStartDialogues.Clear();

			//
			// 메인퀘스트완료대화 목록
			//
			List<WPDMainQuestCompletionDialogue> mainQuestCompletionDialogues = new List<WPDMainQuestCompletionDialogue>();
			foreach (DataRow dr in drcMainQuestCompletionDialogues)
			{
				WPDMainQuestCompletionDialogue data = new WPDMainQuestCompletionDialogue();
				data.mainQuestNo = Convert.ToInt32(dr["mainQuestNo"]);
				data.dialogueNo = Convert.ToInt32(dr["dialogueNo"]);
				data.npcId = Convert.ToInt32(dr["npcId"]);
				data.dialogueKey = Convert.ToString(dr["dialogueKey"]);

				mainQuestCompletionDialogues.Add(data);
			}
			gameDatas.mainQuestCompletionDialogues = mainQuestCompletionDialogues.ToArray();
			mainQuestCompletionDialogues.Clear();

			//
			// 크리처농장퀘스트
			//
			WPDCreatureFarmQuest creatureFarmQuest = new WPDCreatureFarmQuest();
			if (drCreatureFarmQuest != null)
			{
				creatureFarmQuest.nameKey = Convert.ToString(drCreatureFarmQuest["nameKey"]);
				creatureFarmQuest.requiredHeroLevel = Convert.ToInt32(drCreatureFarmQuest["requiredHeroLevel"]);
				creatureFarmQuest.startNpcId = Convert.ToInt32(drCreatureFarmQuest["startNpcId"]);
				creatureFarmQuest.completionNpcId = Convert.ToInt32(drCreatureFarmQuest["completionNpcId"]);
				creatureFarmQuest.limitCount = Convert.ToInt32(drCreatureFarmQuest["limitCount"]);
				creatureFarmQuest.startDialogueKey = Convert.ToString(drCreatureFarmQuest["startDialogueKey"]);
				creatureFarmQuest.completionDialogueKey = Convert.ToString(drCreatureFarmQuest["completionDialogueKey"]);

			}
			gameDatas.creatureFarmQuest = creatureFarmQuest;

			//
			// 크리처농장퀘스트경험치보상 목록
			//
			List<WPDCreatureFarmQuestExpReward> creatureFarmQuestExpRewards = new List<WPDCreatureFarmQuestExpReward>();
			foreach (DataRow dr in drcCreatureFarmQuestExpRewards)
			{
				WPDCreatureFarmQuestExpReward data = new WPDCreatureFarmQuestExpReward();
				data.level = Convert.ToInt32(dr["level"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);

				creatureFarmQuestExpRewards.Add(data);
			}
			gameDatas.creatureFarmQuestExpRewards = creatureFarmQuestExpRewards.ToArray();
			creatureFarmQuestExpRewards.Clear();

			//
			// 크리처농장퀘스트아이템보상 목록
			//
			List<WPDCreatureFarmQuestItemReward> creatureFarmQuestItemRewards = new List<WPDCreatureFarmQuestItemReward>();
			foreach (DataRow dr in drcCreatureFarmQuestItemRewards)
			{
				WPDCreatureFarmQuestItemReward data = new WPDCreatureFarmQuestItemReward();
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				creatureFarmQuestItemRewards.Add(data);
			}
			gameDatas.creatureFarmQuestItemRewards = creatureFarmQuestItemRewards.ToArray();
			creatureFarmQuestItemRewards.Clear();

			//
			// 크리처농장퀘스트미션 목록
			//
			List<WPDCreatureFarmQuestMission> creatureFarmQuestMissions = new List<WPDCreatureFarmQuestMission>();
			foreach (DataRow dr in drcCreatureFarmQuestMissions)
			{
				WPDCreatureFarmQuestMission data = new WPDCreatureFarmQuestMission();
				data.missionNo = Convert.ToInt32(dr["missionNo"]);
				data.targetType = Convert.ToInt32(dr["targetType"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);
				data.targetContinentId = Convert.ToInt32(dr["targetContinentId"]);
				data.targetXPosition = Convert.ToSingle(dr["targetXPosition"]);
				data.targetYPosition = Convert.ToSingle(dr["targetYPosition"]);
				data.targetZPosition = Convert.ToSingle(dr["targetZPosition"]);
				data.targetRadius = Convert.ToSingle(dr["targetRadius"]);
				data.targetContinentObjectId = Convert.ToInt32(dr["targetContinentObjectId"]);
				data.targetAutoCompletionTime = Convert.ToInt32(dr["targetAutoCompletionTime"]);
				data.targetCount = Convert.ToInt32(dr["targetCount"]);

				creatureFarmQuestMissions.Add(data);
			}
			gameDatas.creatureFarmQuestMissions = creatureFarmQuestMissions.ToArray();
			creatureFarmQuestMissions.Clear();

			//
			// 코스튬 목록
			//
			List<WPDCostume> costumes = new List<WPDCostume>();
			foreach (DataRow dr in drcCostumes)
			{
				WPDCostume data = new WPDCostume();
				data.costumeId = Convert.ToInt32(dr["costumeId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.prefabName = Convert.ToString(dr["prefabName"]);
				data.requiredHeroLevel = Convert.ToInt32(dr["requiredHeroLevel"]);
				data.periodLimitDay = Convert.ToInt32(dr["periodLimitDay"]);

				costumes.Add(data);
			}
			gameDatas.costumes = costumes.ToArray();
			costumes.Clear();

			//
			// 코스튬효과 목록
			//
			List<WPDCostumeEffect> costumeEffects = new List<WPDCostumeEffect>();
			foreach (DataRow dr in drcCostumeEffects)
			{
				WPDCostumeEffect data = new WPDCostumeEffect();
				data.costumeEffectId = Convert.ToInt32(dr["costumeEffectId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.prefabName = Convert.ToString(dr["prefabName"]);
				data.requiredItemId = Convert.ToInt32(dr["requiredItemId"]);

				costumeEffects.Add(data);
			}
			gameDatas.costumeEffects = costumeEffects.ToArray();
			costumeEffects.Clear();

			//
			// 안전시간이벤트
			//
			WPDSafeTimeEvent safeTimeEvent = new WPDSafeTimeEvent();
			if (drSafeTimeEvent != null)
			{
				safeTimeEvent.requiredAutoDuration = Convert.ToInt32(drSafeTimeEvent["requiredAutoDuration"]);
				safeTimeEvent.startTime = Convert.ToInt32(drSafeTimeEvent["startTime"]);
				safeTimeEvent.endTime = Convert.ToInt32(drSafeTimeEvent["endTime"]);

			}
			gameDatas.safeTimeEvent = safeTimeEvent;

			//
			// 길드축복버프 목록
			//
			List<WPDGuildBlessingBuff> guildBlessingBuffs = new List<WPDGuildBlessingBuff>();
			foreach (DataRow dr in drcGuildBlessingBuffs)
			{
				WPDGuildBlessingBuff data = new WPDGuildBlessingBuff();
				data.buffId = Convert.ToInt32(dr["buffId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.expRewardFactor = Convert.ToSingle(dr["expRewardFactor"]);
				data.duration = Convert.ToInt32(dr["duration"]);
				data.dia = Convert.ToInt32(dr["dia"]);

				guildBlessingBuffs.Add(data);
			}
			gameDatas.guildBlessingBuffs = guildBlessingBuffs.ToArray();
			guildBlessingBuffs.Clear();

			//
			// 인앱상품 목록
			//
			List<WPDInAppProduct> inAppProducts = new List<WPDInAppProduct>();
			foreach (DataRow dr in drcInAppProducts)
			{
				WPDInAppProduct data = new WPDInAppProduct();
				data.inAppProductKey = Convert.ToString(dr["inAppProductKey"]);

				inAppProducts.Add(data);
			}
			gameDatas.inAppProducts = inAppProducts.ToArray();
			inAppProducts.Clear();

			//
			// 인앱상품가격 목록
			//
			List<WPDInAppProductPrice> inAppProductPrices = new List<WPDInAppProductPrice>();
			foreach (DataRow dr in drcInAppProductPrices)
			{
				WPDInAppProductPrice data = new WPDInAppProductPrice();
				data.inAppProductKey = Convert.ToString(dr["inAppProductKey"]);
				data.storeType = Convert.ToInt32(dr["storeType"]);
				data.currencyCode = Convert.ToString(dr["currencyCode"]);
				data.displayPrice = Convert.ToString(dr["displayPrice"]);

				inAppProductPrices.Add(data);
			}
			gameDatas.inAppProductPrices = inAppProductPrices.ToArray();
			inAppProductPrices.Clear();

			//
			// 캐시상품 목록
			//
			List<WPDCashProduct> cashProducts = new List<WPDCashProduct>();
			foreach (DataRow dr in drcCashProducts)
			{
				WPDCashProduct data = new WPDCashProduct();
				data.productId = Convert.ToInt32(dr["productId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.inAppProductKey = Convert.ToString(dr["inAppProductKey"]);
				data.imageName = Convert.ToString(dr["imageName"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.unOwnDia = Convert.ToInt32(dr["unOwnDia"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);
				data.itemOwned = Convert.ToBoolean(dr["itemOwned"]);
				data.itemCount = Convert.ToInt32(dr["itemCount"]);
				data.vipPoint = Convert.ToInt32(dr["vipPoint"]);
				data.firstPurchaseBonusUnOwnDia = Convert.ToInt32(dr["firstPurchaseBonusUnOwnDia"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);

				cashProducts.Add(data);
			}
			gameDatas.cashProducts = cashProducts.ToArray();
			cashProducts.Clear();

			//
			// 전직퀘스트 목록
			//
			List<WPDJobChangeQuest> jobChangeQuests = new List<WPDJobChangeQuest>();
			foreach (DataRow dr in drcJobChangeQuests)
			{
				WPDJobChangeQuest data = new WPDJobChangeQuest();
				data.questNo = Convert.ToInt32(dr["questNo"]);
				data.titleKey = Convert.ToString(dr["titleKey"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);
				data.questNpcId = Convert.ToInt32(dr["questNpcId"]);
				data.startDialogueKey = Convert.ToString(dr["startDialogueKey"]);
				data.completionDialogueKey = Convert.ToString(dr["completionDialogueKey"]);
				data.type = Convert.ToInt32(dr["type"]);
				data.isTargetOwnNation = Convert.ToBoolean(dr["isTargetOwnNation"]);
				data.targetContinentId = Convert.ToInt32(dr["targetContinentId"]);
				data.targetXPosition = Convert.ToSingle(dr["targetXPosition"]);
				data.targetYPosition = Convert.ToSingle(dr["targetYPosition"]);
				data.targetZPosition = Convert.ToSingle(dr["targetZPosition"]);
				data.targetRadius = Convert.ToSingle(dr["targetRadius"]);
				data.targetMonsterId = Convert.ToInt32(dr["targetMonsterId"]);
				data.targetContinentObjectId = Convert.ToInt32(dr["targetContinentObjectId"]);
				data.targetCount = Convert.ToInt32(dr["targetCount"]);
				data.limitTime = Convert.ToInt32(dr["limitTime"]);
				data.targetMonsterArrangeId = Convert.ToInt64(dr["targetMonsterArrangeId"]);
				data.targetGuildTerritoryXPosition = Convert.ToSingle(dr["targetGuildTerritoryXPosition"]);
				data.targetGuildTerritoryYPosition = Convert.ToSingle(dr["targetGuildTerritoryYPosition"]);
				data.targetGuildTerritoryZPosition = Convert.ToSingle(dr["targetGuildTerritoryZPosition"]);
				data.targetGuildTerritoryRadius = Convert.ToSingle(dr["targetGuildTerritoryRadius"]);
				data.targetGuildMonsterArrangeId = Convert.ToInt64(dr["targetGuildMonsterArrangeId"]);
				data.completionItemRewardId = Convert.ToInt64(dr["completionItemRewardId"]);

				jobChangeQuests.Add(data);
			}
			gameDatas.jobChangeQuests = jobChangeQuests.ToArray();
			jobChangeQuests.Clear();

			//
			// 전직퀘스트난이도 목록
			//
			List<WPDJobChangeQuestDifficulty> jobChangeQuestDifficulties = new List<WPDJobChangeQuestDifficulty>();
			foreach (DataRow dr in drcJobChangeQuestDifficulties)
			{
				WPDJobChangeQuestDifficulty data = new WPDJobChangeQuestDifficulty();
				data.questNo = Convert.ToInt32(dr["questNo"]);
				data.difficulty = Convert.ToInt32(dr["difficulty"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.isTargetPlaceGuildTerritory = Convert.ToBoolean(dr["isTargetPlaceGuildTerritory"]);

				jobChangeQuestDifficulties.Add(data);
			}
			gameDatas.jobChangeQuestDifficulties = jobChangeQuestDifficulties.ToArray();
			jobChangeQuestDifficulties.Clear();

			//
			// 첫충전이벤트
			//
			WPDFirstChargeEvent firstChargeEvent = new WPDFirstChargeEvent();
			if (drFirstChargeEvent != null)
			{
				firstChargeEvent.nameKey = Convert.ToString(drFirstChargeEvent["nameKey"]);
				firstChargeEvent.descriptionKey = Convert.ToString(drFirstChargeEvent["descriptionKey"]);

			}
			gameDatas.firstChargeEvent = firstChargeEvent;

			//
			// 첫충전이벤트보상 목록
			//
			List<WPDFirstChargeEventReward> firstChargeEventRewards = new List<WPDFirstChargeEventReward>();
			foreach (DataRow dr in drcFirstChargeEventRewards)
			{
				WPDFirstChargeEventReward data = new WPDFirstChargeEventReward();
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				firstChargeEventRewards.Add(data);
			}
			gameDatas.firstChargeEventRewards = firstChargeEventRewards.ToArray();
			firstChargeEventRewards.Clear();

			//
			// 재충전이벤트
			//
			WPDRechargeEvent rechargeEvent = new WPDRechargeEvent();
			if (drRechargeEvent != null)
			{
				rechargeEvent.nameKey = Convert.ToString(drRechargeEvent["nameKey"]);
				rechargeEvent.descriptionKey = Convert.ToString(drRechargeEvent["descriptionKey"]);
				rechargeEvent.requiredUnOwnDia = Convert.ToInt32(drRechargeEvent["requiredUnOwnDia"]);

			}
			gameDatas.rechargeEvent = rechargeEvent;

			//
			// 재충전이벤트보상 목록
			//
			List<WPDRechargeEventReward> rechargeEventRewards = new List<WPDRechargeEventReward>();
			foreach (DataRow dr in drcRechargeEventRewards)
			{
				WPDRechargeEventReward data = new WPDRechargeEventReward();
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				rechargeEventRewards.Add(data);
			}
			gameDatas.rechargeEventRewards = rechargeEventRewards.ToArray();
			rechargeEventRewards.Clear();

			//
			// 충전이벤트 목록
			//
			List<WPDChargeEvent> chargeEvents = new List<WPDChargeEvent>();
			foreach (DataRow dr in drcChargeEvents)
			{
				WPDChargeEvent data = new WPDChargeEvent();
				data.eventId = Convert.ToInt32(dr["eventId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.startTime = (dr["startTime"] != DBNull.Value) ? DateTime.Parse(dr["startTime"].ToString()) : DateTime.MinValue;
				data.endTime = (dr["endTime"] != DBNull.Value) ? DateTime.Parse(dr["endTime"].ToString()) : DateTime.MinValue;

				chargeEvents.Add(data);
			}
			gameDatas.chargeEvents = chargeEvents.ToArray();
			chargeEvents.Clear();

			//
			// 충전이벤트미션 목록
			//
			List<WPDChargeEventMission> chargeEventMissions = new List<WPDChargeEventMission>();
			foreach (DataRow dr in drcChargeEventMissions)
			{
				WPDChargeEventMission data = new WPDChargeEventMission();
				data.eventId = Convert.ToInt32(dr["eventId"]);
				data.missionNo = Convert.ToInt32(dr["missionNo"]);
				data.requiredUnOwnDia = Convert.ToInt32(dr["requiredUnOwnDia"]);

				chargeEventMissions.Add(data);
			}
			gameDatas.chargeEventMissions = chargeEventMissions.ToArray();
			chargeEventMissions.Clear();

			//
			// 충전이벤트미션보상 목록
			//
			List<WPDChargeEventMissionReward> chargeEventMissionRewards = new List<WPDChargeEventMissionReward>();
			foreach (DataRow dr in drcChargeEventMissionRewards)
			{
				WPDChargeEventMissionReward data = new WPDChargeEventMissionReward();
				data.eventId = Convert.ToInt32(dr["eventId"]);
				data.missionNo = Convert.ToInt32(dr["missionNo"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				chargeEventMissionRewards.Add(data);
			}
			gameDatas.chargeEventMissionRewards = chargeEventMissionRewards.ToArray();
			chargeEventMissionRewards.Clear();

			//
			// 일일충전이벤트
			//
			WPDDailyChargeEvent dailyChargeEvent = new WPDDailyChargeEvent();
			if (drDailyChargeEvent != null)
			{
				dailyChargeEvent.nameKey = Convert.ToString(drDailyChargeEvent["nameKey"]);
				dailyChargeEvent.descriptionKey = Convert.ToString(drDailyChargeEvent["descriptionKey"]);
				dailyChargeEvent.requiredHeroLevel = Convert.ToInt32(drDailyChargeEvent["requiredHeroLevel"]);

			}
			gameDatas.dailyChargeEvent = dailyChargeEvent;

			//
			// 일일충전이벤트미션 목록
			//
			List<WPDDailyChargeEventMission> dailyChargeEventMissions = new List<WPDDailyChargeEventMission>();
			foreach (DataRow dr in drcDailyChargeEventMissions)
			{
				WPDDailyChargeEventMission data = new WPDDailyChargeEventMission();
				data.missionNo = Convert.ToInt32(dr["missionNo"]);
				data.requiredUnOwnDia = Convert.ToInt32(dr["requiredUnOwnDia"]);

				dailyChargeEventMissions.Add(data);
			}
			gameDatas.dailyChargeEventMissions = dailyChargeEventMissions.ToArray();
			dailyChargeEventMissions.Clear();

			//
			// 일일충전이벤트미션보상 목록
			//
			List<WPDDailyChargeEventMissionReward> dailyChargeEventMissionRewards = new List<WPDDailyChargeEventMissionReward>();
			foreach (DataRow dr in drcDailyChargeEventMissionRewards)
			{
				WPDDailyChargeEventMissionReward data = new WPDDailyChargeEventMissionReward();
				data.missionNo = Convert.ToInt32(dr["missionNo"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				dailyChargeEventMissionRewards.Add(data);
			}
			gameDatas.dailyChargeEventMissionRewards = dailyChargeEventMissionRewards.ToArray();
			dailyChargeEventMissionRewards.Clear();

			//
			// 소비이벤트 목록
			//
			List<WPDConsumeEvent> consumeEvents = new List<WPDConsumeEvent>();
			foreach (DataRow dr in drcConsumeEvents)
			{
				WPDConsumeEvent data = new WPDConsumeEvent();
				data.eventId = Convert.ToInt32(dr["eventId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.startTime = (dr["startTime"] != DBNull.Value) ? DateTime.Parse(dr["startTime"].ToString()) : DateTime.MinValue;
				data.endTime = (dr["endTime"] != DBNull.Value) ? DateTime.Parse(dr["endTime"].ToString()) : DateTime.MinValue;

				consumeEvents.Add(data);
			}
			gameDatas.consumeEvents = consumeEvents.ToArray();
			consumeEvents.Clear();

			//
			// 소비이벤트미션 목록
			//
			List<WPDConsumeEventMission> consumeEventMissions = new List<WPDConsumeEventMission>();
			foreach (DataRow dr in drcConsumeEventMissions)
			{
				WPDConsumeEventMission data = new WPDConsumeEventMission();
				data.eventId = Convert.ToInt32(dr["eventId"]);
				data.missionNo = Convert.ToInt32(dr["missionNo"]);
				data.requiredDia = Convert.ToInt32(dr["requiredDia"]);

				consumeEventMissions.Add(data);
			}
			gameDatas.consumeEventMissions = consumeEventMissions.ToArray();
			consumeEventMissions.Clear();

			//
			// 소비이벤트미션보상 목록
			//
			List<WPDConsumeEventMissionReward> consumeEventMissionRewards = new List<WPDConsumeEventMissionReward>();
			foreach (DataRow dr in drcConsumeEventMissionRewards)
			{
				WPDConsumeEventMissionReward data = new WPDConsumeEventMissionReward();
				data.eventId = Convert.ToInt32(dr["eventId"]);
				data.missionNo = Convert.ToInt32(dr["missionNo"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				consumeEventMissionRewards.Add(data);
			}
			gameDatas.consumeEventMissionRewards = consumeEventMissionRewards.ToArray();
			consumeEventMissionRewards.Clear();

			//
			// 일일소비이벤트
			//
			WPDDailyConsumeEvent dailyConsumeEvent = new WPDDailyConsumeEvent();
			if (drDailyConsumeEvent != null)
			{
				dailyConsumeEvent.nameKey = Convert.ToString(drDailyConsumeEvent["nameKey"]);
				dailyConsumeEvent.descriptionKey = Convert.ToString(drDailyConsumeEvent["descriptionKey"]);
				dailyConsumeEvent.requiredHeroLevel = Convert.ToInt32(drDailyConsumeEvent["requiredHeroLevel"]);

			}
			gameDatas.dailyConsumeEvent = dailyConsumeEvent;

			//
			// 일일소비이벤트미션 목록
			//
			List<WPDDailyConsumeEventMission> dailyConsumeEventMissions = new List<WPDDailyConsumeEventMission>();
			foreach (DataRow dr in drcDailyConsumeEventMissions)
			{
				WPDDailyConsumeEventMission data = new WPDDailyConsumeEventMission();
				data.missionNo = Convert.ToInt32(dr["missionNo"]);
				data.requiredDia = Convert.ToInt32(dr["requiredDia"]);

				dailyConsumeEventMissions.Add(data);
			}
			gameDatas.dailyConsumeEventMissions = dailyConsumeEventMissions.ToArray();
			dailyConsumeEventMissions.Clear();

			//
			// 일일소비이벤트미션보상 목록
			//
			List<WPDDailyConsumeEventMissionReward> dailyConsumeEventMissionRewards = new List<WPDDailyConsumeEventMissionReward>();
			foreach (DataRow dr in drcDailyConsumeEventMissionRewards)
			{
				WPDDailyConsumeEventMissionReward data = new WPDDailyConsumeEventMissionReward();
				data.missionNo = Convert.ToInt32(dr["missionNo"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemRewardId = Convert.ToInt64(dr["itemRewardId"]);

				dailyConsumeEventMissionRewards.Add(data);
			}
			gameDatas.dailyConsumeEventMissionRewards = dailyConsumeEventMissionRewards.ToArray();
			dailyConsumeEventMissionRewards.Clear();

			//
			// 안쿠의무덤
			//
			WPDAnkouTomb ankouTomb = new WPDAnkouTomb();
			if (drAnkouTomb != null)
			{
				ankouTomb.nameKey = Convert.ToString(drAnkouTomb["nameKey"]);
				ankouTomb.descriptionKey = Convert.ToString(drAnkouTomb["descriptionKey"]);
				ankouTomb.targetTitleKey = Convert.ToString(drAnkouTomb["targetTitleKey"]);
				ankouTomb.targetContentKey = Convert.ToString(drAnkouTomb["targetContentKey"]);
				ankouTomb.sceneName = Convert.ToString(drAnkouTomb["sceneName"]);
				ankouTomb.requiredConditionType = Convert.ToInt32(drAnkouTomb["requiredConditionType"]);
				ankouTomb.requiredHeroLevel = Convert.ToInt32(drAnkouTomb["requiredHeroLevel"]);
				ankouTomb.requiredMainQuestNo = Convert.ToInt32(drAnkouTomb["requiredMainQuestNo"]);
				ankouTomb.requiredStamina = Convert.ToInt32(drAnkouTomb["requiredStamina"]);
				ankouTomb.enterCount = Convert.ToInt32(drAnkouTomb["enterCount"]);
				ankouTomb.enterMinMemberCount = Convert.ToInt32(drAnkouTomb["enterMinMemberCount"]);
				ankouTomb.enterMaxMemberCount = Convert.ToInt32(drAnkouTomb["enterMaxMemberCount"]);
				ankouTomb.waveCount = Convert.ToInt32(drAnkouTomb["waveCount"]);
				ankouTomb.matchingWaitingTime = Convert.ToInt32(drAnkouTomb["matchingWaitingTime"]);
				ankouTomb.enterWaitingTime = Convert.ToInt32(drAnkouTomb["enterWaitingTime"]);
				ankouTomb.startDelayTime = Convert.ToInt32(drAnkouTomb["startDelayTime"]);
				ankouTomb.limitTime = Convert.ToInt32(drAnkouTomb["limitTime"]);
				ankouTomb.exitDelayTime = Convert.ToInt32(drAnkouTomb["exitDelayTime"]);
				ankouTomb.startXPosition = Convert.ToSingle(drAnkouTomb["startXPosition"]);
				ankouTomb.startYPosition = Convert.ToSingle(drAnkouTomb["startYPosition"]);
				ankouTomb.startZPosition = Convert.ToSingle(drAnkouTomb["startZPosition"]);
				ankouTomb.startRadius = Convert.ToSingle(drAnkouTomb["startRadius"]);
				ankouTomb.startYRotationType = Convert.ToInt32(drAnkouTomb["startYRotationType"]);
				ankouTomb.startYRotation = Convert.ToSingle(drAnkouTomb["startYRotation"]);
				ankouTomb.monsterSpawnXPosition = Convert.ToSingle(drAnkouTomb["monsterSpawnXPosition"]);
				ankouTomb.monsterSpawnYPosition = Convert.ToSingle(drAnkouTomb["monsterSpawnYPosition"]);
				ankouTomb.monsterSpawnZPosition = Convert.ToSingle(drAnkouTomb["monsterSpawnZPosition"]);
				ankouTomb.monsterSpawnRadius = Convert.ToSingle(drAnkouTomb["monsterSpawnRadius"]);
				ankouTomb.monsterPoint = Convert.ToInt32(drAnkouTomb["monsterPoint"]);
				ankouTomb.bossMonsterPoint = Convert.ToInt32(drAnkouTomb["bossMonsterPoint"]);
				ankouTomb.clearPoint = Convert.ToInt32(drAnkouTomb["clearPoint"]);
				ankouTomb.exp2xRewardRequiredUnOwnDia = Convert.ToInt32(drAnkouTomb["exp2xRewardRequiredUnOwnDia"]);
				ankouTomb.exp3xRewardRequiredUnOwnDia = Convert.ToInt32(drAnkouTomb["exp3xRewardRequiredUnOwnDia"]);
				ankouTomb.safeRevivalWaitingTime = Convert.ToInt32(drAnkouTomb["safeRevivalWaitingTime"]);
				ankouTomb.locationId = Convert.ToInt32(drAnkouTomb["locationId"]);
				ankouTomb.x = Convert.ToSingle(drAnkouTomb["x"]);
				ankouTomb.z = Convert.ToSingle(drAnkouTomb["z"]);
				ankouTomb.xSize = Convert.ToSingle(drAnkouTomb["xSize"]);
				ankouTomb.zSize = Convert.ToSingle(drAnkouTomb["zSize"]);

			}
			gameDatas.ankouTomb = ankouTomb;

			//
			// 안쿠의무덤스케줄 목록
			//
			List<WPDAnkouTombSchedule> ankouTombSchedules = new List<WPDAnkouTombSchedule>();
			foreach (DataRow dr in drcAnkouTombSchedules)
			{
				WPDAnkouTombSchedule data = new WPDAnkouTombSchedule();
				data.scheduleId = Convert.ToInt32(dr["scheduleId"]);
				data.startTime = Convert.ToInt32(dr["startTime"]);
				data.endTime = Convert.ToInt32(dr["endTime"]);

				ankouTombSchedules.Add(data);
			}
			gameDatas.ankouTombSchedules = ankouTombSchedules.ToArray();
			ankouTombSchedules.Clear();

			//
			// 안쿠의무덤난이도 목록
			//
			List<WPDAnkouTombDifficulty> ankouTombDifficulties = new List<WPDAnkouTombDifficulty>();
			foreach (DataRow dr in drcAnkouTombDifficulties)
			{
				WPDAnkouTombDifficulty data = new WPDAnkouTombDifficulty();
				data.difficulty = Convert.ToInt32(dr["difficulty"]);
				data.recommendBattlePower = Convert.ToInt64(dr["recommendBattlePower"]);
				data.minHeroLevel = Convert.ToInt32(dr["minHeroLevel"]);
				data.maxHeroLevel = Convert.ToInt32(dr["maxHeroLevel"]);
				data.goldRewardId = Convert.ToInt64(dr["goldRewardId"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);
				data.pointGoldRewardId = Convert.ToInt64(dr["pointGoldRewardId"]);
				data.pointExpRewardId = Convert.ToInt64(dr["pointExpRewardId"]);
				data.maxAdditionalExp = Convert.ToInt64(dr["maxAdditionalExp"]);

				ankouTombDifficulties.Add(data);
			}
			gameDatas.ankouTombDifficulties = ankouTombDifficulties.ToArray();
			ankouTombDifficulties.Clear();

			//
			// 안쿠의모덤획득가능보상 목록
			//
			List<WPDAnkouTombAvailableReward> ankouTombAvailableRewards = new List<WPDAnkouTombAvailableReward>();
			foreach (DataRow dr in drcAnkouTombAvailableRewards)
			{
				WPDAnkouTombAvailableReward data = new WPDAnkouTombAvailableReward();
				data.difficulty = Convert.ToInt32(dr["difficulty"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);

				ankouTombAvailableRewards.Add(data);
			}
			gameDatas.ankouTombAvailableRewards = ankouTombAvailableRewards.ToArray();
			ankouTombAvailableRewards.Clear();

			//
			// 물약속성 목록
			//
			List<WPDPotionAttr> potionAttrs = new List<WPDPotionAttr>();
			foreach (DataRow dr in drcPotionAttrs)
			{
				WPDPotionAttr data = new WPDPotionAttr();
				data.potionAttrId = Convert.ToInt32(dr["potionAttrId"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.incAttrValueId = Convert.ToInt64(dr["incAttrValueId"]);
				data.requiredItemId = Convert.ToInt32(dr["requiredItemId"]);

				potionAttrs.Add(data);
			}
			gameDatas.potionAttrs = potionAttrs.ToArray();
			potionAttrs.Clear();

			//
			// 추천전투력레벨 목록
			//
			List<WPDRecommendBattlePowerLevel> recommendBattlePowerLevels = new List<WPDRecommendBattlePowerLevel>();
			foreach (DataRow dr in drcRecommendBattlePowerLevels)
			{
				WPDRecommendBattlePowerLevel data = new WPDRecommendBattlePowerLevel();
				data.level = Convert.ToInt32(dr["level"]);
				data.sRankBattlePower = Convert.ToInt64(dr["sRankBattlePower"]);
				data.aRankBattlePower = Convert.ToInt64(dr["aRankBattlePower"]);
				data.bRankBattlePower = Convert.ToInt64(dr["bRankBattlePower"]);
				data.cRankBattlePower = Convert.ToInt64(dr["cRankBattlePower"]);

				recommendBattlePowerLevels.Add(data);
			}
			gameDatas.recommendBattlePowerLevels = recommendBattlePowerLevels.ToArray();
			recommendBattlePowerLevels.Clear();

			//
			// 향상메인카테고리 목록
			//
			List<WPDImprovementMainCategory> improvementMainCategories = new List<WPDImprovementMainCategory>();
			foreach (DataRow dr in drcImprovementMainCategories)
			{
				WPDImprovementMainCategory data = new WPDImprovementMainCategory();
				data.mainCategoryId = Convert.ToInt32(dr["mainCategoryId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);

				improvementMainCategories.Add(data);
			}
			gameDatas.improvementMainCategories = improvementMainCategories.ToArray();
			improvementMainCategories.Clear();

			//
			// 향상메인카테고리컨텐츠 목록
			//
			List<WPDImprovementMainCategoryContent> improvementMainCategoryContents = new List<WPDImprovementMainCategoryContent>();
			foreach (DataRow dr in drcImprovementMainCategoryContents)
			{
				WPDImprovementMainCategoryContent data = new WPDImprovementMainCategoryContent();
				data.mainCategoryId = Convert.ToInt32(dr["mainCategoryId"]);
				data.contentId = Convert.ToInt32(dr["contentId"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);

				improvementMainCategoryContents.Add(data);
			}
			gameDatas.improvementMainCategoryContents = improvementMainCategoryContents.ToArray();
			improvementMainCategoryContents.Clear();

			//
			// 향상서브카테고리 목록
			//
			List<WPDImprovementSubCategory> improvementSubCategories = new List<WPDImprovementSubCategory>();
			foreach (DataRow dr in drcImprovementSubCategories)
			{
				WPDImprovementSubCategory data = new WPDImprovementSubCategory();
				data.subCategoryId = Convert.ToInt32(dr["subCategoryId"]);
				data.mainCategoryId = Convert.ToInt32(dr["mainCategoryId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);

				improvementSubCategories.Add(data);
			}
			gameDatas.improvementSubCategories = improvementSubCategories.ToArray();
			improvementSubCategories.Clear();

			//
			// 향상서브카테고리컨텐츠 목록
			//
			List<WPDImprovementSubCategoryContent> improvementSubCategoryContents = new List<WPDImprovementSubCategoryContent>();
			foreach (DataRow dr in drcImprovementSubCategoryContents)
			{
				WPDImprovementSubCategoryContent data = new WPDImprovementSubCategoryContent();
				data.subCategoryId = Convert.ToInt32(dr["subCategoryId"]);
				data.contentId = Convert.ToInt32(dr["contentId"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);

				improvementSubCategoryContents.Add(data);
			}
			gameDatas.improvementSubCategoryContents = improvementSubCategoryContents.ToArray();
			improvementSubCategoryContents.Clear();

			//
			// 향상컨텐츠 목록
			//
			List<WPDImprovementContent> improvementContents = new List<WPDImprovementContent>();
			foreach (DataRow dr in drcImprovementContents)
			{
				WPDImprovementContent data = new WPDImprovementContent();
				data.contentId = Convert.ToInt32(dr["contentId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.isAchievementDisplay = Convert.ToBoolean(dr["isAchievementDisplay"]);
				data.requiredConditionType = Convert.ToInt32(dr["requiredConditionType"]);
				data.requiredHeroLevel = Convert.ToInt32(dr["requiredHeroLevel"]);
				data.requiredMainQuestNo = Convert.ToInt32(dr["requiredMainQuestNo"]);

				improvementContents.Add(data);
			}
			gameDatas.improvementContents = improvementContents.ToArray();
			improvementContents.Clear();

			//
			// 향상컨텐츠달성도레벨 목록
			//
			List<WPDImprovementContentAchievementLevel> improvementContentAchievementLevels = new List<WPDImprovementContentAchievementLevel>();
			foreach (DataRow dr in drcImprovementContentAchievementLevels)
			{
				WPDImprovementContentAchievementLevel data = new WPDImprovementContentAchievementLevel();
				data.contentId = Convert.ToInt32(dr["contentId"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.achievementValue = Convert.ToInt32(dr["achievementValue"]);

				improvementContentAchievementLevels.Add(data);
			}
			gameDatas.improvementContentAchievementLevels = improvementContentAchievementLevels.ToArray();
			improvementContentAchievementLevels.Clear();

			//
			// 향상컨텐츠달성도 목록
			//
			List<WPDImprovementContentAchievement> improvementContentAchievements = new List<WPDImprovementContentAchievement>();
			foreach (DataRow dr in drcImprovementContentAchievements)
			{
				WPDImprovementContentAchievement data = new WPDImprovementContentAchievement();
				data.achievement = Convert.ToInt32(dr["achievement"]);
				data.achievementRate = Convert.ToInt32(dr["achievementRate"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.colorCode = Convert.ToString(dr["colorCode"]);

				improvementContentAchievements.Add(data);
			}
			gameDatas.improvementContentAchievements = improvementContentAchievements.ToArray();
			improvementContentAchievements.Clear();

			//
			// 별자리 목록
			//
			List<WPDConstellation> constellations = new List<WPDConstellation>();
			foreach (DataRow dr in drcConstellations)
			{
				WPDConstellation data = new WPDConstellation();
				data.constellationId = Convert.ToInt32(dr["constellationId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.requiredConditionType = Convert.ToInt32(dr["requiredConditionType"]);
				data.requiredConditionValue = Convert.ToInt32(dr["requiredConditionValue"]);

				constellations.Add(data);
			}
			gameDatas.constellations = constellations.ToArray();
			constellations.Clear();

			//
			// 별자리단계 목록
			//
			List<WPDConstellationStep> constellationSteps = new List<WPDConstellationStep>();
			foreach (DataRow dr in drcConstellationSteps)
			{
				WPDConstellationStep data = new WPDConstellationStep();
				data.constellationId = Convert.ToInt32(dr["constellationId"]);
				data.step = Convert.ToInt32(dr["step"]);
				data.requiredDia = Convert.ToInt32(dr["requiredDia"]);

				constellationSteps.Add(data);
			}
			gameDatas.constellationSteps = constellationSteps.ToArray();
			constellationSteps.Clear();

			//
			// 별자리사이클 목록
			//
			List<WPDConstellationCycle> constellationCycles = new List<WPDConstellationCycle>();
			foreach (DataRow dr in drcConstellationCycles)
			{
				WPDConstellationCycle data = new WPDConstellationCycle();
				data.constellationId = Convert.ToInt32(dr["constellationId"]);
				data.step = Convert.ToInt32(dr["step"]);
				data.cycle = Convert.ToInt32(dr["cycle"]);

				constellationCycles.Add(data);
			}
			gameDatas.constellationCycles = constellationCycles.ToArray();
			constellationCycles.Clear();

			//
			// 별자리사이클버프 목록
			//
			List<WPDConstellationCycleBuff> constellationCycleBuffs = new List<WPDConstellationCycleBuff>();
			foreach (DataRow dr in drcConstellationCycleBuffs)
			{
				WPDConstellationCycleBuff data = new WPDConstellationCycleBuff();
				data.constellationId = Convert.ToInt32(dr["constellationId"]);
				data.step = Convert.ToInt32(dr["step"]);
				data.cycle = Convert.ToInt32(dr["cycle"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);

				constellationCycleBuffs.Add(data);
			}
			gameDatas.constellationCycleBuffs = constellationCycleBuffs.ToArray();
			constellationCycleBuffs.Clear();

			//
			// 별자리항목 목록
			//
			List<WPDConstellationEntry> constellationEntries = new List<WPDConstellationEntry>();
			foreach (DataRow dr in drcConstellationEntries)
			{
				WPDConstellationEntry data = new WPDConstellationEntry();
				data.constellationId = Convert.ToInt32(dr["constellationId"]);
				data.step = Convert.ToInt32(dr["step"]);
				data.cycle = Convert.ToInt32(dr["cycle"]);
				data.entryNo = Convert.ToInt32(dr["entryNo"]);
				data.requiredStarEssense = Convert.ToInt32(dr["requiredStarEssense"]);
				data.requiredGold = Convert.ToInt64(dr["requiredGold"]);
				data.successRate = Convert.ToInt32(dr["successRate"]);

				constellationEntries.Add(data);
			}
			gameDatas.constellationEntries = constellationEntries.ToArray();
			constellationEntries.Clear();

			//
			// 별자리항목버프 목록
			//
			List<WPDConstellationEntryBuff> constellationEntryBuffs = new List<WPDConstellationEntryBuff>();
			foreach (DataRow dr in drcConstellationEntryBuffs)
			{
				WPDConstellationEntryBuff data = new WPDConstellationEntryBuff();
				data.constellationId = Convert.ToInt32(dr["constellationId"]);
				data.step = Convert.ToInt32(dr["step"]);
				data.cycle = Convert.ToInt32(dr["cycle"]);
				data.entryNo = Convert.ToInt32(dr["entryNo"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);

				constellationEntryBuffs.Add(data);
			}
			gameDatas.constellationEntryBuffs = constellationEntryBuffs.ToArray();
			constellationEntryBuffs.Clear();

			//
			// 아티팩트 목록
			//
			List<WPDArtifact> artifacts = new List<WPDArtifact>();
			foreach (DataRow dr in drcArtifacts)
			{
				WPDArtifact data = new WPDArtifact();
				data.artifactNo = Convert.ToInt32(dr["artifactNo"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.prefabName = Convert.ToString(dr["prefabName"]);

				artifacts.Add(data);
			}
			gameDatas.artifacts = artifacts.ToArray();
			artifacts.Clear();

			//
			// 아티팩트속성 목록
			//
			List<WPDArtifactAttr> artifactAttrs = new List<WPDArtifactAttr>();
			foreach (DataRow dr in drcArtifactAttrs)
			{
				WPDArtifactAttr data = new WPDArtifactAttr();
				data.artifactNo = Convert.ToInt32(dr["artifactNo"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);

				artifactAttrs.Add(data);
			}
			gameDatas.artifactAttrs = artifactAttrs.ToArray();
			artifactAttrs.Clear();

			//
			// 아티팩트레벨 목록
			//
			List<WPDArtifactLevel> artifactLevels = new List<WPDArtifactLevel>();
			foreach (DataRow dr in drcArtifactLevels)
			{
				WPDArtifactLevel data = new WPDArtifactLevel();
				data.artifactNo = Convert.ToInt32(dr["artifactNo"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.nextLevelUpRequiredExp = Convert.ToInt32(dr["nextLevelUpRequiredExp"]);

				artifactLevels.Add(data);
			}
			gameDatas.artifactLevels = artifactLevels.ToArray();
			artifactLevels.Clear();

			//
			// 아티팩트레벨속성 목록
			//
			List<WPDArtifactLevelAttr> artifactLevelAttrs = new List<WPDArtifactLevelAttr>();
			foreach (DataRow dr in drcArtifactLevelAttrs)
			{
				WPDArtifactLevelAttr data = new WPDArtifactLevelAttr();
				data.artifactNo = Convert.ToInt32(dr["artifactNo"]);
				data.level = Convert.ToInt32(dr["level"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);

				artifactLevelAttrs.Add(data);
			}
			gameDatas.artifactLevelAttrs = artifactLevelAttrs.ToArray();
			artifactLevelAttrs.Clear();

			//
			// 아티팩트레벨업재료 목록
			//
			List<WPDArtifactLevelUpMaterial> artifactLevelUpMaterials = new List<WPDArtifactLevelUpMaterial>();
			foreach (DataRow dr in drcArtifactLevelUpMaterials)
			{
				WPDArtifactLevelUpMaterial data = new WPDArtifactLevelUpMaterial();
				data.tier = Convert.ToInt32(dr["tier"]);
				data.grade = Convert.ToInt32(dr["grade"]);
				data.exp = Convert.ToInt32(dr["exp"]);

				artifactLevelUpMaterials.Add(data);
			}
			gameDatas.artifactLevelUpMaterials = artifactLevelUpMaterials.ToArray();
			artifactLevelUpMaterials.Clear();

			//
			// 무역선탈환
			//
			WPDTradeShip tradeShip = new WPDTradeShip();
			if (drTradeShip != null)
			{
				tradeShip.nameKey = Convert.ToString(drTradeShip["nameKey"]);
				tradeShip.descriptionKey = Convert.ToString(drTradeShip["descriptionKey"]);
				tradeShip.sceneName = Convert.ToString(drTradeShip["sceneName"]);
				tradeShip.requiredConditionType = Convert.ToInt32(drTradeShip["requiredConditionType"]);
				tradeShip.requiredHeroLevel = Convert.ToInt32(drTradeShip["requiredHeroLevel"]);
				tradeShip.requiredMainQuestNo = Convert.ToInt32(drTradeShip["requiredMainQuestNo"]);
				tradeShip.requiredStamina = Convert.ToInt32(drTradeShip["requiredStamina"]);
				tradeShip.enterMinMemberCount = Convert.ToInt32(drTradeShip["enterMinMemberCount"]);
				tradeShip.enterMaxMemberCount = Convert.ToInt32(drTradeShip["enterMaxMemberCount"]);
				tradeShip.matchingWaitingTime = Convert.ToInt32(drTradeShip["matchingWaitingTime"]);
				tradeShip.enterWaitingTime = Convert.ToInt32(drTradeShip["enterWaitingTime"]);
				tradeShip.startDelayTime = Convert.ToInt32(drTradeShip["startDelayTime"]);
				tradeShip.limitTime = Convert.ToInt32(drTradeShip["limitTime"]);
				tradeShip.exitDelayTime = Convert.ToInt32(drTradeShip["exitDelayTime"]);
				tradeShip.startXPosition = Convert.ToSingle(drTradeShip["startXPosition"]);
				tradeShip.startYPosition = Convert.ToSingle(drTradeShip["startYPosition"]);
				tradeShip.startZPosition = Convert.ToSingle(drTradeShip["startZPosition"]);
				tradeShip.startRadius = Convert.ToSingle(drTradeShip["startRadius"]);
				tradeShip.startYRotationType = Convert.ToInt32(drTradeShip["startYRotationType"]);
				tradeShip.startYRotation = Convert.ToSingle(drTradeShip["startYRotation"]);
				tradeShip.monsterRegenTime = Convert.ToInt32(drTradeShip["monsterRegenTime"]);
				tradeShip.clearPointPerRemainTime = Convert.ToInt32(drTradeShip["clearPointPerRemainTime"]);
				tradeShip.exp2xRewardRequiredUnOwnDia = Convert.ToInt32(drTradeShip["exp2xRewardRequiredUnOwnDia"]);
				tradeShip.exp3xRewardRequiredUnOwnDia = Convert.ToInt32(drTradeShip["exp3xRewardRequiredUnOwnDia"]);
				tradeShip.safeRevivalWaitingTime = Convert.ToInt32(drTradeShip["safeRevivalWaitingTime"]);
				tradeShip.locationId = Convert.ToInt32(drTradeShip["locationId"]);
				tradeShip.x = Convert.ToSingle(drTradeShip["x"]);
				tradeShip.z = Convert.ToSingle(drTradeShip["z"]);
				tradeShip.xSize = Convert.ToSingle(drTradeShip["xSize"]);
				tradeShip.zSize = Convert.ToSingle(drTradeShip["zSize"]);

			}
			gameDatas.tradeShip = tradeShip;

			//
			// 무역선탈환스케줄 목록
			//
			List<WPDTradeShipSchedule> tradeShipSchedules = new List<WPDTradeShipSchedule>();
			foreach (DataRow dr in drcTradeShipSchedules)
			{
				WPDTradeShipSchedule data = new WPDTradeShipSchedule();
				data.scheduleId = Convert.ToInt32(dr["scheduleId"]);
				data.startTime = Convert.ToInt32(dr["startTime"]);
				data.endTime = Convert.ToInt32(dr["endTime"]);

				tradeShipSchedules.Add(data);
			}
			gameDatas.tradeShipSchedules = tradeShipSchedules.ToArray();
			tradeShipSchedules.Clear();

			//
			// 무역선탈환장애물 목록
			//
			List<WPDTradeShipObstacle> tradeShipObstacles = new List<WPDTradeShipObstacle>();
			foreach (DataRow dr in drcTradeShipObstacles)
			{
				WPDTradeShipObstacle data = new WPDTradeShipObstacle();
				data.obstacleId = Convert.ToInt32(dr["obstacleId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);
				data.scale = Convert.ToSingle(dr["scale"]);
				data.removeStepNo = Convert.ToInt32(dr["removeStepNo"]);

				tradeShipObstacles.Add(data);
			}
			gameDatas.tradeShipObstacles = tradeShipObstacles.ToArray();
			tradeShipObstacles.Clear();

			//
			// 무역선탈환단계 목록
			//
			List<WPDTradeShipStep> tradeShipSteps = new List<WPDTradeShipStep>();
			foreach (DataRow dr in drcTradeShipSteps)
			{
				WPDTradeShipStep data = new WPDTradeShipStep();
				data.stepNo = Convert.ToInt32(dr["stepNo"]);
				data.targetMonsterKillCount = Convert.ToInt32(dr["targetMonsterKillCount"]);
				data.targetTitleKey = Convert.ToString(dr["targetTitleKey"]);
				data.targetContentKey = Convert.ToString(dr["targetContentKey"]);

				tradeShipSteps.Add(data);
			}
			gameDatas.tradeShipSteps = tradeShipSteps.ToArray();
			tradeShipSteps.Clear();

			//
			// 무역선탈환난이도 목록
			//
			List<WPDTradeShipDifficulty> tradeShipDifficulties = new List<WPDTradeShipDifficulty>();
			foreach (DataRow dr in drcTradeShipDifficulties)
			{
				WPDTradeShipDifficulty data = new WPDTradeShipDifficulty();
				data.difficulty = Convert.ToInt32(dr["difficulty"]);
				data.recommendBattlePower = Convert.ToInt64(dr["recommendBattlePower"]);
				data.minHeroLevel = Convert.ToInt32(dr["minHeroLevel"]);
				data.maxHeroLevel = Convert.ToInt32(dr["maxHeroLevel"]);
				data.goldRewardId = Convert.ToInt64(dr["goldRewardId"]);
				data.expRewardId = Convert.ToInt64(dr["expRewardId"]);
				data.pointGoldRewardId = Convert.ToInt64(dr["pointGoldRewardId"]);
				data.pointExpRewardId = Convert.ToInt64(dr["pointExpRewardId"]);
				data.maxAdditionalExp = Convert.ToInt64(dr["maxAdditionalExp"]);

				tradeShipDifficulties.Add(data);
			}
			gameDatas.tradeShipDifficulties = tradeShipDifficulties.ToArray();
			tradeShipDifficulties.Clear();

			//
			// 무역선탈환획득가능보상 목록
			//
			List<WPDTradeShipAvailableReward> tradeShipAvailableRewards = new List<WPDTradeShipAvailableReward>();
			foreach (DataRow dr in drcTradeShipAvailableRewards)
			{
				WPDTradeShipAvailableReward data = new WPDTradeShipAvailableReward();
				data.difficulty = Convert.ToInt32(dr["difficulty"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);

				tradeShipAvailableRewards.Add(data);
			}
			gameDatas.tradeShipAvailableRewards = tradeShipAvailableRewards.ToArray();
			tradeShipAvailableRewards.Clear();

			//
			// 무역선탈환오브젝트 목록
			//
			List<WPDTradeShipObject> tradeShipObjects = new List<WPDTradeShipObject>();
			foreach (DataRow dr in drcTradeShipObjects)
			{
				WPDTradeShipObject data = new WPDTradeShipObject();
				data.difficulty = Convert.ToInt32(dr["difficulty"]);
				data.objectId = Convert.ToInt32(dr["objectId"]);
				data.monsterArrangeId = Convert.ToInt64(dr["monsterArrangeId"]);
				data.xPosition = Convert.ToSingle(dr["xPosition"]);
				data.yPosition = Convert.ToSingle(dr["yPosition"]);
				data.zPosition = Convert.ToSingle(dr["zPosition"]);
				data.yRotation = Convert.ToSingle(dr["yRotation"]);
				data.activationStepNo = Convert.ToInt32(dr["activationStepNo"]);
				data.hitMessageDisplayable = Convert.ToBoolean(dr["hitMessageDisplayable"]);
				data.hitMessageDisplayInterval = Convert.ToInt32(dr["hitMessageDisplayInterval"]);
				data.point = Convert.ToInt32(dr["point"]);

				tradeShipObjects.Add(data);
			}
			gameDatas.tradeShipObjects = tradeShipObjects.ToArray();
			tradeShipObjects.Clear();

			//
			// 탈것각성레벨마스터 목록
			//
			List<WPDMountAwakeningLevelMaster> mountAwakeningLevelMasters = new List<WPDMountAwakeningLevelMaster>();
			foreach (DataRow dr in drcMountAwakeningLevelMasters)
			{
				WPDMountAwakeningLevelMaster data = new WPDMountAwakeningLevelMaster();
				data.awakeningLevel = Convert.ToInt32(dr["awakeningLevel"]);
				data.unequippedAttrFactor = Convert.ToSingle(dr["unequippedAttrFactor"]);

				mountAwakeningLevelMasters.Add(data);
			}
			gameDatas.mountAwakeningLevelMasters = mountAwakeningLevelMasters.ToArray();
			mountAwakeningLevelMasters.Clear();

			//
			// 탈것각성레벨 목록
			//
			List<WPDMountAwakeningLevel> mountAwakeningLevels = new List<WPDMountAwakeningLevel>();
			foreach (DataRow dr in drcMountAwakeningLevels)
			{
				WPDMountAwakeningLevel data = new WPDMountAwakeningLevel();
				data.mountId = Convert.ToInt32(dr["mountId"]);
				data.awakeningLevel = Convert.ToInt32(dr["awakeningLevel"]);
				data.nextLevelUpRequiredAwakeningExp = Convert.ToInt32(dr["nextLevelUpRequiredAwakeningExp"]);

				mountAwakeningLevels.Add(data);
			}
			gameDatas.mountAwakeningLevels = mountAwakeningLevels.ToArray();
			mountAwakeningLevels.Clear();

			//
			// 탈것물약속성횟수 목록
			//
			List<WPDMountPotionAttrCount> mountPotionAttrCounts = new List<WPDMountPotionAttrCount>();
			foreach (DataRow dr in drcMountPotionAttrCounts)
			{
				WPDMountPotionAttrCount data = new WPDMountPotionAttrCount();
				data.count = Convert.ToInt32(dr["count"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);

				mountPotionAttrCounts.Add(data);
			}
			gameDatas.mountPotionAttrCounts = mountPotionAttrCounts.ToArray();
			mountPotionAttrCounts.Clear();


			//
			// 코스튬표시 목록
			//
			List<WPDCostumeDisplay> costumeDisplays = new List<WPDCostumeDisplay>();
			foreach (DataRow dr in drcCostumeDisplays)
			{
				WPDCostumeDisplay data = new WPDCostumeDisplay();
				data.costumeId = Convert.ToInt32(dr["costumeId"]);
				data.jobId = Convert.ToInt32(dr["jobId"]);
				data.hairPrefabName = Convert.ToString(dr["hairPrefabName"]);
				data.facePrefabName = Convert.ToString(dr["facePrefabName"]);

				costumeDisplays.Add(data);
			}
			gameDatas.costumeDisplays = costumeDisplays.ToArray();
			costumeDisplays.Clear();

			//
			// 코스튬콜렉션 목록
			//
			List<WPDCostumeCollection> costumeCollections = new List<WPDCostumeCollection>();
			foreach (DataRow dr in drcCostumeCollections)
			{
				WPDCostumeCollection data = new WPDCostumeCollection();
				data.costumeCollectionId = Convert.ToInt32(dr["costumeCollectionId"]);
				data.nameKey = Convert.ToString(dr["nameKey"]);
				data.descriptionKey = Convert.ToString(dr["descriptionKey"]);
				data.activationItemCount = Convert.ToInt32(dr["activationItemCount"]);

				costumeCollections.Add(data);
			}
			gameDatas.costumeCollections = costumeCollections.ToArray();
			costumeCollections.Clear();

			//
			// 코스튬콜렉션속성 목록
			//
			List<WPDCostumeCollectionAttr> costumeCollectionAttrs = new List<WPDCostumeCollectionAttr>();
			foreach (DataRow dr in drcCostumeCollectionAttrs)
			{
				WPDCostumeCollectionAttr data = new WPDCostumeCollectionAttr();
				data.costumeCollectionId = Convert.ToInt32(dr["costumeCollectionId"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);

				costumeCollectionAttrs.Add(data);
			}
			gameDatas.costumeCollectionAttrs = costumeCollectionAttrs.ToArray();
			costumeCollectionAttrs.Clear();

			//
			// 코스튬콜렉션항목 목록
			//
			List<WPDCostumeCollectionEntry> costumeCollectionEntries = new List<WPDCostumeCollectionEntry>();
			foreach (DataRow dr in drcCostumeCollectionEntries)
			{
				WPDCostumeCollectionEntry data = new WPDCostumeCollectionEntry();
				data.costumeCollectionId = Convert.ToInt32(dr["costumeCollectionId"]);
				data.costumeId = Convert.ToInt32(dr["costumeId"]);
				data.sortNo = Convert.ToInt32(dr["sortNo"]);

				costumeCollectionEntries.Add(data);
			}
			gameDatas.costumeCollectionEntries = costumeCollectionEntries.ToArray();
			costumeCollectionEntries.Clear();

			//
			// 코스튬속성 목록
			//
			List<WPDCostumeAttr> costumeAttrs = new List<WPDCostumeAttr>();
			foreach (DataRow dr in drcCostumeAttrs)
			{
				WPDCostumeAttr data = new WPDCostumeAttr();
				data.costumeId = Convert.ToInt32(dr["costumeId"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);

				costumeAttrs.Add(data);
			}
			gameDatas.costumeAttrs = costumeAttrs.ToArray();
			costumeAttrs.Clear();

			//
			// 코스튬강화레벨 목록
			//
			List<WPDCostumeEnchantLevel> costumeEnchantLevels = new List<WPDCostumeEnchantLevel>();
			foreach (DataRow dr in drcCostumeEnchantLevels)
			{
				WPDCostumeEnchantLevel data = new WPDCostumeEnchantLevel();
				data.enchantLevel = Convert.ToInt32(dr["enchantLevel"]);
				data.step = Convert.ToInt32(dr["step"]);
				data.nextLevelUpSuccessRate = Convert.ToInt32(dr["nextLevelUpSuccessRate"]);
				data.nextLevelUpRequiredItemCount = Convert.ToInt32(dr["nextLevelUpRequiredItemCount"]);
				data.nextLevelUpMaxLuckyValue = Convert.ToInt32(dr["nextLevelUpMaxLuckyValue"]);

				costumeEnchantLevels.Add(data);
			}
			gameDatas.costumeEnchantLevels = costumeEnchantLevels.ToArray();
			costumeEnchantLevels.Clear();

			//
			// 코스튬강화레벨속성 목록
			//
			List<WPDCostumeEnchantLevelAttr> costumeEnchantLevelAttrs = new List<WPDCostumeEnchantLevelAttr>();
			foreach (DataRow dr in drcCostumeEnchantLevelAttrs)
			{
				WPDCostumeEnchantLevelAttr data = new WPDCostumeEnchantLevelAttr();
				data.costumeId = Convert.ToInt32(dr["costumeId"]);
				data.enchantLevel = Convert.ToInt32(dr["enchantLevel"]);
				data.attrId = Convert.ToInt32(dr["attrId"]);
				data.attrValueId = Convert.ToInt64(dr["attrValueId"]);

				costumeEnchantLevelAttrs.Add(data);
			}
			gameDatas.costumeEnchantLevelAttrs = costumeEnchantLevelAttrs.ToArray();
			costumeEnchantLevelAttrs.Clear();

			//
			// 스케줄알림 목록
			//
			List<WPDScheduleNotice> scheduleNotices = new List<WPDScheduleNotice>();
			foreach (DataRow dr in drcScheduleNotices)
			{
				WPDScheduleNotice data = new WPDScheduleNotice();
				data.noticeId = Convert.ToInt32(dr["noticeId"]);
				data.beforeStartNoticeTime = Convert.ToInt32(dr["beforeStartNoticeTime"]);
				data.beforeStartNoticeKey = Convert.ToString(dr["beforeStartNoticeKey"]);
				data.startNoticeKey = Convert.ToString(dr["startNoticeKey"]);
				data.endNoticeKey = Convert.ToString(dr["endNoticeKey"]);

				scheduleNotices.Add(data);
			}
			gameDatas.scheduleNotices = scheduleNotices.ToArray();
			scheduleNotices.Clear();

			//
			// 공유이벤트 목록
			//
			List<WPDSharingEvent> sharingEvents = new List<WPDSharingEvent>();
			foreach (DataRow dr in drcSharingEvents)
			{
				WPDSharingEvent data = new WPDSharingEvent();
				data.eventId = Convert.ToInt32(dr["eventId"]);
				data.contentType = Convert.ToInt32(dr["contentType"]);
				data.content = Convert.ToString(dr["content"]);
				data.rewardRange = Convert.ToInt32(dr["rewardRange"]);
				data.senderRewardLimitCount = Convert.ToInt32(dr["senderRewardLimitCount"]);
				data.targetLevel = Convert.ToInt32(dr["targetLevel"]);
				data.startTime = (dr["startTime"] != DBNull.Value) ? DateTimeOffset.Parse(dr["startTime"].ToString()) : DateTimeOffset.MinValue;
				data.endTime = (dr["endTime"] != DBNull.Value) ? DateTimeOffset.Parse(dr["endTime"].ToString()) : DateTimeOffset.MinValue;
				data.imageName = Convert.ToString(dr["imageName"]);
				data.descriptionKey1 = Convert.ToString(dr["descriptionKey1"]);
				data.descriptionKey2 = Convert.ToString(dr["descriptionKey2"]);

				sharingEvents.Add(data);
			}
			gameDatas.sharingEvents = sharingEvents.ToArray();
			sharingEvents.Clear();

			//
			// 시스템메세지 목록
			//
			List<WPDSystemMessage> systemMessages = new List<WPDSystemMessage>();
			foreach (DataRow dr in drcSystemMessages)
			{
				WPDSystemMessage data = new WPDSystemMessage();
				data.messageId = Convert.ToInt32(dr["messageId"]);
				data.messageKey = Convert.ToString(dr["messageKey"]);

				systemMessages.Add(data);
			}
			gameDatas.systemMessages = systemMessages.ToArray();
			systemMessages.Clear();

			//
			// 공유이벤트발신자보상 목록
			//
			List<WPDSharingEventSenderReward> sharingEventSenderRewards = new List<WPDSharingEventSenderReward>();
			foreach (DataRow dr in drcSharingEventSenderRewards)
			{
				WPDSharingEventSenderReward data = new WPDSharingEventSenderReward();
				data.eventId = Convert.ToInt32(dr["eventId"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);
				data.itemOwned = Convert.ToBoolean(dr["itemOwned"]);
				data.itemCount = Convert.ToInt32(dr["itemCount"]);

				sharingEventSenderRewards.Add(data);
			}
			gameDatas.sharingEventSenderRewards = sharingEventSenderRewards.ToArray();
			sharingEventSenderRewards.Clear();

			//
			// 공유이벤트수신자보상 목록
			//
			List<WPDSharingEventReceiverReward> sharingEventReceiverRewards = new List<WPDSharingEventReceiverReward>();
			foreach (DataRow dr in drcSharingEventReceiverRewards)
			{
				WPDSharingEventReceiverReward data = new WPDSharingEventReceiverReward();
				data.eventId = Convert.ToInt32(dr["eventId"]);
				data.rewardNo = Convert.ToInt32(dr["rewardNo"]);
				data.itemId = Convert.ToInt32(dr["itemId"]);
				data.itemOwned = Convert.ToBoolean(dr["itemOwned"]);
				data.itemCount = Convert.ToInt32(dr["itemCount"]);

				sharingEventReceiverRewards.Add(data);
			}
			gameDatas.sharingEventReceiverRewards = sharingEventReceiverRewards.ToArray();
			sharingEventReceiverRewards.Clear();




			




			// =================================================================
			// 결과
			// =================================================================

			return gameDatas.SerializeBase64String();
		}
		catch (Exception ex)
		{
			LogUtil.Log(ex.Message + "\n" + ex.StackTrace);
			DBUtil.Close(ref conn);
			return null;
		}
		finally
		{
			DBUtil.Close(ref conn);
		}
	}
}