namespace WebCommon;

public class WPDCreatureCard : WPDPacketData
{
	public int creatureCardId;

	public string nameKey;

	public string descriptionKey;

	public int categoryId;

	public int grade;

	public int attack;

	public int life;

	public int attrId;

	public long attrValueId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(creatureCardId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(categoryId);
		writer.Write(grade);
		writer.Write(attack);
		writer.Write(life);
		writer.Write(attrId);
		writer.Write(attrValueId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		creatureCardId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		categoryId = reader.ReadInt32();
		grade = reader.ReadInt32();
		attack = reader.ReadInt32();
		life = reader.ReadInt32();
		attrId = reader.ReadInt32();
		attrValueId = reader.ReadInt64();
	}
}
