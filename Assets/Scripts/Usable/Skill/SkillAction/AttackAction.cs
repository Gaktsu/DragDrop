using UnityEngine;

[CreateAssetMenu(fileName = "AttackAction", menuName = "Scriptable Objects/AttackAction")]
public class AttackAction : SkillAction
{
    public override void Execute(Entity entity, Skill skill)
    {
        if (entity is not Player player) return;

        Vector2 direction = ((Vector2)(player.worldPosition - player.transform.position)).normalized;
        Transform target = player.weaponFactory.OnThrow(direction);
        if (target == null) return;

        PlayerEventBus.Instance.OnThrown?.Invoke(target);
    }
}