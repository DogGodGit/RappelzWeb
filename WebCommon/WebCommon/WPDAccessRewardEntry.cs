namespace WebCommon;

public class WPDAccessRewardEntry : WPDPacketData
{
	public int entryId;

	public int accessTime;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(entryId);
		writer.Write(accessTime);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		entryId = reader.ReadInt32();
		accessTime = reader.ReadInt32();
	}
}
