namespace WebCommon;

public class WPDAttainmentEntry : WPDPacketData
{
	public int entryNo;

	public string nameKey;

	public string descriptionKey;

	public int type;

	public int requiredHeroLevel;

	public int requiredMainQuestNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(entryNo);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(type);
		writer.Write(requiredHeroLevel);
		writer.Write(requiredMainQuestNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		entryNo = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		type = reader.ReadInt32();
		requiredHeroLevel = reader.ReadInt32();
		requiredMainQuestNo = reader.ReadInt32();
	}
}
