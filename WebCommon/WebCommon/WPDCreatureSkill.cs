namespace WebCommon;

public class WPDCreatureSkill : WPDPacketData
{
	public int skillId;

	public int attrId;

	public string nameKey;

	public string imageName;

	public string effectTextKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(skillId);
		writer.Write(attrId);
		writer.Write(nameKey);
		writer.Write(imageName);
		writer.Write(effectTextKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		skillId = reader.ReadInt32();
		attrId = reader.ReadInt32();
		nameKey = reader.ReadString();
		imageName = reader.ReadString();
		effectTextKey = reader.ReadString();
	}
}
