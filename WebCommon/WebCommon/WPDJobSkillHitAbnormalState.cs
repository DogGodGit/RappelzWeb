namespace WebCommon;

public class WPDJobSkillHitAbnormalState : WPDPacketData
{
	public int jobId;

	public int skillId;

	public int hitId;

	public int abnormalStateId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(jobId);
		writer.Write(skillId);
		writer.Write(hitId);
		writer.Write(abnormalStateId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		jobId = reader.ReadInt32();
		skillId = reader.ReadInt32();
		hitId = reader.ReadInt32();
		abnormalStateId = reader.ReadInt32();
	}
}
