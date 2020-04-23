using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptScreen : InteractiveObjectModel
{
    // Start is called before the first frame update
    public override void OnMouseDown()
    {
        this.gameObject.SetActive(false);
    }
    private void Start()
    {
        if (currentObjectState==InteractiveState.Interacted)
            LoadResourceImage("劇本畫面(完成)");
    }
}