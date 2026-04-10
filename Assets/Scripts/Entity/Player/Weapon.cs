using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Throw _throw;
    private ThrowContext throwContext; // dummyWeapon에서만 사용됨
    private Skill skill;

    public Transform weaponTip;
    public LayerMask enemyLayer;
    public LayerMask wallLayer;

    // 1. WeaponHit 참조
    public WeaponHit weaponHit;
    public ParticleSystem throwingParticle;

    // 1. Throw 함수 - ThrowBehavior에 위임
    public void OnThrow(ThrowContext context)
    {
        throwContext = context;
        _throw.throwBehavior.OnThrow(context);
        EffectHandler.Play(throwingParticle);
    }

    // 2. ThrowBehavior Bind 함수
    public void SetupAbility(Throw _throw, Skill skill)
    {
        this._throw = _throw;
        this.skill = skill;
    }

    // 2. Attack 함수 - WeaponHit으로 로직 위임
    public void Attack(GameObject obj, Collider2D collider)
    {
        Vector3 hitPoint = collider.ClosestPoint(weaponTip.position);
        weaponHit.Attack(obj, hitPoint);
    }

    // 2. WeaponTip의 Trigger 수신 함수 - layer와 오브젝트를 매개변수로 받음
    public void OnTipTriggerEnter(int layer, GameObject other, Collider2D collider)
    {
        if ((enemyLayer.value & (1 << layer)) != 0)
        {
            Attack(other, collider);
        }
        else if ((wallLayer.value & (1 << layer)) != 0)
        {
            OnHitWall(collider);
        }
    }

    // 3 & 4. Stop 함수 - Player를 현재 위치로 이동 후 자신 비활성화
    public void OnHitWall(Collider2D collider)
    {
        _throw.throwBehavior.OnHitWall(throwContext, collider);
    }

    public SkillData skillData => skill.data;
    public ThrowData throwData => _throw.data;
}
