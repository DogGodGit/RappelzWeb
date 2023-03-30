namespace WebCommon;

public class WPDRankActiveSkill : WPDPacketData
{
	public int skillId;

	public int requiredRankNo;

	public string nameKey;

	public string descriptionKey;

	public string imageName;

	public int type;

	public float coolTime;

	public float castRange;

	public int abnormalStateId;

	public int sortNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(skillId);
		writer.Write(requiredRankNo);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(imageName);
		writer.Write(type);
		writer.Write(coolTime);
		writer.Write(castRange);
		writer.Write(abnormalStateId);
		writer.Write(sortNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		skillId = reader.ReadInt32();
		requiredRankNo = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		imageName = reader.ReadString();
		type = reader.ReadInt32();
		coolTime = reader.ReadSingle();
		castRange = reader.ReadSingle();
		abnormalStateId = reader.ReadInt32();
		sortNo = reader.ReadInt32();
	}
}
