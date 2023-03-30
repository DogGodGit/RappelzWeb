namespace WebCommon;

public class WPDNationWar : WPDPacketData
{
	public int declarationAvailableServerOpenDayCount;

	public int declarationStartTime;

	public int declarationEndTime;

	public int declarationRequiredNationFund;

	public int weeklyDeclarationMaxCount;

	public int startTime;

	public int endTime;

	public int resultDisplayEndTime;

	public int joinPopupDisplayDuration;

	public int offenseStartContinentId;

	public float offenseStartXPosition;

	public float offenseStartYPosition;

	public float offenseStartZPosition;

	public int offenseStartYRotationType;

	public float offenseStartYRotation;

	public float offenseStartRadius;

	public int defenseStartContinentId;

	public float defenseStartXPosition;

	public float defenseStartYPosition;

	public float defenseStartZPosition;

	public int defenseStartYRotationType;

	public float defenseStartYRotation;

	public float defenseStartRadius;

	public int freeTransmissionCount;

	public int nationCallCount;

	public int nationCallCoolTime;

	public int nationCallLifetime;

	public float nationCallRadius;

	public int convergingAttackCount;

	public int convergingAttackCoolTime;

	public int convergingAttackLifetime;

	public long winNationItemRewardId1;

	public long winNationItemRewardId2;

	public long winNationAllianceItemRewardId;

	public long loseNationItemRewardId1;

	public long loseNationItemRewardId2;

	public long loseNationAllianceItemRewardId;

	public long winNationExploitPointRewardId;

	public long loseNationExploitPointRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(declarationAvailableServerOpenDayCount);
		writer.Write(declarationStartTime);
		writer.Write(declarationEndTime);
		writer.Write(declarationRequiredNationFund);
		writer.Write(weeklyDeclarationMaxCount);
		writer.Write(startTime);
		writer.Write(endTime);
		writer.Write(resultDisplayEndTime);
		writer.Write(joinPopupDisplayDuration);
		writer.Write(offenseStartContinentId);
		writer.Write(offenseStartXPosition);
		writer.Write(offenseStartYPosition);
		writer.Write(offenseStartZPosition);
		writer.Write(offenseStartYRotationType);
		writer.Write(offenseStartYRotation);
		writer.Write(offenseStartRadius);
		writer.Write(defenseStartContinentId);
		writer.Write(defenseStartXPosition);
		writer.Write(defenseStartYPosition);
		writer.Write(defenseStartZPosition);
		writer.Write(defenseStartYRotationType);
		writer.Write(defenseStartYRotation);
		writer.Write(defenseStartRadius);
		writer.Write(freeTransmissionCount);
		writer.Write(nationCallCount);
		writer.Write(nationCallCoolTime);
		writer.Write(nationCallLifetime);
		writer.Write(nationCallRadius);
		writer.Write(convergingAttackCount);
		writer.Write(convergingAttackCoolTime);
		writer.Write(convergingAttackLifetime);
		writer.Write(winNationItemRewardId1);
		writer.Write(winNationItemRewardId2);
		writer.Write(winNationAllianceItemRewardId);
		writer.Write(loseNationItemRewardId1);
		writer.Write(loseNationItemRewardId2);
		writer.Write(loseNationAllianceItemRewardId);
		writer.Write(winNationExploitPointRewardId);
		writer.Write(loseNationExploitPointRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		declarationAvailableServerOpenDayCount = reader.ReadInt32();
		declarationStartTime = reader.ReadInt32();
		declarationEndTime = reader.ReadInt32();
		declarationRequiredNationFund = reader.ReadInt32();
		weeklyDeclarationMaxCount = reader.ReadInt32();
		startTime = reader.ReadInt32();
		endTime = reader.ReadInt32();
		resultDisplayEndTime = reader.ReadInt32();
		joinPopupDisplayDuration = reader.ReadInt32();
		offenseStartContinentId = reader.ReadInt32();
		offenseStartXPosition = reader.ReadSingle();
		offenseStartYPosition = reader.ReadSingle();
		offenseStartZPosition = reader.ReadSingle();
		offenseStartYRotationType = reader.ReadInt32();
		offenseStartYRotation = reader.ReadSingle();
		offenseStartRadius = reader.ReadSingle();
		defenseStartContinentId = reader.ReadInt32();
		defenseStartXPosition = reader.ReadSingle();
		defenseStartYPosition = reader.ReadSingle();
		defenseStartZPosition = reader.ReadSingle();
		defenseStartYRotationType = reader.ReadInt32();
		defenseStartYRotation = reader.ReadSingle();
		defenseStartRadius = reader.ReadSingle();
		freeTransmissionCount = reader.ReadInt32();
		nationCallCount = reader.ReadInt32();
		nationCallCoolTime = reader.ReadInt32();
		nationCallLifetime = reader.ReadInt32();
		nationCallRadius = reader.ReadSingle();
		convergingAttackCount = reader.ReadInt32();
		convergingAttackCoolTime = reader.ReadInt32();
		convergingAttackLifetime = reader.ReadInt32();
		winNationItemRewardId1 = reader.ReadInt64();
		winNationItemRewardId2 = reader.ReadInt64();
		winNationAllianceItemRewardId = reader.ReadInt64();
		loseNationItemRewardId1 = reader.ReadInt64();
		loseNationItemRewardId2 = reader.ReadInt64();
		loseNationAllianceItemRewardId = reader.ReadInt64();
		winNationExploitPointRewardId = reader.ReadInt64();
		loseNationExploitPointRewardId = reader.ReadInt64();
	}
}
