namespace WebCommon;

public class WPDNationWarRevivalPointActivationCondition : WPDPacketData
{
	public int revivalPointId;

	public int arrangeId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(revivalPointId);
		writer.Write(arrangeId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		revivalPointId = reader.ReadInt32();
		arrangeId = reader.ReadInt32();
	}
}
