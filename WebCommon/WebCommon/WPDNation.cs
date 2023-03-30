namespace WebCommon;

public class WPDNation : WPDPacketData
{
	public int nationId;

	public string nameKey;

	public string descriptionKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(nationId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		nationId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
	}
}
