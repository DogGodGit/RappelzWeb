namespace WebCommon;

public class WPDCostume : WPDPacketData
{
	public int costumeId;

	public string nameKey;

	public string descriptionKey;

	public string prefabName;

	public int requiredHeroLevel;

	public int periodLimitDay;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(costumeId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(prefabName);
		writer.Write(requiredHeroLevel);
		writer.Write(periodLimitDay);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		costumeId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		prefabName = reader.ReadString();
		requiredHeroLevel = reader.ReadInt32();
		periodLimitDay = reader.ReadInt32();
	}
}
