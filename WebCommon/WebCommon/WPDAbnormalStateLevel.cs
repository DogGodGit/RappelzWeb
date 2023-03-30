namespace WebCommon;

public class WPDAbnormalStateLevel : WPDPacketData
{
	public int abnormalStateId;

	public int jobId;

	public int level;

	public int duration;

	public int value1;

	public int value2;

	public int value3;

	public int value4;

	public int value5;

	public int value6;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(abnormalStateId);
		writer.Write(jobId);
		writer.Write(level);
		writer.Write(duration);
		writer.Write(value1);
		writer.Write(value2);
		writer.Write(value3);
		writer.Write(value4);
		writer.Write(value5);
		writer.Write(value6);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		abnormalStateId = reader.ReadInt32();
		jobId = reader.ReadInt32();
		level = reader.ReadInt32();
		duration = reader.ReadInt32();
		value1 = reader.ReadInt32();
		value2 = reader.ReadInt32();
		value3 = reader.ReadInt32();
		value4 = reader.ReadInt32();
		value5 = reader.ReadInt32();
		value6 = reader.ReadInt32();
	}
}
