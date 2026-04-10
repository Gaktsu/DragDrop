using UnityEngine;

public class WeaponFactory : MonoBehaviour
{
    private Throw _throw;
    private Skill skill;
    private GameObject owner;
    public float speed = 1f;

    public GameObject weaponPrefab;
    private Weapon dummyWeapon;

    public Transform launchPoint;

    public bool CanThrow { get; private set; } = true;

    public void Init(GameObject owner)
    {
        this.owner = owner;
        PlayerEventBus.Instance.OnWeaponReturned += () => CanThrow = true;
    }

    // 1. Throw 함수 - ThrowBehavior에 위임
    public Transform OnThrow(Vector2 direction)
    {
        if (!CanThrow) return null;

        if (skill == null || _throw == null)
        {
            Debug.Log($"Skill이나 Throw가 선택되지 않았습니다");
            return null;
        }

        dummyWeapon = Instantiate(weaponPrefab, launchPoint.position, launchPoint.rotation).GetComponent<Weapon>();
        Rigidbody2D dummyRb = dummyWeapon.GetComponent<Rigidbody2D>();
        
        ThrowContext context = new ThrowContext
        {
            owner = owner,
            instance = dummyWeapon,
            rb = dummyRb,
            direction = direction,
            speed = speed
        };

        dummyWeapon.SetupAbility(_throw, skill);
        dummyWeapon.OnThrow(context);

        CanThrow = false;
        
        return dummyWeapon.transform;
    }

    public void SetThrow(Throw _throw)
    {
        this._throw = _throw;
    }

    public void SetSkill(Skill skill)
    {
        this.skill = skill;
    }
}
