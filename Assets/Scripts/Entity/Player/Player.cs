using UnityEngine;

public class Player : Entity
{
    public static Player Instance {get;private set;}
    public Vector3 worldPosition {get; private set;}
    public Transform hand;
    public WeaponFactory weaponFactory { get; private set; }
    private Skill selectedSkill;

    protected override void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        weaponFactory = GetComponentInChildren<WeaponFactory>();

        base.Awake();
    }
    void Start()
    {
        weaponFactory.Init(gameObject);

        PlayerEventBus.Instance.OnSkillSelectRequested += SkillSelect;
        PlayerEventBus.Instance.OnThrowSelectRequested += ThrowSelect;
    }

    public void SetWorldPosition(Vector3 position)
    {
        worldPosition = position;
    }

    public void ExecuteSkill()
    {
        if (selectedSkill == null) return;
        
        selectedSkill.data.SkillAction.Execute(this, selectedSkill);
    }

    private void SkillSelect(Skill skill)
    {
        selectedSkill = skill;
        weaponFactory.SetSkill(skill);
    }

    private void ThrowSelect(Throw _throw)
    {
        weaponFactory.SetThrow(_throw);
    }
}
