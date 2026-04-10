using UnityEngine;

public class Entity : MonoBehaviour
{
    public StatusController status { get; protected set; }
    public StatController stat { get; protected set; }

    protected virtual void Awake()
    {
        status = new StatusController();
        stat = new StatController();

        stat.Init(this);
    }
    public virtual void Damaged(int damage)
    {
        
    }
}