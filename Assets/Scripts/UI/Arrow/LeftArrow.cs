using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArrow : ArrowClick
{
    private void Start()
    {
        SetArrowBtnListener();
        sceneIndexFromArrow = -1;
    }
}
