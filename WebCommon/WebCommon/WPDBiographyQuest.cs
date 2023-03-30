namespace WebCommon;

public class WPDBiographyQuest : WPDPacketData
{
	public int biographyId;

	public int questNo;

	public int type;

	public int startNpcId;

	public string startDialogueKey;

	public string targetTitleKey;

	public string targetContentKey;

	public int completionNpcId;

	public string completionDialogueKey;

	public int targetContinentId;

	public float targetXPosition;

	public float targetYPosition;

	public float targetZPosition;

	public float targetRadius;

	public int targetMonsterId;

	public int targetNpcId;

	public int targetContinentObjectId;

	public int targetDungeonId;

	public int targetCount;

	public long expRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(biographyId);
		writer.Write(questNo);
		writer.Write(type);
		writer.Write(startNpcId);
		writer.Write(startDialogueKey);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(completionNpcId);
		writer.Write(completionDialogueKey);
		writer.Write(targetContinentId);
		writer.Write(targetXPosition);
		writer.Write(targetYPosition);
		writer.Write(targetZPosition);
		writer.Write(targetRadius);
		writer.Write(targetMonsterId);
		writer.Write(targetNpcId);
		writer.Write(targetContinentObjectId);
		writer.Write(targetDungeonId);
		writer.Write(targetCount);
		writer.Write(expRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		biographyId = reader.ReadInt32();
		questNo = reader.ReadInt32();
		type = reader.ReadInt32();
		startNpcId = reader.ReadInt32();
		startDialogueKey = reader.ReadString();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		completionNpcId = reader.ReadInt32();
		completionDialogueKey = reader.ReadString();
		targetContinentId = reader.ReadInt32();
		targetXPosition = reader.ReadSingle();
		targetYPosition = reader.ReadSingle();
		targetZPosition = reader.ReadSingle();
		targetRadius = reader.ReadSingle();
		targetMonsterId = reader.ReadInt32();
		targetNpcId = reader.ReadInt32();
		targetContinentObjectId = reader.ReadInt32();
		targetDungeonId = reader.ReadInt32();
		targetCount = reader.ReadInt32();
		expRewardId = reader.ReadInt64();
	}
}
