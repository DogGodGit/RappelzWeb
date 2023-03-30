namespace WebCommon;

public class WPDIllustratedBookExplorationStep : WPDPacketData
{
	public int stepNo;

	public string nameKey;

	public string descriptionKey;

	public int activationExplorationPoint;

	public long goldRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(stepNo);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(activationExplorationPoint);
		writer.Write(goldRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		stepNo = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		activationExplorationPoint = reader.ReadInt32();
		goldRewardId = reader.ReadInt64();
	}
}
public class WPDIllustratedBookExplorationStepReward : WPDPacketData
{
	public int stepNo;

	public int rewardNo;

	public long itemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(stepNo);
		writer.Write(rewardNo);
		writer.Write(itemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		stepNo = reader.ReadInt32();
		rewardNo = reader.ReadInt32();
		itemRewardId = reader.ReadInt64();
	}
}
public class WPDIllustratedBookExplorationStepAttr : WPDPacketData
{
	public int stepNo;

	public int attrId;

	public long attrValueId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(stepNo);
		writer.Write(attrId);
		writer.Write(attrValueId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		stepNo = reader.ReadInt32();
		attrId = reader.ReadInt32();
		attrValueId = reader.ReadInt64();
	}
}
