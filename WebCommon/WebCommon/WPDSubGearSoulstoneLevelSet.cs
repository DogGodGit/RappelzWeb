namespace WebCommon;

public class WPDSubGearSoulstoneLevelSet : WPDPacketData
{
	public int setNo;

	public string nameKey;

	public int requiredTotalLevel;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(setNo);
		writer.Write(nameKey);
		writer.Write(requiredTotalLevel);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		setNo = reader.ReadInt32();
		nameKey = reader.ReadString();
		requiredTotalLevel = reader.ReadInt32();
	}
}
