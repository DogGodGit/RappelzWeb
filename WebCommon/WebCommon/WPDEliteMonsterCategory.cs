namespace WebCommon;

public class WPDEliteMonsterCategory : WPDPacketData
{
	public int categoryId;

	public string nameKey;

	public int recommendMinHeroLevel;

	public int recommendMaxHeroLevel;

	public int continentId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(categoryId);
		writer.Write(nameKey);
		writer.Write(recommendMinHeroLevel);
		writer.Write(recommendMaxHeroLevel);
		writer.Write(continentId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		categoryId = reader.ReadInt32();
		nameKey = reader.ReadString();
		recommendMinHeroLevel = reader.ReadInt32();
		recommendMaxHeroLevel = reader.ReadInt32();
		continentId = reader.ReadInt32();
	}
}
