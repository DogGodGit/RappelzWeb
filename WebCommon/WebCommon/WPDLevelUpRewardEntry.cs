namespace WebCommon;

public class WPDLevelUpRewardEntry : WPDPacketData
{
	public int entryId;

	public int level;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(entryId);
		writer.Write(level);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		entryId = reader.ReadInt32();
		level = reader.ReadInt32();
	}
}
