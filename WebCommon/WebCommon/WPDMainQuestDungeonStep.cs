namespace WebCommon;

public class WPDMainQuestDungeonStep : WPDPacketData
{
	public int dungeonId;

	public int step;

	public int type;

	public string targetTitleKey;

	public string targetContentKey;

	public float targetXPosition;

	public float targetYPosition;

	public float targetZPosition;

	public float targetRadius;

	public int targetMonsterArrangeNo;

	public int directingDuration;

	public float directingStartYRotation;

	public int removeObstacleId;

	public long expRewardId;

	public long goldRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(dungeonId);
		writer.Write(step);
		writer.Write(type);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(targetXPosition);
		writer.Write(targetYPosition);
		writer.Write(targetZPosition);
		writer.Write(targetRadius);
		writer.Write(targetMonsterArrangeNo);
		writer.Write(directingDuration);
		writer.Write(directingStartYRotation);
		writer.Write(removeObstacleId);
		writer.Write(expRewardId);
		writer.Write(goldRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		dungeonId = reader.ReadInt32();
		step = reader.ReadInt32();
		type = reader.ReadInt32();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		targetXPosition = reader.ReadSingle();
		targetYPosition = reader.ReadSingle();
		targetZPosition = reader.ReadSingle();
		targetRadius = reader.ReadSingle();
		targetMonsterArrangeNo = reader.ReadInt32();
		directingDuration = reader.ReadInt32();
		directingStartYRotation = reader.ReadSingle();
		removeObstacleId = reader.ReadInt32();
		expRewardId = reader.ReadInt64();
		goldRewardId = reader.ReadInt64();
	}
}
