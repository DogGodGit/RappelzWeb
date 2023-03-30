namespace WebCommon;

public class WPDMainGear : WPDPacketData
{
	public int mainGearId;

	public int mainGearType;

	public string nameKey;

	public int jobId;

	public int tier;

	public int grade;

	public int quality;

	public int saleGold;

	public string prefabName;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(mainGearId);
		writer.Write(mainGearType);
		writer.Write(nameKey);
		writer.Write(jobId);
		writer.Write(tier);
		writer.Write(grade);
		writer.Write(quality);
		writer.Write(saleGold);
		writer.Write(prefabName);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		mainGearId = reader.ReadInt32();
		mainGearType = reader.ReadInt32();
		nameKey = reader.ReadString();
		jobId = reader.ReadInt32();
		tier = reader.ReadInt32();
		grade = reader.ReadInt32();
		quality = reader.ReadInt32();
		saleGold = reader.ReadInt32();
		prefabName = reader.ReadString();
	}
}
