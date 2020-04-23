using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OtherCloth : InteractiveObjectModel
{
    private void Start()
    {
        if (currentObjectState == InteractiveState.Interacted)
            this.gameObject.SetActive(false);

    }

    public override void OnMouseDown()
    {

    }
    //開啟詢問視窗
    void OnMouseUp()
    {
        if ((!DressingTable.Instance.combOK || !DressingTable.Instance.perfumeOK) && !EventSystem.current.IsPointerOverGameObject())
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                WINDOWS.current_obj = this;
                WINDOWS.Instance.OpenWindows();
                WINDOWS.Instance.SetWindows("看不出來這是甚麼服裝\n是否要穿上?", "取消", "穿上");
            }
    }


    public override void GoOnBtnRight()
    {
        //標示物件已被使用
        OnClick();
        OnClickWithParameter(this);
        Dresses.Instance.ChangeCloth("OtherCloth");
    }
}
