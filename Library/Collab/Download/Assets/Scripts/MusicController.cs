using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : Singleton<MusicController>
{
    Coroutine co;
    bool isPlaying=false;
    Scene scene;
    bool isNearPiano=false; 

    private void Update()
    {
        scene = SceneManager.GetActiveScene();
        string[] frontName = (scene.name).Split('_');

        if (frontName[1] == "Left")
            isNearPiano = true;
        else
            isNearPiano = false;

        if (frontName[0] == "Basement")
        {
            if (!isPlaying)
            {
                if (EndingManager.Instance.EndScore() >= 3)
                {
                    Debug.Log("Happy Ending");
                    StartCo("12345678");
                }
                else
                {
                    Debug.Log("Normal or Bad Ending");
                    StartCo("87654321");
                }
            }
        }
        else
        {
            if (isPlaying)
                EndCo();
        }
    }

    public void StartCo(string playString)
    {
        isPlaying = true;
        co = StartCoroutine(PlayMusic(playString));
    }

    public void EndCo()
    {
        StopCoroutine(co);
        isPlaying = false;
    }

    IEnumerator PlayMusic(string PlayString)
    {
        while (true)
        {
            for (int i = 0; i < PlayString.Length; i++)
            {
                AudioClip now_clip = Resources.Load<AudioClip>("music/" + "piano" + PlayString[i]);
                //AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);

                AudioSource source = this.gameObject.GetComponent<AudioSource>();
                source.clip = now_clip;

                if (isNearPiano)
                    source.volume = 1;
                else
                    source.volume = 0.2f;

                source.Play();
                yield return new WaitForSeconds(2f);
                source.Stop();

            }
        }
    }
}
