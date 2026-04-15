using System;
using System.Collections.Generic;

public class ThrowBook
{
    // 1. Dictionary 변수 (ThrowData, Throw)
    private Dictionary<ThrowData, Throw> learnedThrows = new Dictionary<ThrowData, Throw>();

    // 2. Helper 함수 - ThrowData Throw 반환
    public Throw AddThrow(ThrowData throwData)
    {
        if (learnedThrows.ContainsKey(throwData))
            return null;

        Throw newThrow = new Throw { data = throwData };
        learnedThrows.Add(throwData, newThrow);
        
        PlayerEventBus.Instance.OnAddThrow?.Invoke(newThrow);

        return newThrow;
    }

    public void UpdateAllCooldowns()
    {
        foreach (var _throw in learnedThrows.Values)
        {
            _throw.Tick();
        }
    }
}