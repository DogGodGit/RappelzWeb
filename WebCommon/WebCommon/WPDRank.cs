namespace WebCommon;

public class WPDRank : WPDPacketData
{
	public int rankNo;

	public string nameKey;

	public string colorCode;

	public int requiredExploitPoint;

	public long goldRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(rankNo);
		writer.Write(nameKey);
		writer.Write(colorCode);
		writer.Write(requiredExploitPoint);
		writer.Write(goldRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		rankNo = reader.ReadInt32();
		nameKey = reader.ReadString();
		colorCode = reader.ReadString();
		requiredExploitPoint = reader.ReadInt32();
		goldRewardId = reader.ReadInt64();
	}
}
