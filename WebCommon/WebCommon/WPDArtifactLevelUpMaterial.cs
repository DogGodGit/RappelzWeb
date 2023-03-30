namespace WebCommon;

public class WPDArtifactLevelUpMaterial : WPDPacketData
{
	public int tier;

	public int grade;

	public int exp;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(tier);
		writer.Write(grade);
		writer.Write(exp);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		tier = reader.ReadInt32();
		grade = reader.ReadInt32();
		exp = reader.ReadInt32();
	}
}
