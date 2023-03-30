namespace WebCommon;

public class WPDArtifact : WPDPacketData
{
	public int artifactNo;

	public string nameKey;

	public string prefabName;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(artifactNo);
		writer.Write(nameKey);
		writer.Write(prefabName);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		artifactNo = reader.ReadInt32();
		nameKey = reader.ReadString();
		prefabName = reader.ReadString();
	}
}
