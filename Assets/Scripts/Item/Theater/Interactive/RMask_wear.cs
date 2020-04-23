using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMask_wear : InteractiveObjectModel
{
    public GameObject RHalfMask;
    private void Start()
    {
        if(currentObjectState==InteractiveState.Interacted)
            this.gameObject.SetActive(true);
        else
            this.gameObject.SetActive(false);

        if (EndingManager.Instance.Judge(ItemNameDictionary.RightHalfMask))
            this.gameObject.SetActive(false);
    }

    //開啟詢問視窗
    public override void OnMouseDown()
    {
        if (RHalfMask.gameObject.GetComponent<CollectableItemModel>().availableState == AvailableState.Available)
        {
            WINDOWS.current_obj = this;
            WINDOWS.Instance.OpenWindows();
            WINDOWS.Instance.SetWindows("右半邊的面具。\n是否要配戴上?", "取消", "穿戴");
        }
    }

    public override void GoOnBtnRight()
    {
        //標示物件已被使用
        OnClick();
        OnClickWithParameter(this);
        this.gameObject.SetActive(false);
        ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.RMask_wear, InteractiveState.UnInteracted); //右半面具(穿)消失

        ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.RightHalfMask, InteractiveState.Interacted);
        PlayerState.Instance.SetPlayermaskState(mask_state.onlyRight);
    }

}
