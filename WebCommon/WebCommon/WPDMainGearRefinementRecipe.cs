namespace WebCommon;

public class WPDMainGearRefinementRecipe : WPDPacketData
{
	public int protectionCount;

	public int protectionItemId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(protectionCount);
		writer.Write(protectionItemId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		protectionCount = reader.ReadInt32();
		protectionItemId = reader.ReadInt32();
	}
}
