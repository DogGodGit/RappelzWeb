namespace WebCommon;

public class WPDSubGearLevel : WPDPacketData
{
	public int subGearId;

	public int level;

	public int grade;

	public int nextLevelUpRequiredGold;

	public int nextGradeUpItem1Id;

	public int nextGradeUpItem1Count;

	public int nextGradeUpItem2Id;

	public int nextGradeUpItem2Count;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(subGearId);
		writer.Write(level);
		writer.Write(grade);
		writer.Write(nextLevelUpRequiredGold);
		writer.Write(nextGradeUpItem1Id);
		writer.Write(nextGradeUpItem1Count);
		writer.Write(nextGradeUpItem2Id);
		writer.Write(nextGradeUpItem2Count);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		subGearId = reader.ReadInt32();
		level = reader.ReadInt32();
		grade = reader.ReadInt32();
		nextLevelUpRequiredGold = reader.ReadInt32();
		nextGradeUpItem1Id = reader.ReadInt32();
		nextGradeUpItem1Count = reader.ReadInt32();
		nextGradeUpItem2Id = reader.ReadInt32();
		nextGradeUpItem2Count = reader.ReadInt32();
	}
}
