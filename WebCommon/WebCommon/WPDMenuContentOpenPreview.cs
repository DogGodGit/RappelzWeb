namespace WebCommon;

public class WPDMenuContentOpenPreview : WPDPacketData
{
	public int previewNo;

	public int contentId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(previewNo);
		writer.Write(contentId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		previewNo = reader.ReadInt32();
		contentId = reader.ReadInt32();
	}
}
