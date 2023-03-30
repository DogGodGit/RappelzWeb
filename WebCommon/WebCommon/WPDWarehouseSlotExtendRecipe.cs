namespace WebCommon;

public class WPDWarehouseSlotExtendRecipe : WPDPacketData
{
	public int slotCount;

	public int dia;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(slotCount);
		writer.Write(dia);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		slotCount = reader.ReadInt32();
		dia = reader.ReadInt32();
	}
}
