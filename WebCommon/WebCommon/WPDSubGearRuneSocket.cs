namespace WebCommon;

public class WPDSubGearRuneSocket : WPDPacketData
{
	public int subGearId;

	public int socketIndex;

	public int requiredSubGearLevel;

	public string enableTextKey;

	public string backgroundImageName;

	public string miniBackgroundImageName;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(subGearId);
		writer.Write(socketIndex);
		writer.Write(requiredSubGearLevel);
		writer.Write(enableTextKey);
		writer.Write(backgroundImageName);
		writer.Write(miniBackgroundImageName);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		subGearId = reader.ReadInt32();
		socketIndex = reader.ReadInt32();
		requiredSubGearLevel = reader.ReadInt32();
		enableTextKey = reader.ReadString();
		backgroundImageName = reader.ReadString();
		miniBackgroundImageName = reader.ReadString();
	}
}
