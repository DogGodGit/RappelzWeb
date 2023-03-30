namespace WebCommon;

public class WPDSubQuest : WPDPacketData
{
	public int questId;

	public int requiredConditionType;

	public int requiredConditionValue;

	public string titleKey;

	public int type;

	public int startNpcId;

	public string startDialogueKey;

	public string targetTextKey;

	public int targetContinentId;

	public float targetXPosition;

	public float targetYPosition;

	public float targetZPosition;

	public float targetRadius;

	public int targetContinentObjectId;

	public int targetMonsterId;

	public int targetAcquisitionRate;

	public int targetContentId;

	public int targetCount;

	public int completionNpcId;

	public string completionKey;

	public string completionDialogueKey;

	public bool abandonmentEnabled;

	public bool reacceptanceEnabled;

	public long expRewardId;

	public long goldRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(questId);
		writer.Write(requiredConditionType);
		writer.Write(requiredConditionValue);
		writer.Write(titleKey);
		writer.Write(type);
		writer.Write(startNpcId);
		writer.Write(startDialogueKey);
		writer.Write(targetTextKey);
		writer.Write(targetContinentId);
		writer.Write(targetXPosition);
		writer.Write(targetYPosition);
		writer.Write(targetZPosition);
		writer.Write(targetRadius);
		writer.Write(targetContinentObjectId);
		writer.Write(targetMonsterId);
		writer.Write(targetAcquisitionRate);
		writer.Write(targetContentId);
		writer.Write(targetCount);
		writer.Write(completionNpcId);
		writer.Write(completionKey);
		writer.Write(completionDialogueKey);
		writer.Write(abandonmentEnabled);
		writer.Write(reacceptanceEnabled);
		writer.Write(expRewardId);
		writer.Write(goldRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		questId = reader.ReadInt32();
		requiredConditionType = reader.ReadInt32();
		requiredConditionValue = reader.ReadInt32();
		titleKey = reader.ReadString();
		type = reader.ReadInt32();
		startNpcId = reader.ReadInt32();
		startDialogueKey = reader.ReadString();
		targetTextKey = reader.ReadString();
		targetContinentId = reader.ReadInt32();
		targetXPosition = reader.ReadSingle();
		targetYPosition = reader.ReadSingle();
		targetZPosition = reader.ReadSingle();
		targetRadius = reader.ReadSingle();
		targetContinentObjectId = reader.ReadInt32();
		targetMonsterId = reader.ReadInt32();
		targetAcquisitionRate = reader.ReadInt32();
		targetContentId = reader.ReadInt32();
		targetCount = reader.ReadInt32();
		completionNpcId = reader.ReadInt32();
		completionKey = reader.ReadString();
		completionDialogueKey = reader.ReadString();
		abandonmentEnabled = reader.ReadBoolean();
		reacceptanceEnabled = reader.ReadBoolean();
		expRewardId = reader.ReadInt64();
		goldRewardId = reader.ReadInt64();
	}
}
