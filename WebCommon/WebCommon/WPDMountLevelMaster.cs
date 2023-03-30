namespace WebCommon;

public class WPDMountLevelMaster : WPDPacketData
{
	public int level;

	public int quality;

	public int qualityLevel;

	public int nextLevelUpRequiredSatiety;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(level);
		writer.Write(quality);
		writer.Write(qualityLevel);
		writer.Write(nextLevelUpRequiredSatiety);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		level = reader.ReadInt32();
		quality = reader.ReadInt32();
		qualityLevel = reader.ReadInt32();
		nextLevelUpRequiredSatiety = reader.ReadInt32();
	}
}
