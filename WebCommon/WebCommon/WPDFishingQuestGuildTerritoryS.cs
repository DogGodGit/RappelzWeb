namespace WebCommon;

public class WPDFishingQuestGuildTerritorySpot : WPDPacketData
{
	public int spotId;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public float radius;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(spotId);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(radius);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		spotId = reader.ReadInt32();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		radius = reader.ReadSingle();
	}
}
