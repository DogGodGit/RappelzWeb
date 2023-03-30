namespace WebCommon;

public class WPDAncientRelicStep : WPDPacketData
{
	public int step;

	public int type;

	public string targetTitleKey;

	public string targetContentKey;

	public int targetPoint;

	public string guideImageName;

	public string guideTitleKey;

	public string guideContentKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(step);
		writer.Write(type);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(targetPoint);
		writer.Write(guideImageName);
		writer.Write(guideTitleKey);
		writer.Write(guideContentKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		step = reader.ReadInt32();
		type = reader.ReadInt32();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		targetPoint = reader.ReadInt32();
		guideImageName = reader.ReadString();
		guideTitleKey = reader.ReadString();
		guideContentKey = reader.ReadString();
	}
}
