namespace WebCommon;

public class WPDCreatureLevel : WPDPacketData
{
	public int level;

	public int nextLevelUpRequiredExp;

	public int maxInjectionLevel;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(level);
		writer.Write(nextLevelUpRequiredExp);
		writer.Write(maxInjectionLevel);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		level = reader.ReadInt32();
		nextLevelUpRequiredExp = reader.ReadInt32();
		maxInjectionLevel = reader.ReadInt32();
	}
}
