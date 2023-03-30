namespace WebCommon;

public class WPDGuildBuilding : WPDPacketData
{
	public int buildingId;

	public string nameKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(buildingId);
		writer.Write(nameKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		buildingId = reader.ReadInt32();
		nameKey = reader.ReadString();
	}
}
