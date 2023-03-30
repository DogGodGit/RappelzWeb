namespace WebCommon;

public class WPDJobSkillMaster : WPDPacketData
{
	public int skillId;

	public int openRequiredMainQuestNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(skillId);
		writer.Write(openRequiredMainQuestNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		skillId = reader.ReadInt32();
		openRequiredMainQuestNo = reader.ReadInt32();
	}
}
