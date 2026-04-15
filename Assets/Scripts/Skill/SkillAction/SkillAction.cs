using UnityEngine;

public abstract class SkillAction : ScriptableObject
{
    // 여기서 Entity는 행동의 주체, SkillInstance는 데이터 소스입니다.
    public abstract void Execute(Entity entity, Skill skill);
}