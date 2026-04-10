// using UnityEngine;

// [CreateAssetMenu(fileName = "ShieldAction", menuName = "Scriptable Objects/ShieldAction")]
// public class ShieldAction : SkillAction
// {
//     public int shieldAmount;     // 생성할 보호막 양
//     public int duration;         // 지속 턴 수
//     public GameObject vfx;       // 방어 이펙트

//     public override void Execute(Player player, Skill skill)
//     {
//         StatusEffect effect = new StatusEffect(statType, duration, amount, false);

//         Player.Instance.status.AddEffect(shieldAmount, duration, vfx);
//     }
// }