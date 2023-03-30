namespace WebCommon;

public class WPDWingMemoryPieceSlot : WPDPacketData
{
	public int wingId;

	public int slotIndex;

	public int attrId;

	public int openStep;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(wingId);
		writer.Write(slotIndex);
		writer.Write(attrId);
		writer.Write(openStep);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		wingId = reader.ReadInt32();
		slotIndex = reader.ReadInt32();
		attrId = reader.ReadInt32();
		openStep = reader.ReadInt32();
	}
}
