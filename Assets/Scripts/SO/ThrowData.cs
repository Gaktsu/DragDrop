using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ThrowData", menuName = "Scriptable Objects/ThrowData")]
public class ThrowData : ScriptableObject
{
    public string throwName;
    public string description;
    public Sprite icon;
    public ThrowBehavior throwType;
    public int BaseCoolDown;
}
