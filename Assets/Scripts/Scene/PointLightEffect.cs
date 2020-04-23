using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLightEffect : MonoBehaviour
{
    public new Light light;

    private bool done = false;
    private bool flag = false;

    // Start is called before the first frame update
    void Update()
    {
        if (!done)
        {
            RunFlicker();
        }
        else
        {
            if (!flag)
            {
                StartCoroutine(LoopLightFlicker());
                flag = true;
            }
        }
    }

    public IEnumerator LoopLightFlicker()
    {
        // 每過n秒重新開始閃爍。
        yield return new WaitForSeconds(5f);
        done = true;
    }

    public void RunFlicker()
    {
        StartCoroutine(LightFlicker_SlowDark());
        StartCoroutine(LightFlicker_SlowLight());
        StartCoroutine(LightFlicker_SlowMDark());

        // 重新開始跑，輪迴。
        flag = false;
    }
    public IEnumerator LightFlicker_SlowDark()
    {
        yield return new WaitForSeconds(1.2f);
        light.intensity = 0.3f;
    }
    public IEnumerator LightFlicker_SlowMDark()
    {
        yield return new WaitForSeconds(1.2f);
        light.intensity = 0.6f;
    }
    public IEnumerator LightFlicker_SlowLight()
    {
        yield return new WaitForSeconds(0.8f);
        light.intensity = 1f;
    }
}
