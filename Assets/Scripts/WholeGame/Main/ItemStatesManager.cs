using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class ItemStatesManager : Singleton<ItemStatesManager>
{
    private static bool whenGameStartOnceTime = false;
    static ItemStatesManager instance;
    private void Awake()
    {
        // 每次重開遊戲的時候，把存檔清空，只清空一次。
        if (!whenGameStartOnceTime)
        {
            PlayerPrefs.DeleteAll();
            whenGameStartOnceTime = true;
        }
        if (instance == null)
        {
            instance = this;
        }
        else if (this != instance)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 某些關卡觸發後，會啟用可收集道具的可使用狀態，後重寫儲存資料，並重新儲存檔案
    /// 若原本為 [已啟用]，呼叫後會變成 [未啟用]； 反之亦同。
    /// </summary>
    /// <param name="toWriteItemName"></param>
    public void SetAvailable_CollectableItem(string toWriteItemName, AvailableState toWriteAvailableState)
    {
        string loadItem = PlayerPrefs.GetString(toWriteItemName);
        CollectableItemState toWriteItem = ScriptableObject.CreateInstance<CollectableItemState>();
        if (!string.IsNullOrEmpty(loadItem))
        {
            JsonUtility.FromJsonOverwrite(loadItem, toWriteItem);           
        }

        toWriteItem.isAvailable = toWriteAvailableState;
        //toWriteItem.isUsed = toWriteUseableState;
        toWriteItem.SetItemName(toWriteItemName);
        toWriteItem.SetItemTag("CollectableItem");
        string json = JsonUtility.ToJson(toWriteItem);
        PlayerPrefs.SetString(toWriteItem.itemName, json);

        Recursive_Find_Obj(GameObject.Find("ItemList"), toWriteItem.itemName, toWriteAvailableState);
        bag.Instance.RemoveItem(toWriteItemName);//因為物體可能已經被刪掉而在ItemList找不到
    }

    public void Recursive_Find_Obj(GameObject parentGameObject, string findName, AvailableState toWriteState)
    {
        if (parentGameObject.name == findName)
        {
            if (toWriteState == AvailableState.Available)
                parentGameObject.SetActive(true);
            else
                parentGameObject.SetActive(false);
            return;
        }

        foreach (Transform child in parentGameObject.transform) {
            Recursive_Find_Obj(child.gameObject, findName, toWriteState);
        }
    }

    /// <summary>
    /// 切換並儲存InteractiveObjectModel狀態
    /// </summary>
    /// <param name="toWriteItemName"></param>
    public void Set_Interact_InteractiveObject(string toWriteItemName, InteractiveState setState)
    {
        string loadItem = PlayerPrefs.GetString(toWriteItemName);
        InteractiveObjectState toWriteItem = ScriptableObject.CreateInstance<InteractiveObjectState>();
        if (!string.IsNullOrEmpty(loadItem))
        {
            JsonUtility.FromJsonOverwrite(loadItem, toWriteItem);
        }
        if (setState == InteractiveState.Interacted)
            toWriteItem.Interact();
        else
            toWriteItem.Reset();

        toWriteItem.SetItemName(toWriteItemName);
        toWriteItem.SetItemTag("InteractiveObject"); 
        string json = JsonUtility.ToJson(toWriteItem);
        PlayerPrefs.SetString(toWriteItem.itemName, json);
    }


    /// <summary>
    /// 切換並儲存InteractiveObjectModel狀態
    /// </summary>
    /// <param name="toWriteItemName"></param>
    public void Set_LevelObject(string toWriteItemName, InteractiveState setState)
    {
        // string loadItem = PlayerPrefs.GetString(toWriteItemName);
        // CollectableItemState toWriteItem = ScriptableObject.CreateInstance<CollectableItemState>();
        // if (!string.IsNullOrEmpty(loadItem))
        // {
        //     JsonUtility.FromJsonOverwrite(loadItem, toWriteItem);
        // }

        // toWriteItem.isAvailable = toWriteAvailableState;
        // //toWriteItem.isUsed = toWritePickableState;
        // toWriteItem.SetItemName(toWriteItemName);
        // toWriteItem.SetItemTag("CollectableItem");
        // string json = JsonUtility.ToJson(toWriteItem);
        // PlayerPrefs.SetString(toWriteItem.itemName, json);

        // Recursive_Find_Obj(GameObject.Find("ItemList"), toWriteItem.itemName, toWriteAvailableState);
        // bag.Instance.RemoveItem(toWriteItemName);//因為物體可能已經被刪掉而在ItemList找不到
    }
}
