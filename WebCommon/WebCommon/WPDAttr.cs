namespace WebCommon;

public class WPDAttr : WPDPacketData
{
	public int attrId;

	public string nameKey;

	public int battlePowerFactor;

	public int attrCategoryId;

	public int sortNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(attrId);
		writer.Write(nameKey);
		writer.Write(battlePowerFactor);
		writer.Write(attrCategoryId);
		writer.Write(sortNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		attrId = reader.ReadInt32();
		nameKey = reader.ReadString();
		battlePowerFactor = reader.ReadInt32();
		attrCategoryId = reader.ReadInt32();
		sortNo = reader.ReadInt32();
	}
}
