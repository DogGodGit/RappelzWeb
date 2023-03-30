namespace WebCommon;

public class WPDSubGearName : WPDPacketData
{
	public int subGearId;

	public int grade;

	public string nameKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(subGearId);
		writer.Write(grade);
		writer.Write(nameKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		subGearId = reader.ReadInt32();
		grade = reader.ReadInt32();
		nameKey = reader.ReadString();
	}
}
