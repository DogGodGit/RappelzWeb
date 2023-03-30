namespace WebCommon;

public class WPDMount : WPDPacketData
{
	public int mountId;

	public string nameKey;

	public string acquisitionTextKey;

	public float moveSpeed;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(mountId);
		writer.Write(nameKey);
		writer.Write(acquisitionTextKey);
		writer.Write(moveSpeed);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		mountId = reader.ReadInt32();
		nameKey = reader.ReadString();
		acquisitionTextKey = reader.ReadString();
		moveSpeed = reader.ReadSingle();
	}
}
