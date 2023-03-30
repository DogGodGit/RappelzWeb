namespace WebCommon;

public class WPDGuildMission : WPDPacketData
{
	public int missionId;

	public string targetTitleKey;

	public string targetContentKey;

	public string targetDescriptionKey;

	public int type;

	public int targetContinentId;

	public float targetXPosition;

	public float targetYPosition;

	public float targetZPosition;

	public float targetRadius;

	public int targetNpcId;

	public int targetContinentObjectId;

	public int targetMonsterId;

	public long targetSummonMonsterArrangeId;

	public float targetSummonMonsterRadius;

	public int targetSummonMonsterKillLimitTime;

	public int targetCount;

	public long guildContributionPointRewardId;

	public long guildFundRewardId;

	public long guildBuildingPointRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(missionId);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(targetDescriptionKey);
		writer.Write(type);
		writer.Write(targetContinentId);
		writer.Write(targetXPosition);
		writer.Write(targetYPosition);
		writer.Write(targetZPosition);
		writer.Write(targetRadius);
		writer.Write(targetNpcId);
		writer.Write(targetContinentObjectId);
		writer.Write(targetMonsterId);
		writer.Write(targetSummonMonsterArrangeId);
		writer.Write(targetSummonMonsterRadius);
		writer.Write(targetSummonMonsterKillLimitTime);
		writer.Write(targetCount);
		writer.Write(guildContributionPointRewardId);
		writer.Write(guildFundRewardId);
		writer.Write(guildBuildingPointRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		missionId = reader.ReadInt32();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		targetDescriptionKey = reader.ReadString();
		type = reader.ReadInt32();
		targetContinentId = reader.ReadInt32();
		targetXPosition = reader.ReadSingle();
		targetYPosition = reader.ReadSingle();
		targetZPosition = reader.ReadSingle();
		targetRadius = reader.ReadSingle();
		targetNpcId = reader.ReadInt32();
		targetContinentObjectId = reader.ReadInt32();
		targetMonsterId = reader.ReadInt32();
		targetSummonMonsterArrangeId = reader.ReadInt64();
		targetSummonMonsterRadius = reader.ReadSingle();
		targetSummonMonsterKillLimitTime = reader.ReadInt32();
		targetCount = reader.ReadInt32();
		guildContributionPointRewardId = reader.ReadInt64();
		guildFundRewardId = reader.ReadInt64();
		guildBuildingPointRewardId = reader.ReadInt64();
	}
}
