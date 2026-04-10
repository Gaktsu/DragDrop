using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Scriptable Objects/SkillData")]
public class SkillData : ScriptableObject
{
    public string throwName;
    public string description;
    public Sprite icon;
    
    // 3. 공격력, 톙기는 횟수 private 변수
    [SerializeField] private SkillAction action;

    // 4. 헬퍼 프로퍼티
    public SkillAction SkillAction => action;
}
