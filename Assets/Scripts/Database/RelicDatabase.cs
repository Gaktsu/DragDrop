using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "RelicDatabase", menuName = "Scriptable Objects/RelicDatabase")]
public class RelicDatabase : ScriptableObject
{
    public List<RelicData> relics = new List<RelicData>();

    public RelicData GetRandomRelic()
    {
        if (relics == null || relics.Count == 0) return null;

        int randomIndex = Random.Range(0, relics.Count);
        return relics[randomIndex];
    }
}