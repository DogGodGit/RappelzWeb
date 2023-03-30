namespace WebCommon;

public class WPDClientText : WPDPacketData
{
	public string name;

	public string value;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(name);
		writer.Write(value);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		name = reader.ReadString();
		value = reader.ReadString();
	}
}
