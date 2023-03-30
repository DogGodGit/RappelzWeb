namespace WebCommon;

public class WPDGuildLevel : WPDPacketData
{
	public int level;

	public int maxMemberCount;

	public long dailyItemRewardId;

	public long altarItemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(level);
		writer.Write(maxMemberCount);
		writer.Write(dailyItemRewardId);
		writer.Write(altarItemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		level = reader.ReadInt32();
		maxMemberCount = reader.ReadInt32();
		dailyItemRewardId = reader.ReadInt64();
		altarItemRewardId = reader.ReadInt64();
	}
}
