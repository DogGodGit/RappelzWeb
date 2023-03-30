namespace WebCommon;

public class WPDRetrievalReward : WPDPacketData
{
	public int retrievalId;

	public int level;

	public long goldExpRewardId;

	public long goldItemRewardId;

	public long diaExpRewardId;

	public long diaItemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(retrievalId);
		writer.Write(level);
		writer.Write(goldExpRewardId);
		writer.Write(goldItemRewardId);
		writer.Write(diaExpRewardId);
		writer.Write(diaItemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		retrievalId = reader.ReadInt32();
		level = reader.ReadInt32();
		goldExpRewardId = reader.ReadInt64();
		goldItemRewardId = reader.ReadInt64();
		diaExpRewardId = reader.ReadInt64();
		diaItemRewardId = reader.ReadInt64();
	}
}
