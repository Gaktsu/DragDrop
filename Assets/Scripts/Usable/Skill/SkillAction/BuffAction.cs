using UnityEngine;

[CreateAssetMenu(fileName = "BuffAction", menuName = "Scriptable Objects/BuffAction")]
public class BuffAction : SkillAction
{
    public StatusEffectType statType;      // 어떤 스탯을?
    public float amount;           // 얼마나?
    public int duration;           // 몇 턴 동안?
    public GameObject vfx;   // 실행 시 재생할 이펙트

    public override void Execute(Entity entity, Skill skill)
    {
        StatusEffect effect = new StatusEffect(statType, duration, amount, false);

        entity.status.AddEffect(effect);
    }
}