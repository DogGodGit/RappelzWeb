namespace WebCommon;

public class WPDMainGearSetAttr : WPDPacketData
{
	public int tier;

	public int grade;

	public int quality;

	public int attrId;

	public long attrValueId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(tier);
		writer.Write(grade);
		writer.Write(quality);
		writer.Write(attrId);
		writer.Write(attrValueId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		tier = reader.ReadInt32();
		grade = reader.ReadInt32();
		quality = reader.ReadInt32();
		attrId = reader.ReadInt32();
		attrValueId = reader.ReadInt64();
	}
}
