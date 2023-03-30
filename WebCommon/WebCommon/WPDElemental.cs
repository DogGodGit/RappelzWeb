namespace WebCommon;

public class WPDElemental : WPDPacketData
{
	public int elementalId;

	public string nameKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(elementalId);
		writer.Write(nameKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		elementalId = reader.ReadInt32();
		nameKey = reader.ReadString();
	}
}
