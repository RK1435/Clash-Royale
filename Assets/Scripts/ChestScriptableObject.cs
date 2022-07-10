using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChestSO", menuName = "ScriptableObjects/Chests/ChestSO")]
public class ChestScriptableObject : ScriptableObject
{
    public string ChestName;
    public Sprite ChestSprite;
    public float UnlockDuration;
    public int MinCoins;
    public int MaxCoins;
    public int MinGems;
    public int MaxGems;
    public int UnlockCost;
}
