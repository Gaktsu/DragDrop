using System.Collections.Generic;
using UnityEngine;

public class RelicBook
{
    // 현재 플레이어가 보유 중인 유물 리스트
    private Dictionary<RelicData, Relic> relics = new Dictionary<RelicData, Relic>();

    // 새로운 유물을 획득했을 때 호출
    public Relic AddRelic(RelicData relicData)
    {
        if (relics.ContainsKey(relicData))
            return null;

        Relic newRelic = new Relic(relicData);
        relics.Add(relicData, newRelic);

        PlayerEventBus.Instance.OnAddRelic?.Invoke(newRelic);

        return newRelic;
    }

    // 외부(CombatSystem 등)에서 사건이 발생하면 호출하는 핵심 함수
    public void NotifyRelics(RelicContext context)
    {
        if (relics.Count == 0) return;

        // 가지고 있는 모든 유물을 순회하며 조건 체크
        foreach (var relic in relics.Values)
        {
            // 유물 데이터에게 "이 상황(context)에 네가 할 일 있니?"라고 물어봄
            relic.HandleEvent(context);
        }
    }
}