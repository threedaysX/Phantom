using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//鏡子面
public class Basement_R : LightControl
{
    void Start()
    {
        //不是拿著右半面具時，鏡子面暗
        if (PlayerState.Instance.GetPlayermaskState() != mask_state.onlyRight)
        {
            PlantDarkBlock();
            LightOff();
        }
        else
        {
            UnPlantDarkBlock();
            GetDarkBackGround();
            LightUp();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
