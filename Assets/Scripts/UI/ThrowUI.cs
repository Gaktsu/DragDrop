using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThrowUI : MonoBehaviour, IPointerClickHandler
{
    private Throw myThrow;
    public TextMeshProUGUI cooldownText;

    public Action<Throw> OnClicked;

    public void Setup(Throw _throw)
    {
        myThrow = _throw;
        // 중요: Skill의 신호를 구독합니다.
        myThrow.OnUpdateCoolDown += UpdateVisual;
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        // 여기서 쿨타임 텍스트나 아이콘 어둡게 하기 등을 처리
        cooldownText.text = myThrow.currentCooldown > 0 ? myThrow.currentCooldown.ToString() : "";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (myThrow.currentCooldown <= 0)
        {
            OnClicked?.Invoke(myThrow);
        }
    }
}