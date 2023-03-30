namespace WebCommon;

public class WPDMainQuestCompletionDialogue : WPDPacketData
{
	public int mainQuestNo;

	public int dialogueNo;

	public int npcId;

	public string dialogueKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(mainQuestNo);
		writer.Write(dialogueNo);
		writer.Write(npcId);
		writer.Write(dialogueKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		mainQuestNo = reader.ReadInt32();
		dialogueNo = reader.ReadInt32();
		npcId = reader.ReadInt32();
		dialogueKey = reader.ReadString();
	}
}
