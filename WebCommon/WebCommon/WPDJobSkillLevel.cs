namespace WebCommon;

public class WPDJobSkillLevel : WPDPacketData
{
	public int jobId;

	public int skillId;

	public int level;

	public string summaryKey;

	public long battlePower;

	public long physicalOffenseAmpAttrValueId;

	public long magicalOffenseAmpAttrValueId;

	public long offensePointAttrValueId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(jobId);
		writer.Write(skillId);
		writer.Write(level);
		writer.Write(summaryKey);
		writer.Write(battlePower);
		writer.Write(physicalOffenseAmpAttrValueId);
		writer.Write(magicalOffenseAmpAttrValueId);
		writer.Write(offensePointAttrValueId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		jobId = reader.ReadInt32();
		skillId = reader.ReadInt32();
		level = reader.ReadInt32();
		summaryKey = reader.ReadString();
		battlePower = reader.ReadInt64();
		physicalOffenseAmpAttrValueId = reader.ReadInt64();
		magicalOffenseAmpAttrValueId = reader.ReadInt64();
		offensePointAttrValueId = reader.ReadInt64();
	}
}
