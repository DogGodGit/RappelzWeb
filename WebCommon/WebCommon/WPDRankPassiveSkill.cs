namespace WebCommon;

public class WPDRankPassiveSkill : WPDPacketData
{
	public int skillId;

	public int requiredRankNo;

	public string nameKey;

	public string descriptionKey;

	public string imageName;

	public int sortNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(skillId);
		writer.Write(requiredRankNo);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(imageName);
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
		sortNo = reader.ReadInt32();
	}
}
