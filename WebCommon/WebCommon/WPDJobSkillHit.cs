namespace WebCommon;

public class WPDJobSkillHit : WPDPacketData
{
	public int jobId;

	public int skillId;

	public int hitId;

	public float damageFactor;

	public int acquireLak;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(jobId);
		writer.Write(skillId);
		writer.Write(hitId);
		writer.Write(damageFactor);
		writer.Write(acquireLak);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		jobId = reader.ReadInt32();
		skillId = reader.ReadInt32();
		hitId = reader.ReadInt32();
		damageFactor = reader.ReadSingle();
		acquireLak = reader.ReadInt32();
	}
}
