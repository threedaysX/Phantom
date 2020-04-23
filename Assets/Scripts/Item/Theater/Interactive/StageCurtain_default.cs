using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCurtain_default : MonoBehaviour
{
    public GameObject stageCurain;
    public GameObject stageCurain2;
    public GameObject anothorCurain;

    void OnMouseDown()
    {
        this.gameObject.SetActive(false);
        anothorCurain.SetActive(false);
        stageCurain.SetActive(true);
        stageCurain2.SetActive(true);
    }
}
