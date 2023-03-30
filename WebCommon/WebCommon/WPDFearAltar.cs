namespace WebCommon;

public class WPDFearAltar : WPDPacketData
{
	public string nameKey;

	public string descriptionKey;

	public int requiredConditionType;

	public int requiredHeroLevel;

	public int requiredMainQuestNo;

	public int requiredStamina;

	public int enterMinMemberCount;

	public int enterMaxMemberCount;

	public int matchingWaitingTime;

	public int enterWaitingTime;

	public int startDelayTime;

	public int limitTime;

	public int exitDelayTime;

	public int safeRevivalWaitingTime;

	public int halidomMonsterLifetime;

	public string halidomMonsterSpawnTextKey;

	public int halidomDisplayDuration;

	public int halidomAcquisitionRate;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(requiredConditionType);
		writer.Write(requiredHeroLevel);
		writer.Write(requiredMainQuestNo);
		writer.Write(requiredStamina);
		writer.Write(enterMinMemberCount);
		writer.Write(enterMaxMemberCount);
		writer.Write(matchingWaitingTime);
		writer.Write(enterWaitingTime);
		writer.Write(startDelayTime);
		writer.Write(limitTime);
		writer.Write(exitDelayTime);
		writer.Write(safeRevivalWaitingTime);
		writer.Write(halidomMonsterLifetime);
		writer.Write(halidomMonsterSpawnTextKey);
		writer.Write(halidomDisplayDuration);
		writer.Write(halidomAcquisitionRate);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		requiredConditionType = reader.ReadInt32();
		requiredHeroLevel = reader.ReadInt32();
		requiredMainQuestNo = reader.ReadInt32();
		requiredStamina = reader.ReadInt32();
		enterMinMemberCount = reader.ReadInt32();
		enterMaxMemberCount = reader.ReadInt32();
		matchingWaitingTime = reader.ReadInt32();
		enterWaitingTime = reader.ReadInt32();
		startDelayTime = reader.ReadInt32();
		limitTime = reader.ReadInt32();
		exitDelayTime = reader.ReadInt32();
		safeRevivalWaitingTime = reader.ReadInt32();
		halidomMonsterLifetime = reader.ReadInt32();
		halidomMonsterSpawnTextKey = reader.ReadString();
		halidomDisplayDuration = reader.ReadInt32();
		halidomAcquisitionRate = reader.ReadInt32();
	}
}
