namespace WebCommon;

public class WPDOrdealQuest : WPDPacketData
{
	public int questNo;

	public string nameKey;

	public string descriptionKey;

	public int requiredHeroLevel;

	public int availableRewardItemId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(questNo);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(requiredHeroLevel);
		writer.Write(availableRewardItemId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		questNo = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		requiredHeroLevel = reader.ReadInt32();
		availableRewardItemId = reader.ReadInt32();
	}
}
