namespace WebCommon;

public class WPDCreatureCardGrade : WPDPacketData
{
	public int grade;

	public string colorCode;

	public int saleSoulPowder;

	public int disassembleSoulPowder;

	public int compositionSoulPowder;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(grade);
		writer.Write(colorCode);
		writer.Write(saleSoulPowder);
		writer.Write(disassembleSoulPowder);
		writer.Write(compositionSoulPowder);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		grade = reader.ReadInt32();
		colorCode = reader.ReadString();
		saleSoulPowder = reader.ReadInt32();
		disassembleSoulPowder = reader.ReadInt32();
		compositionSoulPowder = reader.ReadInt32();
	}
}
