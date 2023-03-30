namespace WebCommon;

public class WPDArtifactRoomFloor : WPDPacketData
{
	public int floor;

	public string nameKey;

	public int requiredHeroLevel;

	public long recommendBattlePower;

	public int sweepDuration;

	public int sweepDia;

	public long itemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(floor);
		writer.Write(nameKey);
		writer.Write(requiredHeroLevel);
		writer.Write(recommendBattlePower);
		writer.Write(sweepDuration);
		writer.Write(sweepDia);
		writer.Write(itemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		floor = reader.ReadInt32();
		nameKey = reader.ReadString();
		requiredHeroLevel = reader.ReadInt32();
		recommendBattlePower = reader.ReadInt64();
		sweepDuration = reader.ReadInt32();
		sweepDia = reader.ReadInt32();
		itemRewardId = reader.ReadInt64();
	}
}
