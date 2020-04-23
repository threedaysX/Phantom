using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//床
public class Basement_D : LightControl
{
    void Start()
    {
        //不是拿著左半面具時，鏡子面暗
        if (PlayerState.Instance.GetPlayermaskState() != mask_state.onlyLeft)
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
