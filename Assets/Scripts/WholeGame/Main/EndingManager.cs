using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : Singleton<EndingManager>
{
    public  int endingScore = 0;
    public  bool key_flag = false;      //DeskLock
    public  bool pen_flag = false;      //UnfinishedScript
    public  bool dress_flag = false;
    public  bool lady_flag = false;     //DressingTable_for_Comb、DressingTable_for_Perfume

    public int GetendingScore()
    {
        return endingScore;
    }

    public void GetEndScore()
    {
        endingScore = 0;

        if (key_flag)
            endingScore++;

        if (pen_flag)
            endingScore++;

        if (lady_flag)
            endingScore++;

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
