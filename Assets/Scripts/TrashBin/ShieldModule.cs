// using UnityEngine;
// public class ShieldModule : MonoBehaviour
// {
//     public void ApplyShield(int shieldAmount, int remainTurns, GameObject vfx = null)
//     {

//         // 2. 보호막 적용
//         if (shieldAmount > 0)
//         {
//             // 보호막도 턴이 지나면 사라지게 하고 싶다면? 
//             // PlayerStat에 'Shield' 타입의 Modifier를 추가하거나 별도 관리가 필요합니다.
//             PlayerStat.Instance.SetShieldAmount(PlayerStat.Instance.ShieldAmount + shieldAmount);

//             // [참고] 보호막 전용 턴 관리자를 추가할 수도 있습니다.
//             // 여기서는 단순하게 즉시 ShieldAmount를 늘려주는 방식으로 작성합니다.
//         }

//         // 3. 연출
//         if (vfx != null)
//         {
//             Instantiate(vfx, transform.position, Quaternion.identity, transform);
//         }

//         Debug.Log($"방어막 전개: 보호막+{shieldAmount} (지속: {remainTurns}턴)");
//     }
// }