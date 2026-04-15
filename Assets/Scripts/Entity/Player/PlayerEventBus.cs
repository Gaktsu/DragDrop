using System;
using UnityEngine;

// Goal 
// - Player와 외부의 Event를 연결한다

public class PlayerEventBus : MonoBehaviour
{
    private static PlayerEventBus instance;
    public static PlayerEventBus Instance => instance;

    public Action<Transform> OnThrown;
    public Action<Transform> OnTeleport;
    public Action OnWeaponReturned;

    public Action<Throw> OnAddThrow;
    public Action<Skill> OnAddSkill;
    public Action<Relic> OnAddRelic;

    public Action<Skill> OnSkillSelectRequested;
    public Action<Throw> OnThrowSelectRequested;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}