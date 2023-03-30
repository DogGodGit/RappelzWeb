namespace WebCommon;

public class WPDLimitationGift : WPDPacketData
{
	public string nameKey;

	public string scheduleTextKey;

	public int requiredHeroLevel;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(nameKey);
		writer.Write(scheduleTextKey);
		writer.Write(requiredHeroLevel);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		nameKey = reader.ReadString();
		scheduleTextKey = reader.ReadString();
		requiredHeroLevel = reader.ReadInt32();
	}
}
