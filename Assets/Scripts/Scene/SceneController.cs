using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;
using System.Linq;

public class SceneController : ReadSceneNames
{
    private static List<string> scenesToChange = new List<string>();
    private static List<string> sideScenes = new List<string>();

    protected string currentSceneName;
    protected int sceneIndexFromArrow;

    private void Awake()
    {
        scenesToChange = GetAllScenesName();
    }

    /// <summary>
    /// 會讀取所有場景的Name
    /// </summary>
    protected List<string> GetAllScenesName()
    {
        List<string> tempScenes = new List<string>();
        
        string[] sceneName = GetScenes().ToArray();       
        for (int i = 0; i < sceneName.Length; i++)
        {
            tempScenes.Add(sceneName[i]);
        }

        return tempScenes;
    }

    #region 大場景切換相關
    /// <summary>
    /// 切換大場景前，要先把所有場景的Name拆出需要的部分(場景傳送只傳送到這些部分，簡單來說就是目標處)
    /// </summary>
    protected List<string> GetMainSceneNameGroup()
    {
        List<string> tempScenes = new List<string>();

        // 每次轉場固定出現在最上方
        foreach (var scene in scenesToChange.Where(x => x.Contains("Up")))
        {
            tempScenes.Add(scene);
        }

        return tempScenes;
    }
    /// <summary>
    /// 切換大場景。
    /// </summary>
    protected void ChangeMainScene(string loadName)
    {
        // 先取得各大場景目的地
        List<string> mainScenes = GetMainSceneNameGroup();

        if (!string.IsNullOrWhiteSpace(loadName))
        {
            SceneManager.LoadScene(mainScenes.Find(x => x.Contains(loadName)));
        }
    }
    #endregion

    #region 小場景切換相關
    /// <summary>
    /// 取得各面小場景，把所有場景的Name取出場景的4面....
    /// </summary>
    /// <returns></returns>
    protected List<string> GetSideSceneNameGroup()
    {
        // 取得當前場景Name
        currentSceneName = SceneManager.GetActiveScene().name;
        List<string> tempScenes = new List<string>();

        // 用Regex取得當前場景名稱至底線處的前綴(代表玩家現在身在何處(大場景)，然後找出之中的每面小場景)
        Match m = Regex.Match(currentSceneName, "^(.*?)_");
        if (m.Success)
        {
            foreach(var scene in scenesToChange.Where(x => x.Contains(m.Value)))
            {
                tempScenes.Add(scene);
            }
        }

        return tempScenes;
    }

    /// <summary>
    /// 切換小場景(面)，一個場景有4面。在 SideSceneManager 實作
    /// </summary>
    protected void ChangeSceneSideInSingleSceneWithLoop()
    {
        // 取得當前場景Name
        currentSceneName = SceneManager.GetActiveScene().name;

        // 切換前，重新取得各面小場景
        sideScenes = GetSideSceneNameGroup();

        // 根據scenesToChange List中的場景編號，不斷的輪迴切換場景
        int currentIndex = sideScenes.FindIndex(x => x.Equals(currentSceneName));
        int limitRange = currentIndex + sceneIndexFromArrow;

        if (limitRange > sideScenes.Count - 1)
        {
            limitRange = 0; // 若超出範圍外，歸0，輪迴。
        }
        else if (limitRange < 0)
        {
            limitRange = sideScenes.Count - 1; // 若範圍小於1(比最初場景還小)，則回到最後的場景，輪迴。
        }
        SceneManager.LoadScene(sideScenes[limitRange]);
    }
    #endregion
}
