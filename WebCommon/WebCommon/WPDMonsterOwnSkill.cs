namespace WebCommon;

public class WPDMonsterOwnSkill : WPDPacketData
{
	public int monsterId;

	public int skillId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(monsterId);
		writer.Write(skillId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		monsterId = reader.ReadInt32();
		skillId = reader.ReadInt32();
	}
}
