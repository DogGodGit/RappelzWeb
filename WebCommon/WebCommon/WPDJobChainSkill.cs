namespace WebCommon;

public class WPDJobChainSkill : WPDPacketData
{
	public int jobId;

	public int skillId;

	public int chainSkillId;

	public int hitAreaType;

	public float hitAreaValue1;

	public float hitAreaValue2;

	public int hitAreaOffsetType;

	public float hitAreaOffset;

	public float castConditionStartTime;

	public float castConditionEndTIme;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(jobId);
		writer.Write(skillId);
		writer.Write(chainSkillId);
		writer.Write(hitAreaType);
		writer.Write(hitAreaValue1);
		writer.Write(hitAreaValue2);
		writer.Write(hitAreaOffsetType);
		writer.Write(hitAreaOffset);
		writer.Write(castConditionStartTime);
		writer.Write(castConditionEndTIme);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		jobId = reader.ReadInt32();
		skillId = reader.ReadInt32();
		chainSkillId = reader.ReadInt32();
		hitAreaType = reader.ReadInt32();
		hitAreaValue1 = reader.ReadSingle();
		hitAreaValue2 = reader.ReadSingle();
		hitAreaOffsetType = reader.ReadInt32();
		hitAreaOffset = reader.ReadSingle();
		castConditionStartTime = reader.ReadSingle();
		castConditionEndTIme = reader.ReadSingle();
	}
}
