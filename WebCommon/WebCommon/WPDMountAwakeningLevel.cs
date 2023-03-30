namespace WebCommon;

public class WPDMountAwakeningLevel : WPDPacketData
{
	public int mountId;

	public int awakeningLevel;

	public int nextLevelUpRequiredAwakeningExp;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(mountId);
		writer.Write(awakeningLevel);
		writer.Write(nextLevelUpRequiredAwakeningExp);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		mountId = reader.ReadInt32();
		awakeningLevel = reader.ReadInt32();
		nextLevelUpRequiredAwakeningExp = reader.ReadInt32();
	}
}
