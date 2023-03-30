namespace WebCommon;

public class WPDJob : WPDPacketData
{
	public int jobId;

	public string nameKey;

	public string descriptionKey;

	public int moveSpeed;

	public int walkMoveSpeed;

	public int offenseType;

	public int elementalId;

	public float radius;

	public int parentJobId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(jobId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(moveSpeed);
		writer.Write(walkMoveSpeed);
		writer.Write(offenseType);
		writer.Write(elementalId);
		writer.Write(radius);
		writer.Write(parentJobId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		jobId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		moveSpeed = reader.ReadInt32();
		walkMoveSpeed = reader.ReadInt32();
		offenseType = reader.ReadInt32();
		elementalId = reader.ReadInt32();
		radius = reader.ReadSingle();
		parentJobId = reader.ReadInt32();
	}
}
