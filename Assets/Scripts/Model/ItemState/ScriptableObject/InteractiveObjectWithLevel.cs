using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectWithLevel : ItemStateData
{
    public int currentLevel = 0;
    public int maxLevel = 3;

    public override bool Interact()
    {
        return true;
    }
    public bool Interact(int itemLevel)
    {
        if ((itemLevel + 1) <= maxLevel)
        {
            currentLevel = itemLevel + 1;
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void Reset()
    {
        currentLevel = 0;
    }
}
