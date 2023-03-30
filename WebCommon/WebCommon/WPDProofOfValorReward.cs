namespace WebCommon;

public class WPDProofOfValorReward : WPDPacketData
{
	public int heroLevel;

	public long successExpRewardId;

	public long failureExpRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(heroLevel);
		writer.Write(successExpRewardId);
		writer.Write(failureExpRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		heroLevel = reader.ReadInt32();
		successExpRewardId = reader.ReadInt64();
		failureExpRewardId = reader.ReadInt64();
	}
}
