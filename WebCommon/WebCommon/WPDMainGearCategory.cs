namespace WebCommon;

public class WPDMainGearCategory : WPDPacketData
{
	public int categoryId;

	public string nameKey;

	public int slotIndex;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(categoryId);
		writer.Write(nameKey);
		writer.Write(slotIndex);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		categoryId = reader.ReadInt32();
		nameKey = reader.ReadString();
		slotIndex = reader.ReadInt32();
	}
}
