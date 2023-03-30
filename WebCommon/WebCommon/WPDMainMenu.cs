namespace WebCommon;

public class WPDMainMenu : WPDPacketData
{
	public int menuId;

	public string nameKey;

	public string popupName;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(menuId);
		writer.Write(nameKey);
		writer.Write(popupName);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		menuId = reader.ReadInt32();
		nameKey = reader.ReadString();
		popupName = reader.ReadString();
	}
}
