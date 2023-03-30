namespace WebCommon;

public class WPDDimensionRaidQuestStep : WPDPacketData
{
	public int step;

	public string targetTitleKey;

	public string targetContentKey;

	public int targetNpcId;

	public string targetInteractionTextKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(step);
		writer.Write(targetTitleKey);
		writer.Write(targetContentKey);
		writer.Write(targetNpcId);
		writer.Write(targetInteractionTextKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		step = reader.ReadInt32();
		targetTitleKey = reader.ReadString();
		targetContentKey = reader.ReadString();
		targetNpcId = reader.ReadInt32();
		targetInteractionTextKey = reader.ReadString();
	}
}
