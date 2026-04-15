using UnityEngine;

public class ThrowContext
{
    public GameObject owner; // 원본(하이어라키에 있는 Weapon)
    public Weapon instance; // 프리팁
    public Rigidbody2D rb;
    public Vector2 direction;
    public int bounceCount = 0; // 아직은 사용하지 않음
    public float speed;
}

public abstract class ThrowBehavior : ScriptableObject
{
    public abstract void OnThrow(ThrowContext context);
    public virtual void OnHitWall(ThrowContext context, Collider2D collider)
    {
        context.owner.transform.position = context.instance.weaponTip.position;
        PlayerEventBus.Instance.OnTeleport?.Invoke(context.owner.transform);

        Destroy(context.instance.gameObject);

        if (context.bounceCount == 0)
            PlayerEventBus.Instance.OnWeaponReturned?.Invoke();
    }
}