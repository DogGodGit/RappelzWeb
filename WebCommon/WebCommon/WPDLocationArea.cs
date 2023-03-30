namespace WebCommon;

public class WPDLocationArea : WPDPacketData
{
	public int locationId;

	public int areaNo;

	public string nameKey;

	public bool isMinimapDisplay;

	public int minimapX;

	public int minimapY;

	public string minimapTextColorCode;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(locationId);
		writer.Write(areaNo);
		writer.Write(nameKey);
		writer.Write(isMinimapDisplay);
		writer.Write(minimapX);
		writer.Write(minimapY);
		writer.Write(minimapTextColorCode);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		locationId = reader.ReadInt32();
		areaNo = reader.ReadInt32();
		nameKey = reader.ReadString();
		isMinimapDisplay = reader.ReadBoolean();
		minimapX = reader.ReadInt32();
		minimapY = reader.ReadInt32();
		minimapTextColorCode = reader.ReadString();
	}
}
