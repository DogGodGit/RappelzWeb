namespace WebCommon;

public class WPDMainGearBaseAttr : WPDPacketData
{
	public int mainGearId;

	public int attrId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(mainGearId);
		writer.Write(attrId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		mainGearId = reader.ReadInt32();
		attrId = reader.ReadInt32();
	}
}
