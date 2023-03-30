namespace WebCommon;

public class WPDScheduleNotice : WPDPacketData
{
	public int noticeId;

	public int beforeStartNoticeTime;

	public string beforeStartNoticeKey;

	public string startNoticeKey;

	public string endNoticeKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(noticeId);
		writer.Write(beforeStartNoticeTime);
		writer.Write(beforeStartNoticeKey);
		writer.Write(startNoticeKey);
		writer.Write(endNoticeKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		noticeId = reader.ReadInt32();
		beforeStartNoticeTime = reader.ReadInt32();
		beforeStartNoticeKey = reader.ReadString();
		startNoticeKey = reader.ReadString();
		endNoticeKey = reader.ReadString();
	}
}
