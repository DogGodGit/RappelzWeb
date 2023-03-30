namespace WebCommon;

public class WPDMonsterSkillHit : WPDPacketData
{
	public int skillId;

	public int hitId;

	public float damageFactor;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(skillId);
		writer.Write(hitId);
		writer.Write(damageFactor);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		skillId = reader.ReadInt32();
		hitId = reader.ReadInt32();
		damageFactor = reader.ReadSingle();
	}
}
