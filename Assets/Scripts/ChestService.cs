using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestService : SingletonGeneric<ChestService>
{
    public ChestController selectedController;

    public ChestController GetChest(ChestScriptableObject randomChestSO, ChestView chestView)
    {
        ChestModel chestModel = new ChestModel(randomChestSO);
        ChestController chestController = new ChestController(chestModel, chestView);
        return chestController;
    }
    
    public void OnClickStartTimerWithCoins()
    {
        if(ResourceHandler.Instance.coins < selectedController.chestModel.CoinCost)
        {
            UIHandler.Instance.ToggleUnlockChestPopup(false);
            UIHandler.Instance.ToggleInsufficientResourcesPopup(true);
        }
        else
        {
            ResourceHandler.Instance.DecreaseCoins(selectedController.chestModel.CoinCost);
            selectedController.chestView.EnteringUnlockingState();
            UIHandler.Instance.ToggleUnlockChestPopup(false);
        }
    }

    public void OnClickOpenInstantlyWithGems()
    {
        if(ResourceHandler.Instance.gems < selectedController.GetGemCost())
        {
            UIHandler.Instance.ToggleUnlockChestPopup(false);
            UIHandler.Instance.ToggleInsufficientResourcesPopup(true);
        }
        else
        {
            ResourceHandler.Instance.DecreaseGems(selectedController.GetGemCost());
            selectedController.chestView.OpenInstantly();
            UIHandler.Instance.ToggleUnlockChestPopup(false);
        }
    }

    public void ToggleRewardsPopup(bool setActive)
    {
        if(!setActive)
        {
            selectedController = null;
        }
        else
        {
            UIHandler.Instance.rewardRecivedText.text = "You recived" + selectedController.chestModel.CoinsReward + " coins and " + selectedController.chestModel.GemsReward + " gems.";
        }
        UIHandler.Instance.rewardPopup.SetActive(setActive);
    }
}
