public enum DebuffTriggerType
{
    OnAttack, // 공격 시 공격받은 적에게 디버프 부여
    OnDefend // 피격 시 공격한 적에게 디버프 부여
}

public enum StatusEffectType
{
    // Buffs
    Haste, Strength, Regeneration, Defense, Shield,
    // Debuffs
    Burn, Slow, Stun, Weakness,

    None
}

public enum ProductType
{
    Skill,
    Throw,
    Relic,
    Item,
}

public enum RelicActionType
{
    None,
    Attack,     // 공격 (데미지)
    Shield,     // 방어막 부여/획득
    Buff,       // 이로운 효과 부여
    Debuff,     // 해로운 효과 부여
    Heal        // 체력 회복
}

public enum ScalingSource { Owner, Target } // 누구를 기준으로?
public enum StatType { Attack, MaxHP, CurrentHP, Shield } // 어떤 능력치를?