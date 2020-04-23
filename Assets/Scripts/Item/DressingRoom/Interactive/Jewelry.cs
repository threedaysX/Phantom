using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Jewelry : InteractiveObjectModel
{
    private void Start()
    {
        if (currentObjectState == InteractiveState.Interacted)
            this.gameObject.SetActive(false);
    }

    //開啟詢問視窗
    public override void OnMouseDown()
    {
        WINDOWS.current_obj = this;
        WINDOWS.Instance.OpenWindows();
        WINDOWS.Instance.SetWindows("一個很精緻的首飾。\n是否要配戴上?", "取消","穿戴");
    }

    public override void GoOnBtnRight()
    {
        //標示物件已被使用
        OnClick();
        OnClickWithParameter(this);
        this.gameObject.SetActive(false);
        ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.Jewelry, InteractiveState.Interacted);
    }
}
