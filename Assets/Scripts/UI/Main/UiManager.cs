using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    static UiManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (this != instance)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            Destroy(gameObject);
        }
    }
}
