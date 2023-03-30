using System;
using System.IO;

namespace WebCommon;

public class WPDClientTexts : WPDPacketData
{
	public int languageId;

	public WPDClientText[] clientTexts;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(languageId);
		writer.Write(clientTexts);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		languageId = reader.ReadInt32();
		clientTexts = reader.ReadPDPacketDatas<WPDClientText>();
	}

	public string SerializeBase64String()
	{
		byte[] result;
		using (MemoryStream stream = new MemoryStream())
		{
			WPacketWriter writer = new WPacketWriter(stream);
			Serialize(writer);
			result = stream.ToArray();
		}
		return Convert.ToBase64String(result);
	}

	public void DeserializeFromBase64String(string sData)
	{
		byte[] data = Convert.FromBase64String(sData);
		using MemoryStream stream = new MemoryStream(data);
		WPacketReader reader = new WPacketReader(stream);
		Deserialize(reader);
	}
}
