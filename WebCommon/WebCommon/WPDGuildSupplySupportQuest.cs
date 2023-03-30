namespace WebCommon;

public class WPDGuildSupplySupportQuest : WPDPacketData
{
	public string nameKey;

	public string descriptionKey;

	public int limitTime;

	public int startNpcId;

	public int cartId;

	public int completionNpcId;

	public string startDialogueKey;

	public string completionDialogueKey;

	public long guildBuildingPointRewardId;

	public long guildFundRewardId;

	public float completionRewardableRadius;

	public long completionGuildContributionPointRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(limitTime);
		writer.Write(startNpcId);
		writer.Write(cartId);
		writer.Write(completionNpcId);
		writer.Write(startDialogueKey);
		writer.Write(completionDialogueKey);
		writer.Write(guildBuildingPointRewardId);
		writer.Write(guildFundRewardId);
		writer.Write(completionRewardableRadius);
		writer.Write(completionGuildContributionPointRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		limitTime = reader.ReadInt32();
		startNpcId = reader.ReadInt32();
		cartId = reader.ReadInt32();
		completionNpcId = reader.ReadInt32();
		startDialogueKey = reader.ReadString();
		completionDialogueKey = reader.ReadString();
		guildBuildingPointRewardId = reader.ReadInt64();
		guildFundRewardId = reader.ReadInt64();
		completionRewardableRadius = reader.ReadSingle();
		completionGuildContributionPointRewardId = reader.ReadInt64();
	}
}
