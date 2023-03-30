namespace WebCommon;

public class WPDProofOfValorClearGrade : WPDPacketData
{
	public int clearGrade;

	public int minRemainTime;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(clearGrade);
		writer.Write(minRemainTime);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		clearGrade = reader.ReadInt32();
		minRemainTime = reader.ReadInt32();
	}
}
