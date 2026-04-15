using UnityEngine;

public class DatabaseHub : MonoBehaviour
{
    public static DatabaseHub Instance;

    public SkillDatabase skillDB;
    public ThrowDatabase throwDB;
    public RelicDatabase relicDB;

    void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
}