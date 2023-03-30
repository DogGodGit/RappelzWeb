namespace WebCommon;

public class WPDNationNoblesse : WPDPacketData
{
	public int noblesseId;

	public string nameKey;

	public bool nationWarDeclarationEnabled;

	public bool nationCallEnabled;

	public bool nationWarCallEnabled;

	public bool nationWarConvergingAttackEnabled;

	public bool nationAllianceEnabled;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(noblesseId);
		writer.Write(nameKey);
		writer.Write(nationWarDeclarationEnabled);
		writer.Write(nationCallEnabled);
		writer.Write(nationWarCallEnabled);
		writer.Write(nationWarConvergingAttackEnabled);
		writer.Write(nationAllianceEnabled);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		noblesseId = reader.ReadInt32();
		nameKey = reader.ReadString();
		nationWarDeclarationEnabled = reader.ReadBoolean();
		nationCallEnabled = reader.ReadBoolean();
		nationWarCallEnabled = reader.ReadBoolean();
		nationWarConvergingAttackEnabled = reader.ReadBoolean();
		nationAllianceEnabled = reader.ReadBoolean();
	}
}
