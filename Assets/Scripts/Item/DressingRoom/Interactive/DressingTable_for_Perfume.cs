using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DressingTable_for_Perfume : InteractiveObjectModel
{
    private void Start()
    {
        if (EndingManager.Instance.Judge(ItemNameDictionary.DressingTable))
            LoadResourceImage("梳妝台(碎)");
    }

    public override void OnMouseDown()
    {
        ItemName = "DressingTable_for_Perfume";

        if (Input.GetMouseButtonDown(0) && PlayerState.Instance.GetPlayerTakeOnHandState())
        {
            string playerHandItemName = PlayerState.Instance.GetPlayerTakeOnHandItemName();

            if (playerHandItemName == ItemNameDictionary.Perfume)
            {
                ItemStatesManager.Instance.SetAvailable_CollectableItem(ItemNameDictionary.Perfume, AvailableState.UnAvailable);
                DressingTable.Instance.perfumeOK = true;
                if (DressingTable.Instance.combOK)
                {
                    OnClick();
                    OnClickWithParameter(this);
                    LoadResourceImage("梳妝台(碎)");

                    if (EndingManager.Instance.Judge(ItemNameDictionary.LeadingLady))
                        EndingManager.Instance.lady_flag = true;
                    ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.DressingTable, InteractiveState.Interacted);
                    ItemStatesManager.Instance.SetAvailable_CollectableItem(ItemNameDictionary.GoldBlock, AvailableState.Available);                   
                }
            }
        }
    }
}
