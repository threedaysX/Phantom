using System.Collections.Generic;
using UnityEngine;

public class ReadSceneNames : MonoBehaviour
{
    private List<string> allScenes;

    private List<string> ReadNames()
    {
        List<string> temp = new List<string>();
        int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        for (int i = 0; i < sceneCount; i++)
        {
            temp.Add(System.IO.Path.GetFileNameWithoutExtension(UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i)));
        }
        return temp;
    }

    protected List<string> GetScenes()
    {
        allScenes = ReadNames();
        return allScenes;
    }
    
}
