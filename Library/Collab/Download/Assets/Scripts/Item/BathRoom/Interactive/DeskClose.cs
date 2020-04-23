using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeskClose : MonoBehaviour
{
    public GameObject open_desk;
    public GameObject inner_obj;
    void OnMouseUp()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            this.gameObject.SetActive(false);
            open_desk.SetActive(true);
            if (inner_obj != null && inner_obj.gameObject.GetComponent<CollectableItemModel>().availableState == AvailableState.Available)
                inner_obj.SetActive(true);
        }
    }
}
