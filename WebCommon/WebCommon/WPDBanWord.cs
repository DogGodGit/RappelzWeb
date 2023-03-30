namespace WebCommon;

public class WPDBanWord : WPDPacketData
{
	public int type;

	public string word;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(type);
		writer.Write(word);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		type = reader.ReadInt32();
		word = reader.ReadString();
	}
}
