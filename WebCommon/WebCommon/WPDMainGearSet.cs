namespace WebCommon;

public class WPDMainGearSet : WPDPacketData
{
	public int tier;

	public int grade;

	public int quality;

	public string nameKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(tier);
		writer.Write(grade);
		writer.Write(quality);
		writer.Write(nameKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		tier = reader.ReadInt32();
		grade = reader.ReadInt32();
		quality = reader.ReadInt32();
		nameKey = reader.ReadString();
	}
}
