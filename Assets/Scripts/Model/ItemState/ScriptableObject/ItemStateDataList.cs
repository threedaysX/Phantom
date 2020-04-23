using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemDataList", menuName = "GameSave/ItemDataList")]
public class ItemStateDataList : ScriptableObject
{
    public ItemStateData[] itemStateData = new ItemStateData[0];
    
    public void Reset() 
    {
        for (int i = 0; i < itemStateData.Length; i++)
        {
            itemStateData[i].Reset();
        }
    }
}
