namespace WebCommon;

public class WPDGuildHuntingQuestObjective : WPDPacketData
{
	public int objectiveId;

	public int minHeroLevel;

	public string targetTitleKey;

	public string targetContentKey;

	public string targetDescriptionKey;

	public int type;

	public int targetContinentId;

	public float targetXPosition;

	public float targetYPosition;

	public float targetZPosition;

	public float targetRadius;

	public int targetContinentObjectId;

	public int targetMonsterId;

	public int targetCount;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(objectiveId);
		writer.Write(minHeroLevel);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(targetDescriptionKey);
		writer.Write(type);
		writer.Write(targetContinentId);
		writer.Write(targetXPosition);
		writer.Write(targetYPosition);
		writer.Write(targetZPosition);
		writer.Write(targetRadius);
		writer.Write(targetContinentObjectId);
		writer.Write(targetMonsterId);
		writer.Write(targetCount);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		objectiveId = reader.ReadInt32();
		minHeroLevel = reader.ReadInt32();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		targetDescriptionKey = reader.ReadString();
		type = reader.ReadInt32();
		targetContinentId = reader.ReadInt32();
		targetXPosition = reader.ReadSingle();
		targetYPosition = reader.ReadSingle();
		targetZPosition = reader.ReadSingle();
		targetRadius = reader.ReadSingle();
		targetContinentObjectId = reader.ReadInt32();
		targetMonsterId = reader.ReadInt32();
		targetCount = reader.ReadInt32();
	}
}
