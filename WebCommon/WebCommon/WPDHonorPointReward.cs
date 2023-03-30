namespace WebCommon;

public class WPDHonorPointReward : WPDPacketData
{
	public long honorPointRewardId;

	public int value;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(honorPointRewardId);
		writer.Write(value);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		honorPointRewardId = reader.ReadInt64();
		value = reader.ReadInt32();
	}
}
