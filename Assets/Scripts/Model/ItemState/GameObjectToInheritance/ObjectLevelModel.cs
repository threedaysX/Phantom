using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 可互動物件(可破壞型)繼承此。
/// </summary>
public class ObjectLevelModel : ItemModel
{
    public GameObject breakEffect1;
    public GameObject breakEffect2;
    
    public int currentLevel = 0;
    private int maxLevel = 3;
    
    private Vector3 localScale;
    private Vector3 breakScale1;
    private Vector3 breakScale2;
    private bool flag = false;

    private void Start()
    {
        if (!flag)
        {
            localScale = this.gameObject.transform.localScale;
            breakScale1 = breakEffect1.gameObject.transform.localScale;
            breakScale2 = breakEffect2.gameObject.transform.localScale;
            flag = true;
        }

        #region 重新讀取 [物件當前階級] 狀態
        string loadObject = PlayerPrefs.GetString(this.gameObject.name);
        if (!string.IsNullOrEmpty(loadObject))
        {
            InteractiveObjectWithLevel toLoadObj = ScriptableObject.CreateInstance<InteractiveObjectWithLevel>();
            JsonUtility.FromJsonOverwrite(loadObject, toLoadObj);
            currentLevel = toLoadObj.currentLevel;
        }
        ResetObjectLevel();
        #endregion

        if (ItemTag != "Hole")
            ItemTag = "ObjectLevelModel";

        _IClick = new _InteractiveItemWithLevel();
    }

    public void OnMouseDown()
    {
        // 當玩家手上沒有拿著道具的時候，才可以破壞。
        if (Input.GetMouseButtonDown(0) && 
            !EventSystem.current.IsPointerOverGameObject() &&
            !PlayerState.Instance.GetPlayerTakeOnHandState())
        {
            if (currentLevel < maxLevel)
            {
                OnClick();
                OnClickWithParameter(this);
                currentLevel++;
            }
            ResetObjectLevel();           
        }
    }

    void ResetObjectLevel()
    {
        var sp = this.gameObject.GetComponent<SpriteRenderer>();

        switch (currentLevel)
        {
            case 1:
                sp.color = new Color(255, 255, 255, 255);
                breakEffect1.SetActive(false);
                breakEffect2.SetActive(false);
                break;
            case 2:
                sp.sprite = breakEffect1.GetComponent<SpriteRenderer>().sprite;
                this.gameObject.transform.localScale = new Vector3(localScale.x * breakScale1.x, localScale.y * breakScale1.y, localScale.z * breakScale1.z);
                break;
            case 3:
                sp.sprite = breakEffect2.GetComponent<SpriteRenderer>().sprite;
                this.gameObject.transform.localScale = new Vector3(localScale.x * breakScale2.x, localScale.y * breakScale2.y, localScale.z * breakScale2.z);
                break;
            default:
                break;
        }
    }
}