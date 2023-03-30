namespace WebCommon;

public class WPDSceneryQuest : WPDPacketData
{
	public int questId;

	public string nameKey;

	public string descriptionKey;

	public string targetTitleKey;

	public string targetContentKey;

	public int continentId;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public float radius;

	public int waitingTime;

	public long itemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(questId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(continentId);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(radius);
		writer.Write(waitingTime);
		writer.Write(itemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		questId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		continentId = reader.ReadInt32();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		radius = reader.ReadSingle();
		waitingTime = reader.ReadInt32();
		itemRewardId = reader.ReadInt64();
	}
}
