using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : Singleton<CameraShake>
{
    public Camera mainCam;

    float shakeAmount = 0;

    private void Awake()
    {
        if(mainCam == null)
        {
            mainCam = Camera.main;
        }
    }

    public void Shake(float amt, float length)
    {
        shakeAmount = amt;
        InvokeRepeating("DoShake", 0, 0.01f);
        Invoke("StopShake", length);
    }

    private void DoShake()
    {
        if (shakeAmount > 0)
        {
            Vector3 cameraPos = mainCam.transform.position;

            float shakeAmtX = Random.value * shakeAmount * 2 - shakeAmount;
            float shakeAmtY = Random.value * shakeAmount * 2 - shakeAmount;
            cameraPos.x += shakeAmtX;
            cameraPos.y += shakeAmtY;

            mainCam.transform.position = cameraPos;
        }
    }

    private void StopShake()
    {
        CancelInvoke("DoShake");
        mainCam.transform.localPosition = Vector3.zero;
    }
}
