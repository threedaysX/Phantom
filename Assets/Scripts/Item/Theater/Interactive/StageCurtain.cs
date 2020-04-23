using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StageCurtain : InteractiveObjectModel
{
    static bool IsPullup;
    static bool IsMoving;
    public GameObject isMessengePrint;

    float leftX, leftY, leftZ;   //分成兩個(左布幕) (右布幕)
    float rightX, rightY, rightZ;

    public GameObject anotherStageCurtain;
    GameObject leftStageCurtain;
    GameObject rightStageCurtain;
    private void Start()
    {
        IsPullup = true;
        IsMoving = false;
    }
    public override void OnMouseDown()
    {
        
        if (isMessengePrint.GetComponent<InteractiveObjectModel>().currentObjectState == InteractiveState.UnInteracted)
        {
            WINDOWS.current_obj = this;
            WINDOWS.Instance.OpenWindows();
            WINDOWS.Instance.SetWindows("布幕好像可以拉起","我知道了");
            ItemStatesManager.Instance.Set_Interact_InteractiveObject("MessengePrint", InteractiveState.Interacted);
            isMessengePrint.GetComponent<InteractiveObjectModel>().currentObjectState = InteractiveState.Interacted;
        }
        else if (Input.GetMouseButtonDown(0) && !IsMoving && !EventSystem.current.IsPointerOverGameObject())
        {
            #region  如果上拉且完成鋼琴......

            if (IsPullup == true)
                CurtainPullUp();
            else
                CurtainPullDown();

            #endregion
        }
    }
    public void CurtainPullUp()
    {
        //布幕上拉
        StartCoroutine(CurtainMove(1));
        OnClickWithParameter(this);

        //使觀眾席能改變為觀眾席(滿),讓黑色方塊出現
        if (currentObjectState == InteractiveState.Interacted) {

            ItemStatesManager.Instance.SetAvailable_CollectableItem(ItemNameDictionary.RightHalfMask, AvailableState.Available);
            //ItemStatesManager.Instance.SetAvailable_CollectableItem(ItemNameDictionary.BrokenCostume, AvailableState.Available);

            ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.leftStageCurtain, InteractiveState.UnInteracted);
            ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.rightStageCurtain, InteractiveState.UnInteracted);

            ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.StageBackground, InteractiveState.Interacted);//使舞台背景能改變
            ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.RMask_wear, InteractiveState.Interacted);
            //Debug.Log("Hello:\n");
            currentObjectState = InteractiveState.UnInteracted;
            //ItemStatesManager.Instance.Set_Interact_InteractiveObject(ItemNameDictionary.Auditorium, InteractiveState.Interacted);
        }
    }
    public void CurtainPullDown()
    {
        //布幕下拉
        StartCoroutine(CurtainMove(-1));
    }
    IEnumerator CurtainMove(int signed) //1是上拉,-1是下拉
    {
        if (gameObject.name == "布幕(右)")
        {
            leftStageCurtain=anotherStageCurtain;
            rightStageCurtain=gameObject;
        }
        else if(gameObject.name == "布幕(左)")
        {
            leftStageCurtain = gameObject;
            rightStageCurtain = anotherStageCurtain;
        }

        IsMoving = true;
        leftX = leftStageCurtain.gameObject.transform.localPosition.x;
        leftY = leftStageCurtain.gameObject.transform.localPosition.y;
        leftZ = leftStageCurtain.gameObject.transform.localPosition.z;
        rightX = rightStageCurtain.gameObject.transform.localPosition.x;
        rightY = rightStageCurtain.gameObject.transform.localPosition.y;
        rightZ = rightStageCurtain.gameObject.transform.localPosition.z;

        for (float i = 0; i < 30; i+=1)
        {
            leftStageCurtain.gameObject.transform.localPosition = Vector3.MoveTowards(leftStageCurtain.transform.localPosition, new Vector3(leftX + 320 * signed *1, leftY, leftZ), i);
            rightStageCurtain.gameObject.transform.localPosition = Vector3.MoveTowards(rightStageCurtain.transform.localPosition, new Vector3(rightX + 280 * signed *-1, rightY, rightZ), i);
            yield return 0;
        }

        IsPullup = !IsPullup;
        IsMoving = false;
    }

}
