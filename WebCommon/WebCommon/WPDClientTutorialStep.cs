namespace WebCommon;

public class WPDClientTutorialStep : WPDPacketData
{
	public int tutorialId;

	public int step;

	public string textKey;

	public float textXPosition;

	public float textYPosition;

	public float arrowXPosition;

	public float arrowYPosition;

	public float arrowYRotation;

	public float clickXPosition;

	public float clickYPosition;

	public int clickWidth;

	public int clickHeight;

	public string effectName;

	public float effectXPosition;

	public float effectYPosition;

	public int effectWidth;

	public int effectHeight;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(tutorialId);
		writer.Write(step);
		writer.Write(textKey);
		writer.Write(textXPosition);
		writer.Write(textYPosition);
		writer.Write(arrowXPosition);
		writer.Write(arrowYPosition);
		writer.Write(arrowYRotation);
		writer.Write(clickXPosition);
		writer.Write(clickYPosition);
		writer.Write(clickWidth);
		writer.Write(clickHeight);
		writer.Write(effectName);
		writer.Write(effectXPosition);
		writer.Write(effectYPosition);
		writer.Write(effectWidth);
		writer.Write(effectHeight);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		tutorialId = reader.ReadInt32();
		step = reader.ReadInt32();
		textKey = reader.ReadString();
		textXPosition = reader.ReadSingle();
		textYPosition = reader.ReadSingle();
		arrowXPosition = reader.ReadSingle();
		arrowYPosition = reader.ReadSingle();
		arrowYRotation = reader.ReadSingle();
		clickXPosition = reader.ReadSingle();
		clickYPosition = reader.ReadSingle();
		clickWidth = reader.ReadInt32();
		clickHeight = reader.ReadInt32();
		effectName = reader.ReadString();
		effectXPosition = reader.ReadSingle();
		effectYPosition = reader.ReadSingle();
		effectWidth = reader.ReadInt32();
		effectHeight = reader.ReadInt32();
	}
}
