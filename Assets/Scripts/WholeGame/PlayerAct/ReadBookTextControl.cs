using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadBookTextControl : Singleton<ReadBookTextControl>
{
    public GameObject Memory_1;
    public GameObject Memory_2;
    public GameObject Memory_3;
    public GameObject Memory_4;
    public GameObject Memory_5;
    public GameObject Memory_6;
    
    private static int ReadBookIndex = 0;
    private bool flag = false;
    private bool activeFlag = false;

    public void ResetBook()
    {
        Memory_1.SetActive(false);
        Memory_2.SetActive(false);
        Memory_3.SetActive(false);
        Memory_4.SetActive(false);
        Memory_5.SetActive(false);
    }

    public void GetBookText(int bookNum)
    {
        ResetBook();
        switch (bookNum)
        {
            case 1:
                Memory_1.SetActive(true);
                break;
            case 2:
                Memory_2.SetActive(true);
                break;
            case 3:
                Memory_3.SetActive(true);
                break;
            case 4:
                Memory_4.SetActive(true);
                break;
            case 5:
                Memory_5.SetActive(true);
                break;
            case 6:
                Memory_6.SetActive(true);
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
        }
    }
}
