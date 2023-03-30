namespace WebCommon;

public class WPDUndergroundMazeEntrance : WPDPacketData
{
	public int floor;

	public int requiredHeroLevel;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(floor);
		writer.Write(requiredHeroLevel);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		floor = reader.ReadInt32();
		requiredHeroLevel = reader.ReadInt32();
	}
}
