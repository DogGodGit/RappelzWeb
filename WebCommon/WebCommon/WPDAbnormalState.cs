namespace WebCommon;

public class WPDAbnormalState : WPDPacketData
{
	public int abnormalStateId;

	public string nameKey;

	public string descriptionKey;

	public bool isOverlap;

	public int type;

	public int sourceType;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(abnormalStateId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(isOverlap);
		writer.Write(type);
		writer.Write(sourceType);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		abnormalStateId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		isOverlap = reader.ReadBoolean();
		type = reader.ReadInt32();
		sourceType = reader.ReadInt32();
	}
}
