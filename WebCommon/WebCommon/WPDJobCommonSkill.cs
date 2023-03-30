namespace WebCommon;

public class WPDJobCommonSkill : WPDPacketData
{
	public int skillId;

	public string nameKey;

	public string descriptionKey;

	public int type;

	public int formType;

	public bool isRequireTarget;

	public float castRange;

	public float hitRange;

	public float coolTime;

	public int hitAreaType;

	public float hitAreaValue1;

	public float hitAreaValue2;

	public int hitAreaOffsetType;

	public float hitAreaOffset;

	public int slotIndex;

	public int clientSkillIndex;

	public int mentalStrengthDamage;

	public int buffAbnormalStateId;

	public int openRequiredMainQuestNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(skillId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(type);
		writer.Write(formType);
		writer.Write(isRequireTarget);
		writer.Write(castRange);
		writer.Write(hitRange);
		writer.Write(coolTime);
		writer.Write(hitAreaType);
		writer.Write(hitAreaValue1);
		writer.Write(hitAreaValue2);
		writer.Write(hitAreaOffsetType);
		writer.Write(hitAreaOffset);
		writer.Write(slotIndex);
		writer.Write(clientSkillIndex);
		writer.Write(mentalStrengthDamage);
		writer.Write(buffAbnormalStateId);
		writer.Write(openRequiredMainQuestNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		skillId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		type = reader.ReadInt32();
		formType = reader.ReadInt32();
		isRequireTarget = reader.ReadBoolean();
		castRange = reader.ReadSingle();
		hitRange = reader.ReadSingle();
		coolTime = reader.ReadSingle();
		hitAreaType = reader.ReadInt32();
		hitAreaValue1 = reader.ReadSingle();
		hitAreaValue2 = reader.ReadSingle();
		hitAreaOffsetType = reader.ReadInt32();
		hitAreaOffset = reader.ReadSingle();
		slotIndex = reader.ReadInt32();
		clientSkillIndex = reader.ReadInt32();
		mentalStrengthDamage = reader.ReadInt32();
		buffAbnormalStateId = reader.ReadInt32();
		openRequiredMainQuestNo = reader.ReadInt32();
	}
}
