namespace WebCommon;

public class WPDProofOfValorBuffBox : WPDPacketData
{
	public int buffBoxId;

	public string prefabName;

	public float offenseFactor;

	public float physicalDefenseFactor;

	public float hpRecoveryFactor;

	public string useGuideTitleKey;

	public string useGuideContentKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(buffBoxId);
		writer.Write(prefabName);
		writer.Write(offenseFactor);
		writer.Write(physicalDefenseFactor);
		writer.Write(hpRecoveryFactor);
		writer.Write(useGuideTitleKey);
		writer.Write(useGuideContentKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		buffBoxId = reader.ReadInt32();
		prefabName = reader.ReadString();
		offenseFactor = reader.ReadSingle();
		physicalDefenseFactor = reader.ReadSingle();
		hpRecoveryFactor = reader.ReadSingle();
		useGuideTitleKey = reader.ReadString();
		useGuideContentKey = reader.ReadString();
	}
}
