namespace WebCommon;

public class WPDSubMenu : WPDPacketData
{
	public int menuId;

	public int subMenuId;

	public string nameKey;

	public string prefab1;

	public string prefab2;

	public string prefab3;

	public int layout;

	public bool isDefault;

	public int sortNo;

	public int contentId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(menuId);
		writer.Write(subMenuId);
		writer.Write(nameKey);
		writer.Write(prefab1);
		writer.Write(prefab2);
		writer.Write(prefab3);
		writer.Write(layout);
		writer.Write(isDefault);
		writer.Write(sortNo);
		writer.Write(contentId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		menuId = reader.ReadInt32();
		subMenuId = reader.ReadInt32();
		nameKey = reader.ReadString();
		prefab1 = reader.ReadString();
		prefab2 = reader.ReadString();
		prefab3 = reader.ReadString();
		layout = reader.ReadInt32();
		isDefault = reader.ReadBoolean();
		sortNo = reader.ReadInt32();
		contentId = reader.ReadInt32();
	}
}
