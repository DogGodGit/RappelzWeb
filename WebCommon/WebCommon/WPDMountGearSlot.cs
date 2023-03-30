namespace WebCommon;

public class WPDMountGearSlot : WPDPacketData
{
	public int slotIndex;

	public int openHeroLevel;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(slotIndex);
		writer.Write(openHeroLevel);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		slotIndex = reader.ReadInt32();
		openHeroLevel = reader.ReadInt32();
	}
}
