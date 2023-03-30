namespace WebCommon;

public class WPDOwnDiaReward : WPDPacketData
{
	public long ownDiaRewardId;

	public int value;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(ownDiaRewardId);
		writer.Write(value);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		ownDiaRewardId = reader.ReadInt64();
		value = reader.ReadInt32();
	}
}
