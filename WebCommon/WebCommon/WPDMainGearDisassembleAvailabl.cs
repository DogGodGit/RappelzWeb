namespace WebCommon;

public class WPDMainGearDisassembleAvailableResultEntry : WPDPacketData
{
	public int tier;

	public int grade;

	public int entryNo;

	public int itemId;

	public int itemCount;

	public bool itemOwned;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(tier);
		writer.Write(grade);
		writer.Write(entryNo);
		writer.Write(itemId);
		writer.Write(itemCount);
		writer.Write(itemOwned);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		tier = reader.ReadInt32();
		grade = reader.ReadInt32();
		entryNo = reader.ReadInt32();
		itemId = reader.ReadInt32();
		itemCount = reader.ReadInt32();
		itemOwned = reader.ReadBoolean();
	}
}
