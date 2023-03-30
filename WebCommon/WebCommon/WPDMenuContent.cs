namespace WebCommon;

public class WPDMenuContent : WPDPacketData
{
	public int contentId;

	public int menuId;

	public string nameKey;

	public string descriptionKey;

	public string imageName;

	public int requiredHeroLevel;

	public int requiredMainQuestNo;

	public bool isDisplay;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(contentId);
		writer.Write(menuId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(imageName);
		writer.Write(requiredHeroLevel);
		writer.Write(requiredMainQuestNo);
		writer.Write(isDisplay);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		contentId = reader.ReadInt32();
		menuId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		imageName = reader.ReadString();
		requiredHeroLevel = reader.ReadInt32();
		requiredMainQuestNo = reader.ReadInt32();
		isDisplay = reader.ReadBoolean();
	}
}
