using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeskOpen : MonoBehaviour
{
    public GameObject inner_obj_1;
    public GameObject inner_obj_2;
    public GameObject close_desk;
    void OnMouseUp()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            this.gameObject.SetActive(false);
            close_desk.SetActive(true);
            if(inner_obj_1 !=null)
                inner_obj_1.SetActive(false);
            if (inner_obj_2 != null)
                inner_obj_2.SetActive(false);
        }
    }
}
