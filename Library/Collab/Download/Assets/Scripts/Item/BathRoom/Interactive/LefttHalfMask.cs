using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LefttHalfMask : InteractiveObjectModel
{
    public GameObject poster;

    private void Start()
    {
        //玩家身上的是左半，所以這裡呈現右半
        if (PlayerState.Instance.GetPlayermaskState() == mask_state.onlyLeft)
            LoadResourceImage("右半面具");
    }

    //開啟詢問視窗
    public override void OnMouseDown()
    {

        if (PlayerState.Instance.GetPlayermaskState() == mask_state.onlyRight)
        {
            WINDOWS.current_obj = this;
            WINDOWS.Instance.OpenWindows();

            WINDOWS.Instance.SetWindows("左半邊的面具\n一次只能戴一個，是否要戴上?", "取消", "穿戴");
        }
        else if (PlayerState.Instance.GetPlayermaskState() == mask_state.onlyLeft)
        {
            WINDOWS.current_obj = this;
            WINDOWS.Instance.OpenWindows();

            WINDOWS.Instance.SetWindows("右半邊的面具\n一次只能戴一個，是否要戴上?", "取消", "穿戴");
        }
        //else if(currentObjectState != InteractiveState.Interacted)
        //WINDOWS.Instance.SetWindows("這是...只有左半邊的面具?\n看著就覺得詭異。","放回");
    }

    public override void GoOnBtnRight()
    {
        if(PlayerState.Instance.GetPlayermaskState() == mask_state.none)
            OnClick();
        else
            SwitchMask();
    }

    private void SwitchMask()
    {
        //拿右半面具和左半面具交換
        //更換海報照片
        if (PlayerState.Instance.GetPlayermaskState() == mask_state.onlyRight)
        {
            if (currentObjectState == InteractiveState.UnInteracted)
            {
                //劇場的黑色方塊出現
                ItemStatesManager.Instance.SetAvailable_CollectableItem(ItemNameDictionary.BlackSquare, AvailableState.Available);
                ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.LeftHalfMask, InteractiveState.Interacted);
            }

            ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.RightHalfMask, InteractiveState.UnInteracted);

            LoadResourceImage("右半面具");
            PlayerState.Instance.SetPlayermaskState(mask_state.onlyLeft);
            poster.GetComponent<ItemModel>().LoadResourceImage("海報(放上右半面具)");

        }
        else if (PlayerState.Instance.GetPlayermaskState() == mask_state.onlyLeft)
        {
            ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.RightHalfMask, InteractiveState.Interacted);

            LoadResourceImage("左半面具");
            PlayerState.Instance.SetPlayermaskState(mask_state.onlyRight);
            poster.GetComponent<ItemModel>().LoadResourceImage("公演海報(殘骸)");
        }
    }


}
