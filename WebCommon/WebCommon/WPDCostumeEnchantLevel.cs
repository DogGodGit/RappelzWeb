namespace WebCommon;

public class WPDCostumeEnchantLevel : WPDPacketData
{
	public int enchantLevel;

	public int step;

	public int nextLevelUpSuccessRate;

	public int nextLevelUpRequiredItemCount;

	public int nextLevelUpMaxLuckyValue;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(enchantLevel);
		writer.Write(step);
		writer.Write(nextLevelUpSuccessRate);
		writer.Write(nextLevelUpRequiredItemCount);
		writer.Write(nextLevelUpMaxLuckyValue);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		enchantLevel = reader.ReadInt32();
		step = reader.ReadInt32();
		nextLevelUpSuccessRate = reader.ReadInt32();
		nextLevelUpRequiredItemCount = reader.ReadInt32();
		nextLevelUpMaxLuckyValue = reader.ReadInt32();
	}
}
