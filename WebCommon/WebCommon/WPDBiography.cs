namespace WebCommon;

public class WPDBiography : WPDPacketData
{
	public int biographyId;

	public string titleKey;

	public string nameKey;

	public string descriptionKey;

	public string openConditionTextKey;

	public string targetTitleKey;

	public int requiredItemId;

	public int sortNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(biographyId);
		writer.Write(titleKey);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(openConditionTextKey);
		writer.Write(targetTitleKey);
		writer.Write(requiredItemId);
		writer.Write(sortNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		biographyId = reader.ReadInt32();
		titleKey = reader.ReadString();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		openConditionTextKey = reader.ReadString();
		targetTitleKey = reader.ReadString();
		requiredItemId = reader.ReadInt32();
		sortNo = reader.ReadInt32();
	}
}
