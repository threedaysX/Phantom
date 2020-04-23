using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sink : InteractiveObjectModel
{
    public override void OnMouseDown()
    {
        // 當玩家手上拿著道具的時候，才可以互動。
        if (Input.GetMouseButtonDown(0) && PlayerState.Instance.GetPlayerTakeOnHandState())
        {
            string playerHandItemName = PlayerState.Instance.GetPlayerTakeOnHandItemName();

            #region  當玩家手上拿著......
            if (playerHandItemName == ItemNameDictionary.ToothMug)
            {
                OnClick();
                OnClickWithParameter(this);

                ItemStatesManager.Instance.SetAvailable_CollectableItem(ItemNameDictionary.ToothMug, AvailableState.UnAvailable);
                ItemStatesManager.Instance.SetAvailable_CollectableItem(ItemNameDictionary.ToothMug_Water, AvailableState.Available);
            }
            #endregion
        }
    }
}
