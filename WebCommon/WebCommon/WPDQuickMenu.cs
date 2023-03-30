namespace WebCommon;

public class WPDQuickMenu : WPDPacketData
{
	public int menuId;

	public string imageName;

	public int itemType;

	public int sortNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(menuId);
		writer.Write(imageName);
		writer.Write(itemType);
		writer.Write(sortNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		menuId = reader.ReadInt32();
		imageName = reader.ReadString();
		itemType = reader.ReadInt32();
		sortNo = reader.ReadInt32();
	}
}
