namespace WebCommon;

public class WPDInfiniteWarBuffBox : WPDPacketData
{
	public int buffBoxId;

	public string prefabName;

	public float offenseFactor;

	public float defenseFactor;

	public float hpRecoveryFactor;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(buffBoxId);
		writer.Write(prefabName);
		writer.Write(offenseFactor);
		writer.Write(defenseFactor);
		writer.Write(hpRecoveryFactor);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		buffBoxId = reader.ReadInt32();
		prefabName = reader.ReadString();
		offenseFactor = reader.ReadSingle();
		defenseFactor = reader.ReadSingle();
		hpRecoveryFactor = reader.ReadSingle();
	}
}
