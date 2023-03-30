namespace WebCommon;

public class WPDSecretLetterGrade : WPDPacketData
{
	public int grade;

	public long exploitPointRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(grade);
		writer.Write(exploitPointRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		grade = reader.ReadInt32();
		exploitPointRewardId = reader.ReadInt64();
	}
}
