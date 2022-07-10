using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController
{
    public ChestModel chestModel;
    public ChestView chestView;
    public float unlockTimer;

    public ChestController(ChestModel chestModel, ChestView chestView)
    {
        this.chestModel = chestModel;
        this.chestView = chestView;
        InitializeView();
        unlockTimer = this.chestModel.UnlockDuration;
    }

    public void InitializeView()
    {
        chestView.SetControllerReferance(this);
        chestView.InitializeViewUIForLockedChest();
    }

    public int GetGemCost()
    {
        unlockTimer = chestModel.UnlockDuration;
        return (int)Mathf.Ceil(unlockTimer / 2);
    }

    public async void StartTimer()
    {
        while(unlockTimer > 0)
        {
            chestView.chestTimerText.text = unlockTimer.ToString() + " s";
            unlockTimer -= 1;
        }
        chestView.EnteringUnlockedState();
        return;
    }
 }
