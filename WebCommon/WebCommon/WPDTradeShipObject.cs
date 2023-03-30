namespace WebCommon;

public class WPDTradeShipObject : WPDPacketData
{
	public int difficulty;

	public int objectId;

	public long monsterArrangeId;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public float yRotation;

	public int activationStepNo;

	public bool hitMessageDisplayable;

	public int hitMessageDisplayInterval;

	public int point;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(difficulty);
		writer.Write(objectId);
		writer.Write(monsterArrangeId);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(yRotation);
		writer.Write(activationStepNo);
		writer.Write(hitMessageDisplayable);
		writer.Write(hitMessageDisplayInterval);
		writer.Write(point);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		difficulty = reader.ReadInt32();
		objectId = reader.ReadInt32();
		monsterArrangeId = reader.ReadInt64();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		yRotation = reader.ReadSingle();
		activationStepNo = reader.ReadInt32();
		hitMessageDisplayable = reader.ReadBoolean();
		hitMessageDisplayInterval = reader.ReadInt32();
		point = reader.ReadInt32();
	}
}
