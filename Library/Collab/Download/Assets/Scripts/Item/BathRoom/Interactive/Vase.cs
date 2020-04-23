using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//花瓶
public class Vase : InteractiveObjectModel
{
    public GameObject water_obj;
    private void Start()
    {
        if (currentObjectState == InteractiveState.Interacted)
            water_obj.SetActive(true);
    }

    public override void OnMouseDown()
    {
        // 當玩家手上拿著道具的時候，才可以互動。
        if (Input.GetMouseButtonDown(0) && PlayerState.Instance.GetPlayerTakeOnHandState())
        {
            string playerHandItemName = PlayerState.Instance.GetPlayerTakeOnHandItemName();

            #region  當玩家手上拿著......
            if (playerHandItemName == ItemNameDictionary.ToothMug_Water)
            {
                OnClick();
                OnClickWithParameter(this);                                       
                this.transform.Find(ItemNameDictionary.Vase_Water).gameObject.SetActive(true);

                ItemStatesManager.Instance.SetAvailable_CollectableItem(ItemNameDictionary.ToothMug_Water, AvailableState.UnAvailable);
                ItemStatesManager.Instance.SetAvailable_CollectableItem(ItemNameDictionary.Key, AvailableState.Available);
                ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.Vase, InteractiveState.Interacted);
            }
            #endregion
        }
    }
}
