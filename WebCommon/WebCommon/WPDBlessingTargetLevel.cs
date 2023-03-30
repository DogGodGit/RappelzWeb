namespace WebCommon;

public class WPDBlessingTargetLevel : WPDPacketData
{
	public int targetLevelId;

	public int targetHeroLevel;

	public int prospectQuestObjectiveLevel;

	public int prospectQuestObjectiveLimitTime;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(targetLevelId);
		writer.Write(targetHeroLevel);
		writer.Write(prospectQuestObjectiveLevel);
		writer.Write(prospectQuestObjectiveLimitTime);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		targetLevelId = reader.ReadInt32();
		targetHeroLevel = reader.ReadInt32();
		prospectQuestObjectiveLevel = reader.ReadInt32();
		prospectQuestObjectiveLimitTime = reader.ReadInt32();
	}
}
