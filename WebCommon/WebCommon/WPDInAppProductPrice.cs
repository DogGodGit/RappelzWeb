namespace WebCommon;

public class WPDInAppProductPrice : WPDPacketData
{
	public string inAppProductKey;

	public int storeType;

	public string currencyCode;

	public string displayPrice;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(inAppProductKey);
		writer.Write(storeType);
		writer.Write(currencyCode);
		writer.Write(displayPrice);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		inAppProductKey = reader.ReadString();
		storeType = reader.ReadInt32();
		currencyCode = reader.ReadString();
		displayPrice = reader.ReadString();
	}
}
