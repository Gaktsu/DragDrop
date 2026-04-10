using UnityEngine;

// 정리
// SkillPanel과 ThrowPanel에 각 SlotPrefab을 넣어주는 기능
// 
public class BehaviorActPanel : MonoBehaviour 
{
    public ThrowBook throwBook;
    public SkillBook skillBook;
    public Transform throwPanel;
    public Transform skillPanel;

    public GameObject thorwUIPrefab;
    public GameObject skillUIPrefab;

    void Start()
    {
        PlayerEventBus.Instance.OnAddThrow += ThrowUIInstantiate;
        PlayerEventBus.Instance.OnAddSkill += SkillUIInstantiate;
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
}