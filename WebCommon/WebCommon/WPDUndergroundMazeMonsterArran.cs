namespace WebCommon;

public class WPDUndergroundMazeMonsterArrange : WPDPacketData
{
	public int floor;

	public int arrangeNo;

	public long monsterArrangeId;

	public int monsterCount;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public float radius;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(floor);
		writer.Write(arrangeNo);
		writer.Write(monsterArrangeId);
		writer.Write(monsterCount);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(radius);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		floor = reader.ReadInt32();
		arrangeNo = reader.ReadInt32();
		monsterArrangeId = reader.ReadInt64();
		monsterCount = reader.ReadInt32();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		radius = reader.ReadSingle();
	}
}
