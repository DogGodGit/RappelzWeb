namespace WebCommon;

public class WPDPresent : WPDPacketData
{
	public int presentId;

	public string nameKey;

	public string descriptionKey;

	public int requiredVipLevel;

	public string imageName;

	public int displayCount;

	public int requiredDia;

	public int popularityPoint;

	public int contributionPoint;

	public bool isMessageSend;

	public string messageTextKey;

	public bool isEffectDisplay;

	public string effectPrefabName;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(presentId);
		writer.Write(nameKey);
		writer.Write(descriptionKey);
		writer.Write(requiredVipLevel);
		writer.Write(imageName);
		writer.Write(displayCount);
		writer.Write(requiredDia);
		writer.Write(popularityPoint);
		writer.Write(contributionPoint);
		writer.Write(isMessageSend);
		writer.Write(messageTextKey);
		writer.Write(isEffectDisplay);
		writer.Write(effectPrefabName);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		presentId = reader.ReadInt32();
		nameKey = reader.ReadString();
		descriptionKey = reader.ReadString();
		requiredVipLevel = reader.ReadInt32();
		imageName = reader.ReadString();
		displayCount = reader.ReadInt32();
		requiredDia = reader.ReadInt32();
		popularityPoint = reader.ReadInt32();
		contributionPoint = reader.ReadInt32();
		isMessageSend = reader.ReadBoolean();
		messageTextKey = reader.ReadString();
		isEffectDisplay = reader.ReadBoolean();
		effectPrefabName = reader.ReadString();
	}
}
