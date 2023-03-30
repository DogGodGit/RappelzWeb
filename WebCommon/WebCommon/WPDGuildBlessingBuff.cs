namespace WebCommon;

public class WPDGuildBlessingBuff : WPDPacketData
{
	public int buffId;

	public string nameKey;

	public string descriptionKey;

	public float expRewardFactor;

	public int duration;

	public int dia;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(buffId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(expRewardFactor);
		writer.Write(duration);
		writer.Write(dia);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		buffId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		expRewardFactor = reader.ReadSingle();
		duration = reader.ReadInt32();
		dia = reader.ReadInt32();
	}
}
