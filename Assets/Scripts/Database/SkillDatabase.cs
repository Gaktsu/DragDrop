using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SkillDatabase", menuName = "Scriptable Objects/SkillDatabase")]
public class SkillDatabase : ScriptableObject 
{
    public List<SkillData> skills = new List<SkillData>();

    public SkillData GetRandomSkill()
    {
        if (skills == null || skills.Count == 0) return null;

        int randomIndex = Random.Range(0, skills.Count);
        return skills[randomIndex];
    }
}