// using UnityEngine;
// using System.Collections.Generic;

// public class Afflictor : MonoBehaviour
// {
//     // --- 1. 기본 수치 디버프 (공격 적중 시 등) ---
//     public void ApplyStatDebuff(Enemy target,int duration)
//     {
//         // 적(Enemy)의 Stat 시스템에 접근하여 디버프 부여
//         // target.Stats.AddModifier(new StatModifier(-value, type, duration));
//         Debug.Log($"{target.name}에게 {type} 감소 디버프 부여!");
//     }

//     // --- 2. 피격 시 반격 디버프 (Reactive) ---
//     // 플레이어가 공격받았을 때, 나를 때린 녀석(attacker)에게 전달
//     public void ApplyCounterDebuff(Enemy attacker, StatType type, float value, int duration)
//     {
//         if (attacker == null) return;
//         ApplyStatDebuff(attacker, type, value, duration);
//         Debug.Log($"반격! {attacker.name}의 {type}을 깎았습니다.");
//     }

//     // --- 3. 특수 디버프 껍데기 (확장용) ---
//     public void ApplySpecialStatus(Enemy target, SpecialStatusType statusType, int duration)
//     {
//         switch (statusType)
//         {
//             case SpecialStatusType.Stun:
//                 // target.SetState(EnemyState.Stun, duration);
//                 break;
//             case SpecialStatusType.Burn:
//                 // target.AddDotDamage(damage, duration);
//                 break;
//             case SpecialStatusType.Freeze:
//                 // target.AnimSpeed = 0;
//                 break;
//         }
//         Debug.Log($"{target.name}에게 특수 효과 [{statusType}] 부여!");
//     }
// }