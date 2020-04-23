using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeskClose : MonoBehaviour
{
    public GameObject open_desk;
    public GameObject inner_obj_1;
    public GameObject inner_obj_2;
    void OnMouseUp()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            this.gameObject.SetActive(false);
            open_desk.SetActive(true);
            if (inner_obj_1 != null && inner_obj_1.gameObject.GetComponent<CollectableItemModel>().availableState == AvailableState.Available)
                inner_obj_1.SetActive(true);
            if (inner_obj_2 != null && inner_obj_2.gameObject.GetComponent<CollectableItemModel>().availableState == AvailableState.Available)
                inner_obj_2.SetActive(true); 
        }
    }
}
