namespace WebCommon;

public class WPDCostumeEffect : WPDPacketData
{
	public int costumeEffectId;

	public string nameKey;

	public string prefabName;

	public int requiredItemId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(costumeEffectId);
		writer.Write(nameKey);
		writer.Write(prefabName);
		writer.Write(requiredItemId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		costumeEffectId = reader.ReadInt32();
		nameKey = reader.ReadString();
		prefabName = reader.ReadString();
		requiredItemId = reader.ReadInt32();
	}
}
