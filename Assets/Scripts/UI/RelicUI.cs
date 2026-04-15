using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class RelicUI : MonoBehaviour
{
    private Relic myRelic;
    public TextMeshProUGUI stackCountText;

    public void Setup(Relic relic)
    {
        myRelic = relic;
        // 중요: Skill의 신호를 구독합니다.
        myRelic.OnUpdateStackCount += UpdateVisual;
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        // 여기서 쿨타임 텍스트나 아이콘 어둡게 하기 등을 처리
        //cooldownText.text = mySkill.currentCooldown > 0 ? mySkill.currentCooldown.ToString() : "";
    }
}