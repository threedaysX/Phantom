using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WhiteBlock : CollectableItemModel
{
    public void Start()
    {
        base.Start();
        if (!EndingManager.Instance.Judge(ItemNameDictionary.Mask))
            gameObject.SetActive(false);
    }
}
