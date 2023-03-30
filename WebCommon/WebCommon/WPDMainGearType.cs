namespace WebCommon;

public class WPDMainGearType : WPDPacketData
{
	public int mainGearType;

	public int categoryId;

	public string nameKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(mainGearType);
		writer.Write(categoryId);
		writer.Write(nameKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		mainGearType = reader.ReadInt32();
		categoryId = reader.ReadInt32();
		nameKey = reader.ReadString();
	}
}
