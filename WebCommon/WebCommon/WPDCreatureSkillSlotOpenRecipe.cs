namespace WebCommon;

public class WPDCreatureSkillSlotOpenRecipe : WPDPacketData
{
	public int slotCount;

	public int requiredItemId;

	public int requiredItemCount;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(slotCount);
		writer.Write(requiredItemId);
		writer.Write(requiredItemCount);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		slotCount = reader.ReadInt32();
		requiredItemId = reader.ReadInt32();
		requiredItemCount = reader.ReadInt32();
	}
}
