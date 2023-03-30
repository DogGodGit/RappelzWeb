namespace WebCommon;

public class WPDMountAwakeningLevelMaster : WPDPacketData
{
	public int awakeningLevel;

	public float unequippedAttrFactor;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(awakeningLevel);
		writer.Write(unequippedAttrFactor);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		awakeningLevel = reader.ReadInt32();
		unequippedAttrFactor = reader.ReadSingle();
	}
}
