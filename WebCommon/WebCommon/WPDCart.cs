namespace WebCommon;

public class WPDCart : WPDPacketData
{
	public int cartId;

	public string nameKey;

	public string prefabName;

	public int grade;

	public float ridableRange;

	public float radius;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(cartId);
		writer.Write(nameKey);
		writer.Write(prefabName);
		writer.Write(grade);
		writer.Write(ridableRange);
		writer.Write(radius);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		cartId = reader.ReadInt32();
		nameKey = reader.ReadString();
		prefabName = reader.ReadString();
		grade = reader.ReadInt32();
		ridableRange = reader.ReadSingle();
		radius = reader.ReadSingle();
	}
}
