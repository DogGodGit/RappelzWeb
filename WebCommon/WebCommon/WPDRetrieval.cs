namespace WebCommon;

public class WPDRetrieval : WPDPacketData
{
	public int retrievalId;

	public string nameKey;

	public int rewardDisplayType;

	public string goldRetrievalTextKey;

	public long goldRetrievalRequiredGold;

	public string diaRetrievalTextKey;

	public int diaRetrievalRequiredDia;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(retrievalId);
		writer.Write(nameKey);
		writer.Write(rewardDisplayType);
		writer.Write(goldRetrievalTextKey);
		writer.Write(goldRetrievalRequiredGold);
		writer.Write(diaRetrievalTextKey);
		writer.Write(diaRetrievalRequiredDia);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		retrievalId = reader.ReadInt32();
		nameKey = reader.ReadString();
		rewardDisplayType = reader.ReadInt32();
		goldRetrievalTextKey = reader.ReadString();
		goldRetrievalRequiredGold = reader.ReadInt64();
		diaRetrievalTextKey = reader.ReadString();
		diaRetrievalRequiredDia = reader.ReadInt32();
	}
}
