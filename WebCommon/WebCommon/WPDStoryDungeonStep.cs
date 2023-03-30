namespace WebCommon;

public class WPDStoryDungeonStep : WPDPacketData
{
	public int dungeonNo;

	public int difficulty;

	public int step;

	public int type;

	public string targetTitleKey;

	public string targetContentKey;

	public float targetXPosition;

	public float targetYPosition;

	public float targetZPosition;

	public float targetRadius;

	public int removeObstacleId;

	public bool isCompletionRemoveTaming;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(dungeonNo);
		writer.Write(difficulty);
		writer.Write(step);
		writer.Write(type);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(targetXPosition);
		writer.Write(targetYPosition);
		writer.Write(targetZPosition);
		writer.Write(targetRadius);
		writer.Write(removeObstacleId);
		writer.Write(isCompletionRemoveTaming);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		dungeonNo = reader.ReadInt32();
		difficulty = reader.ReadInt32();
		step = reader.ReadInt32();
		type = reader.ReadInt32();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		targetXPosition = reader.ReadSingle();
		targetYPosition = reader.ReadSingle();
		targetZPosition = reader.ReadSingle();
		targetRadius = reader.ReadSingle();
		removeObstacleId = reader.ReadInt32();
		isCompletionRemoveTaming = reader.ReadBoolean();
	}
}
