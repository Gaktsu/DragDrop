// using UnityEngine;

// public class EnhanceModule : MonoBehaviour
// {
//     public void ApplyBuff(StatType type, float amount, int remainTurns, GameObject vfx = null)
//     {
//         // 1. 실제 데이터 적용 (계산기에게 전달)
//         StatModifier newMod = new StatModifier(amount, type, remainTurns);
//         PlayerStat.Instance.AddModifier(newMod);

//         // 2. 연출 (VFX/SFX)
//         if (vfx != null)
//         {
//             Instantiate(vfx, transform.position, Quaternion.identity, transform);
//         }

//         Debug.Log($"{type} 버프 적용: {amount} (지속: {remainTurns}턴)");
//     }
// }