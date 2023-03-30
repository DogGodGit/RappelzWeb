namespace WebCommon;

public class WPDFishingQuest : WPDPacketData
{
	public int npcId;

	public int requiredHeroLevel;

	public int limitCount;

	public int castingCount;

	public int castingInterval;

	public float partyRadius;

	public float partyExpRewardFactor;

	public int partyRecommendPopUpDisplayDuration;

	public int partyRecommendPopUpHideDuration;

	public float guildExpRewardFactor;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(npcId);
		writer.Write(requiredHeroLevel);
		writer.Write(limitCount);
		writer.Write(castingCount);
		writer.Write(castingInterval);
		writer.Write(partyRadius);
		writer.Write(partyExpRewardFactor);
		writer.Write(partyRecommendPopUpDisplayDuration);
		writer.Write(partyRecommendPopUpHideDuration);
		writer.Write(guildExpRewardFactor);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		npcId = reader.ReadInt32();
		requiredHeroLevel = reader.ReadInt32();
		limitCount = reader.ReadInt32();
		castingCount = reader.ReadInt32();
		castingInterval = reader.ReadInt32();
		partyRadius = reader.ReadSingle();
		partyExpRewardFactor = reader.ReadSingle();
		partyRecommendPopUpDisplayDuration = reader.ReadInt32();
		partyRecommendPopUpHideDuration = reader.ReadInt32();
		guildExpRewardFactor = reader.ReadSingle();
	}
}
