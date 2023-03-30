namespace WebCommon;

public class WPDGuildHuntingQuest : WPDPacketData
{
	public int limitCount;

	public int questNpcId;

	public string completionDialogueKey;

	public long itemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(limitCount);
		writer.Write(questNpcId);
		writer.Write(completionDialogueKey);
		writer.Write(itemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		limitCount = reader.ReadInt32();
		questNpcId = reader.ReadInt32();
		completionDialogueKey = reader.ReadString();
		itemRewardId = reader.ReadInt64();
	}
}
