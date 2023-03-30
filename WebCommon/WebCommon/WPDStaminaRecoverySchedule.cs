namespace WebCommon;

public class WPDStaminaRecoverySchedule : WPDPacketData
{
	public int scheduleId;

	public int recoveryTime;

	public int recoveryStamina;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(scheduleId);
		writer.Write(recoveryTime);
		writer.Write(recoveryStamina);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		scheduleId = reader.ReadInt32();
		recoveryTime = reader.ReadInt32();
		recoveryStamina = reader.ReadInt32();
	}
}
