namespace WebCommon;

public class WPDWorldLevelExpFactor : WPDPacketData
{
	public int levelGap;

	public float expFactor;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(levelGap);
		writer.Write(expFactor);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		levelGap = reader.ReadInt32();
		expFactor = reader.ReadSingle();
	}
}
