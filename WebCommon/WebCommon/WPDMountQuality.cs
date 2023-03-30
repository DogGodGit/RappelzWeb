namespace WebCommon;

public class WPDMountQuality : WPDPacketData
{
	public int mountId;

	public int quality;

	public string prefabName;

	public int potionAttrMaxCount;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(mountId);
		writer.Write(quality);
		writer.Write(prefabName);
		writer.Write(potionAttrMaxCount);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		mountId = reader.ReadInt32();
		quality = reader.ReadInt32();
		prefabName = reader.ReadString();
		potionAttrMaxCount = reader.ReadInt32();
	}
}
