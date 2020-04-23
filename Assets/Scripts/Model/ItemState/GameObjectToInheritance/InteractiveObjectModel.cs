using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 可互動物件(不可破壞型)繼承此。
public abstract class InteractiveObjectModel : ItemModel
{
    public GameObject unInteractedEffect;
    public GameObject interactedEffect;

    public InteractiveState currentObjectState = InteractiveState.UnInteracted;

    void Start()
    {
        _IClick = new _InteractiveItem();
        ItemTag = "InteractiveObject";
    }

    private void ResetObjectState()
    {
        switch(currentObjectState)
        {
            case InteractiveState.UnInteracted:
                unInteractedEffect.SetActive(true);
                break;
            case InteractiveState.Interacted:
                interactedEffect.SetActive(true);
                break;
        }
    }

    public abstract void OnMouseDown();
    public virtual void GoOnBtnRight() {}
}
