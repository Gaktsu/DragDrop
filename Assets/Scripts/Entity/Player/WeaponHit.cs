using UnityEngine;
using System.Collections.Generic;

public class WeaponHit : MonoBehaviour
{
    // 1. 피격 UX
    public HitImpact hitImpact;

    // 3. Attack 함수 - IDamageable에 데미지 적용
    public void Attack(GameObject obj, Vector3 hitPoint)
    {
        if (obj.TryGetComponent<Entity>(out var target))
        {
            Player player = Player.Instance;

            float damageValue = player.stat.GetAttackPower();
            hitImpact.ActiveHitImpact(hitPoint);
            int damageValueToInt = Mathf.RoundToInt(damageValue);
            ApplyDebuff(target, Player.Instance.status.GetDebuff(target));
            target.Damaged(damageValueToInt);

            RelicContext context = new RelicContext(player, target, RelicActionType.Attack, damageValue, StatusEffectType.None);
            ActionLibrary.Instance.relicBook.NotifyRelics(context);
        }
    }

    private void ApplyDebuff(Entity target, List<StatusEffect> debuff)
    {
        foreach (var effect in debuff)
        {
            // 2. 적에게 부여할 때는 IsOnHitEffect를 false로 설정하여 즉시 적용되게 함
            StatusEffect effectToGive = new StatusEffect(
                effect.Type,
                effect.RemainingTurns,
                effect.Value,
                false // 적은 이걸 남에게 주는 게 아니라 본인이 걸리는 것이므로 false
            );

            target.status.AddEffect(effectToGive);
        }
    }
}