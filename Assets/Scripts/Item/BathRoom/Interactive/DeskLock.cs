using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeskLock : InteractiveObjectModel
{
    public GameObject desk_interact;
    private void Start()
    {
        if (EndingManager.Instance.Judge(ItemNameDictionary.Desk))
            Object.Destroy(this.gameObject);
    }
    public override void OnMouseDown()
    {
        // 當玩家手上拿著道具的時候，才可以互動。
        if (Input.GetMouseButtonDown(0) && PlayerState.Instance.GetPlayerTakeOnHandState())
        {
            string playerHandItemName = PlayerState.Instance.GetPlayerTakeOnHandItemName();
            #region  當玩家手上拿著......
            if (playerHandItemName == ItemNameDictionary.Key)
            {
                OnClick();
                OnClickWithParameter(this);

                EndingManager.Instance.key_flag = true;
                ItemStatesManager.Instance.SetAvailable_CollectableItem(ItemNameDictionary.Key, AvailableState.UnAvailable);
                ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.Desk, InteractiveState.Interacted);
                Object.Destroy(this.gameObject);

                // 正確結局: 用鑰匙開櫃子
                // Karma升級。
                EndingManager.Instance.GetEndScore();
                KarmaBase.currentKarmaLevel++;
            }
            if (playerHandItemName == ItemNameDictionary.Hammer)
            {
                OnClick();
                OnClickWithParameter(this);

                ItemStatesManager.Instance.SetAvailable_CollectableItem(ItemNameDictionary.Hammer, AvailableState.UnAvailable);
                ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.Desk, InteractiveState.Interacted);
                Object.Destroy(this.gameObject);

                // Karma升級。
                KarmaBase.currentKarmaLevel++;
            }
            #endregion

        }else if (currentObjectState == InteractiveState.UnInteracted && !EventSystem.current.IsPointerOverGameObject())
        {
            WINDOWS.current_obj = this;
            WINDOWS.Instance.OpenWindows();
            WINDOWS.Instance.SetWindows("鎖上的櫃子，好像可以用什麼破壞","明白了");

            ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.DeskLock, InteractiveState.Interacted);
            currentObjectState = InteractiveState.Interacted;
        }
    }
    public override void GoOnBtnRight()
    {
    }

}