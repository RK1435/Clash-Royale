using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestModel
{
    public ChestModel(ChestScriptableObject ChestSO)
    {
        ChestName = ChestSO.ChestName;
        ChestSprite = ChestSO.ChestSprite;
        UnlockDuration = ChestSO.UnlockDuration;
        CoinCost = ChestSO.UnlockCost;
        CoinsReward = Random.Range(ChestSO.MinCoins, ChestSO.MaxCoins + 1);
        GemsReward = Random.Range(ChestSO.MinGems, ChestSO.MaxGems + 1);
    }

    public float UnlockDuration { get; }
    public string ChestName { get; }
    public Sprite ChestSprite { get; }
    public int UnlockCost { get; }
    public int CoinCost { get; }
    public int CoinsReward { get; }
    public int GemCost { get; }
    public int GemsReward { get; }
}
