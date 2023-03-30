namespace WebCommon;

public class WPDGuildFoodWarehouseLevel : WPDPacketData
{
	public int level;

	public int nextLevelUpRequiredExp;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(level);
		writer.Write(nextLevelUpRequiredExp);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		level = reader.ReadInt32();
		nextLevelUpRequiredExp = reader.ReadInt32();
	}
}
