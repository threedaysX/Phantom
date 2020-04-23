using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArrow : ArrowClick
{
    private void Start()
    {
        SetArrowBtnListener();
        sceneIndexFromArrow = 1;
    }
}
