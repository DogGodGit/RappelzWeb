namespace WebCommon;

public class WPDMainGearEnchantStep : WPDPacketData
{
	public int step;

	public int nextEnchantMaterialItemId;

	public int nextEnchantPenaltyPreventItemId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(step);
		writer.Write(nextEnchantMaterialItemId);
		writer.Write(nextEnchantPenaltyPreventItemId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		step = reader.ReadInt32();
		nextEnchantMaterialItemId = reader.ReadInt32();
		nextEnchantPenaltyPreventItemId = reader.ReadInt32();
	}
}
