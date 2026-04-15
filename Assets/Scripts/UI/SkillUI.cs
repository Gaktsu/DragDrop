using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillUI : MonoBehaviour, IPointerClickHandler
{
    private Skill mySkill;
    public TextMeshProUGUI acrRequireText;

    public Action<Skill> OnClicked;

    public void Setup(Skill skill)
    {
        mySkill = skill;
        // 중요: Skill의 신호를 구독합니다.
        mySkill.OnUpdateActRequire += UpdateVisual;
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        // 여기서 쿨타임 텍스트나 아이콘 어둡게 하기 등을 처리
        //cooldownText.text = mySkill.currentCooldown > 0 ? mySkill.currentCooldown.ToString() : "";
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //if (mySkill.currentCooldown <= 0)
        //{
            OnClicked?.Invoke(mySkill);
        //}
    }
}