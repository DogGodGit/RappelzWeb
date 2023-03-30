namespace WebCommon;

public class WPDSubGearRuneSocketAvailableItemType : WPDPacketData
{
	public int subGearId;

	public int socketIndex;

	public int itemType;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(subGearId);
		writer.Write(socketIndex);
		writer.Write(itemType);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		subGearId = reader.ReadInt32();
		socketIndex = reader.ReadInt32();
		itemType = reader.ReadInt32();
	}
}
