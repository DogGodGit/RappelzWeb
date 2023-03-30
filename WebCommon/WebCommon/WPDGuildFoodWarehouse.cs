namespace WebCommon;

public class WPDGuildFoodWarehouse : WPDPacketData
{
	public string nameKey;

	public int limitCount;

	public int guildTerritoryNpcId;

	public int levelUpRequiredItemType;

	public long fullLevelItemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(nameKey);
		writer.Write(limitCount);
		writer.Write(guildTerritoryNpcId);
		writer.Write(levelUpRequiredItemType);
		writer.Write(fullLevelItemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		nameKey = reader.ReadString();
		limitCount = reader.ReadInt32();
		guildTerritoryNpcId = reader.ReadInt32();
		levelUpRequiredItemType = reader.ReadInt32();
		fullLevelItemRewardId = reader.ReadInt64();
	}
}
