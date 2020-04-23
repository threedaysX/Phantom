using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : Singleton<MusicController>
{
    Coroutine co;
    bool isPlaying=false;
    Scene scene;
    AudioSource source ;

    private void Start()
    {
        source = this.gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        scene = SceneManager.GetActiveScene();
        string[] frontName = (scene.name).Split('_');

        if (isPlaying && frontName[1] == "Left") {
            source.volume = 1;
        }
        else {
            source.volume = 0.5f;
        }

        if (frontName[0] == "Basement")
        {
            if (!isPlaying)
            {
                if (EndingManager.Instance.Judge(ItemNameDictionary.Piano)) {
                    isPlaying = true;
                    AudioClip now_clip;

                    EndingManager.Instance.GetEndScore();

                    if (EndingManager.Instance.GetendingScore() >= 3)
                        now_clip = Resources.Load<AudioClip>("music/" + "ThinkOfMe");
                    
                    else
                        now_clip = Resources.Load<AudioClip>("music/" + "Phantom_Overture");
                    
                    source.clip = now_clip;
                    source.Play();
                }
                else
                {
                    EndingManager.Instance.GetEndScore();
                    
                    if (EndingManager.Instance.GetendingScore() >= 3)
                    {
                        Debug.Log("Happy Ending");
                        string[] AnsNotes = { "F4#", "G4", "F4#", "F4#", "E4", "C4#", "D4", "D4", "D4", "D5", "A4" };
                        StartCo(AnsNotes);
                    }
                    else
                    {
                        Debug.Log("Normal or Bad Ending");
                        string[] AnsNotes = { "F4#", "G4", "F4#", "F4#", "E4", "C4#", "D4", "D4", "D4", "D5", "A4" };
                        StartCo(AnsNotes);
                    }
                }
            }
        }
        else
        {
            if (isPlaying)
                EndCo();
        }
    }

    public void StartCo(string[] playString)
    {
        isPlaying = true;
        co = StartCoroutine(PlayMusic(playString));
    }

    public void EndCo()
    {
        StopCoroutine(co);
        isPlaying = false;
    }

    IEnumerator PlayMusic(string[] PlayString)
    {
        while (true)
        {
            for (int i = 0; i < PlayString.Length; i++)
            {
                AudioClip now_clip = Resources.Load<AudioClip>("music/" + PlayString[i]);
                //AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);

                source.clip = now_clip;

                source.Play();
                yield return new WaitForSeconds(0.5f);
                source.Stop();

            }
            yield return new WaitForSeconds(1.5f);
        }
    }
}
