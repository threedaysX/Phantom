using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// 道具通用: 點擊觸發某些事物 => 針對接口實作{實作觸發什麼事物}
public interface IClick
{
    void OnClick();
    void OnClick<T>(T someObject);
}

#region DoorButton
public class DoorButton : IClick
{
    public void OnClick() { }

    // 當按下色塊按鈕時，會先存放到這個參數，並觸發點擊事件，最後切換到對應的場景。
    public void OnClick<T>(T sceneName)
    {
        SetSceneName(sceneName);
    }

    // 如果按下按鈕，執行這個funtion，會去修改DoorMainControl程式中的btnName，為此Iteme該對應的地點名稱。
    private void SetSceneName(object sceneName)
    {
        DoorMainControl.btnName = sceneName.ToString(); 
    }
}
#endregion

#region CollectableItem
/// 可收集式道具
public class _CollectableItem : IClick
{
    public void OnClick()
    {
        #region 收集道具
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10, -1);
        if (hit.collider)
        {
            string tag = hit.collider.gameObject.tag;
            if (tag == "CollectableItem" && !EventSystem.current.IsPointerOverGameObject())
            {
                ItemModel tempModel = hit.transform.gameObject.GetComponent<ItemModel>();

                bag.Instance.AddItem(tempModel);

                Object.Destroy(hit.transform.gameObject);
                //hit.transform.gameObject.SetActive(false);
            }
            else if (tag == "InteractiveObject")
            {
                // 不做事
            }
        }
        #endregion

        KarmaBase.currentKarmaValue += 0.5f;        
    }
    public void OnClick<T>(T _object)
    {
        #region 儲存道具狀態到記憶體
        CollectableItemModel tempObj = _object as CollectableItemModel;
        CollectableItemState storeItemState = ScriptableObject.CreateInstance<CollectableItemState>();
        storeItemState.SwitchAvailable();
        storeItemState.Interact();
        storeItemState.isAvailable = AvailableState.UnAvailable;
        storeItemState.isUsed = tempObj.usedState;
        storeItemState.SetItemName(tempObj.ItemName);
        storeItemState.SetItemTag(tempObj.ItemTag);

        string json = JsonUtility.ToJson(storeItemState);
        Debug.Log(json);
        PlayerPrefs.SetString(storeItemState.itemName, json);
        #endregion
    }
}
#endregion

#region InteractiveItem
/// 可互動式道具
public class _InteractiveItem : IClick
{
    public void OnClick()
    {
        // 如果玩家沒拿著道具，可以破壞東西(產生畫面特效、增加善惡值)。
        if (!PlayerState.Instance.GetPlayerTakeOnHandState())
        {
            Debug.Log("***********************************************");
            KarmaBase.currentKarmaValue += 0.5f;
            ClickEffect.Instance.PlayClickEffect();
            CameraShake.Instance.Shake(0.1f, 0.2f);
        }
    }
    public void OnClick<T>(T _object)//////////////////////ItemStatesManager.cs已有處理寫檔，這似乎用不到?
    {
        #region 儲存狀態到記憶體
        InteractiveObjectModel tempObj = _object as InteractiveObjectModel;
        InteractiveObjectState objState = ScriptableObject.CreateInstance<InteractiveObjectState>();

        //objState.Interact();
        objState.isInteracted = tempObj.currentObjectState;
        objState.SetItemName(tempObj.ItemName);
        objState.SetItemTag(tempObj.ItemTag);

        string json = JsonUtility.ToJson(objState);
        Debug.Log(json);
        PlayerPrefs.SetString(objState.itemName, json);
        #endregion
    }
}
#endregion

#region InteractiveItem_WithLevel
/// 可互動式道具
public class _InteractiveItemWithLevel : IClick
{
    public void OnClick()
    {
        // 如果玩家手上沒有拿著道具，可以破壞東西(產生畫面特效、增加善惡值)。
        if(!PlayerState.Instance.GetPlayerTakeOnHandState())
        {
            KarmaBase.currentKarmaValue += 1;
            ClickEffect.Instance.PlayClickEffect();
            CameraShake.Instance.Shake(0.1f, 0.2f);
        }       
    }
    public void OnClick<T>(T _object)
    {
        #region 儲存狀態到記憶體
        ObjectLevelModel tempObj = _object as ObjectLevelModel;
        InteractiveObjectWithLevel objState = ScriptableObject.CreateInstance<InteractiveObjectWithLevel>();
        int currentLevel = tempObj.currentLevel;
        
        if (currentLevel < objState.maxLevel)
        {
            objState.Interact(currentLevel);
            objState.SetItemName(tempObj.ItemName);
            objState.SetItemTag(tempObj.ItemTag);
        }

        string json = JsonUtility.ToJson(objState);
        Debug.Log(json);
        PlayerPrefs.SetString(objState.itemName, json);
        #endregion
    }
}
#endregion

#region DoNothing
public class DoNothing : IClick
{
    public void OnClick()
    {

    }
    public void OnClick<T>(T name)
    {
        
    }
}
#endregion