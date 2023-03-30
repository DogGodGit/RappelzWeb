namespace WebCommon;

public class WPDCreatureSkillSlotProtection : WPDPacketData
{
	public int protectionCount;

	public int requiredSkillCount;

	public int requiredItemCount;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(protectionCount);
		writer.Write(requiredSkillCount);
		writer.Write(requiredItemCount);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		protectionCount = reader.ReadInt32();
		requiredSkillCount = reader.ReadInt32();
		requiredItemCount = reader.ReadInt32();
	}
}
