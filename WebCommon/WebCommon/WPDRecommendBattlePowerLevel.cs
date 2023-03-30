namespace WebCommon;

public class WPDRecommendBattlePowerLevel : WPDPacketData
{
	public int level;

	public long sRankBattlePower;

	public long aRankBattlePower;

	public long bRankBattlePower;

	public long cRankBattlePower;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(level);
		writer.Write(sRankBattlePower);
		writer.Write(aRankBattlePower);
		writer.Write(bRankBattlePower);
		writer.Write(cRankBattlePower);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		level = reader.ReadInt32();
		sRankBattlePower = reader.ReadInt64();
		aRankBattlePower = reader.ReadInt64();
		bRankBattlePower = reader.ReadInt64();
		cRankBattlePower = reader.ReadInt64();
	}
}
