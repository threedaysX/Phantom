using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New InteractiveObject", menuName = "InteractiveObject")]
public class InteractiveObjectState : ItemStateData
{
    public InteractiveState isInteracted = InteractiveState.UnInteracted;

    public override bool Interact()
    {
        if (isInteracted == InteractiveState.UnInteracted)
        {
            isInteracted = InteractiveState.Interacted;
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void Reset()
    {
        isInteracted = InteractiveState.UnInteracted;
    }
}


[System.Serializable]
public enum InteractiveState
{
    UnInteracted = 0,
    Interacted = 1
}