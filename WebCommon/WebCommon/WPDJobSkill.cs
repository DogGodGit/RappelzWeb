namespace WebCommon;

public class WPDJobSkill : WPDPacketData
{
	public int jobId;

	public int skillId;

	public string nameKey;

	public string descriptionKey;

	public int type;

	public int formType;

	public bool isRequireTarget;

	public float castRange;

	public float hitRange;

	public float coolTime;

	public int heroHitType;

	public int hitAreaType;

	public float hitAreaValue1;

	public float hitAreaValue2;

	public int hitAreaOffsetType;

	public float hitAreaOffset;

	public int slotIndex;

	public float ssStartDelay;

	public float ssDuration;

	public int castingMoveType;

	public int castingMoveValue1;

	public int castingMoveValue2;

	public int autoPriorityGroup;

	public int autoWeight;

	public int clientSkillIndex;

	public int buffAbnormalStateId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(jobId);
		writer.Write(skillId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(type);
		writer.Write(formType);
		writer.Write(isRequireTarget);
		writer.Write(castRange);
		writer.Write(hitRange);
		writer.Write(coolTime);
		writer.Write(heroHitType);
		writer.Write(hitAreaType);
		writer.Write(hitAreaValue1);
		writer.Write(hitAreaValue2);
		writer.Write(hitAreaOffsetType);
		writer.Write(hitAreaOffset);
		writer.Write(slotIndex);
		writer.Write(ssStartDelay);
		writer.Write(ssDuration);
		writer.Write(castingMoveType);
		writer.Write(castingMoveValue1);
		writer.Write(castingMoveValue2);
		writer.Write(autoPriorityGroup);
		writer.Write(autoWeight);
		writer.Write(clientSkillIndex);
		writer.Write(buffAbnormalStateId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		jobId = reader.ReadInt32();
		skillId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		type = reader.ReadInt32();
		formType = reader.ReadInt32();
		isRequireTarget = reader.ReadBoolean();
		castRange = reader.ReadSingle();
		hitRange = reader.ReadSingle();
		coolTime = reader.ReadSingle();
		heroHitType = reader.ReadInt32();
		hitAreaType = reader.ReadInt32();
		hitAreaValue1 = reader.ReadSingle();
		hitAreaValue2 = reader.ReadSingle();
		hitAreaOffsetType = reader.ReadInt32();
		hitAreaOffset = reader.ReadSingle();
		slotIndex = reader.ReadInt32();
		ssStartDelay = reader.ReadSingle();
		ssDuration = reader.ReadSingle();
		castingMoveType = reader.ReadInt32();
		castingMoveValue1 = reader.ReadInt32();
		castingMoveValue2 = reader.ReadInt32();
		autoPriorityGroup = reader.ReadInt32();
		autoWeight = reader.ReadInt32();
		clientSkillIndex = reader.ReadInt32();
		buffAbnormalStateId = reader.ReadInt32();
	}
}
