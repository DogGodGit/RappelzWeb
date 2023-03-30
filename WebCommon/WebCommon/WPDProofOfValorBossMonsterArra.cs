namespace WebCommon;

public class WPDProofOfValorBossMonsterArrange : WPDPacketData
{
	public int proofOfValorBossMonsterArrangeId;

	public bool isSpecial;

	public int starGrade;

	public long monsterArrangeId;

	public string descriptionKey;

	public int rewardSoulPowder;

	public int specialRewardSoulPowder;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(proofOfValorBossMonsterArrangeId);
		writer.Write(isSpecial);
		writer.Write(starGrade);
		writer.Write(monsterArrangeId);
		writer.Write(descriptionKey);
		writer.Write(rewardSoulPowder);
		writer.Write(specialRewardSoulPowder);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		proofOfValorBossMonsterArrangeId = reader.ReadInt32();
		isSpecial = reader.ReadBoolean();
		starGrade = reader.ReadInt32();
		monsterArrangeId = reader.ReadInt64();
		descriptionKey = reader.ReadString();
		rewardSoulPowder = reader.ReadInt32();
		specialRewardSoulPowder = reader.ReadInt32();
	}
}
