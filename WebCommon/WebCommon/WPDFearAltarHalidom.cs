namespace WebCommon;

public class WPDFearAltarHalidom : WPDPacketData
{
	public int halidomId;

	public int halidomElementalId;

	public int halidomLevel;

	public string imageName;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(halidomId);
		writer.Write(halidomElementalId);
		writer.Write(halidomLevel);
		writer.Write(imageName);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		halidomId = reader.ReadInt32();
		halidomElementalId = reader.ReadInt32();
		halidomLevel = reader.ReadInt32();
		imageName = reader.ReadString();
	}
}
