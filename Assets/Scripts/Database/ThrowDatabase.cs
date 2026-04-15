using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ThrowDatabase", menuName = "Scriptable Objects/ThrowDatabase")]
public class ThrowDatabase : ScriptableObject
{
    public List<ThrowData> throws = new List<ThrowData>();

    public ThrowData GetRandomThrow()
    {
        if (throws == null || throws.Count == 0) return null;

        int randomIndex = Random.Range(0, throws.Count);
        return throws[randomIndex];
    }
}