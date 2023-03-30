namespace WebCommon;

public class WPDFieldBoss : WPDPacketData
{
	public int fieldBossId;

	public string nameKey;

	public string imageName;

	public long monsterArrangeId;

	public int continentId;

	public float xPosition;

	public float yPosition;

	public float zPosition;

	public float yRotation;

	public long itemRewardId;

	public int sortNo;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(fieldBossId);
		writer.Write(nameKey);
		writer.Write(imageName);
		writer.Write(monsterArrangeId);
		writer.Write(continentId);
		writer.Write(xPosition);
		writer.Write(yPosition);
		writer.Write(zPosition);
		writer.Write(yRotation);
		writer.Write(itemRewardId);
		writer.Write(sortNo);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		fieldBossId = reader.ReadInt32();
		nameKey = reader.ReadString();
		imageName = reader.ReadString();
		monsterArrangeId = reader.ReadInt64();
		continentId = reader.ReadInt32();
		xPosition = reader.ReadSingle();
		yPosition = reader.ReadSingle();
		zPosition = reader.ReadSingle();
		yRotation = reader.ReadSingle();
		itemRewardId = reader.ReadInt64();
		sortNo = reader.ReadInt32();
	}
}
