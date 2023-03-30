namespace WebCommon;

public class WPDDailyQuestMission : WPDPacketData
{
	public int missionId;

	public string titleKey;

	public string targetTitleKey;

	public string targetContentKey;

	public string targetDescriptionKey;

	public int requiredHeroLevel;

	public int grade;

	public int type;

	public int targetContinentId;

	public float targetXPosotion;

	public float targetYPosition;

	public float targetZPosition;

	public float targetRadius;

	public int targetMonsterId;

	public int targetContinentObjectId;

	public int targetCount;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(missionId);
		writer.Write(titleKey);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(targetDescriptionKey);
		writer.Write(requiredHeroLevel);
		writer.Write(grade);
		writer.Write(type);
		writer.Write(targetContinentId);
		writer.Write(targetXPosotion);
		writer.Write(targetYPosition);
		writer.Write(targetZPosition);
		writer.Write(targetRadius);
		writer.Write(targetMonsterId);
		writer.Write(targetContinentObjectId);
		writer.Write(targetCount);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		missionId = reader.ReadInt32();
		titleKey = reader.ReadString();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		targetDescriptionKey = reader.ReadString();
		requiredHeroLevel = reader.ReadInt32();
		grade = reader.ReadInt32();
		type = reader.ReadInt32();
		targetContinentId = reader.ReadInt32();
		targetXPosotion = reader.ReadSingle();
		targetYPosition = reader.ReadSingle();
		targetZPosition = reader.ReadSingle();
		targetRadius = reader.ReadSingle();
		targetMonsterId = reader.ReadInt32();
		targetContinentObjectId = reader.ReadInt32();
		targetCount = reader.ReadInt32();
	}
}
