using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatController
{
    public Entity owner;

    public int Hp { get; private set; }
    public int MaxHp { get; private set; }
    public float BaseAttackPower { get; private set; }
    public float BaseDefensePower { get; private set; }
    public float CriticalChance { get; private set; }
    public int ShieldAmount { get; private set; }

    public void Init(Entity owner)
    {
        this.owner = owner;
    }
    public void SetHp(int value)
    {
        Hp = Mathf.Clamp(value, 0, MaxHp);
    }

    public void SetMaxHp(int value)
    {
        MaxHp = Mathf.Max(0, value);
        Hp = Mathf.Min(Hp, MaxHp);
    }

    public void SetBaseAttackPower(float value)
    {
        BaseAttackPower = Mathf.Max(0f, value);
    }

    public void SetBaseDefensePower(float value)
    {
        BaseDefensePower = Mathf.Max(0f, value);
    }

    public void AddShield(int amount)
    {
        ShieldAmount += amount;
    }

    public int AbsorbShield(int damage)
    {
        if (damage <= 0) return 0;

        int absorb = Mathf.Min(ShieldAmount, damage);
        ShieldAmount = Mathf.Clamp(ShieldAmount - absorb, 0, Int16.MaxValue);
        damage -= absorb;

        return damage;
    }

    public int GetCurrentShield()
    {
        return ShieldAmount;
    }

    public int GetCurrentHP()
    {
        return Hp;
    }
    public int GetMaxHP()
    {
        return MaxHp;
    }

    public float GetAttackPower()
    {
        float totalMod = owner.status.EffectsList
            .Where(m => m.Type == StatusEffectType.Strength)
            .Sum(m => m.Value);

        return Mathf.Max(0, BaseAttackPower + totalMod);
    }

    public float GetDefensePower()
    {
        float totalMod = owner.status.EffectsList
            .Where(m => m.Type == StatusEffectType.Defense)
            .Sum(m => m.Value);

        return Mathf.Max(0, BaseDefensePower + totalMod);
    }

    public void SetCriticalChance(float value)
    {
        CriticalChance = Mathf.Clamp(value, 0f, 1f);
    }
}