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
    Burn, Slow, Stun, Weakness
}

public enum ProductType
{
    Skill,
    Throw,
    Relic,
    Item,
}