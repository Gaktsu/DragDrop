using UnityEngine;

[CreateAssetMenu(fileName = "RelicOnAttack", menuName = "Scriptable Objects/RelicOnAttack")]
public class RelicOnAttack : RelicTrigger
{
    [Range(0f, 1f)]
    [Tooltip("발동 확률 (1.0이면 100%)")]
    public float triggerChance = 1.0f;

    public override bool CheckCondition(RelicContext context)
    {
        // 1. 현재 일어난 사건이 '공격'인지 확인
        if (context.actionType != RelicActionType.Attack)
            return false;

        // 2. 확률 체크 (Random.value는 0.0~1.0 사이의 값을 반환)
        if (Random.value > triggerChance)
            return false;

        // 모든 조건 만족 시 true 반환
        return true;
    }
}