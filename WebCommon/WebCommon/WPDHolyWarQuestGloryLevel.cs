namespace WebCommon;

public class WPDHolyWarQuestGloryLevel : WPDPacketData
{
	public int gloryLevel;

	public int requiredKillCount;

	public long exploitPointRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(gloryLevel);
		writer.Write(requiredKillCount);
		writer.Write(exploitPointRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		gloryLevel = reader.ReadInt32();
		requiredKillCount = reader.ReadInt32();
		exploitPointRewardId = reader.ReadInt64();
	}
}
