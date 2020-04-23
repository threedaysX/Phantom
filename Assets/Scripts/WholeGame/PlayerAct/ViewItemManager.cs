using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ViewItemManager : Singleton<ViewItemManager>
{
    public GameObject viewItemMode;
    public GameObject bookCanvas;

    // 原始大小(固定不變)
    private static Vector2 constImageSize;
    public Image itemImg;
    
    public ViewModeState viewModeState = ViewModeState.UnOpened;

    static ViewItemManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (this != instance)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            Destroy(gameObject);
        }
        if (itemImg != null)
        {
            constImageSize = itemImg.rectTransform.sizeDelta;
        }
    }

    void Start()
    {
        if (viewItemMode == null)
        {
            viewItemMode = GameObject.Find("ViewItemMode");
        }
    }

    void Update()
    {
        if (viewItemMode == null)
        {
            viewItemMode = GameObject.Find("ViewItemMode");
        }
        if (Input.GetMouseButtonUp(0) && EventSystem.current.IsPointerOverGameObject())
        {
            CloseViewItemMode();
        }
    }

    // Camera move with canvas
    /// <summary>
    /// 前置判斷: 滑鼠點擊右鍵後，開啟檢視模式。
    /// 備註: OnMouseDown只可以用左鍵觸發(所以不能判斷右鍵)，所以在此是用OnMouseOver持續偵測，是否點下右鍵。
    /// </summary>
    public void OpenViewItemMode(GameObject theGameObject)
    {
        Sprite sp = theGameObject.GetComponent<SpriteRenderer>().sprite;
        itemImg.rectTransform.sizeDelta = constImageSize;
        if (viewItemMode != null)
        {
            Rect spRect = sp.rect;
            float spWidth = spRect.width;
            float spHeight = spRect.height;
            float spTotal = spWidth + spHeight;
            // 計算原本圖片的比例
            Vector2 spScale = new Vector2(spWidth / spTotal, spHeight / spTotal);
            // 若玩家點擊的是洞，則開啟閱讀劇本模式。
            if (theGameObject.tag == "Hole")
            {
                viewModeState = ViewModeState.Opened_ReadBook;
                viewItemMode.SetActive(true);
                viewItemMode.gameObject.transform.Find("Hole_Canvas").gameObject.SetActive(true);
                bookCanvas.gameObject.SetActive(true);

                string holeName = theGameObject.name;
                ReadBookTextControl.Instance.GetBookText(holeName[17] - 48);
            }
            /*else if (theGameObject.name == ItemNameDictionary.Piano && !EndingManager.Instance.Judge(ItemNameDictionary.Piano)) 
            {
                SceneManager.LoadScene("Piano_Perform");
            }*/
            else
            {
                viewModeState = ViewModeState.Opened_ViewItem;
                viewItemMode.SetActive(true);
                viewItemMode.gameObject.transform.Find("Hole_Canvas").gameObject.SetActive(false);
                bookCanvas.gameObject.SetActive(false);
            }
            itemImg.sprite = theGameObject.GetComponent<SpriteRenderer>().sprite;
            Vector2 currentImgSize = itemImg.rectTransform.sizeDelta * spScale;

            itemImg.rectTransform.sizeDelta = currentImgSize;
        }
    }

    /// <summary>
    /// 前置判斷: 滑鼠點擊後放開，在任何一處，即關閉放大檢視模式。
    /// 前置額外判斷: 若進入了ScrollView模式，就不會關閉視窗。
    /// </summary>
    public void CloseViewItemMode()
    {
        if (viewItemMode != null)
        {
            viewModeState = ViewModeState.UnOpened;
            viewItemMode.SetActive(false);
        }
        itemImg.rectTransform.sizeDelta = constImageSize;
    }

    public enum ViewModeState
    {
        UnOpened = 0,
        Opened_ViewItem = 1,
        Opened_ReadBook = 2,
    }
}
