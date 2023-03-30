namespace WebCommon;

public class WPDMainGearTier : WPDPacketData
{
	public int tier;

	public int requiredHeroLevel;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(tier);
		writer.Write(requiredHeroLevel);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		tier = reader.ReadInt32();
		requiredHeroLevel = reader.ReadInt32();
	}
}
