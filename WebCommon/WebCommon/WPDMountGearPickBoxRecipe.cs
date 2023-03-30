namespace WebCommon;

public class WPDMountGearPickBoxRecipe : WPDPacketData
{
	public int itemId;

	public int requiredHeroLevel;

	public int gold;

	public bool owned;

	public int materialItem1Id;

	public int materialItem1Count;

	public int materialItem2Id;

	public int materialItem2Count;

	public int materialItem3Id;

	public int materialItem3Count;

	public int materialItem4Id;

	public int materialItem4Count;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(itemId);
		writer.Write(requiredHeroLevel);
		writer.Write(gold);
		writer.Write(owned);
		writer.Write(materialItem1Id);
		writer.Write(materialItem1Count);
		writer.Write(materialItem2Id);
		writer.Write(materialItem2Count);
		writer.Write(materialItem3Id);
		writer.Write(materialItem3Count);
		writer.Write(materialItem4Id);
		writer.Write(materialItem4Count);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		itemId = reader.ReadInt32();
		requiredHeroLevel = reader.ReadInt32();
		gold = reader.ReadInt32();
		owned = reader.ReadBoolean();
		materialItem1Id = reader.ReadInt32();
		materialItem1Count = reader.ReadInt32();
		materialItem2Id = reader.ReadInt32();
		materialItem2Count = reader.ReadInt32();
		materialItem3Id = reader.ReadInt32();
		materialItem3Count = reader.ReadInt32();
		materialItem4Id = reader.ReadInt32();
		materialItem4Count = reader.ReadInt32();
	}
}
