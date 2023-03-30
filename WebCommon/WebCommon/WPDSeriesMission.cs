namespace WebCommon;

public class WPDSeriesMission : WPDPacketData
{
	public int missionId;

	public string nameKey;

	public string descriptionKey;

	public int sortNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(missionId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(sortNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		missionId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		sortNo = reader.ReadInt32();
	}
}
