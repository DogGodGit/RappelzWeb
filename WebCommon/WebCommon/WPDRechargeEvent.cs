namespace WebCommon;

public class WPDRechargeEvent : WPDPacketData
{
	public string nameKey;

	public string descriptionKey;

	public int requiredUnOwnDia;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(requiredUnOwnDia);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		requiredUnOwnDia = reader.ReadInt32();
	}
}
