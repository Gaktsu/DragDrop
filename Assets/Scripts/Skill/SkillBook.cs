using System;
using System.Collections.Generic;

public class SkillBook
{
    // 1. Dictionary 변수 (SkillData, Skill)
    private Dictionary<SkillData, Skill> learnedSkills = new Dictionary<SkillData, Skill>();

    // 2. Helper 함수 - SkillData로 Skill 반환
    public Skill AddSkill(SkillData skillData)
    {
        if(learnedSkills.ContainsKey(skillData))
            return null;

        Skill newSkill = new Skill {data = skillData};
        learnedSkills.Add(skillData, newSkill);

        PlayerEventBus.Instance.OnAddSkill?.Invoke(newSkill);

        return newSkill;
    }

    // public void UpdateAllCooldowns()
    // {
    //     foreach(var skill in learnedSkills.Values)
    //     {
    //         skill.Tick();
    //     }
    // }
}