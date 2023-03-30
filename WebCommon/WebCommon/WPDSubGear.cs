namespace WebCommon;

public class WPDSubGear : WPDPacketData
{
	public int subGearId;

	public int slotIndex;

	public string nameKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(subGearId);
		writer.Write(slotIndex);
		writer.Write(nameKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		subGearId = reader.ReadInt32();
		slotIndex = reader.ReadInt32();
		nameKey = reader.ReadString();
	}
}
