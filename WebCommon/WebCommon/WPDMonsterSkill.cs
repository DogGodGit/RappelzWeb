namespace WebCommon;

public class WPDMonsterSkill : WPDPacketData
{
	public int skillId;

	public int baseDamageType;

	public int type;

	public int elementalId;

	public int formType;

	public bool isRequiredTarget;

	public float castRange;

	public float hitRange;

	public float coolTime;

	public int hitAreaType;

	public float hitAreaValue1;

	public float hitAreaValue2;

	public int hitAreaOffsetType;

	public float hitAreaOffset;

	public float ssStartDelay;

	public float ssDuration;

	public int autoPriorityGroup;

	public int autoWeight;

	public string sound;

	public float soundVolume;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(skillId);
		writer.Write(baseDamageType);
		writer.Write(type);
		writer.Write(elementalId);
		writer.Write(formType);
		writer.Write(isRequiredTarget);
		writer.Write(castRange);
		writer.Write(hitRange);
		writer.Write(coolTime);
		writer.Write(hitAreaType);
		writer.Write(hitAreaValue1);
		writer.Write(hitAreaValue2);
		writer.Write(hitAreaOffsetType);
		writer.Write(hitAreaOffset);
		writer.Write(ssStartDelay);
		writer.Write(ssDuration);
		writer.Write(autoPriorityGroup);
		writer.Write(autoWeight);
		writer.Write(sound);
		writer.Write(soundVolume);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		skillId = reader.ReadInt32();
		baseDamageType = reader.ReadInt32();
		type = reader.ReadInt32();
		elementalId = reader.ReadInt32();
		formType = reader.ReadInt32();
		isRequiredTarget = reader.ReadBoolean();
		castRange = reader.ReadSingle();
		hitRange = reader.ReadSingle();
		coolTime = reader.ReadSingle();
		hitAreaType = reader.ReadInt32();
		hitAreaValue1 = reader.ReadSingle();
		hitAreaValue2 = reader.ReadSingle();
		hitAreaOffsetType = reader.ReadInt32();
		hitAreaOffset = reader.ReadSingle();
		ssStartDelay = reader.ReadSingle();
		ssDuration = reader.ReadSingle();
		autoPriorityGroup = reader.ReadInt32();
		autoWeight = reader.ReadInt32();
		sound = reader.ReadString();
		soundVolume = reader.ReadSingle();
	}
}
