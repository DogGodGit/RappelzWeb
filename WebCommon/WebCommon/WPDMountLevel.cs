namespace WebCommon;

public class WPDMountLevel : WPDPacketData
{
	public int mountId;

	public int level;

	public long maxHpAttrValueId;

	public long physicalOffenseAttrValueId;

	public long magicalOffenseAttrValueId;

	public long physicalDefenseAttrValueId;

	public long magicalDefenseAttrValueId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(mountId);
		writer.Write(level);
		writer.Write(maxHpAttrValueId);
		writer.Write(physicalOffenseAttrValueId);
		writer.Write(magicalOffenseAttrValueId);
		writer.Write(physicalDefenseAttrValueId);
		writer.Write(magicalDefenseAttrValueId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		mountId = reader.ReadInt32();
		level = reader.ReadInt32();
		maxHpAttrValueId = reader.ReadInt64();
		physicalOffenseAttrValueId = reader.ReadInt64();
		magicalOffenseAttrValueId = reader.ReadInt64();
		physicalDefenseAttrValueId = reader.ReadInt64();
		magicalDefenseAttrValueId = reader.ReadInt64();
	}
}
