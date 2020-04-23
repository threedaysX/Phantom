using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DressingTable_for_Comb : InteractiveObjectModel
{
    private void Start()
    {
        if (EndingManager.Instance.Judge(ItemNameDictionary.DressingTable))
            LoadResourceImage("梳妝台(碎)");
    }

    public override void OnMouseDown()
    {
        ItemName = "DressingTable_for_Comb";

        if (Input.GetMouseButtonDown(0) && PlayerState.Instance.GetPlayerTakeOnHandState())
        {
            string playerHandItemName = PlayerState.Instance.GetPlayerTakeOnHandItemName();

            if (playerHandItemName == ItemNameDictionary.Comb)
            {
                ItemStatesManager.Instance.SetAvailable_CollectableItem(ItemNameDictionary.Comb, AvailableState.UnAvailable);
                DressingTable.Instance.combOK = true;
                if (DressingTable.Instance.perfumeOK)
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
public class DressingTable:  Singleton<DressingTable>
{
    public bool combOK = false;
    public bool perfumeOK = false;
}
