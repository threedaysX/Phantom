using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasementDoor : SceneController
{
    void OnMouseDown()
    {
        if (EndingManager.Instance.Judge(ItemNameDictionary.Piano) && EndingManager.Instance.Judge(ItemNameDictionary.MusicBox))
            SceneManager.LoadScene("DressingRoom_Up");
    }
}
