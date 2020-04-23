using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public GameObject darkBlock;
    public GameObject light1_obj;
    public GameObject light2_obj;
    public Light light1;
    public Light light2;
    public GameObject backGround;
    public Material originMaterial;
    public Material darkbackGroundMaterial;

    public void GetDarkBackGround()
    {
        backGround.GetComponent<Renderer>().material = darkbackGroundMaterial;
        backGround.SetActive(true);
    }
    public void GetLightBackGround()
    {
        backGround.GetComponent<Renderer>().material = originMaterial;
        backGround.SetActive(false);
    }

    public void LightUp()
    {
        light1_obj.SetActive(true);
        light2_obj.SetActive(true);
        light1.gameObject.SetActive(true);
        light2.gameObject.SetActive(true);
    }
    public void LightOff()
    {
        light1_obj.SetActive(false);
        light2_obj.SetActive(false);
        light1.gameObject.SetActive(false);
        light2.gameObject.SetActive(false);
    }

    public void PlantDarkBlock()
    {
        darkBlock.SetActive(true);
        darkBlock.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 240);
    }
    public void UnPlantDarkBlock()
    {
        darkBlock.SetActive(false);
        darkBlock.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 0);
    }
}
