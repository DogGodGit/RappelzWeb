namespace WebCommon;

public class WPDGuildBuildingPointReward : WPDPacketData
{
	public long guildBuildingPointRewardId;

	public int value;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(guildBuildingPointRewardId);
		writer.Write(value);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		guildBuildingPointRewardId = reader.ReadInt64();
		value = reader.ReadInt32();
	}
}
