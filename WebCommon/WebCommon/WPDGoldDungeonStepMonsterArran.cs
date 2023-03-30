namespace WebCommon;

public class WPDGoldDungeonStepMonsterArrange : WPDPacketData
{
	public int difficulty;

	public int step;

	public int arrangeNo;

	public long monsterArrangeId;

	public int monsterCount;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public float radius;

	public int yRotationType;

	public float yRotation;

	public bool isFugitive;

	public int activationWaveNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(difficulty);
		writer.Write(step);
		writer.Write(arrangeNo);
		writer.Write(monsterArrangeId);
		writer.Write(monsterCount);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(radius);
		writer.Write(yRotationType);
		writer.Write(yRotation);
		writer.Write(isFugitive);
		writer.Write(activationWaveNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		difficulty = reader.ReadInt32();
		step = reader.ReadInt32();
		arrangeNo = reader.ReadInt32();
		monsterArrangeId = reader.ReadInt64();
		monsterCount = reader.ReadInt32();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		radius = reader.ReadSingle();
		yRotationType = reader.ReadInt32();
		yRotation = reader.ReadSingle();
		isFugitive = reader.ReadBoolean();
		activationWaveNo = reader.ReadInt32();
	}
}
