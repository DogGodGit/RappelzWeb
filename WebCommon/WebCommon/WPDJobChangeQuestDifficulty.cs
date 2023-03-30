namespace WebCommon;

public class WPDJobChangeQuestDifficulty : WPDPacketData
{
	public int questNo;

	public int difficulty;

	public string nameKey;

	public bool isTargetPlaceGuildTerritory;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(questNo);
		writer.Write(difficulty);
		writer.Write(nameKey);
		writer.Write(isTargetPlaceGuildTerritory);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		questNo = reader.ReadInt32();
		difficulty = reader.ReadInt32();
		nameKey = reader.ReadString();
		isTargetPlaceGuildTerritory = reader.ReadBoolean();
	}
}
