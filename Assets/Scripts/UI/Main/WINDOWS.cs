using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WINDOWS : Singleton<WINDOWS>
{
    public static InteractiveObjectModel current_obj=null;
    Transform itemList;
    public Text title;
    public Text str_L;
    public Text str_R;
    void Start()
    {
        
    }

    public void OpenWindows()
    {
        itemList = GameObject.Find("Windows_Canvas").transform.Find("windows");
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            itemList.gameObject.SetActive(true);
        }
    }

    public void SetWindows(string title_str, string btnL_str, string btnR_str)
    {
        title.text = title_str;
        str_L.transform.parent.gameObject.SetActive(true);
        str_L.text = btnL_str;
        str_R.text = btnR_str;
    }

    public void SetWindows(string title_str, string btn_str)
    {
        title.text = title_str;
        str_L.transform.parent.gameObject.SetActive(false);
        str_R.text = btn_str;
    }

    //左按鈕為取消關閉(不動作)
    public void Close()
    {
        itemList.gameObject.SetActive(false);
    }

    public void GetReturn_btnR()
    {
        current_obj.GoOnBtnRight();
        Close();
    }

}
