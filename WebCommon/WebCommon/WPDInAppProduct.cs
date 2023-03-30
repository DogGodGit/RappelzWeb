namespace WebCommon;

public class WPDInAppProduct : WPDPacketData
{
	public string inAppProductKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(inAppProductKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		inAppProductKey = reader.ReadString();
	}
}
