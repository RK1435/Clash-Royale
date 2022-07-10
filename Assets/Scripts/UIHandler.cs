using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : SingletonGeneric<UIHandler>
{
    [SerializeField]
    private Text valueOfGems;
    [SerializeField]
    private Text valueOfCoins;
    [SerializeField]
    private GameObject slotsFullPopup;
    [SerializeField]
    private GameObject busyUnlockingPopup;
    [SerializeField]
    private GameObject unlockChestPopup;
    [SerializeField]
    private GameObject insufficientResourcesPopup;
    [SerializeField]
    public GameObject rewardPopup;
    [SerializeField]
    public Text rewardRecivedText;


    public void ToggleSlotsFullPopup(bool setActive)
    {
        slotsFullPopup.SetActive(setActive);
    }

    public void ToggleBusyUnlockingPopup(bool setActive)
    {
        busyUnlockingPopup.SetActive(setActive);
    }

    public void ToggleUnlockChestPopup(bool setActive)
    {
        unlockChestPopup.SetActive(setActive);
        if(setActive == false)
        {
            ChestService.Instance.selectedController = null;
        }
    }

    public void ToggleInsufficientResourcesPopup(bool setActive)
    {
        insufficientResourcesPopup.SetActive(setActive);
    }

    public void UpdateGemsUI(int gems)
    {
        valueOfGems.text = gems.ToString();
    }

    public void UpdateCoinsUI(int coins)
    {
        valueOfCoins.text = coins.ToString();
    }
}
