using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mask_Inte : InteractiveObjectModel
{
    public override void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.Mask, InteractiveState.Interacted);
        }
    }
}
