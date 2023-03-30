namespace WebCommon;

public class WPDCostumeDisplay : WPDPacketData
{
	public int costumeId;

	public int jobId;

	public string hairPrefabName;

	public string facePrefabName;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(costumeId);
		writer.Write(jobId);
		writer.Write(hairPrefabName);
		writer.Write(facePrefabName);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		costumeId = reader.ReadInt32();
		jobId = reader.ReadInt32();
		hairPrefabName = reader.ReadString();
		facePrefabName = reader.ReadString();
	}
}
