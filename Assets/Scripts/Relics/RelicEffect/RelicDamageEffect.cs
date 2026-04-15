using UnityEngine;

[CreateAssetMenu(fileName = "RelicDamageEffect", menuName = "Scriptable Objects/RelicDamageEffect")]
public class RelicDamageEffect : RelicEffect
{
    [Header("Base")]
    public float baseDamage;

    [Header("Scaling")]
    public ScalingSource source; // 시전자 혹은 대상
    public StatType statType;    // 공격력, 체력 등
    public float ratio;          // 계수 (0.1 = 10%)

    public override void Execute(RelicContext context)
    {
        // 1. 계산 대상 결정 (Caster 혹은 Target)
        Entity subject = (source == ScalingSource.Owner) ? context.owner : context.target;

        if (subject == null) return;

        // 2. 해당 대상의 StatController 가져오기
        var statController = subject.stat;
        if (statController == null) return;

        // 3. 선택한 타입에 따라 값 추출
        float statValue = GetStatValue(statController, statType);

        // 4. 최종 데미지 계산 및 적용
        float finalDamage = baseDamage + (statValue * ratio);

        if (context.target != null)
        {
            context.target.Damaged((int)finalDamage);
            Debug.Log($"[{relicName}] {source}의 {statType} 기반 데미지 {finalDamage} 적용");
        }
    }

    private float GetStatValue(StatController stats, StatType type)
    {
        // StatController에 구현된 메서드들을 호출
        return type switch
        {
            StatType.Attack => stats.GetAttackPower(),
            StatType.MaxHP => stats.GetMaxHP(),
            StatType.CurrentHP => stats.GetCurrentHP(), // 필요시 구현
            StatType.Shield => stats.GetCurrentShield(),    // 필요시 구현
            _ => 0
        };
    }
}