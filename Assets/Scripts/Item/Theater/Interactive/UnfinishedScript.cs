using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnfinishedScript : InteractiveObjectModel
{
    public GameObject scriptScreen;
    public override void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && PlayerState.Instance.GetPlayerTakeOnHandState())
        {
            string playerHandItemName = PlayerState.Instance.GetPlayerTakeOnHandItemName();
            if (currentObjectState== InteractiveState.UnInteracted)
            {
                #region  
                if (playerHandItemName == ItemNameDictionary.FeatherPen) //筆筒裡的筆，代表的是好結局
                {
                    ItemStatesManager.Instance.SetAvailable_CollectableItem(ItemNameDictionary.FeatherPen, AvailableState.UnAvailable);
                    EndingManager.Instance.pen_flag = true;
                    ChangeStatus();

                    // Karma升級。
                    KarmaBase.currentKarmaLevel++;
                    EndingManager.Instance.GetEndScore();
                }
                else if (playerHandItemName == ItemNameDictionary.FountainPen) // 懸浮的筆，代表的是壞結局
                {
                    ItemStatesManager.Instance.SetAvailable_CollectableItem(ItemNameDictionary.FountainPen, AvailableState.UnAvailable);
                    ChangeStatus();

                    // Karma升級。
                    KarmaBase.currentKarmaLevel++;
                }
                #endregion
            }
        }
        else if(Input.GetMouseButtonDown(0))
        {
            scriptScreen.gameObject.SetActive(true);
            Debug.Log("HI");
        }
    }
    private void ChangeStatus()
    {
        OnClick();
        OnClickWithParameter(this);
        ItemStatesManager.Instance.SetAvailable_CollectableItem(ItemNameDictionary.PianoScore, AvailableState.Available);

        currentObjectState = InteractiveState.Interacted;
        ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.UnfinishedScript, InteractiveState.Interacted); 

        ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.Auditorium , InteractiveState.Interacted); //啟用 觀眾席 圖片的功能

        ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.leftStageCurtain, InteractiveState.Interacted); //判斷是否完成劇本，啟用布幕的功能
        ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.rightStageCurtain, InteractiveState.Interacted);

        ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.Poster, InteractiveState.Interacted);
        ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.ScriptScreen, InteractiveState.Interacted);

        scriptScreen.GetComponent<InteractiveObjectModel>().LoadResourceImage("劇本畫面(完成)");
    }
}
