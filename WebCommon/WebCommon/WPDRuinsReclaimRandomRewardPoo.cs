namespace WebCommon;

public class WPDRuinsReclaimRandomRewardPoolEntry : WPDPacketData
{
	public int entryNo;

	public long itemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(entryNo);
		writer.Write(itemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		entryNo = reader.ReadInt32();
		itemRewardId = reader.ReadInt64();
	}
}
