namespace WebCommon;

public class WPDCreatureFarmQuest : WPDPacketData
{
	public string nameKey;

	public int requiredHeroLevel;

	public int startNpcId;

	public int completionNpcId;

	public int limitCount;

	public string startDialogueKey;

	public string completionDialogueKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(nameKey);
		writer.Write(requiredHeroLevel);
		writer.Write(startNpcId);
		writer.Write(completionNpcId);
		writer.Write(limitCount);
		writer.Write(startDialogueKey);
		writer.Write(completionDialogueKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		nameKey = reader.ReadString();
		requiredHeroLevel = reader.ReadInt32();
		startNpcId = reader.ReadInt32();
		completionNpcId = reader.ReadInt32();
		limitCount = reader.ReadInt32();
		startDialogueKey = reader.ReadString();
		completionDialogueKey = reader.ReadString();
	}
}
