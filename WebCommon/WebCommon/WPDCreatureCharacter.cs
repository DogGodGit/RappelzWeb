namespace WebCommon;

public class WPDCreatureCharacter : WPDPacketData
{
	public int creatureCharacterId;

	public string nameKey;

	public string descriptionKey;

	public int requiredHeroLevel;

	public string prefabName;

	public string imageName;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(creatureCharacterId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(requiredHeroLevel);
		writer.Write(prefabName);
		writer.Write(imageName);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		creatureCharacterId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		requiredHeroLevel = reader.ReadInt32();
		prefabName = reader.ReadString();
		imageName = reader.ReadString();
	}
}
