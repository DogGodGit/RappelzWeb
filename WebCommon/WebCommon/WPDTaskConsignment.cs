namespace WebCommon;

public class WPDTaskConsignment : WPDPacketData
{
	public int consignmentId;

	public string nameKey;

	public string descriptionKey;

	public int requiredItemId;

	public int requiredItemCount;

	public int completionRequiredTime;

	public int immediateCompletionRequiredGold;

	public int immediateCompletionRequiredGoldReduceInterval;

	public int todayTaskId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(consignmentId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(requiredItemId);
		writer.Write(requiredItemCount);
		writer.Write(completionRequiredTime);
		writer.Write(immediateCompletionRequiredGold);
		writer.Write(immediateCompletionRequiredGoldReduceInterval);
		writer.Write(todayTaskId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		consignmentId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		requiredItemId = reader.ReadInt32();
		requiredItemCount = reader.ReadInt32();
		completionRequiredTime = reader.ReadInt32();
		immediateCompletionRequiredGold = reader.ReadInt32();
		immediateCompletionRequiredGoldReduceInterval = reader.ReadInt32();
		todayTaskId = reader.ReadInt32();
	}
}
