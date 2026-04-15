using UnityEngine;

public abstract class RelicTrigger : ScriptableObject
{
    // 각 조건에 필요한 데이터 (확률 등)
    public float chance = 1.0f;
    
    // 조건이 맞는지 체크하는 로직
    public abstract bool CheckCondition(RelicContext context);
}
