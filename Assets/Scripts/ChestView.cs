using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChestView : MonoBehaviour
{
    public ChestController chestController;
    [HideInInspector]
    public Slot slotReferance;

    [SerializeField] private Sprite EmptySlotSprite;
    [SerializeField] public Text chestTimerText;
    [SerializeField] private Image chestSlotSprite;
    [SerializeField] private Text chestTypeText;
    [SerializeField] private Image coinImage;
    [SerializeField] private Text coinsText;
    [SerializeField] private Image gemImage;
    [SerializeField] private Text gemsText;

    [SerializeField] private Button ChestButton;

    private ChestState currentState;

    public void SetControllerReferance(ChestController chestController)
    {
        this.chestController = chestController;
    }
    
    private void Start()
    {
        InitializeEmptyChestView();
    }

    public void InitializeEmptyChestView()
    {
        chestTimerText.gameObject.SetActive(false);
        chestSlotSprite.sprite = EmptySlotSprite;
        chestTypeText.gameObject.SetActive(false);
        coinImage.gameObject.SetActive(false);
        coinsText.gameObject.SetActive(false);
        gemImage.gameObject.SetActive(false);
        gemsText.gameObject.SetActive(false);
        ChestButton.enabled = false;
        currentState = ChestState.None;
    }

    public void InitializeViewUIForLockedChest()
    {
        chestTimerText.gameObject.SetActive(false);
        chestSlotSprite.sprite = chestController.chestModel.ChestSprite;
        chestTypeText.gameObject.SetActive(true);
        chestTypeText.text = chestController.chestModel.ChestName;
        coinImage.gameObject.SetActive(true);
        coinsText.gameObject.SetActive(true);
        coinsText.text = chestController.chestModel.CoinCost.ToString();
        gemImage.gameObject.SetActive(true);
        gemsText.gameObject.SetActive(true);
        gemsText.text = chestController.GetGemCost().ToString();
        ChestButton.enabled = true;
        currentState = ChestState.Locked;
    }

    public void InitializeViewUIForUnlockingChest()
    {
        chestTimerText.gameObject.SetActive(true);
        chestSlotSprite.sprite = chestController.chestModel.ChestSprite;
        chestTypeText.gameObject.SetActive(true);
        chestTypeText.text = chestController.chestModel.ChestName;
        coinImage.gameObject.SetActive(false);
        coinsText.gameObject.SetActive(false);
        gemImage.gameObject.SetActive(false);
        gemsText.gameObject.SetActive(false);
        ChestButton.enabled = false;
        currentState = ChestState.Unlocking;
    }

    public void IntializeViewUIForUnlockedChest()
    {
        chestTimerText.gameObject.SetActive(true);
        chestSlotSprite.sprite = chestController.chestModel.ChestSprite;
        chestTypeText.gameObject.SetActive(true);
        chestTypeText.text = chestController.chestModel.ChestName;
        coinImage.gameObject.SetActive(false);
        coinsText.gameObject.SetActive(false);
        gemImage.gameObject.SetActive(false);
        gemsText.gameObject.SetActive(false);
        ChestButton.enabled = true;
        currentState = ChestState.Unlocked;
    }

    public void OnClickChestButton()
    {
        if(currentState == ChestState.Locked)
        {
            if(SlotsController.Instance.isUnlocking)
            {
                UIHandler.Instance.ToggleBusyUnlockingPopup(true);
            }
            else
            {
                ChestService.Instance.selectedController = chestController;
                UIHandler.Instance.ToggleUnlockChestPopup(true);
            }
        }
        else if(currentState == ChestState.Unlocking)
        {

        }
        else if(currentState == ChestState.Unlocked)
        {
            ChestService.Instance.selectedController = chestController;
            OpenChest();
            ChestService.Instance.ToggleRewardsPopup(true);
        }
    }

    public void EnteringUnlockingState()
    {
        SlotsController.Instance.isUnlocking = true;
        InitializeViewUIForUnlockingChest();
        chestController.StartTimer();
    }

    public void OpenInstantly()
    {
        InitializeEmptyChestView();
        ReceiveChestRewards();
        ChestService.Instance.selectedController = chestController;
        slotReferance.isEmpty = true;
        ChestService.Instance.ToggleRewardsPopup(true);
        slotReferance.chestController = null;
    }

    public void EnteringUnlockedState()
    {
        SlotsController.Instance.isUnlocking = false;
        IntializeViewUIForUnlockedChest();
        chestTimerText.text = "OPEN!";
    }

    public void OpenChest()
    {
        InitializeEmptyChestView();
        ReceiveChestRewards();
        slotReferance.isEmpty = true;
        slotReferance.chestController = null;
    }

    public void ReceiveChestRewards()
    {
        ResourceHandler.Instance.IncreaseCoins(chestController.chestModel.CoinsReward);
        ResourceHandler.Instance.IncreaseGems(chestController.chestModel.GemsReward);
    }
}
