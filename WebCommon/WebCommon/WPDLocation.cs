namespace WebCommon;

public class WPDLocation : WPDPacketData
{
	public int locationId;

	public float minimapMagnification;

	public bool accelerationEnabled;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(locationId);
		writer.Write(minimapMagnification);
		writer.Write(accelerationEnabled);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		locationId = reader.ReadInt32();
		minimapMagnification = reader.ReadSingle();
		accelerationEnabled = reader.ReadBoolean();
	}
}
