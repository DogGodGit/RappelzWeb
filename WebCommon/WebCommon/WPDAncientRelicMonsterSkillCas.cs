namespace WebCommon;

public class WPDAncientRelicMonsterSkillCastingGuide : WPDPacketData
{
	public int step;

	public int waveNo;

	public int arrangeNo;

	public int monsterSkillId;

	public string guideImageName;

	public string guideTitleKey;

	public string guideContentKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(step);
		writer.Write(waveNo);
		writer.Write(arrangeNo);
		writer.Write(monsterSkillId);
		writer.Write(guideImageName);
		writer.Write(guideTitleKey);
		writer.Write(guideContentKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		step = reader.ReadInt32();
		waveNo = reader.ReadInt32();
		arrangeNo = reader.ReadInt32();
		monsterSkillId = reader.ReadInt32();
		guideImageName = reader.ReadString();
		guideTitleKey = reader.ReadString();
		guideContentKey = reader.ReadString();
	}
}
