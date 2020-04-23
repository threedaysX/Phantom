using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightEffect : MonoBehaviour
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
            if(!flag)
            {
                StartCoroutine(LoopLightFlicker());
                flag = true;
            }
        }
    }

    public IEnumerator LoopLightFlicker()
    {
        // 每過n秒重新開始閃爍。
        yield return new WaitForSeconds(6f);
        done = true;
    }

    public void RunFlicker()
    {
        StartCoroutine(LightFlicker());
        StartCoroutine(LightFlicker_FastDark());
        StartCoroutine(LightFlicker_FastLight());
        StartCoroutine(LightFlicker_FastDark());
        StartCoroutine(LightFlicker_SlowLight());
        
        // 重新開始跑，輪迴。
        flag = false;
    }
    public IEnumerator LightFlicker()
    {
        yield return new WaitForSeconds(2f);
        light.intensity = 10f;       
    }
    public IEnumerator LightFlicker_FastDark()
    {
        yield return new WaitForSeconds(0.3f);
        light.intensity = 3f;
    }
    public IEnumerator LightFlicker_FastLight()
    {
        yield return new WaitForSeconds(0.6f);
        light.intensity = 18f;
    }
    public IEnumerator LightFlicker_SlowLight()
    {
        yield return new WaitForSeconds(1.2f);
        light.intensity = 22f;
    }
}
