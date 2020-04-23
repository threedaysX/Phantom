using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auditorium : InteractiveObjectModel
{
    public override void OnMouseDown()
    {
    }
    private void Start()
    {
        if (currentObjectState == InteractiveState.Interacted)
        {
            LoadResourceImage("觀眾席(滿)");
        }
    }
}