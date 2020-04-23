using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLock : InteractiveObjectModel
{
    public int buttonIsUnlock=0; //0為上鎖中,1為無上鎖
    public string buttonSceneName;
    private void Awake()
    {
        PlayerPrefs.SetInt("DressingRoomDoorButton",1); 
        buttonSceneName = this.gameObject.name;
        buttonIsUnlock = PlayerPrefs.GetInt(buttonSceneName);
    }
    public override void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && PlayerState.Instance.GetPlayerTakeOnHandState())
        {
            string playerHandItemName = PlayerState.Instance.GetPlayerTakeOnHandItemName();
            if (playerHandItemName == ItemNameDictionary.GoldBlock && buttonSceneName== "TheaterDoorButton")
            {
                PlayerPrefs.SetInt("TheaterDoorButton", 1);
                ItemStatesManager.Instance.SetAvailable_CollectableItem(ItemNameDictionary.GoldBlock, AvailableState.UnAvailable);
                buttonIsUnlock = PlayerPrefs.GetInt(buttonSceneName);

                GetComponent<ButtonPressEffect>().ColorChange();
            }
            else if (playerHandItemName == ItemNameDictionary.BlackSquare && buttonSceneName == "BasementDoorButton")
            {
                PlayerPrefs.SetInt("BasementDoorButton", 1);
                ItemStatesManager.Instance.SetAvailable_CollectableItem(ItemNameDictionary.BlackSquare, AvailableState.UnAvailable);
                buttonIsUnlock = PlayerPrefs.GetInt(buttonSceneName);

                GetComponent<ButtonPressEffect>().ColorChange();
            }
            else if (playerHandItemName == ItemNameDictionary.WhiteBlock && buttonSceneName == "BathRoomDoorButton")
            {
                PlayerPrefs.SetInt("BathRoomDoorButton", 1);
                ItemStatesManager.Instance.SetAvailable_CollectableItem(ItemNameDictionary.WhiteBlock, AvailableState.UnAvailable);
                buttonIsUnlock = PlayerPrefs.GetInt(buttonSceneName);

                GetComponent<ButtonPressEffect>().ColorChange();
            }

        }
    }
}
