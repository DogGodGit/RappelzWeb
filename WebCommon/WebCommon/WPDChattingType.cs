namespace WebCommon;

public class WPDChattingType : WPDPacketData
{
	public int chattingType;

	public string nameKey;

	public string colorCode;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(chattingType);
		writer.Write(nameKey);
		writer.Write(colorCode);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		chattingType = reader.ReadInt32();
		nameKey = reader.ReadString();
		colorCode = reader.ReadString();
	}
}
