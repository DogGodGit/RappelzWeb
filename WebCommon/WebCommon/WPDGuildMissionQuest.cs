namespace WebCommon;

public class WPDGuildMissionQuest : WPDPacketData
{
	public string nameKey;

	public int limitCount;

	public int startNpcId;

	public long completionItemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(nameKey);
		writer.Write(limitCount);
		writer.Write(startNpcId);
		writer.Write(completionItemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		nameKey = reader.ReadString();
		limitCount = reader.ReadInt32();
		startNpcId = reader.ReadInt32();
		completionItemRewardId = reader.ReadInt64();
	}
}
