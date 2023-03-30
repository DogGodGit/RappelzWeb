namespace WebCommon;

public class WPDMountQualityMaster : WPDPacketData
{
	public int quality;

	public string nameKey;

	public string colorCode;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(quality);
		writer.Write(nameKey);
		writer.Write(colorCode);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		quality = reader.ReadInt32();
		nameKey = reader.ReadString();
		colorCode = reader.ReadString();
	}
}
