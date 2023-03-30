namespace WebCommon;

public class WPDUndergroundMazeFloor : WPDPacketData
{
	public int floor;

	public string nameKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(floor);
		writer.Write(nameKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		floor = reader.ReadInt32();
		nameKey = reader.ReadString();
	}
}
