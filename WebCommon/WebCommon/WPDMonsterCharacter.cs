namespace WebCommon;

public class WPDMonsterCharacter : WPDPacketData
{
	public int monsterCharacterId;

	public string nameKey;

	public string prefabName;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(monsterCharacterId);
		writer.Write(nameKey);
		writer.Write(prefabName);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		monsterCharacterId = reader.ReadInt32();
		nameKey = reader.ReadString();
		prefabName = reader.ReadString();
	}
}
