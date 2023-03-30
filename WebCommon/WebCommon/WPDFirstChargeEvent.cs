namespace WebCommon;

public class WPDFirstChargeEvent : WPDPacketData
{
	public string nameKey;

	public string descriptionKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
	}
}
