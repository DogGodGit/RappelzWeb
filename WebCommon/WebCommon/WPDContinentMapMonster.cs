namespace WebCommon;

public class WPDContinentMapMonster : WPDPacketData
{
	public int continentId;

	public int monsterId;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(continentId);
		writer.Write(monsterId);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		continentId = reader.ReadInt32();
		monsterId = reader.ReadInt32();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
	}
}
