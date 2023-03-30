namespace WebCommon;

public class WPDMountGearType : WPDPacketData
{
	public int type;

	public string nameKey;

	public int slotIndex;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(type);
		writer.Write(nameKey);
		writer.Write(slotIndex);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		type = reader.ReadInt32();
		nameKey = reader.ReadString();
		slotIndex = reader.ReadInt32();
	}
}
