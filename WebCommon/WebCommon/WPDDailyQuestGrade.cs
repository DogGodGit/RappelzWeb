namespace WebCommon;

public class WPDDailyQuestGrade : WPDPacketData
{
	public int grade;

	public int point;

	public string colorCode;

	public int immediateCompletionRequiredGold;

	public int autoCompletionRequiredTime;

	public int rewardVipPoint;

	public long itemRewardId;

	public long availableItemRewardId1;

	public long availableItemRewardId2;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(grade);
		writer.Write(point);
		writer.Write(colorCode);
		writer.Write(immediateCompletionRequiredGold);
		writer.Write(autoCompletionRequiredTime);
		writer.Write(rewardVipPoint);
		writer.Write(itemRewardId);
		writer.Write(availableItemRewardId1);
		writer.Write(availableItemRewardId2);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		grade = reader.ReadInt32();
		point = reader.ReadInt32();
		colorCode = reader.ReadString();
		immediateCompletionRequiredGold = reader.ReadInt32();
		autoCompletionRequiredTime = reader.ReadInt32();
		rewardVipPoint = reader.ReadInt32();
		itemRewardId = reader.ReadInt64();
		availableItemRewardId1 = reader.ReadInt64();
		availableItemRewardId2 = reader.ReadInt64();
	}
}
