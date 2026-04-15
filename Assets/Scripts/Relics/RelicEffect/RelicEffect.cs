using UnityEngine;
public abstract class RelicEffect : ScriptableObject
{
    public string relicName;
    public float value;

    // 실제 효과를 실행하는 로직
    public abstract void Execute(RelicContext context);
}