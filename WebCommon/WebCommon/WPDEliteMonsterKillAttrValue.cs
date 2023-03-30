namespace WebCommon;

public class WPDEliteMonsterKillAttrValue : WPDPacketData
{
	public int eliteMonsterId;

	public int killCount;

	public long attrValueId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(eliteMonsterId);
		writer.Write(killCount);
		writer.Write(attrValueId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		eliteMonsterId = reader.ReadInt32();
		killCount = reader.ReadInt32();
		attrValueId = reader.ReadInt64();
	}
}
