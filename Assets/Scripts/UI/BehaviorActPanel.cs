using UnityEngine;

// 정리
// SkillPanel과 ThrowPanel에 각 SlotPrefab을 넣어주는 기능
// 
public class BehaviorActPanel : MonoBehaviour 
{
    public Transform throwPanel;
    public Transform skillPanel;
    public Transform relicPanel;

    public GameObject thorwUIPrefab;
    public GameObject skillUIPrefab;
    public GameObject relicUIPrefab;

    void Start()
    {
        PlayerEventBus.Instance.OnAddThrow += ThrowUIInstantiate;
        PlayerEventBus.Instance.OnAddSkill += SkillUIInstantiate;
        PlayerEventBus.Instance.OnAddRelic += RelicUIInstantiate;
    }

    public void ThrowUIInstantiate(Throw _throw)
    {
        GameObject throwSlotUI = Instantiate(thorwUIPrefab);
        ThrowUI throwUI = throwSlotUI.GetComponent<ThrowUI>();
        throwUI.Setup(_throw);
        throwUI.OnClicked += (selectedThrow) =>
        {
            PlayerEventBus.Instance.OnThrowSelectRequested?.Invoke(selectedThrow);
        };

        throwSlotUI.transform.SetParent(throwPanel);
    }

    public void SkillUIInstantiate(Skill skill)
    {
        GameObject skillSlotUI = Instantiate(skillUIPrefab);
        SkillUI skillUI = skillSlotUI.GetComponent<SkillUI>();
        skillUI.Setup(skill);
        skillUI.OnClicked += (selectedSkill) =>
        {
            PlayerEventBus.Instance.OnSkillSelectRequested?.Invoke(selectedSkill);
        };
        skillSlotUI.transform.SetParent(skillPanel);
    }

    public void RelicUIInstantiate(Relic relic)
    {
        GameObject relicSlotUI = Instantiate(relicUIPrefab);
        RelicUI relicUI = relicSlotUI.GetComponent<RelicUI>();
        relicUI.Setup(relic);
        relicSlotUI.transform.SetParent(relicPanel);
    }
}