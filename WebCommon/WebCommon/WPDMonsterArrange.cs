namespace WebCommon;

public class WPDMonsterArrange : WPDPacketData
{
	public long monsterArrangeId;

	public int monsterId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(monsterArrangeId);
		writer.Write(monsterId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		monsterArrangeId = reader.ReadInt64();
		monsterId = reader.ReadInt32();
	}
}
