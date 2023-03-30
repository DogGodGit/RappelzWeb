namespace WebCommon;

public class WPDCreatureFarmQuestMission : WPDPacketData
{
	public int missionNo;

	public int targetType;

	public string targetTitleKey;

	public string targetContentKey;

	public int targetContinentId;

	public float targetXPosition;

	public float targetYPosition;

	public float targetZPosition;

	public float targetRadius;

	public int targetContinentObjectId;

	public int targetAutoCompletionTime;

	public int targetCount;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(missionNo);
		writer.Write(targetType);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(targetContinentId);
		writer.Write(targetXPosition);
		writer.Write(targetYPosition);
		writer.Write(targetZPosition);
		writer.Write(targetRadius);
		writer.Write(targetContinentObjectId);
		writer.Write(targetAutoCompletionTime);
		writer.Write(targetCount);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		missionNo = reader.ReadInt32();
		targetType = reader.ReadInt32();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		targetContinentId = reader.ReadInt32();
		targetXPosition = reader.ReadSingle();
		targetYPosition = reader.ReadSingle();
		targetZPosition = reader.ReadSingle();
		targetRadius = reader.ReadSingle();
		targetContinentObjectId = reader.ReadInt32();
		targetAutoCompletionTime = reader.ReadInt32();
		targetCount = reader.ReadInt32();
	}
}
