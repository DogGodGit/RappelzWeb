namespace WebCommon;

public class WPDMenu : WPDPacketData
{
	public int menuId;

	public string nameKey;

	public string imageName;

	public int requiredHeroLevel;

	public int requiredMainQuestNo;

	public int menuGroup;

	public int sortNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(menuId);
		writer.Write(nameKey);
		writer.Write(imageName);
		writer.Write(requiredHeroLevel);
		writer.Write(requiredMainQuestNo);
		writer.Write(menuGroup);
		writer.Write(sortNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		menuId = reader.ReadInt32();
		nameKey = reader.ReadString();
		imageName = reader.ReadString();
		requiredHeroLevel = reader.ReadInt32();
		requiredMainQuestNo = reader.ReadInt32();
		menuGroup = reader.ReadInt32();
		sortNo = reader.ReadInt32();
	}
}
