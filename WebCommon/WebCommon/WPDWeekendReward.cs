namespace WebCommon;

public class WPDWeekendReward : WPDPacketData
{
	public string nameKey;

	public string scheduleTextKey;

	public string descriptionKey;

	public int requiredHeroLevel;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(nameKey);
		writer.Write(scheduleTextKey);
		writer.Write(descriptionKey);
		writer.Write(requiredHeroLevel);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		nameKey = reader.ReadString();
		scheduleTextKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		requiredHeroLevel = reader.ReadInt32();
	}
}
