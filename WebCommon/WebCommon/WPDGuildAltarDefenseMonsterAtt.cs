namespace WebCommon;

public class WPDGuildAltarDefenseMonsterAttrFactor : WPDPacketData
{
	public int heroLevel;

	public float maxHpFactor;

	public float offenseFactor;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(heroLevel);
		writer.Write(maxHpFactor);
		writer.Write(offenseFactor);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		heroLevel = reader.ReadInt32();
		maxHpFactor = reader.ReadSingle();
		offenseFactor = reader.ReadSingle();
	}
}
