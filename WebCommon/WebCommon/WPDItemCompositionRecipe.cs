namespace WebCommon;

public class WPDItemCompositionRecipe : WPDPacketData
{
	public int itemId;

	public int materialItemId;

	public int materialItemCount;

	public int gold;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(itemId);
		writer.Write(materialItemId);
		writer.Write(materialItemCount);
		writer.Write(gold);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		itemId = reader.ReadInt32();
		materialItemId = reader.ReadInt32();
		materialItemCount = reader.ReadInt32();
		gold = reader.ReadInt32();
	}
}
