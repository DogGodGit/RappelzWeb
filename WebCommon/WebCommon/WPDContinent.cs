namespace WebCommon;

public class WPDContinent : WPDPacketData
{
	public int continentId;

	public string nameKey;

	public string descriptionKey;

	public bool isNationTerritory;

	public int requiredHeroLevel;

	public bool isNationWarTarget;

	public string sceneName;

	public int locationId;

	public float x;

	public float z;

	public float xSize;

	public float zSize;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(continentId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(isNationTerritory);
		writer.Write(requiredHeroLevel);
		writer.Write(isNationWarTarget);
		writer.Write(sceneName);
		writer.Write(locationId);
		writer.Write(x);
		writer.Write(z);
		writer.Write(xSize);
		writer.Write(zSize);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		continentId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		isNationTerritory = reader.ReadBoolean();
		requiredHeroLevel = reader.ReadInt32();
		isNationWarTarget = reader.ReadBoolean();
		sceneName = reader.ReadString();
		locationId = reader.ReadInt32();
		x = reader.ReadSingle();
		z = reader.ReadSingle();
		xSize = reader.ReadSingle();
		zSize = reader.ReadSingle();
	}
}
