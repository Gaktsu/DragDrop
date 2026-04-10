using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

[Serializable]
public class StatusEffect
{
    public StatusEffectType Type;
    public string EffectName; // UI 표시용
    public int RemainingTurns;
    public float Value;

    // 이 효과가 버프인지 여부 (UI 색상이나 정화 로직 등에서 활용)
    public bool IsOnHitEffect;

    public StatusEffect(StatusEffectType type, int duration, float value, bool isOnHitEffect)
    {
        Type = type;
        Value = value;
        RemainingTurns = duration;
        IsOnHitEffect = isOnHitEffect;
        EffectName = type.ToString();
    }
}

public class StatusController
{
    private List<StatusEffect> ActiveEffects = new List<StatusEffect>();
    public List<StatusEffect> EffectsList => ActiveEffects;

    // 1. 공통 추가 로직
    public void AddEffect(StatusEffect newEffect)
    {
        // 중첩 로직 (동일 타입이 있으면 턴수나 수치 증가)
        var existing = ActiveEffects.Find(e => e.Type == newEffect.Type && e.IsOnHitEffect == newEffect.IsOnHitEffect);
        if (existing != null)
        {
            existing.RemainingTurns += newEffect.RemainingTurns;
            existing.Value += newEffect.Value;
        }
        else
        {
            ActiveEffects.Add(newEffect);
        }
    }

    // 2. 턴 진행 (모든 효과 공통)
    public void ProcessTurn()
    {
        for (int i = ActiveEffects.Count - 1; i >= 0; i--)
        {
            ActiveEffects[i].RemainingTurns--;
            if (ActiveEffects[i].RemainingTurns <= 0) ActiveEffects.RemoveAt(i);
        }
    }

    // 3. 실시간 스탯 보정 (Enhance/Debuff 합산)
    public float GetTotalModifier(StatusEffectType type)
    {
        return ActiveEffects.Where(e => e.Type == type).Sum(e => e.Value);
    }

    // 4. 보호막 전용 로직 (특정 상황에서만 호출)  
    public float HandleShield(float damage)
    {
        var shields = ActiveEffects.Where(e => e.Type == StatusEffectType.Shield).ToList();
        foreach (var s in shields)
        {
            if (damage <= 0) break;
            float absorb = Mathf.Min(s.Value, damage);
            s.Value -= absorb;
            damage -= absorb;
        }
        ActiveEffects.RemoveAll(e => e.Type == StatusEffectType.Shield && e.Value <= 0);
        return damage;
    }

    // 
    public List<StatusEffect> GetDebuff(Entity target)
    {
        // 1. 내 몸에 있는 '전이용' 효과들만 추출
        return ActiveEffects.Where(e => e.IsOnHitEffect).ToList();
    }
}