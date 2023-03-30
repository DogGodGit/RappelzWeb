namespace WebCommon;

public class WPDSystemMessage : WPDPacketData
{
	public int messageId;

	public string messageKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(messageId);
		writer.Write(messageKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		messageId = reader.ReadInt32();
		messageKey = reader.ReadString();
	}
}
