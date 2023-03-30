namespace WebCommon;

public class WPDContentOpenEntry : WPDPacketData
{
	public int entryId;

	public string nameKey;

	public string descriptionKey;

	public int type;

	public int requiredHeroLevel;

	public int requiredMainQuestNo;

	public bool isDisplay;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(entryId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(type);
		writer.Write(requiredHeroLevel);
		writer.Write(requiredMainQuestNo);
		writer.Write(isDisplay);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		entryId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		type = reader.ReadInt32();
		requiredHeroLevel = reader.ReadInt32();
		requiredMainQuestNo = reader.ReadInt32();
		isDisplay = reader.ReadBoolean();
	}
}
