namespace WebCommon;

public class WPDSubGearSoulstoneSocket : WPDPacketData
{
	public int subGearId;

	public int socketIndex;

	public int itemType;

	public int requiredSubGearGrade;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(subGearId);
		writer.Write(socketIndex);
		writer.Write(itemType);
		writer.Write(requiredSubGearGrade);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		subGearId = reader.ReadInt32();
		socketIndex = reader.ReadInt32();
		itemType = reader.ReadInt32();
		requiredSubGearGrade = reader.ReadInt32();
	}
}
