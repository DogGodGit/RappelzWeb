namespace WebCommon;

public class WPDTrueHeroQuestStep : WPDPacketData
{
	public int stepNo;

	public string targetContentKey;

	public int targetContinentId;

	public float targetObjectXPosition;

	public float targetObjectYPosition;

	public float targetObjectZPosition;

	public int objectiveWaitingTime;

	public long itemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(stepNo);
		writer.Write(targetContentKey);
		writer.Write(targetContinentId);
		writer.Write(targetObjectXPosition);
		writer.Write(targetObjectYPosition);
		writer.Write(targetObjectZPosition);
		writer.Write(objectiveWaitingTime);
		writer.Write(itemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		stepNo = reader.ReadInt32();
		targetContentKey = reader.ReadString();
		targetContinentId = reader.ReadInt32();
		targetObjectXPosition = reader.ReadSingle();
		targetObjectYPosition = reader.ReadSingle();
		targetObjectZPosition = reader.ReadSingle();
		objectiveWaitingTime = reader.ReadInt32();
		itemRewardId = reader.ReadInt64();
	}
}
