namespace WebCommon;

public class WPDConstellation : WPDPacketData
{
	public int constellationId;

	public string nameKey;

	public int requiredConditionType;

	public int requiredConditionValue;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(constellationId);
		writer.Write(nameKey);
		writer.Write(requiredConditionType);
		writer.Write(requiredConditionValue);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		constellationId = reader.ReadInt32();
		nameKey = reader.ReadString();
		requiredConditionType = reader.ReadInt32();
		requiredConditionValue = reader.ReadInt32();
	}
}
