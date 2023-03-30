namespace WebCommon;

public class WPDArtifactLevel : WPDPacketData
{
	public int artifactNo;

	public int level;

	public int nextLevelUpRequiredExp;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(artifactNo);
		writer.Write(level);
		writer.Write(nextLevelUpRequiredExp);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		artifactNo = reader.ReadInt32();
		level = reader.ReadInt32();
		nextLevelUpRequiredExp = reader.ReadInt32();
	}
}
