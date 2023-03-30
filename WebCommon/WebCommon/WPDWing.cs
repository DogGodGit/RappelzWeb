namespace WebCommon;

public class WPDWing : WPDPacketData
{
	public int wingId;

	public string nameKey;

	public string prefabName;

	public int attrId;

	public long attrValueId;

	public string acquisitionTextKey;

	public bool memoryPieceInstallationEnabled;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(wingId);
		writer.Write(nameKey);
		writer.Write(prefabName);
		writer.Write(attrId);
		writer.Write(attrValueId);
		writer.Write(acquisitionTextKey);
		writer.Write(memoryPieceInstallationEnabled);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		wingId = reader.ReadInt32();
		nameKey = reader.ReadString();
		prefabName = reader.ReadString();
		attrId = reader.ReadInt32();
		attrValueId = reader.ReadInt64();
		acquisitionTextKey = reader.ReadString();
		memoryPieceInstallationEnabled = reader.ReadBoolean();
	}
}
