namespace WebCommon;

public class WPDFearAltarHalidomLevel : WPDPacketData
{
	public int halidomLevel;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(halidomLevel);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		halidomLevel = reader.ReadInt32();
	}
}
