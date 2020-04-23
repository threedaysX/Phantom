using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask_Coll : CollectableItemModel
{
    public GameObject WhiteBlock;
    bool falling=false;
    public override void OnMouseDown()
    {
        if (EndingManager.Instance.Judge(ItemNameDictionary.Mask))
            return;
        if (Input.GetMouseButtonDown(0) && !falling)
        {
            falling = true;
            WhiteBlock.SetActive(true);
            StartCoroutine(Tween(1.0f, new Vector3(WhiteBlock.transform.position.x, WhiteBlock.transform.position.y + 3.5f, WhiteBlock.transform.position.z), WhiteBlock.transform.position));
        }
    }

    IEnumerator Tween(float duration, Vector3 posStart, Vector3 posEnd)
    {
        var timeStart = Time.time;
        var timeEnd = timeStart + duration;
        while (Time.time < timeEnd)
        {
            var t = Mathf.InverseLerp(timeStart, timeEnd, Time.time);
            var v = t * t * t;
            var position = Vector3.LerpUnclamped(posStart, posEnd, v);
            WhiteBlock.transform.localPosition = position;
            yield return null;
        }
        WhiteBlock.transform.localPosition = posEnd;
        //OnClick();
        //OnClickWithParameter(this);
    }
}
