using System;
using UnityEngine;

// 현재는 CoolTime으로 했지만, 나중에는 행동력 과부하로 변경할 것
// CoolTime방식은 나중에 사용될 Thorw 쪽으로 넘길것

public class Throw
{
    public ThrowData data;
    public ThrowBehavior throwBehavior => data.throwType; // 이름, 아이콘 등 SO 참조
    public int currentCooldown; // 현재 남은 쿨타임

    public bool IsReady => currentCooldown <= 0;

    public Action OnUpdateCoolDown;

    public void Use()
    {
        currentCooldown = data.BaseCoolDown; // 사용 시 최대 쿨타임으로 초기화
    }

    public void Tick()
    {
        if (currentCooldown > 0) currentCooldown--; // 턴 경과 시 감소
    }
}