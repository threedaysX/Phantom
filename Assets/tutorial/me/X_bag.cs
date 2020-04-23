/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class bag : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    Vector2 menu_open_deltapos;
    RectTransform myRectTransform;
    bool is_move = false;
    bool is_open = false;

    /// ///////////////////////////////////////////////////////////////////////////////////
    /// ///////////////////////////////////////////////////////////////////////////////////
    /// ///////////////////////////////////////////////////////////////////////////////////
    /// ///////////////////////////////////////////////////////////////////////////////////
    public Image[] itemImages = new Image[numItemSlots];
    public ItemModel[] items = new ItemModel[numItemSlots];

    public const int numItemSlots = 4;

    public void AddItem(ItemModel itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                return;
            }
        }
    }

    public void RemoveItem(ItemModel itemToRemove)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }
    }
    /// ///////////////////////////////////////////////////////////////////////////////////
    /// ///////////////////////////////////////////////////////////////////////////////////
    /// ///////////////////////////////////////////////////////////////////////////////////
    /// ///////////////////////////////////////////////////////////////////////////////////

    void Awake()
    {
        myRectTransform = this.GetComponent<RectTransform>();
        menu_open_deltapos = new Vector3(-113f, 0.0f);
    }


    //*********************************************************實作IPointerEnterHandler, IPointerExitHandler介面
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!is_open && !is_move)
        {
            Debug.Log("Open Menu");
            //Debug.Log(myRectTransform.anchoredPosition);
            StartCoroutine(my_Tween(1, myRectTransform.anchoredPosition, myRectTransform.anchoredPosition + menu_open_deltapos));
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (is_open && !is_move)
        {
            Debug.Log("Exit Menu");
            StartCoroutine(my_Tween(1, myRectTransform.anchoredPosition, myRectTransform.anchoredPosition - menu_open_deltapos));
        }
    }
    //*********************************************************
    ////////////////////////////////////////////////////////////////////////獲得點擊物品
    // https://codertw.com/%E7%A8%8B%E5%BC%8F%E8%AA%9E%E8%A8%80/523515/
   //  Unity NGUI效能優化方法
    //  我們遊戲的某些邏輯會在一幀內頻繁呼叫GameObject.SetActive，顯示或隱藏一些物件，數量達到一百多次之多。
     // 這類操作的CPU開銷很大（尤其是NGUI的UIWidget在啟用的時候會做很多初始化工作），而且會觸發大量GC。
    //  
    //  我們可以改變顯示和隱藏物件的方法
    //  讓物件一直保持啟用狀態（activeInHierarchy為true），
    //  而原來的SetActive(false)改為將物件移到螢幕外，SetActive(true)改為將物件移回螢幕內。
    // 
    Vector3 mouse_p;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            Debug.Log(rayHit.transform.name);
            rayHit.transform.gameObject.SetActive(false);

            ItemModel itemM = rayHit.transform.gameObject.GetComponent<ItemModel>();

            AddItem(itemM);

            //Debug.Log("id:"+itemM.Id);
            //Debug.Log("name:" + itemM.Name);
            //SetItemField(itemM.Id);
        }
    }

    ///////////////////////////////////////////////////////////////////////////TWEEN
    IEnumerator my_Tween(float duration, Vector3 posStart, Vector3 posEnd)
    {
        is_move = true;
        float timeStart = Time.time;
        float timeEnd = timeStart + duration;
        while (Time.time < timeEnd)
        {
            float t = Mathf.InverseLerp(timeStart, timeEnd, Time.time);       //lerp 插值，InverseLerp回傳time在timeStart, timeEnd之間第幾趴(0~1之間)
            float v = CubicEaseOut(t);
            //LerpUnclamped(a,b,t) >> a = 0.33f, and b = 1.5f. If interpolator t = -0.25f then the return value is 0.0375f.
            Vector3 position = Vector3.LerpUnclamped(posStart, posEnd, v);      //從百分比推回數字，t不局限於0~1
            GetComponent<RectTransform>().anchoredPosition = position;
            //this.transform.Translate(position - this.transform.position);
            yield return null;
        }
        is_open = !is_open;
        is_move = false;
    }

    // CubicOut
    float CubicEaseOut(float t)
    {
        return ((t = t - 1) * t * t + 1);
    }
}
*/