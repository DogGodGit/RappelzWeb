namespace WebCommon;

public class WPDWingStep : WPDPacketData
{
	public int step;

	public string nameKey;

	public string colorCode;

	public int enchantMaterialItemCount;

	public int rewardWingId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(step);
		writer.Write(nameKey);
		writer.Write(colorCode);
		writer.Write(enchantMaterialItemCount);
		writer.Write(rewardWingId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		step = reader.ReadInt32();
		nameKey = reader.ReadString();
		colorCode = reader.ReadString();
		enchantMaterialItemCount = reader.ReadInt32();
		rewardWingId = reader.ReadInt32();
	}
}
