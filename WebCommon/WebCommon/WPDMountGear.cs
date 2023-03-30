namespace WebCommon;

public class WPDMountGear : WPDPacketData
{
	public int mountGearId;

	public int requiredHeroLevel;

	public int type;

	public int grade;

	public int quality;

	public string nameKey;

	public string imageName;

	public int saleGold;

	public long maxHpAttrValueId;

	public long physicalOffenseAttrValueId;

	public long magicalOffenseAttrValueId;

	public long physicalDefenseAttrValueId;

	public long magicalDefenseAttrValueId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(mountGearId);
		writer.Write(requiredHeroLevel);
		writer.Write(type);
		writer.Write(grade);
		writer.Write(quality);
		writer.Write(nameKey);
		writer.Write(imageName);
		writer.Write(saleGold);
		writer.Write(maxHpAttrValueId);
		writer.Write(physicalOffenseAttrValueId);
		writer.Write(magicalOffenseAttrValueId);
		writer.Write(physicalDefenseAttrValueId);
		writer.Write(magicalDefenseAttrValueId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		mountGearId = reader.ReadInt32();
		requiredHeroLevel = reader.ReadInt32();
		type = reader.ReadInt32();
		grade = reader.ReadInt32();
		quality = reader.ReadInt32();
		nameKey = reader.ReadString();
		imageName = reader.ReadString();
		saleGold = reader.ReadInt32();
		maxHpAttrValueId = reader.ReadInt64();
		physicalOffenseAttrValueId = reader.ReadInt64();
		magicalOffenseAttrValueId = reader.ReadInt64();
		physicalDefenseAttrValueId = reader.ReadInt64();
		magicalDefenseAttrValueId = reader.ReadInt64();
	}
}
