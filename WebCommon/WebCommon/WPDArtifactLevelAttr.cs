namespace WebCommon;

public class WPDArtifactLevelAttr : WPDPacketData
{
	public int artifactNo;

	public int level;

	public int attrId;

	public long attrValueId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(artifactNo);
		writer.Write(level);
		writer.Write(attrId);
		writer.Write(attrValueId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		artifactNo = reader.ReadInt32();
		level = reader.ReadInt32();
		attrId = reader.ReadInt32();
		attrValueId = reader.ReadInt64();
	}
}
