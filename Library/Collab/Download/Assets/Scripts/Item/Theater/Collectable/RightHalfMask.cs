using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHalfMask : CollectableItemModel
{
    public override void OnMouseDown()
    {
        OnClickWithParameter(this);
    }
}
