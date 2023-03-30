namespace WebCommon;

public class WPDMainGearQuality : WPDPacketData
{
	public int quality;

	public string nameKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(quality);
		writer.Write(nameKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		quality = reader.ReadInt32();
		nameKey = reader.ReadString();
	}
}
