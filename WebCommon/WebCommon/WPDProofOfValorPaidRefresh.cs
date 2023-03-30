namespace WebCommon;

public class WPDProofOfValorPaidRefresh : WPDPacketData
{
	public int refreshCount;

	public int requiredDia;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(refreshCount);
		writer.Write(requiredDia);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		refreshCount = reader.ReadInt32();
		requiredDia = reader.ReadInt32();
	}
}
