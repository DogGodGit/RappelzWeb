namespace WebCommon;

public class WPDBiographyQuestStartDialogue : WPDPacketData
{
	public int biographyId;

	public int questNo;

	public int dialogueNo;

	public int npcId;

	public string dialogueKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(biographyId);
		writer.Write(questNo);
		writer.Write(dialogueNo);
		writer.Write(npcId);
		writer.Write(dialogueKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		biographyId = reader.ReadInt32();
		questNo = reader.ReadInt32();
		dialogueNo = reader.ReadInt32();
		npcId = reader.ReadInt32();
		dialogueKey = reader.ReadString();
	}
}
