using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Perform : MonoBehaviour
{
    string AnsNotes = "23455664";
    int times = 0;
    string yourans = "";
    bool is_error = false;

    public AudioSource audiosource;

    void Awake()
    {
        audiosource = gameObject.AddComponent<AudioSource>();
        audiosource.playOnAwake = false;  //playOnAwake设为false时，通过调用play()方法启用
    }

    public void CollectNote(int inputNote)
    {
        times++;

        //如果還沒出錯就繼續計算
        if (times <= 8 && !is_error)
        {
            if ((int)AnsNotes[times - 1] != '0' + inputNote)
            {
                is_error = true;
                Debug.LogError("error" + inputNote);
            }
            yourans += inputNote;
        }
        StartCoroutine(PlaySound("piano" + inputNote));
    }
    IEnumerator PlaySound(string sound_name)
    {
        AudioClip clip = Resources.Load<AudioClip>("music/" + sound_name);
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);

        yield return new WaitForSeconds(1.5f);
        
        //第八個音結束
        if (times >= 8)
        {
            if (yourans == AnsNotes)
            {
                Debug.Log("Finish!!!!!!!!!!");
                SceneManager.LoadScene("Basement_Left");
            }
            else
            {
                Debug.Log("FALSE!!!!!!!!!!" + yourans);
                yourans = "";
                times = 0;
                is_error = false;
            }
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("Basement_Left");
    }
}
