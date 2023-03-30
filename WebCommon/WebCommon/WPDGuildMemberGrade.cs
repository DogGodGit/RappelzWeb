namespace WebCommon;

public class WPDGuildMemberGrade : WPDPacketData
{
	public int memberGrade;

	public string nameKey;

	public bool invitationEnabled;

	public bool applicationAcceptanceEnabled;

	public bool guildFoodWarehouseRewardCollectionEnabled;

	public bool guildSupplySupportQuestEnabled;

	public bool guildBuildingLevelUpEnabled;

	public bool guildCallEnabled;

	public bool weeklyObjectiveSettingEnabled;

	public bool guildBlessingBuffEnabled;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(memberGrade);
		writer.Write(nameKey);
		writer.Write(invitationEnabled);
		writer.Write(applicationAcceptanceEnabled);
		writer.Write(guildFoodWarehouseRewardCollectionEnabled);
		writer.Write(guildSupplySupportQuestEnabled);
		writer.Write(guildBuildingLevelUpEnabled);
		writer.Write(guildCallEnabled);
		writer.Write(weeklyObjectiveSettingEnabled);
		writer.Write(guildBlessingBuffEnabled);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		memberGrade = reader.ReadInt32();
		nameKey = reader.ReadString();
		invitationEnabled = reader.ReadBoolean();
		applicationAcceptanceEnabled = reader.ReadBoolean();
		guildFoodWarehouseRewardCollectionEnabled = reader.ReadBoolean();
		guildSupplySupportQuestEnabled = reader.ReadBoolean();
		guildBuildingLevelUpEnabled = reader.ReadBoolean();
		guildCallEnabled = reader.ReadBoolean();
		weeklyObjectiveSettingEnabled = reader.ReadBoolean();
		guildBlessingBuffEnabled = reader.ReadBoolean();
	}
}
