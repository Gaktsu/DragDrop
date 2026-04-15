using System;
using UnityEngine;

// 현재는 CoolTime으로 했지만, 나중에는 행동력 과부하로 변경할 것
// CoolTime방식은 나중에 사용될 Thorw 쪽으로 넘길것

public class Skill
{
    public SkillData data; // 이름, 아이콘 등 SO 참조

    public Action OnUpdateActRequire;

    public void Use()
    {
        
    }
}