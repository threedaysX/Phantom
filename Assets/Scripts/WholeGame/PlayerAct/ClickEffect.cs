using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickEffect : Singleton<ClickEffect>
{
    public ParticleSystem particle;
    private new Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        particle.Stop();
        if (camera == null)
        {
            camera = Camera.main;
        }
        if (particle == null)
        {
            
        }
    }

    public void PlayClickEffect()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 1.5f;
        var targetPos = camera.ScreenToWorldPoint(mousePos);
        particle.transform.position = targetPos;
        GameObject cloneObj = Instantiate(particle, targetPos, Quaternion.identity).gameObject;

        // 跑完特效後，1秒後刪除剛剛生成的物件(特效)
        Destroy(cloneObj, 1.0f);
    }
}
