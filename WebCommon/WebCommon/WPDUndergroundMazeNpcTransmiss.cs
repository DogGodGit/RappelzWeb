namespace WebCommon;

public class WPDUndergroundMazeNpcTransmissionEntry : WPDPacketData
{
	public int npcId;

	public int floor;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(npcId);
		writer.Write(floor);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		npcId = reader.ReadInt32();
		floor = reader.ReadInt32();
	}
}
