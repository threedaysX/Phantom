using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poster : InteractiveObjectModel
{
    void Start()
    {
        if (currentObjectState == InteractiveState.Interacted)
            LoadResourceImage("公演海報(殘骸)");
        if(PlayerState.Instance.GetPlayermaskState() == mask_state.onlyLeft)
            LoadResourceImage("海報(放上右半面具)");
    }

    public override void OnMouseDown()
    {

    }
}
