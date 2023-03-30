using System;

namespace WebCommon;

public class WPDSharingEvent : WPDPacketData
{
	public int eventId;

	public int contentType;

	public string content;

	public int rewardRange;

	public int senderRewardLimitCount;

	public int targetLevel;

	public DateTimeOffset startTime;

	public DateTimeOffset endTime;

	public string imageName;

	public string descriptionKey1;

	public string descriptionKey2;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(eventId);
		writer.Write(contentType);
		writer.Write(content);
		writer.Write(rewardRange);
		writer.Write(senderRewardLimitCount);
		writer.Write(targetLevel);
		writer.Write(startTime);
		writer.Write(endTime);
		writer.Write(imageName);
		writer.Write(descriptionKey1);
		writer.Write(descriptionKey2);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		eventId = reader.ReadInt32();
		contentType = reader.ReadInt32();
		content = reader.ReadString();
		rewardRange = reader.ReadInt32();
		senderRewardLimitCount = reader.ReadInt32();
		targetLevel = reader.ReadInt32();
		startTime = reader.ReadDateTimeOffset();
		endTime = reader.ReadDateTimeOffset();
		imageName = reader.ReadString();
		descriptionKey1 = reader.ReadString();
		descriptionKey2 = reader.ReadString();
	}
}
