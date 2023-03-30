namespace WebCommon;

public class WPDSubGearLevelQuality : WPDPacketData
{
	public int subGearId;

	public int level;

	public int quality;

	public int nextQualityUpItem1Id;

	public int nextQualityUpItem1Count;

	public int nextQualityUpItem2Id;

	public int nextQualityUpItem2Count;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(subGearId);
		writer.Write(level);
		writer.Write(quality);
		writer.Write(nextQualityUpItem1Id);
		writer.Write(nextQualityUpItem1Count);
		writer.Write(nextQualityUpItem2Id);
		writer.Write(nextQualityUpItem2Count);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		subGearId = reader.ReadInt32();
		level = reader.ReadInt32();
		quality = reader.ReadInt32();
		nextQualityUpItem1Id = reader.ReadInt32();
		nextQualityUpItem1Count = reader.ReadInt32();
		nextQualityUpItem2Id = reader.ReadInt32();
		nextQualityUpItem2Count = reader.ReadInt32();
	}
}
