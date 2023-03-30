namespace WebCommon;

public class WPDBiographyQuestDungeonWave : WPDPacketData
{
	public int dungeonId;

	public int waveNo;

	public string targetTitleKey;

	public string targetContentKey;

	public int targetType;

	public int targetArrangeKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(dungeonId);
		writer.Write(waveNo);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(targetType);
		writer.Write(targetArrangeKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		dungeonId = reader.ReadInt32();
		waveNo = reader.ReadInt32();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		targetType = reader.ReadInt32();
		targetArrangeKey = reader.ReadInt32();
	}
}
