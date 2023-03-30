namespace WebCommon;

public class WPDSeriesMissionStep : WPDPacketData
{
	public int missionId;

	public int step;

	public int targetCount;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(missionId);
		writer.Write(step);
		writer.Write(targetCount);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		missionId = reader.ReadInt32();
		step = reader.ReadInt32();
		targetCount = reader.ReadInt32();
	}
}
