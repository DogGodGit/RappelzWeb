namespace WebCommon;

public class WPDFieldBossEvent : WPDPacketData
{
	public string nameKey;

	public string descriptionKey;

	public int requiredHeroLevel;

	public float rewardRadius;

	public int fieldBossLifetime;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(requiredHeroLevel);
		writer.Write(rewardRadius);
		writer.Write(fieldBossLifetime);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		requiredHeroLevel = reader.ReadInt32();
		rewardRadius = reader.ReadSingle();
		fieldBossLifetime = reader.ReadInt32();
	}
}
