using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemStateData : ScriptableObject
{
    public string itemName;
    public string itemTag;

    public void SetItemName(string itemname)
    {
        this.itemName = itemname;
    }
    public void SetItemTag(string itemtag)
    {
        this.itemTag = itemtag;
    }

    public abstract bool Interact();

    public abstract void Reset();
}
