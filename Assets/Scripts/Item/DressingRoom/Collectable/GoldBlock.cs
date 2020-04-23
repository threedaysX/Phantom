using UnityEngine;
using UnityEngine.EventSystems;

public class GoldBlock : CollectableItemModel
{
    public override void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            OnClick();
            OnClickWithParameter(this);
            EndingManager.Instance.GetEndScore();
        }
    }
}
