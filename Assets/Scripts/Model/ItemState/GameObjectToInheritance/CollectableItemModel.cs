using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// 可收集道具繼承此。
public class CollectableItemModel : ItemModel
{
    public AvailableState availableState = AvailableState.Available;
    public UseableState usedState = UseableState.UnUse;

    public void Start()
    {
        _IClick = new _CollectableItem();
        ItemTag = "CollectableItem";
    }

    public virtual void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            OnClick();
            OnClickWithParameter(this);
        }
    }
}
