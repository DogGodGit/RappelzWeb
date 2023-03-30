namespace WebCommon;

public class WPDEliteMonster : WPDPacketData
{
	public int eliteMonsterId;

	public int eliteMonsterMasterId;

	public int starGrade;

	public int attrId;

	public long monsterArrangeId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(eliteMonsterId);
		writer.Write(eliteMonsterMasterId);
		writer.Write(starGrade);
		writer.Write(attrId);
		writer.Write(monsterArrangeId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		eliteMonsterId = reader.ReadInt32();
		eliteMonsterMasterId = reader.ReadInt32();
		starGrade = reader.ReadInt32();
		attrId = reader.ReadInt32();
		monsterArrangeId = reader.ReadInt64();
	}
}
