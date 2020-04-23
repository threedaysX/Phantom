using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Perform : Singleton<Perform>
{
    //Do#
    //Fa#

    string[] AnsNotes ={"F4#", "G4","F4#", "F4#", "E4", "C4#",  "D4", "D4", "D4", "D5", "A4" };//低4~高2 包括升降音


    //4614
    //5725
    //5725
    //6136

    //6146

    //6136
    //5725
    //5725
    //4614
    
    int times = 0;
    bool is_error = false;

    AudioSource audiosource;

    void Awake()
    {
        audiosource = gameObject.AddComponent<AudioSource>();
        //audiosource = MusicController.Instance.GetComponent<AudioSource>();
        audiosource.playOnAwake = false;  //playOnAwake设为false时，通过调用play()方法启用
    }

    public void CollectNote(string inputNote)
    {
        //如果還沒出錯就繼續計算
        if (times < AnsNotes.Length)
        {
            if (inputNote != AnsNotes[times])
            {
                times = 0;
            }
        }

        StartCoroutine(PlaySound(inputNote));
        times++;
    }
    IEnumerator PlaySound(string sound_name)
    {
        AudioClip clip = Resources.Load<AudioClip>("music/" + sound_name);
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);

        yield return new WaitForSeconds(1.5f);
        
        //第八個音結束
        if (times == AnsNotes.Length)
        {
            ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.Piano, InteractiveState.Interacted);
            Debug.Log("Finish!!!!!!!!!!");
            SceneManager.LoadScene("Basement_Left");
        }
    }
    
    public void Back()
    {
        SceneManager.LoadScene("Basement_Left");
    }
    
}
