using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : Singleton<EndingManager>
{
    private int value = 0;

    public int EndScore()
    {
        if (Judge(ItemNameDictionary.Key))
            value++;
        if (Judge(ItemNameDictionary.FeatherPen))
            value++;
        if (Judge(ItemNameDictionary.LeadingLady))
            value++;

        return value;

    }

    public bool Judge(string obj_name)
    {
        string loadItem = PlayerPrefs.GetString(obj_name);

        if (!string.IsNullOrEmpty(loadItem))
        {
            CollectableItemState toLoadItem = ScriptableObject.CreateInstance<CollectableItemState>();
            JsonUtility.FromJsonOverwrite(loadItem, toLoadItem);

            if (toLoadItem.itemTag == "CollectableItem")
            {
                if (toLoadItem.isAvailable == AvailableState.UnAvailable)
                    return true;
            }
            else 
            {
                InteractiveObjectState toLoadItem2 = ScriptableObject.CreateInstance<InteractiveObjectState>();
                JsonUtility.FromJsonOverwrite(loadItem, toLoadItem2);

                if (toLoadItem2.itemTag == "InteractiveObject")
                    if (toLoadItem2.isInteracted == InteractiveState.Interacted)
                        return true;
            }
        }

        return false;

    }
}
