namespace WebCommon;

public class WPDInfiniteWarMonsterAttrFactor : WPDPacketData
{
	public int level;

	public float maxHpFactor;

	public float offenseFactor;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(level);
		writer.Write(maxHpFactor);
		writer.Write(offenseFactor);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		level = reader.ReadInt32();
		maxHpFactor = reader.ReadSingle();
		offenseFactor = reader.ReadSingle();
	}
}
