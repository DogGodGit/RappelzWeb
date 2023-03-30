namespace WebCommon;

public class WPDCreature : WPDPacketData
{
	public int creatureId;

	public int creatureCharacterId;

	public int grade;

	public int minQuality;

	public int maxQuality;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(creatureId);
		writer.Write(creatureCharacterId);
		writer.Write(grade);
		writer.Write(minQuality);
		writer.Write(maxQuality);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		creatureId = reader.ReadInt32();
		creatureCharacterId = reader.ReadInt32();
		grade = reader.ReadInt32();
		minQuality = reader.ReadInt32();
		maxQuality = reader.ReadInt32();
	}
}
