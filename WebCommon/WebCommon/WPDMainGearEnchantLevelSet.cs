namespace WebCommon;

public class WPDMainGearEnchantLevelSet : WPDPacketData
{
	public int setNo;

	public string nameKey;

	public int requiredTotalEnchantLevel;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(setNo);
		writer.Write(nameKey);
		writer.Write(requiredTotalEnchantLevel);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		setNo = reader.ReadInt32();
		nameKey = reader.ReadString();
		requiredTotalEnchantLevel = reader.ReadInt32();
	}
}
