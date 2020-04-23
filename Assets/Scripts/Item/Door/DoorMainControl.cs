using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DoorMainControl : SceneController
{
    // 當按下色塊按鈕時，會修改這個參數。
    public static string btnName = string.Empty;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 確認是否點擊此物件(true代表玩家點擊在UI上)
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                OnDoorBtnClick();
                btnName = string.Empty; //每傳送一次，初始化btnName
            }
        }
    }

    private void OnDoorBtnClick()
    {
        ChangeMainScene(btnName);
    }
}
