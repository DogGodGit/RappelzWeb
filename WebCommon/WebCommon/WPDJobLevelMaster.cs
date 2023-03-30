namespace WebCommon;

public class WPDJobLevelMaster : WPDPacketData
{
	public int level;

	public long nextLevelUpExp;

	public int inventorySlotAccCount;

	public long restMaxExpRewardId;

	public int potionAttrMaxCount;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(level);
		writer.Write(nextLevelUpExp);
		writer.Write(inventorySlotAccCount);
		writer.Write(restMaxExpRewardId);
		writer.Write(potionAttrMaxCount);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		level = reader.ReadInt32();
		nextLevelUpExp = reader.ReadInt64();
		inventorySlotAccCount = reader.ReadInt32();
		restMaxExpRewardId = reader.ReadInt64();
		potionAttrMaxCount = reader.ReadInt32();
	}
}
