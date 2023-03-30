namespace WebCommon;

public class WPDWisdomTempleQuizPoolEntry : WPDPacketData
{
	public int stepNo;

	public int quizNo;

	public string questionKey;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(stepNo);
		writer.Write(quizNo);
		writer.Write(questionKey);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		stepNo = reader.ReadInt32();
		quizNo = reader.ReadInt32();
		questionKey = reader.ReadString();
	}
}
