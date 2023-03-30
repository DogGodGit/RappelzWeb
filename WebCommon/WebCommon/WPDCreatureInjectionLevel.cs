namespace WebCommon;

public class WPDCreatureInjectionLevel : WPDPacketData
{
	public int injectionLevel;

	public int nextLevelUpRequiredExp;

	public int requiredItemCount;

	public long requiredGold;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(injectionLevel);
		writer.Write(nextLevelUpRequiredExp);
		writer.Write(requiredItemCount);
		writer.Write(requiredGold);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		injectionLevel = reader.ReadInt32();
		nextLevelUpRequiredExp = reader.ReadInt32();
		requiredItemCount = reader.ReadInt32();
		requiredGold = reader.ReadInt64();
	}
}
