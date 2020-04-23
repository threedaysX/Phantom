using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Christine : InteractiveObjectModel
{
    private void Start()
    {
        if (currentObjectState == InteractiveState.Interacted)
            this.gameObject.SetActive(false);
    }
    public override void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.Christine, InteractiveState.Interacted);
            Fade.Instance.SpriteChangeColortoColor(gameObject,this.GetComponent<SpriteRenderer>().color, new Color(255, 255, 255, 0),2.0f);
        }
    }
}
