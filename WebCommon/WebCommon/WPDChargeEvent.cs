using System;

namespace WebCommon;

public class WPDChargeEvent : WPDPacketData
{
	public int eventId;

	public string nameKey;

	public string descriptionKey;

	public DateTime startTime;

	public DateTime endTime;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(eventId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(startTime);
		writer.Write(endTime);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		eventId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		startTime = reader.ReadDateTime();
		endTime = reader.ReadDateTime();
	}
}
