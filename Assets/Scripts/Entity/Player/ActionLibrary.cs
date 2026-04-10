
// TODO
// 싱글톤 적용
using UnityEngine;

public class ActionLibrary : MonoBehaviour
{
    public static ActionLibrary Instance;
    public SkillBook skillBook = new SkillBook();
    public ThrowBook throwBook = new ThrowBook();

    public void Start()
    {
        if(Instance == null)
            Instance = this;
    }

    public void AddSkill(Skill skill)
    {
        skillBook.AddSkill(skill.data);
    }

    public void AddThrow(Throw _throw)
    {
        throwBook.AddThrow(_throw.data);
    }
}