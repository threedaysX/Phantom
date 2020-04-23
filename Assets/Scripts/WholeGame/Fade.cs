using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : Singleton<Fade>
{
    //只適用於，SpriteRenderer 和 text
    public void SpriteChangeColortoColor(GameObject TargetObj,Color32 StartColor,Color32 EndColor,float FadeTime)
    {
        StartCoroutine(ColorLerpCoroutine(TargetObj, StartColor, EndColor, FadeTime));
    }

    IEnumerator ColorLerpCoroutine(GameObject TargetObj, Color fromColor, Color toColor,float FadeTime)
    {
        float i = 0f;
        while (i <= 1f)
        {
            //計算上影格到這影格的時間佔dayNightDuration多少時間，並加至i上
            i += Time.deltaTime / FadeTime;

            if (TargetObj.GetComponent<SpriteRenderer>() != null)
            {
                //設定SpriteRenderer的color
                TargetObj.GetComponent<SpriteRenderer>().color = Color.Lerp(fromColor, toColor, i);
            }else if (TargetObj.GetComponent<Text>() != null)
            {
                TargetObj.GetComponent<Text>().color = Color.Lerp(fromColor, toColor, i);
            }
            yield return null;
        }
    }

}