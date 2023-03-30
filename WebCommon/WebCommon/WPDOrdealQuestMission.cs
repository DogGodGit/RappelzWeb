namespace WebCommon;

public class WPDOrdealQuestMission : WPDPacketData
{
	public int questNo;

	public int slotIndex;

	public int missionNo;

	public string nameKey;

	public int type;

	public int targetCount;

	public int autoCompletionRequiredTime;

	public int availableRewardItemId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(questNo);
		writer.Write(slotIndex);
		writer.Write(missionNo);
		writer.Write(nameKey);
		writer.Write(type);
		writer.Write(targetCount);
		writer.Write(autoCompletionRequiredTime);
		writer.Write(availableRewardItemId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		questNo = reader.ReadInt32();
		slotIndex = reader.ReadInt32();
		missionNo = reader.ReadInt32();
		nameKey = reader.ReadString();
		type = reader.ReadInt32();
		targetCount = reader.ReadInt32();
		autoCompletionRequiredTime = reader.ReadInt32();
		availableRewardItemId = reader.ReadInt32();
	}
}
