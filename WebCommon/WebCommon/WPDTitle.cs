namespace WebCommon;

public class WPDTitle : WPDPacketData
{
	public int titleId;

	public string nameKey;

	public int type;

	public int grade;

	public string acquisitionTextKey;

	public string backgroundImageName;

	public int lifetime;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(titleId);
		writer.Write(nameKey);
		writer.Write(type);
		writer.Write(grade);
		writer.Write(acquisitionTextKey);
		writer.Write(backgroundImageName);
		writer.Write(lifetime);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		titleId = reader.ReadInt32();
		nameKey = reader.ReadString();
		type = reader.ReadInt32();
		grade = reader.ReadInt32();
		acquisitionTextKey = reader.ReadString();
		backgroundImageName = reader.ReadString();
		lifetime = reader.ReadInt32();
	}
}
