namespace WebCommon;

public class WPDAnkouTombAvailableReward : WPDPacketData
{
	public int difficulty;

	public int rewardNo;

	public int itemId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(difficulty);
		writer.Write(rewardNo);
		writer.Write(itemId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		difficulty = reader.ReadInt32();
		rewardNo = reader.ReadInt32();
		itemId = reader.ReadInt32();
	}
}
