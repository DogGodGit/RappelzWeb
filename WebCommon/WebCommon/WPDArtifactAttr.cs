namespace WebCommon;

public class WPDArtifactAttr : WPDPacketData
{
	public int artifactNo;

	public int attrId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(artifactNo);
		writer.Write(attrId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		artifactNo = reader.ReadInt32();
		attrId = reader.ReadInt32();
	}
}
