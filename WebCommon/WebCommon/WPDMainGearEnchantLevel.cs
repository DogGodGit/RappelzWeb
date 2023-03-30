namespace WebCommon;

public class WPDMainGearEnchantLevel : WPDPacketData
{
	public int enchantLevel;

	public int step;

	public int nextSuccessRate;

	public bool penaltyPreventEnabled;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(enchantLevel);
		writer.Write(step);
		writer.Write(nextSuccessRate);
		writer.Write(penaltyPreventEnabled);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		enchantLevel = reader.ReadInt32();
		step = reader.ReadInt32();
		nextSuccessRate = reader.ReadInt32();
		penaltyPreventEnabled = reader.ReadBoolean();
	}
}
