namespace WebCommon;

public class WPDEliteMonsterSpawnSchedule : WPDPacketData
{
	public int eliteMonsterMasterId;

	public int scheduleNo;

	public int spawnTime;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(eliteMonsterMasterId);
		writer.Write(scheduleNo);
		writer.Write(spawnTime);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		eliteMonsterMasterId = reader.ReadInt32();
		scheduleNo = reader.ReadInt32();
		spawnTime = reader.ReadInt32();
	}
}
