namespace WebCommon;

public class WPDWingMemoryPieceSlotStep : WPDPacketData
{
	public int wingId;

	public int slotIndex;

	public int step;

	public int attrMaxValue;

	public int attrIncBaseValue;

	public int attrDecValue;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(wingId);
		writer.Write(slotIndex);
		writer.Write(step);
		writer.Write(attrMaxValue);
		writer.Write(attrIncBaseValue);
		writer.Write(attrDecValue);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		wingId = reader.ReadInt32();
		slotIndex = reader.ReadInt32();
		step = reader.ReadInt32();
		attrMaxValue = reader.ReadInt32();
		attrIncBaseValue = reader.ReadInt32();
		attrDecValue = reader.ReadInt32();
	}
}
