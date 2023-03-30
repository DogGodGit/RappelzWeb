namespace WebCommon;

public class WPDMoneyBuff : WPDPacketData
{
	public int buffId;

	public string nameKey;

	public string descriptionKey;

	public int lifetime;

	public int moneyType;

	public int moneyAmount;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(buffId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(lifetime);
		writer.Write(moneyType);
		writer.Write(moneyAmount);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		buffId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		lifetime = reader.ReadInt32();
		moneyType = reader.ReadInt32();
		moneyAmount = reader.ReadInt32();
	}
}
