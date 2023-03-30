namespace WebCommon;

public class WPDWingStepLevel : WPDPacketData
{
	public int step;

	public int level;

	public int nextLevelUpRequiredExp;

	public int accEnchantLimitCount;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(step);
		writer.Write(level);
		writer.Write(nextLevelUpRequiredExp);
		writer.Write(accEnchantLimitCount);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		step = reader.ReadInt32();
		level = reader.ReadInt32();
		nextLevelUpRequiredExp = reader.ReadInt32();
		accEnchantLimitCount = reader.ReadInt32();
	}
}
