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
    [SerializeField] private float launchAngleOffset = -90f;

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

        if (launchPoint == null || weaponPrefab == null)
        {
            Debug.LogWarning("launchPoint 또는 weaponPrefab이 설정되지 않았습니다.");
            return null;
        }

        Quaternion spawnRotation = launchPoint.rotation * Quaternion.Euler(0f, 0f, launchAngleOffset);
        dummyWeapon = Instantiate(weaponPrefab, launchPoint.position, spawnRotation).GetComponent<Weapon>();
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
