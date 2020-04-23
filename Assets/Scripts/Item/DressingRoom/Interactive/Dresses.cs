using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Dresses: Singleton<Dresses>
{
    public GameObject PhantomC;
    public GameObject WorkerC;
    public GameObject LeadingLadyC;
    public GameObject OtherC;

    public void ChangeCloth(string dressName)
    {
        switch (dressName)
        {
            case "PhantomCostume":
                ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.PhantomCostume, InteractiveState.Interacted);
                ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.WorkerClothes, InteractiveState.UnInteracted);
                ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.LeadingLady, InteractiveState.UnInteracted);
                ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.OtherCloth, InteractiveState.UnInteracted);
                PhantomC.gameObject.SetActive(false);
                WorkerC.gameObject.SetActive(true);
                LeadingLadyC.gameObject.SetActive(true);
                OtherC.gameObject.SetActive(true);
                break;

            case "WorkerClothes":
                ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.PhantomCostume, InteractiveState.UnInteracted);
                ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.WorkerClothes, InteractiveState.Interacted);
                ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.LeadingLady, InteractiveState.UnInteracted);
                ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.OtherCloth, InteractiveState.UnInteracted);
                PhantomC.gameObject.SetActive(true);
                WorkerC.gameObject.SetActive(false);
                LeadingLadyC.gameObject.SetActive(true);
                OtherC.gameObject.SetActive(true);
                break;

            case "LeadingLady":
                ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.PhantomCostume, InteractiveState.UnInteracted);
                ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.WorkerClothes, InteractiveState.UnInteracted);
                ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.LeadingLady, InteractiveState.Interacted);
                ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.OtherCloth, InteractiveState.UnInteracted);
                PhantomC.gameObject.SetActive(true);
                WorkerC.gameObject.SetActive(true);
                LeadingLadyC.gameObject.SetActive(false);
                OtherC.gameObject.SetActive(true);               
                break;

            case "OtherCloth":
                ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.PhantomCostume, InteractiveState.UnInteracted);
                ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.WorkerClothes, InteractiveState.UnInteracted);
                ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.LeadingLady, InteractiveState.UnInteracted);
                ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.OtherCloth, InteractiveState.Interacted);
                PhantomC.gameObject.SetActive(true);
                WorkerC.gameObject.SetActive(true);
                LeadingLadyC.gameObject.SetActive(true);
                OtherC.gameObject.SetActive(false);
                break;
        }

    }
}
