namespace WebCommon;

public class WPDGoldDungeonStep : WPDPacketData
{
	public int difficulty;

	public int step;

	public long goldRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(difficulty);
		writer.Write(step);
		writer.Write(goldRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		difficulty = reader.ReadInt32();
		step = reader.ReadInt32();
		goldRewardId = reader.ReadInt64();
	}
}
