using UnityEngine;

[CreateAssetMenu(fileName = "RelicData", menuName = "Scriptable Objects/RelicData")]
public class RelicData : ScriptableObject
{
    public string relicName;
    public string description;
    public Sprite icon;

    // 전략 부품을 하나씩만 가짐 (1 Trigger, 1 Effect)
    public RelicTrigger trigger;
    public RelicEffect effect;

    // public void OnEventOccurred(RelicContext context)
    // {
    //     if (trigger.CheckCondition(context))
    //     {
    //         effect.Execute(context);
    //     }
    // }
}