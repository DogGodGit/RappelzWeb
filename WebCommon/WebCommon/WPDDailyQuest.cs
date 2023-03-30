namespace WebCommon;

public class WPDDailyQuest : WPDPacketData
{
	public string titleKey;

	public int playCount;

	public int requiredHeroLevel;

	public int freeRefreshCount;

	public int refreshRequiredGold;

	public int slotCount;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(titleKey);
		writer.Write(playCount);
		writer.Write(requiredHeroLevel);
		writer.Write(freeRefreshCount);
		writer.Write(refreshRequiredGold);
		writer.Write(slotCount);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		titleKey = reader.ReadString();
		playCount = reader.ReadInt32();
		requiredHeroLevel = reader.ReadInt32();
		freeRefreshCount = reader.ReadInt32();
		refreshRequiredGold = reader.ReadInt32();
		slotCount = reader.ReadInt32();
	}
}
