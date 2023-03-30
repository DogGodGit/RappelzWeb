namespace WebCommon;

public class WPDGuildBuildingLevel : WPDPacketData
{
	public int buildingId;

	public int level;

	public int nextLevelUpGuildBuildingPoint;

	public int nextLevelUpGuildFund;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(buildingId);
		writer.Write(level);
		writer.Write(nextLevelUpGuildBuildingPoint);
		writer.Write(nextLevelUpGuildFund);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		buildingId = reader.ReadInt32();
		level = reader.ReadInt32();
		nextLevelUpGuildBuildingPoint = reader.ReadInt32();
		nextLevelUpGuildFund = reader.ReadInt32();
	}
}
