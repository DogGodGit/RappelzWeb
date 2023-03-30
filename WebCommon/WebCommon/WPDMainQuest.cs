namespace WebCommon;

public class WPDMainQuest : WPDPacketData
{
	public int mainQuestNo;

	public int requiredHeroLevel;

	public string titleKey;

	public int type;

	public int startNpcId;

	public string startTextKey;

	public string targetTextKey;

	public int targetContinentId;

	public float targetXPosition;

	public float targetYPosition;

	public float targetZPosition;

	public float targetRadius;

	public int targetNpcId;

	public int targetContinentObjectId;

	public int targetDungeonId;

	public int targetMonsterId;

	public int targetAcquisitionRate;

	public int targetContentId;

	public int targetCount;

	public int transformationMonsterId;

	public int transformationLifetime;

	public bool transformationRestored;

	public int completionNpcId;

	public string completionTextKey;

	public long expRewardId;

	public long goldRewardId;

	public int cartId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(mainQuestNo);
		writer.Write(requiredHeroLevel);
		writer.Write(titleKey);
		writer.Write(type);
		writer.Write(startNpcId);
		writer.Write(startTextKey);
		writer.Write(targetTextKey);
		writer.Write(targetContinentId);
		writer.Write(targetXPosition);
		writer.Write(targetYPosition);
		writer.Write(targetZPosition);
		writer.Write(targetRadius);
		writer.Write(targetNpcId);
		writer.Write(targetContinentObjectId);
		writer.Write(targetDungeonId);
		writer.Write(targetMonsterId);
		writer.Write(targetAcquisitionRate);
		writer.Write(targetContentId);
		writer.Write(targetCount);
		writer.Write(transformationMonsterId);
		writer.Write(transformationLifetime);
		writer.Write(transformationRestored);
		writer.Write(completionNpcId);
		writer.Write(completionTextKey);
		writer.Write(expRewardId);
		writer.Write(goldRewardId);
		writer.Write(cartId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		mainQuestNo = reader.ReadInt32();
		requiredHeroLevel = reader.ReadInt32();
		titleKey = reader.ReadString();
		type = reader.ReadInt32();
		startNpcId = reader.ReadInt32();
		startTextKey = reader.ReadString();
		targetTextKey = reader.ReadString();
		targetContinentId = reader.ReadInt32();
		targetXPosition = reader.ReadSingle();
		targetYPosition = reader.ReadSingle();
		targetZPosition = reader.ReadSingle();
		targetRadius = reader.ReadSingle();
		targetNpcId = reader.ReadInt32();
		targetContinentObjectId = reader.ReadInt32();
		targetDungeonId = reader.ReadInt32();
		targetMonsterId = reader.ReadInt32();
		targetAcquisitionRate = reader.ReadInt32();
		targetContentId = reader.ReadInt32();
		targetCount = reader.ReadInt32();
		transformationMonsterId = reader.ReadInt32();
		transformationLifetime = reader.ReadInt32();
		transformationRestored = reader.ReadBoolean();
		completionNpcId = reader.ReadInt32();
		completionTextKey = reader.ReadString();
		expRewardId = reader.ReadInt64();
		goldRewardId = reader.ReadInt64();
		cartId = reader.ReadInt32();
	}
}
