using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBackground : InteractiveObjectModel
{
    // Start is called before the first frame update
    public override void OnMouseDown()
    {

    }
    private void Start()
    {
        Debug.Log(currentObjectState);
        if(currentObjectState==InteractiveState.Interacted)
        {
            LoadResourceImage("舞台背景(改變後)");
        }
    }
}
