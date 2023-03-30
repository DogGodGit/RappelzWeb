namespace WebCommon;

public class WPDItem : WPDPacketData
{
	public int itemId;

	public int itemType;

	public string nameKey;

	public string descriptionKey;

	public int grade;

	public int level;

	public int requiredMinHeroLevel;

	public int requiredMaxHeroLevel;

	public int usingType;

	public bool usingRecommendationEnabled;

	public bool saleable;

	public int saleGold;

	public bool autoUsable;

	public int value1;

	public int value2;

	public long longValue1;

	public long longValue2;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(itemId);
		writer.Write(itemType);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(grade);
		writer.Write(level);
		writer.Write(requiredMinHeroLevel);
		writer.Write(requiredMaxHeroLevel);
		writer.Write(usingType);
		writer.Write(usingRecommendationEnabled);
		writer.Write(saleable);
		writer.Write(saleGold);
		writer.Write(autoUsable);
		writer.Write(value1);
		writer.Write(value2);
		writer.Write(longValue1);
		writer.Write(longValue2);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		itemId = reader.ReadInt32();
		itemType = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		grade = reader.ReadInt32();
		level = reader.ReadInt32();
		requiredMinHeroLevel = reader.ReadInt32();
		requiredMaxHeroLevel = reader.ReadInt32();
		usingType = reader.ReadInt32();
		usingRecommendationEnabled = reader.ReadBoolean();
		saleable = reader.ReadBoolean();
		saleGold = reader.ReadInt32();
		autoUsable = reader.ReadBoolean();
		value1 = reader.ReadInt32();
		value2 = reader.ReadInt32();
		longValue1 = reader.ReadInt64();
		longValue2 = reader.ReadInt64();
	}
}
