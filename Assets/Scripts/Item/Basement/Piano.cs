using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Piano : InteractiveObjectModel
{
    public GameObject sheetMusic;

    private void Start()
    {
        if (EndingManager.Instance.Judge(ItemNameDictionary.Piano))
            sheetMusic.SetActive(true);
    }

    public override void OnMouseDown()
    {
        if(EndingManager.Instance.Judge(ItemNameDictionary.PianoScore))
            SceneManager.LoadScene("Piano_Perform");
        // 當玩家手上拿著道具的時候，才可以互動。
        if (Input.GetMouseButtonDown(0) && PlayerState.Instance.GetPlayerTakeOnHandState())
        {
            string playerHandItemName = PlayerState.Instance.GetPlayerTakeOnHandItemName();

            #region  當玩家手上拿著......
            if (playerHandItemName == ItemNameDictionary.PianoScore)
            {
                OnClick();
                OnClickWithParameter(this);

                sheetMusic.SetActive(true);

                ItemStatesManager.Instance.SetAvailable_CollectableItem(ItemNameDictionary.PianoScore, AvailableState.UnAvailable);
                
            }
            #endregion
        }

    }
}