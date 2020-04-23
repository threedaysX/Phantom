using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mask : CollectableItemModel
{

    public override void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClick();
            OnClickWithParameter(this);
            PlayerPrefs.SetInt("BathRoomDoorButton",1);
        }
    }
}
