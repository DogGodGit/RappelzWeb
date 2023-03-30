namespace WebCommon;

public class WPDStoryDungeonAvailableReward : WPDPacketData
{
	public int dungeonNo;

	public int difficulty;

	public int rewardNo;

	public int itemId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(dungeonNo);
		writer.Write(difficulty);
		writer.Write(rewardNo);
		writer.Write(itemId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		dungeonNo = reader.ReadInt32();
		difficulty = reader.ReadInt32();
		rewardNo = reader.ReadInt32();
		itemId = reader.ReadInt32();
	}
}
