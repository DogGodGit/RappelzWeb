namespace WebCommon;

public class WPDMonster : WPDPacketData
{
	public int monsterId;

	public int monsterCharacterId;

	public string nameKey;

	public int level;

	public float scale;

	public int height;

	public float radius;

	public int moveSpeed;

	public int battleMoveSpeed;

	public float visibilityRange;

	public float patrolRange;

	public float activeAreaRadius;

	public float returnCompletionRadius;

	public float skillCastingInterval;

	public int maxHp;

	public int physicalOffense;

	public float questAreaRadius;

	public bool moveEnabled;

	public bool attackEnabled;

	public float attackStopRange;

	public bool tamingEnabled;

	public int mentalStrength;

	public float stealRadius;

	public int stealSuccessRate;

	public long stealItemRewardId;

	public override void Serialize(WPacketWriter writer)
	{
		base.Serialize(writer);
		writer.Write(monsterId);
		writer.Write(monsterCharacterId);
		writer.Write(nameKey);
		writer.Write(level);
		writer.Write(scale);
		writer.Write(height);
		writer.Write(radius);
		writer.Write(moveSpeed);
		writer.Write(battleMoveSpeed);
		writer.Write(visibilityRange);
		writer.Write(patrolRange);
		writer.Write(activeAreaRadius);
		writer.Write(returnCompletionRadius);
		writer.Write(skillCastingInterval);
		writer.Write(maxHp);
		writer.Write(physicalOffense);
		writer.Write(questAreaRadius);
		writer.Write(moveEnabled);
		writer.Write(attackEnabled);
		writer.Write(attackStopRange);
		writer.Write(tamingEnabled);
		writer.Write(mentalStrength);
		writer.Write(stealRadius);
		writer.Write(stealSuccessRate);
		writer.Write(stealItemRewardId);
	}

	public override void Deserialize(WPacketReader reader)
	{
		base.Deserialize(reader);
		monsterId = reader.ReadInt32();
		monsterCharacterId = reader.ReadInt32();
		nameKey = reader.ReadString();
		level = reader.ReadInt32();
		scale = reader.ReadSingle();
		height = reader.ReadInt32();
		radius = reader.ReadSingle();
		moveSpeed = reader.ReadInt32();
		battleMoveSpeed = reader.ReadInt32();
		visibilityRange = reader.ReadSingle();
		patrolRange = reader.ReadSingle();
		activeAreaRadius = reader.ReadSingle();
		returnCompletionRadius = reader.ReadSingle();
		skillCastingInterval = reader.ReadSingle();
		maxHp = reader.ReadInt32();
		physicalOffense = reader.ReadInt32();
		questAreaRadius = reader.ReadSingle();
		moveEnabled = reader.ReadBoolean();
		attackEnabled = reader.ReadBoolean();
		attackStopRange = reader.ReadSingle();
		tamingEnabled = reader.ReadBoolean();
		mentalStrength = reader.ReadInt32();
		stealRadius = reader.ReadSingle();
		stealSuccessRate = reader.ReadInt32();
		stealItemRewardId = reader.ReadInt64();
	}
}
