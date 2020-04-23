using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fade : Singleton<Fade>
{

    public void ChangeColortoColor(GameObject TargetImg,Color32 StartColor,Color32 EndColor,float FadeTime)
    {
        StartCoroutine(ColorLerpCoroutine(TargetImg,StartColor, EndColor, FadeTime));
    }

    IEnumerator ColorLerpCoroutine(GameObject TargetImg,Color fromColor, Color toColor,float FadeTime)
    {
        float i = 0f;
        while (i <= 1f)
        {
            //計算上影格到這影格的時間佔dayNightDuration多少時間，並加至i上
            i += Time.deltaTime / FadeTime;

            //設定SpriteRenderer的color
            TargetImg.GetComponent<SpriteRenderer>().color = Color.Lerp(fromColor, toColor, i);

            yield return null;
        }
    }

}