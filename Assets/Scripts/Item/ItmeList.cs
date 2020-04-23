using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//並沒有把讀出來的資料塞回每個物件
public class ItmeList : MonoBehaviour
{
    private void Awake()
    {
        Recursive_Set_All_ItemList_Item(GameObject.Find("ItemList"));
        SetWindowsFalse();
    }

    public void Recursive_Set_All_ItemList_Item(GameObject parentGameObject)
    {
        //如果是可蒐集物件CollectableItemModel
        if (parentGameObject.gameObject.tag == "CollectableItem")
        {

            CollectableItemModel current_CollectableItemModel = parentGameObject.gameObject.GetComponent<CollectableItemModel>();
            string loadItem = PlayerPrefs.GetString(parentGameObject.name);

            if (!string.IsNullOrEmpty(loadItem))
            {
                CollectableItemState toLoadItem = ScriptableObject.CreateInstance<CollectableItemState>();
                JsonUtility.FromJsonOverwrite(loadItem, toLoadItem);
                current_CollectableItemModel.availableState = toLoadItem.isAvailable;

                if (toLoadItem.isUsed == UseableState.Used)
                    Object.Destroy(parentGameObject.gameObject);

                else if (current_CollectableItemModel.availableState == AvailableState.Available)
                    parentGameObject.gameObject.SetActive(true);
                else
                    parentGameObject.gameObject.SetActive(false);
            }
        }

        //如果是互動物件InteractiveObjectModel
        if (parentGameObject.gameObject.tag == "InteractiveObject" || parentGameObject.gameObject.tag == "Hole")
        {
            InteractiveObjectModel current_InteractiveObjectModel = parentGameObject.gameObject.GetComponent<InteractiveObjectModel>();
            string loadObject = PlayerPrefs.GetString(parentGameObject.name);

            if (!string.IsNullOrEmpty(loadObject))
            {
                InteractiveObjectState toLoadObj = ScriptableObject.CreateInstance<InteractiveObjectState>();
                JsonUtility.FromJsonOverwrite(loadObject, toLoadObj);
                current_InteractiveObjectModel.currentObjectState = toLoadObj.isInteracted;
            }
        }

        foreach (Transform child in parentGameObject.transform)
        {
            Recursive_Set_All_ItemList_Item(child.gameObject);
        }
    }

    private void SetWindowsFalse()
    {
        Transform windows_canvas = GameObject.Find("Windows_Canvas").transform;
        foreach (Transform currentItem in windows_canvas)
        {
            currentItem.gameObject.SetActive(false);
        }
    }
}
