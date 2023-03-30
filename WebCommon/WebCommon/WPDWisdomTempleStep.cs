namespace WebCommon;

public class WPDWisdomTempleStep : WPDPacketData
{
	public int stepNo;

	public int type;

	public string targetTitleKey;

	public string targetContentKey;

	public string guideTitleKey;

	public string guideContentKey;

	public int startDelayTime;

	public long itemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(stepNo);
		writer.Write(type);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(guideTitleKey);
		writer.Write(guideContentKey);
		writer.Write(startDelayTime);
		writer.Write(itemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		stepNo = reader.ReadInt32();
		type = reader.ReadInt32();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		guideTitleKey = reader.ReadString();
		guideContentKey = reader.ReadString();
		startDelayTime = reader.ReadInt32();
		itemRewardId = reader.ReadInt64();
	}
}
