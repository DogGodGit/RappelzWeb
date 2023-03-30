namespace WebCommon;

public class WPDAncientRelicStepRoute : WPDPacketData
{
	public int step;

	public int routeId;

	public float targetXPosition;

	public float targetYPosition;

	public float targetZPosition;

	public float targetRadius;

	public int removeObstacleId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(step);
		writer.Write(routeId);
		writer.Write(targetXPosition);
		writer.Write(targetYPosition);
		writer.Write(targetZPosition);
		writer.Write(targetRadius);
		writer.Write(removeObstacleId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		step = reader.ReadInt32();
		routeId = reader.ReadInt32();
		targetXPosition = reader.ReadSingle();
		targetYPosition = reader.ReadSingle();
		targetZPosition = reader.ReadSingle();
		targetRadius = reader.ReadSingle();
		removeObstacleId = reader.ReadInt32();
	}
}
