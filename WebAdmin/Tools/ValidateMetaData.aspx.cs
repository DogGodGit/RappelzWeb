using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class Tools_ValidateMetaData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		//======================================================================
		//브라우저 캐쉬 제거
		//======================================================================
		ComUtil.SetNoBrowserCache();

		//======================================================================
		// 파라미터
		//======================================================================

		if (IsPostBack)
			return;
		try
		{
			PageLoad();
		}
		catch (System.Threading.ThreadAbortException) { }
		catch (Exception ex)
		{
			ComUtil.ErrorLogMsg(ex);
		}
    }

	private void PageLoad()
	{
		WBtnValidate.Attributes.Add("onclick", "return confirm('서버에 부하가 발생할 수 있습니다. \\n진행하시겠습니까?');");
	}

	protected void WBtnValidate_OnClick(object sender, EventArgs e)
	{
		StringBuilder sbResult = new StringBuilder();

		// 몬스터-몬스터캐릭터
		ValidateMetaData.Validate(sbResult, "r_Monster", "r_MonsterCharacter", new string[] { "monsterCharacterId" }, "");

		// 대륙몬스터배치풀항목-몬스터
		ValidateMetaData.Validate(sbResult, "r_ContinentMonsterArrangePoolEntry", "r_Monster", new string[] { "monsterId" }, "");

		// 대륙몬스터배치풀항목-대륙몬스터배치
		ValidateMetaData.Validate(sbResult, "r_ContinentMonsterArrangePoolEntry", "r_ContinentMonsterArrange", new string[] { "continentId", "arrangeNo" }, "");

		// 대륙몬스터배치-대륙
		ValidateMetaData.Validate(sbResult, "r_ContinentMonsterArrange", "r_Continent", new string[] { "continentId" }, "");

		// 대륙-국가
		ValidateMetaData.Validate(sbResult, "r_Continent", "r_Nation", new string[] { "nationId" }, "r_Continent.nationId > 0");

		// 대륙-위치
		ValidateMetaData.Validate(sbResult, "r_Continent", "r_Location", new string[] { "locationId" }, "");

		// 몬스터-드롭개수풀항목
		ValidateMetaData.Validate(sbResult, "r_Monster", "r_DropCountPoolEntry", new string[] { "dropCountPoolId" }, "r_Monster.dropCountPoolId > 0");

		// 몬스터-드롭객체풀항목
		ValidateMetaData.Validate(sbResult, "r_Monster", "r_DropObjectPoolEntry", new string[] { "dropObjectPoolId" }, "r_Monster.dropObjectPoolId > 0");

		// 드롭객체풀항목-드롭장비등급풀항목
		ValidateMetaData.Validate(sbResult, "r_DropObjectPoolEntry", "r_DropGearGradePoolEntry", new string[] { "dropGearGradePoolId" }, "r_DropObjectPoolEntry.dropGearGradePoolId > 0");

		// 아이템-아이템타입
		ValidateMetaData.Validate(sbResult, "r_Item", "r_ItemType", new string[] { "itemType" }, "");

		// 아이템-등급
		ValidateMetaData.Validate(sbResult, "r_Item", "r_Grade", new string[] { "grade" }, "");

		// 소울스톤아이템속성-아이템
		ValidateMetaData.Validate(sbResult, "r_SoulStoneItemAttr", "r_Item", new string[] { "itemId" }, "");

		// 소울스톤아이템속성-속성
		ValidateMetaData.Validate(sbResult, "r_SoulStoneItemAttr", "r_Attr", new string[] { "attrId" }, "");

		// 직업레벨-직업
		ValidateMetaData.Validate(sbResult, "r_JobLevel", "r_Job", new string[] { "jobId" }, "");

		// 직업스킬-직업
		ValidateMetaData.Validate(sbResult, "r_JobSkill", "r_Job", new string[] { "jobId" }, "");

		// 직업스킬-메인퀘스트
		ValidateMetaData.Validate(sbResult, "r_JobSkill", "r_MainQuest", new string[] { "requiredMainQuestNo" }, new string[] { "mainQuestNo" }, "r_JobSkill.requiredMainQuestNo > 0");

		// 직업스킬레벨-직업스킬
		ValidateMetaData.Validate(sbResult, "r_JobSkillLevel", "r_JobSkill", new string[] { "skillId" }, "");

		// 직업스킬히트-직업스킬
		ValidateMetaData.Validate(sbResult, "r_JobSkillHit", "r_JobSkill", new string[] { "skillId" }, "");

		// 직업스킬히트룬-직업스킬히트
		ValidateMetaData.Validate(sbResult, "r_JobSkillHitRune", "r_JobSkillHit", new string[] { "skillId", "hitId" }, "");

		// 직업스킬히트룬-상태이상
		ValidateMetaData.Validate(sbResult, "r_JobSkillHitRune", "r_AbnormalState", new string[] { "abnormalStateId" }, "r_JobSkillHitRune.abnormalStateId > 0");

		// 직업연계스킬-직업스킬
		ValidateMetaData.Validate(sbResult, "r_JobChainSkill", "r_JobSkill", new string[] { "skillId" }, "");

		// 직업연계스킬히트-직업연계스킬
		ValidateMetaData.Validate(sbResult, "r_JobChainSkillHit", "r_JobChainSkill", new string[] { "skillId", "chainSkillId" }, "");

		// 직업연계스킬히트룬-직업연계스킬히트
		ValidateMetaData.Validate(sbResult, "r_JobChainSkillHitRune", "r_JobChainSkillHit", new string[] { "skillId", "chainSkillId", "hitId" }, "");

		// 직업연계스킬히트룬-상태이상
		ValidateMetaData.Validate(sbResult, "r_JobChainSkillHitRune", "r_AbnormalState", new string[] { "abnormalStateId" }, "r_JobChainSkillHitRune.abnormalStateId > 0");

		// 직업스킬룬-직업스킬
		ValidateMetaData.Validate(sbResult, "r_JobSkillRune", "r_JobSkill", new string[] { "skillId" }, "");

		// 직업스킬룬-아이템
		ValidateMetaData.Validate(sbResult, "r_JobSkillRune", "r_Item", new string[] { "materialItemId" }, new string[] { "itemId" }, "r_JobSkillRune.materialItemId > 0");

		// 직업스킬룬-상태이상
		ValidateMetaData.Validate(sbResult, "r_JobSkillRune", "r_AbnormalState", new string[] { "abnormalStateId" }, "r_JobSkillRune.abnormalStateId > 0");

		// 직업스킬룬레벨-직업스킬룬
		ValidateMetaData.Validate(sbResult, "r_JobSkillRuneLevel", "r_JobSkillRune", new string[] { "skillId", "runeNo" }, "");

		// 상태이상상세-상태이상
		ValidateMetaData.Validate(sbResult, "r_AbnormalStateDetail", "r_AbnormalState", new string[] { "abnormalStateId" }, "");

		// 장비타입-장비카테고리
		ValidateMetaData.Validate(sbResult, "r_GearType", "r_GearCategory", new string[] { "categoryId" }, "");

		// 장비타입-인벤토리카테고리
		ValidateMetaData.Validate(sbResult, "r_GearType", "r_InventoryCategory", new string[] { "inventoryCategoryId" }, "");

		// 장비타입소켓-장비타입
		ValidateMetaData.Validate(sbResult, "r_GearTypeSocket", "r_GearType", new string[] { "gearType" }, "");

		// 장비타입소켓-아이템타입
		ValidateMetaData.Validate(sbResult, "r_GearTypeSocket", "r_ItemType", new string[] { "itemType" }, "");

		// 장비타입강화레벨-장비타입
		ValidateMetaData.Validate(sbResult, "r_GearTypeSocket", "r_GearType", new string[] { "gearType" }, "");

		// 장비-직업
		ValidateMetaData.Validate(sbResult, "r_Gear", "r_Job", new string[] { "jobId" }, "r_Gear.jobId > 0");

		// 장비-장비타입
		ValidateMetaData.Validate(sbResult, "r_Gear", "r_GearType", new string[] { "gearType" }, "");

		// 장비-티어
		ValidateMetaData.Validate(sbResult, "r_Gear", "r_GearTier", new string[] { "tier" }, "");

		// 장비기본속성-장비
		ValidateMetaData.Validate(sbResult, "r_GearBaseAttr", "r_Gear", new string[] { "gearId" }, "");

		// 장비기본속성-등급
		ValidateMetaData.Validate(sbResult, "r_GearBaseAttr", "r_Grade", new string[] { "grade" }, "");

		// 장비기본속성-속성
		ValidateMetaData.Validate(sbResult, "r_GearBaseAttr", "r_Attr", new string[] { "attrId" }, "");

		// 장비옵션속성등급-장비
		ValidateMetaData.Validate(sbResult, "r_GearOptionAttrGrade", "r_Gear", new string[] { "gearId" }, "");

		// 장비옵션속성등급-속성
		ValidateMetaData.Validate(sbResult, "r_GearOptionAttrGrade", "r_Attr", new string[] { "attrId" }, "");

		// 장비옵션속성등급-등급
		ValidateMetaData.Validate(sbResult, "r_GearOptionAttrGrade", "r_Grade", new string[] { "grade" }, "");

		// 장비소지속성-장비
		ValidateMetaData.Validate(sbResult, "r_GearPassiveAttr", "r_Gear", new string[] { "gearId" }, "");

		// 장비소지속성-속성
		ValidateMetaData.Validate(sbResult, "r_GearPassiveAttr", "r_Attr", new string[] { "attrId" }, "");

		// 장비레벨기본속성-직업
		ValidateMetaData.Validate(sbResult, "r_GearLevelBaseAttr", "r_Job", new string[] { "jobId" }, "");

		// 장비레벨기본속성-장비타입
		ValidateMetaData.Validate(sbResult, "r_GearLevelBaseAttr", "r_GearType", new string[] { "gearType" }, "");

		// 장비레벨기본속성-등급
		ValidateMetaData.Validate(sbResult, "r_GearLevelBaseAttr", "r_Grade", new string[] { "grade" }, "");

		// 장비레벨기본속성-속성
		ValidateMetaData.Validate(sbResult, "r_GearLevelBaseAttr", "r_Attr", new string[] { "attrId" }, "");

		// 장비티어로열속성-장비티어
		ValidateMetaData.Validate(sbResult, "r_GearTierRoyalAttr", "r_GearTier", new string[] { "tier" }, "");

		// 장비티어로열속성-장비로열타입
		ValidateMetaData.Validate(sbResult, "r_GearTierRoyalAttr", "r_GearRoyalType", new string[] { "royalType" }, "");

		// 장비티어로열속성-속성
		ValidateMetaData.Validate(sbResult, "r_GearTierRoyalAttr", "r_Attr", new string[] { "attrId" }, "");

		// 기성장비-장비
		ValidateMetaData.Validate(sbResult, "r_ReadyMadeGear", "r_Gear", new string[] { "gearId" }, "");

		// 기성장비-등급
		ValidateMetaData.Validate(sbResult, "r_ReadyMadeGear", "r_Grade", new string[] { "grade" }, "");

		// 기성장비-로열타입
		ValidateMetaData.Validate(sbResult, "r_ReadyMadeGear", "r_GearRoyalType", new string[] { "royalType" }, "r_ReadyMadeGear.royalType > 0");

		// 기성장비옵션속성-기성장비
		ValidateMetaData.Validate(sbResult, "r_ReadyMadeGearOptionAttr", "r_ReadyMadeGear", new string[] { "readyMadeGearId" }, "");

		// 기성장비옵션속성-속성
		ValidateMetaData.Validate(sbResult, "r_ReadyMadeGearOptionAttr", "r_Attr", new string[] { "attrId" }, "");

		// 에피소드-챕터
		ValidateMetaData.Validate(sbResult, "r_Episode", "r_Chapter", new string[] { "chapterNo" }, "");

		// 에피소드-아이템
		ValidateMetaData.Validate(sbResult, "r_Episode", "r_Item", new string[] { "additionalRewardItemId" }, new string[] { "itemId" }, "r_Episode.additionalRewardItemId > 0");

		// 메인퀘스트-에피소드
		ValidateMetaData.Validate(sbResult, "r_MainQuest", "r_Episode", new string[] { "chapterNo", "episodeNo" }, "");

		// 메인퀘스트-국가
		ValidateMetaData.Validate(sbResult, "r_MainQuest", "r_Nation", new string[] { "nationId" }, "");

		// 메인퀘스트-NPC
		ValidateMetaData.Validate(sbResult, "r_MainQuest", "r_Npc", new string[] { "startNpcId" }, new string[] { "npcId" }, "r_MainQuest.startNpcId > 0");

		// 메인퀘스트-NPC
		ValidateMetaData.Validate(sbResult, "r_MainQuest", "r_Npc", new string[] { "objectiveNpcId" }, new string[] { "npcId" }, "r_MainQuest.type in (2)");

		// 메인퀘스트-NPC
		ValidateMetaData.Validate(sbResult, "r_MainQuest", "r_Npc", new string[] { "completionNpcId" }, new string[] { "npcId" }, "r_MainQuest.completionNpcId > 0");

		// 메인퀘스트-대륙
		ValidateMetaData.Validate(sbResult, "r_MainQuest", "r_Continent", new string[] { "objectiveContinentId" }, new string[] { "continentId" }, "");

		// 메인퀘스트-메인퀘스트오브젝트
		ValidateMetaData.Validate(sbResult, "r_MainQuest", "r_MainQuestObject", new string[] { "objectiveObjectId" }, new string[] { "objectId" }, "r_MainQuest.type in (3,4,5)");

		// 메인퀘스트-몬스터
		ValidateMetaData.Validate(sbResult, "r_MainQuest", "r_Monster", new string[] { "objectiveMonsterId" }, new string[] { "monsterId" }, "r_MainQuest.type in (6,7)");

		// 메인퀘스트-대륙
		ValidateMetaData.Validate(sbResult, "r_MainQuest", "r_Continent", new string[] { "objectiveCompletionReenterContinentId" }, new string[] { "continentId" }, "r_MainQuest.objectiveCompletionDirectingEnabled=1");

		// 메인퀘스트시작대화항목-메인퀘스트
		ValidateMetaData.Validate(sbResult, "r_MainQuestStartDialogueEntry", "r_MainQuest", new string[] { "nationId", "mainQuestNo" }, "");

		// 메인퀘스트시작대화항목-NPC
		ValidateMetaData.Validate(sbResult, "r_MainQuestStartDialogueEntry", "r_Npc", new string[] { "npcId" }, "r_MainQuestStartDialogueEntry.npcId > 0");

		// 메인퀘스트보상-메인퀘스트
		ValidateMetaData.Validate(sbResult, "r_MainQuestReward", "r_MainQuest", new string[] { "nationId", "mainQuestNo" }, "");

		// 메인퀘스트보상-직업
		ValidateMetaData.Validate(sbResult, "r_MainQuestReward", "r_Job", new string[] { "jobId" }, "r_MainQuestReward.jobId > 0");

		// 메인퀘스트보상-기성장비
		ValidateMetaData.Validate(sbResult, "r_MainQuestReward", "r_ReadyMadeGear", new string[] { "readyMadeGearId" }, "r_MainQuestReward.type = 1");

		// 메인퀘스트보상-아이템
		ValidateMetaData.Validate(sbResult, "r_MainQuestReward", "r_Item", new string[] { "itemId" }, "r_MainQuestReward.type = 2");

		// 메인퀘스트완료대화항목-메인퀘스트
		ValidateMetaData.Validate(sbResult, "r_DialogueMainQuestDialogueEntry", "r_MainQuest", new string[] { "nationId", "mainQuestNo" }, "");

		// 메인퀘스트완료대화항목-NPC
		ValidateMetaData.Validate(sbResult, "r_DialogueMainQuestDialogueEntry", "r_Npc", new string[] { "npcId" }, "r_DialogueMainQuestDialogueEntry.npcId > 0");

		// 메인퀘스트오브젝트배치-메인퀘스트오브젝트
		ValidateMetaData.Validate(sbResult, "r_MainQuestObjectArrange", "r_MainQuestObject", new string[] { "objectId" }, "");

		// 메인퀘스트오브젝트-대륙
		ValidateMetaData.Validate(sbResult, "r_MainQuestObject", "r_Continent", new string[] { "continentId" }, "");

		// 장비제련레시피-장비타입
		ValidateMetaData.Validate(sbResult, "r_GearRefinementRecipe", "r_GearType", new string[] { "gearType" }, "");

		// 장비제련레시피-아이템
		ValidateMetaData.Validate(sbResult, "r_GearRefinementRecipe", "r_Item", new string[] { "material1ItemId" }, new string[] { "itemId" }, "");

		// 장비제련레시피-아이템
		ValidateMetaData.Validate(sbResult, "r_GearRefinementRecipe", "r_Item", new string[] { "material2ItemId" }, new string[] { "itemId" }, "");

		// 장비강화레시피-장비타입
		ValidateMetaData.Validate(sbResult, "r_GearEnchantRecipe", "r_GearType", new string[] { "gearType" }, "");

		// 장비강화레시피-아이템
		ValidateMetaData.Validate(sbResult, "r_GearEnchantRecipe", "r_Item", new string[] { "materialItemId" }, new string[] { "itemId" }, "");

		// 장비강화레시피-아이템
		ValidateMetaData.Validate(sbResult, "r_GearEnchantRecipe", "r_Item", new string[] { "luckyMaterialItemId" }, new string[] { "itemId" }, "");

		// 장비강화레시피-아이템
		ValidateMetaData.Validate(sbResult, "r_GearEnchantRecipe", "r_Item", new string[] { "penaltyPreventionItemId" }, new string[] { "itemId" }, "");

		// 장비옵션속성계승레시피-장비
		ValidateMetaData.Validate(sbResult, "r_GearOptionAttrInheritRecipe", "r_Gear", new string[] { "gearId" }, "");

		// 장비옵션속성계승레시피-등급
		ValidateMetaData.Validate(sbResult, "r_GearOptionAttrInheritRecipe", "r_Grade", new string[] { "grade" }, "");

		// 장비합성레시피-장비
		ValidateMetaData.Validate(sbResult, "r_GearCompositionRecipe", "r_Gear", new string[] { "gearId" }, "");

		// 장비합성레시피-등급
		ValidateMetaData.Validate(sbResult, "r_GearCompositionRecipe", "r_Grade", new string[] { "grade" }, "");

		// 장비합성레시피-장비
		ValidateMetaData.Validate(sbResult, "r_GearCompositionRecipe", "r_Gear", new string[] { "compositedGearId" }, new string[] { "gearId" }, "");

		// 던전지역-대륙
		ValidateMetaData.Validate(sbResult, "r_DungeonArea", "r_Continent", new string[] { "continentId" }, "");

		// 던전지역항목-던전지역
		ValidateMetaData.Validate(sbResult, "r_DungeonAreaEntry", "r_DungeonArea", new string[] { "dungeonAreaId" }, "");

		// 던전지역항목-위치
		ValidateMetaData.Validate(sbResult, "r_DungeonAreaEntry", "r_Location", new string[] { "locationId" }, "");

		// 경험치던전-메인퀘스트
		ValidateMetaData.Validate(sbResult, "r_ExpDungeon", "r_MainQuest", new string[] { "requiredMainQuestNo" }, new string[] { "mainQuestNo" }, "");

		// 경험치던전-아이템
		ValidateMetaData.Validate(sbResult, "r_ExpDungeon", "r_Item", new string[] { "directEnterItemId" }, new string[] { "itemId" }, "");

		// 경험치던전-위치
		ValidateMetaData.Validate(sbResult, "r_ExpDungeon", "r_Location", new string[] { "locationId" }, "");

		// 경험치던전난이도웨이브배치-경험치던전난이도
		ValidateMetaData.Validate(sbResult, "r_ExpDungeonDifficultyWaveArrange", "r_ExpDungeonDifficulty", new string[] { "difficulty" }, "");

		// 경험치던전난이도웨이브배치-몬스터
		ValidateMetaData.Validate(sbResult, "r_ExpDungeonDifficultyWaveArrange", "r_Monster", new string[] { "monsterId" }, "");

		// 아이템합성레시피-아이템
		ValidateMetaData.Validate(sbResult, "r_ItemCompositionRecipe", "r_Item", new string[] { "itemId" }, "");

		// 아이템합성레시피-아이템
		ValidateMetaData.Validate(sbResult, "r_ItemCompositionRecipe", "r_Item", new string[] { "compositedItemId" }, new string[] { "itemId" }, "");

		// 장비분해레시피-장비티어
		ValidateMetaData.Validate(sbResult, "r_GearDisassembleRecipe", "r_GearTier", new string[] { "tier" }, "");

		// 장비분해레시피-등급
		ValidateMetaData.Validate(sbResult, "r_GearDisassembleRecipe", "r_Grade", new string[] { "grade" }, "");

		// 장비분해레시피-아이템
		ValidateMetaData.Validate(sbResult, "r_GearDisassembleRecipe", "r_Item", new string[] { "itemId" }, "");

		// 일일퀘스트추가보상-아이템
		ValidateMetaData.Validate(sbResult, "r_DailyQuestExtraReward", "r_Item", new string[] { "itemId" }, "");

		// 일일퀘스트목표-일일퀘스트목표타입
		ValidateMetaData.Validate(sbResult, "r_DailyQuestObjective", "r_DailyQuestObjectiveType", new string[] { "objectiveType" }, "");

		// 일일퀘스트레벨보상-일일퀘스트목표타입
		ValidateMetaData.Validate(sbResult, "r_DailyQuestLevelReward", "r_DailyQuestObjectiveType", new string[] { "objectiveType" }, "");

		// 도적소굴-메인퀘스트
		ValidateMetaData.Validate(sbResult, "r_ThievesDen", "r_MainQuest", new string[] { "requiredMainQuestNo" }, new string[] { "mainQuestNo" }, "");

		// 도적소굴-아이템
		ValidateMetaData.Validate(sbResult, "r_ThievesDen", "r_Item", new string[] { "directEnterItemId" }, new string[] { "itemId" }, "");

		// 도적소굴-위치
		ValidateMetaData.Validate(sbResult, "r_ThievesDen", "r_Location", new string[] { "locationId" }, "");

		// 도적소굴단계-도적소굴장애물
		ValidateMetaData.Validate(sbResult, "r_ThievesDenStep", "r_ThievesDenObstacle", new string[] { "removeObstacleId" }, new string[] { "obstacleId" }, "r_ThievesDenStep.removeObstacleId > 0");

		// 도적소굴단계-몬스터
		ValidateMetaData.Validate(sbResult, "r_ThievesDenStep", "r_Monster", new string[] { "objectiveMonsterId" }, new string[] { "monsterId" }, "r_ThievesDenStep.objectiveMonsterId > 0");

		// 도적소굴획득가능보상-도적소굴난이도
		ValidateMetaData.Validate(sbResult, "r_ThievesDenAvailableReward", "r_ThievesDenDifficulty", new string[] { "difficulty" }, "");

		// 도적소굴획득가능보상-아이템
		ValidateMetaData.Validate(sbResult, "r_ThievesDenAvailableReward", "r_Item", new string[] { "itemId" }, "");

		// 도적소굴난이도보상-도적소굴난이도
		ValidateMetaData.Validate(sbResult, "r_ThievesDenReward", "r_ThievesDenDifficulty", new string[] { "difficulty" }, "");

		// 도적소굴난이도보상-도적소굴클리어등급
		ValidateMetaData.Validate(sbResult, "r_ThievesDenReward", "r_ThievesDenClearGrade", new string[] { "clearGrade" }, "");

		// 도적소굴난이도보상-아이템
		ValidateMetaData.Validate(sbResult, "r_ThievesDenReward", "r_Item", new string[] { "itemId" }, "");

		// 도적소굴몬스터배치-도적소굴난이도
		ValidateMetaData.Validate(sbResult, "r_ThievesDenMonsterArrange", "r_ThievesDenDifficulty", new string[] { "difficulty" }, "");

		// 도적소굴몬스터배치-몬스터
		ValidateMetaData.Validate(sbResult, "r_ThievesDenMonsterArrange", "r_Monster", new string[] { "monsterId" }, "");

		// 도적소굴몬스터배치-도적소굴단계
		ValidateMetaData.Validate(sbResult, "r_ThievesDenMonsterArrange", "r_ThievesDenStep", new string[] { "stepId" }, "");

		// 도적소굴오브젝트-도적소굴난이도
		ValidateMetaData.Validate(sbResult, "r_ThievesDenObject", "r_ThievesDenDifficulty", new string[] { "difficulty" }, "");

		// 도적소굴오브젝트-몬스터
		ValidateMetaData.Validate(sbResult, "r_ThievesDenObject", "r_Monster", new string[] { "monsterId" }, "");

		// 도적소굴오브젝트-도적소굴단계
		ValidateMetaData.Validate(sbResult, "r_ThievesDenObject", "r_ThievesDenStep", new string[] { "stepId" }, "");

		// 파티모험항목-위치
		ValidateMetaData.Validate(sbResult, "r_PartyAdventureEntry", "r_Location", new string[] { "locationId" }, "");

		// 위치지역배경음악-위치
		ValidateMetaData.Validate(sbResult, "r_LocationArea", "r_Location", new string[] { "locationId" }, "");

		// 주간퀘스트-메인퀘스트
		ValidateMetaData.Validate(sbResult, "r_WeeklyQuest", "r_MainQuest", new string[] { "requiredMainQuestNo" }, new string[] { "mainQuestNo" }, "");

		// 주간퀘스트추가보상-아이템
		ValidateMetaData.Validate(sbResult, "r_WeeklyQuestExtraReward", "r_Item", new string[] { "itemId" }, "");

		// 주간퀘스트피버단계-아이템
		ValidateMetaData.Validate(sbResult, "r_WeeklyQuestFeverStep", "r_Item", new string[] { "itemId" }, "");

		// 주간퀘스트보상-영웅레벨
		//ValidateMetaData.Validate(sbResult, "r_WeeklyQuestReward", "r_JobLevel", new string[] { "level" }, "");

		// 영웅레벨-주간퀘스트보상
		ValidateMetaData.Validate(sbResult, "r_JobLevel", "r_WeeklyQuestReward", new string[] { "level" }, "");

		// 주간퀘스트목표풀항목-주간퀘스트목표풀
		ValidateMetaData.Validate(sbResult, "r_WeeklyQuestObjectivePoolEntry", "r_WeeklyQuestObjectivePool", new string[] { "poolId" }, "");

		// 주간퀘스트목표풀-주간퀘스트목표풀항목
		ValidateMetaData.Validate(sbResult, "r_WeeklyQuestObjectivePool", "r_WeeklyQuestObjectivePoolEntry", new string[] { "poolId" }, "");

		// 주간퀘스트목표풀항목-몬스터
		ValidateMetaData.Validate(sbResult, "r_WeeklyQuestObjectivePoolEntry", "r_Monster", new string[] { "monsterId" }, "");

		// 주간퀘스트목표풀항목-대륙
		ValidateMetaData.Validate(sbResult, "r_WeeklyQuestObjectivePoolEntry", "r_Continent", new string[] { "continentId" }, "");

		// 스킨-직업
		ValidateMetaData.Validate(sbResult, "r_Skin", "r_Job", new string[] { "jobId" }, "");

		// 직업-스킨
		ValidateMetaData.Validate(sbResult, "r_Job", "r_Skin", new string[] { "jobId" }, "");

		// 직업-스킨(기본스킨)
		ValidateMetaData.Validate(sbResult, "r_Job", "r_Skin", new string[] { "defaultSkinId" }, new string[] { "skinId" }, "");

		// 스킨활성화조건항목-스킨
		ValidateMetaData.Validate(sbResult, "r_SkinActivationConditionEntry", "r_Skin", new string[] { "skinId" }, "");

		// 스킨활성화조건항목-장비
		ValidateMetaData.Validate(sbResult, "r_SkinActivationConditionEntry", "r_Gear", new string[] { "gearId" }, "");

		// 스킨활성화조건항목-등급
		ValidateMetaData.Validate(sbResult, "r_SkinActivationConditionEntry", "r_Grade", new string[] { "minGrade" }, new string[] { "grade" }, "");

		// 스킨속성-스킨
		ValidateMetaData.Validate(sbResult, "r_SkinAttr", "r_Skin", new string[] { "skinId" }, "");

		// 스킨-스킨속성
		ValidateMetaData.Validate(sbResult, "r_Skin", "r_SkinAttr", new string[] { "skinId" }, "");

		// 스킨속성-속성
		ValidateMetaData.Validate(sbResult, "r_SkinAttr", "r_Attr", new string[] { "attrId" }, "");

		// NPC표시범위-NPC
		ValidateMetaData.Validate(sbResult, "r_NpcVisibleBoundary", "r_Npc", new string[] { "npcId" }, "");

		// NPC표시범위-메인퀘스트
		ValidateMetaData.Validate(sbResult, "r_NpcVisibleBoundary", "r_MainQuest", new string[] { "startCompletedMainQuestNo" }, new string[] { "mainQuestNo" }, "");

		// NPC표시범위-메인퀘스트
		ValidateMetaData.Validate(sbResult, "r_NpcVisibleBoundary", "r_MainQuest", new string[] { "endCompletedMainQuestNo" }, new string[] { "mainQuestNo" }, "");

		// 금안족의은신처-메인퀘스트
		ValidateMetaData.Validate(sbResult, "r_Hideout", "r_MainQuest", new string[] { "requiredMainQuestNo" }, new string[] { "mainQuestNo" }, "");

		// 금안족의은신처-위치
		ValidateMetaData.Validate(sbResult, "r_Hideout", "r_Location", new string[] { "locationId" }, "");

		// 금안족의은신처난이도-아이템
		ValidateMetaData.Validate(sbResult, "r_HideoutDifficulty", "r_Item", new string[] { "exceptionalRewardItemId" }, new string[] { "itemId" }, "");

		// 금안족의은신처획득가능보상-금안족의은신처난이도
		ValidateMetaData.Validate(sbResult, "r_HideoutAvailableReward", "r_HideoutDifficulty", new string[] { "difficulty" }, "");

		// 금안족의은신처난이도-금안족의은신처획득가능보상
		ValidateMetaData.Validate(sbResult, "r_HideoutDifficulty", "r_HideoutAvailableReward", new string[] { "difficulty" }, "");
		
		// 금안족의은신처획득가능보상-아이템
		ValidateMetaData.Validate(sbResult, "r_HideoutAvailableReward", "r_Item", new string[] { "itemId" }, "");

		// 금안족의은신처난이도기본보상-금안족의은신처난이도
		ValidateMetaData.Validate(sbResult, "r_HideoutDifficultyBaseReward", "r_HideoutDifficulty", new string[] { "difficulty" }, "");

		// 금안족의은신처난이도-금안족의은신처난이도기본보상
		ValidateMetaData.Validate(sbResult, "r_HideoutDifficulty", "r_HideoutDifficultyBaseReward", new string[] { "difficulty" }, "");

		// 금안족의은신처난이도기본보상-아이템
		ValidateMetaData.Validate(sbResult, "r_HideoutDifficultyBaseReward", "r_Item", new string[] { "itemId" }, "");

		// 금안족의은신처난이도추가보상-금안족의은신처난이도
		ValidateMetaData.Validate(sbResult, "r_HideoutDifficultyAdditionalReward", "r_HideoutDifficulty", new string[] { "difficulty" }, "");

		// 금안족의은신처난이도-금안족의은신처난이도추가보상
		ValidateMetaData.Validate(sbResult, "r_HideoutDifficulty", "r_HideoutDifficultyAdditionalReward", new string[] { "difficulty" }, "");

		// 금안족의은신처난이도추가보상-아이템
		ValidateMetaData.Validate(sbResult, "r_HideoutDifficultyAdditionalReward", "r_Item", new string[] { "itemId" }, "");

		// 금안족의은신처클리어순위-금안족의은신처난이도추가보상
		ValidateMetaData.Validate(sbResult, "r_HideoutClearRank", "r_HideoutDifficultyAdditionalReward", new string[] { "rank" }, "");

		// 금안족의은신처난이도추가보상-금안족의은신처클리어순위
		ValidateMetaData.Validate(sbResult, "r_HideoutDifficultyAdditionalReward", "r_HideoutClearRank", new string[] { "rank" }, "");

		// 금안족의은신처클리어순위-금안족의은신처패널티
		ValidateMetaData.Validate(sbResult, "r_HideoutClearRank", "r_HideoutPenalty", new string[] { "rank" }, "");

		// 금안족의은신처패널티-금안족의은신처클리어순위
		ValidateMetaData.Validate(sbResult, "r_HideoutPenalty", "r_HideoutClearRank", new string[] { "rank" }, "");

		// 금안족의은신처난이도웨이브배치-금안족의은신처난이도
		ValidateMetaData.Validate(sbResult, "r_HideoutDifficultyWaveArrange", "r_HideoutDifficulty", new string[] { "difficulty" }, "");

		// 금안족의은신처난이도-금안족의은신처난이도웨이브배치
		ValidateMetaData.Validate(sbResult, "r_HideoutDifficulty", "r_HideoutDifficultyWaveArrange", new string[] { "difficulty" }, "");

		// 금안족의은신처난이도웨이브배치-몬스터
		ValidateMetaData.Validate(sbResult, "r_HideoutDifficultyWaveArrange", "r_Monster", new string[] { "monsterId" }, "");

		// 몬스터상태이상상세-상태이상
		ValidateMetaData.Validate(sbResult, "r_MonsterAbnormalStateDetail", "r_AbnormalState", new string[] { "abnormalStateId" }, "");

		// 몬스터보유스킬-몬스터
		ValidateMetaData.Validate(sbResult, "r_MonsterOwnSkill", "r_Monster", new string[] { "monsterId" }, "");

		// 몬스터-몬스터보유스킬
		ValidateMetaData.Validate(sbResult, "r_Monster", "r_MonsterOwnSkill", new string[] { "monsterId" }, "r_Monster.attackEnabled=1");

		// 몬스터보유스킬-몬스터스킬
		ValidateMetaData.Validate(sbResult, "r_MonsterOwnSkill", "r_MonsterSkill", new string[] { "skillId" }, "");

		// 몬스터스킬-몬스터보유스킬
		ValidateMetaData.Validate(sbResult, "r_MonsterSkill", "r_MonsterOwnSkill", new string[] { "skillId" }, "");

		// 몬스터스킬-몬스터스킬히트
		ValidateMetaData.Validate(sbResult, "r_MonsterSkill", "r_MonsterSkillHit", new string[] { "skillId" }, "");

		// 몬스터스킬-원소
		ValidateMetaData.Validate(sbResult, "r_MonsterSkill", "r_Elemental", new string[] { "elementalId" }, "");

		// 몬스터스킬-몬스터상태이상상세
		ValidateMetaData.Validate(sbResult, "r_MonsterSkill", "r_MonsterAbnormalStateDetail", new string[] { "monsterAbnormalStateDetailId" }, "r_MonsterSkill.monsterAbnormalStateDetailId > 0");

		// 몬스터스킬히트-몬스터상태이상상세
		ValidateMetaData.Validate(sbResult, "r_MonsterSkillHit", "r_MonsterAbnormalStateDetail", new string[] { "monsterAbnormalStateDetailId" }, "r_MonsterSkillHit.monsterAbnormalStateDetailId > 0");

		// 몬스터속성-몬스터
		ValidateMetaData.Validate(sbResult, "r_MonsterAttr", "r_Monster", new string[] { "monsterId" }, "");

		// 몬스터-몬스터속성
		ValidateMetaData.Validate(sbResult, "r_Monster", "r_MonsterAttr", new string[] { "monsterId" }, "");

		// 몬스터속성-속성
		ValidateMetaData.Validate(sbResult, "r_MonsterAttr", "r_Attr", new string[] { "attrId" }, "");

		// 포탈-대륙
		ValidateMetaData.Validate(sbResult, "r_Portal", "r_Continent", new string[] { "continentId" }, "");

		// 사냥던전-메인퀘스트
		ValidateMetaData.Validate(sbResult, "r_HuntingDungeon", "r_MainQuest", new string[] { "requiredMainQuestNo" }, new string[] { "mainQuestNo" }, "");

		// 사냥던전-아이템
		ValidateMetaData.Validate(sbResult, "r_HuntingDungeon", "r_Item", new string[] { "directEnterItemId" }, new string[] { "itemId" }, "");

		// 사냥던전-위치
		ValidateMetaData.Validate(sbResult, "r_HuntingDungeon", "r_Location", new string[] { "locationId" }, "");

		// 사냥던전층몬스터배치-사냥던전층
		ValidateMetaData.Validate(sbResult, "r_HuntingDungeonFloorMonsterArrange", "r_HuntingDungeonFloor", new string[] { "floor" }, "");

		// 사냥던전층-사냥던전층몬스터배치
		ValidateMetaData.Validate(sbResult, "r_HuntingDungeonFloor", "r_HuntingDungeonFloorMonsterArrange", new string[] { "floor" }, "");

		// 사냥던전층몬스터배치-몬스터
		ValidateMetaData.Validate(sbResult, "r_HuntingDungeonFloorMonsterArrange", "r_Monster", new string[] { "monsterId" }, "");

		// 사냥던전층퀘스트보상아이템-사냥던전층
		ValidateMetaData.Validate(sbResult, "r_HuntingDungeonFloorQuestRewardItem", "r_HuntingDungeonFloor", new string[] { "floor" }, "");

		// 사냥던전층-사냥던전층퀘스트보상아이템
		ValidateMetaData.Validate(sbResult, "r_HuntingDungeonFloor", "r_HuntingDungeonFloorQuestRewardItem", new string[] { "floor" }, "");

		// 사냥던전층퀘스트보상아이템-아이템
		ValidateMetaData.Validate(sbResult, "r_HuntingDungeonFloorQuestRewardItem", "r_Item", new string[] { "itemId" }, "");

		// 사냥던전포탈-사냥던전층
		ValidateMetaData.Validate(sbResult, "r_HuntingDungeonPortal", "r_HuntingDungeonFloor", new string[] { "floor" }, "");

		//
		// 결과 표시
		//

		WLtlResult.Text = sbResult.ToString().Replace("\n", "<br />");
		sbResult.Clear();
	}
}