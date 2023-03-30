namespace WebCommon;

public class WPDWingMemoryPieceType : WPDPacketData
{
	public int type;

	public string descriptionKey;

	public int requiredItemId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(type);
		writer.Write(descriptionKey);
		writer.Write(requiredItemId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		type = reader.ReadInt32();
		descriptionKey = reader.ReadString();
		requiredItemId = reader.ReadInt32();
	}
}
