namespace WebCommon;

public class WPDTradeShipStep : WPDPacketData
{
	public int stepNo;

	public int targetMonsterKillCount;

	public string targetTitleKey;

	public string targetContentKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(stepNo);
		writer.Write(targetMonsterKillCount);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		stepNo = reader.ReadInt32();
		targetMonsterKillCount = reader.ReadInt32();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
	}
}
