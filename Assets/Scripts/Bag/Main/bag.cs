using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//public class bag : Singleton<bag>, IPointerEnterHandler, IPointerExitHandler
public class bag : Singleton<bag>
{
    //menu
    Vector2 menu_open_deltapos;
    RectTransform myRectTransform;
    bool is_move = false;
    bool is_open = false;

    //bag
    public Image[] itemImages = new Image[numItemSlots];
    public ItemModel[] items = new ItemModel[numItemSlots];
    public const int numItemSlots = 5;

    public void AddItem(ItemModel itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].ItemName == "Bag_EmptyItemModel")
            {
                items[i].Copy(itemToAdd);
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                return;
            }
        }
        //滿了要提示
        //否則裝不下，且物件被刪除
        //...
    }

    public Image mouse_img;
    // 使用道具。
    // 點擊畫面背包欄時啟用
    public void UseItem(int bag_id) 
    {
        Sprite sp = itemImages[bag_id].sprite;
        if (sp != null)
        {
            mouse_img.sprite = sp;
            mouse_img.color = new Color32(255, 255, 255, 255);
            PlayerState.Instance.TakeOn(items[bag_id].ItemName);
        }
    }

    public Text description;
    private bool fading=false;
    //右鍵點擊畫面背包欄時，顯示道具描述，由ItemSlot.cs呼叫
    public void ViewItem(int bag_id)
    {
        Sprite sp = itemImages[bag_id].sprite;
        if (sp != null && !fading)
        {
            fading = true;
            description.text = ItemDescriptionDitionary.FindInDictionary(items[bag_id].ItemName);
            StartCoroutine(FadeInOut());
            //Debug.Log(items[bag_id].ItemName + "333333333333333333333333333333333");
        }
    }
    IEnumerator FadeInOut()
    {
        Fade.Instance.SpriteChangeColortoColor(description.gameObject, new Color(255, 255, 255, 0), new Color(255, 255, 255, 255), 1f);
        yield return new WaitForSeconds(2.0f);
        Fade.Instance.SpriteChangeColortoColor(description.gameObject, new Color(255, 255, 255, 255), new Color(255, 255, 255, 0), 1f);
        yield return new WaitForSeconds(1.0f);
        fading = false;
    }

    // 結束使用、不使用道具，就恢復原樣。
    public void ResetUseItem()
    {
        mouse_img.sprite = null;
        mouse_img.transform.position = new Vector3(0, 0, 0);
        mouse_img.color = new Color32(255, 255, 255, 0);
        PlayerState.Instance.TakeOff();
    }

    public void RemoveItem(string itemToRemove_name)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].ItemName == itemToRemove_name)
            {
                //items[i] = null;
                items[i].ItemName = "Bag_EmptyItemModel";
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;

                //重新排列格子
                while (i < 4)//如果被移除的不是最後一個格子
                {
                    //把後一個移到目前這格
                    items[i].ItemName = items[i+1].ItemName;
                    itemImages[i].sprite = itemImages[i+1].sprite;
                    itemImages[i].enabled = itemImages[i+1].enabled;

                    items[i+1].ItemName = "Bag_EmptyItemModel";
                    itemImages[i+1].sprite = null;
                    itemImages[i+1].enabled = false;

                    i++;
                }
                //最後一個為空
                items[4].ItemName = "Bag_EmptyItemModel";
                itemImages[4].sprite = null;
                itemImages[4].enabled = false;


                return;
            }
            

        }

    }

    void Awake()
    {
        myRectTransform = this.GetComponent<RectTransform>();
        menu_open_deltapos = new Vector3(-113f, 0.0f);
    }


    //*********************************************************實作IPointerEnterHandler, IPointerExitHandler介面
    /*
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!is_open && !is_move)
        {
            //Debug.Log("Open Menu");
            StartCoroutine(my_Tween(1, myRectTransform.anchoredPosition, myRectTransform.anchoredPosition + menu_open_deltapos));
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (is_open && !is_move)
        {
            //Debug.Log("Exit Menu");
            StartCoroutine(my_Tween(1, myRectTransform.anchoredPosition, myRectTransform.anchoredPosition - menu_open_deltapos));
        }
    }
    */
    //*********************************************************
    ////////////////////////////////////////////////////////////////////////獲得點擊物品
    /* https://codertw.com/%E7%A8%8B%E5%BC%8F%E8%AA%9E%E8%A8%80/523515/
     * Unity NGUI效能優化方法
     * 我們遊戲的某些邏輯會在一幀內頻繁呼叫GameObject.SetActive，顯示或隱藏一些物件，數量達到一百多次之多。
     * 這類操作的CPU開銷很大（尤其是NGUI的UIWidget在啟用的時候會做很多初始化工作），而且會觸發大量GC。
     * 
     * 我們可以改變顯示和隱藏物件的方法
     * 讓物件一直保持啟用狀態（activeInHierarchy為true），
     * 而原來的SetActive(false)改為將物件移到螢幕外，SetActive(true)改為將物件移回螢幕內。
     */

    Vector3 mousePos;
    void Update()
    {
        // 使用道具中...
        if (mouse_img.sprite!= null)
        {
            mousePos = Input.mousePosition;
            mousePos.z = 15f;
            mouse_img.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
            if (Input.GetMouseButtonDown(0))
            {
                ResetUseItem();
            }
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
