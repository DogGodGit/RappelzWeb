namespace WebCommon;

public class WPDAncientRelicTrap : WPDPacketData
{
	public int trapId;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public float width;

	public float height;

	public int startDelayTime;

	public int regenInterval;

	public int duration;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(trapId);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(width);
		writer.Write(height);
		writer.Write(startDelayTime);
		writer.Write(regenInterval);
		writer.Write(duration);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		trapId = reader.ReadInt32();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		width = reader.ReadSingle();
		height = reader.ReadSingle();
		startDelayTime = reader.ReadInt32();
		regenInterval = reader.ReadInt32();
		duration = reader.ReadInt32();
	}
}
