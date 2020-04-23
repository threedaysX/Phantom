using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonPressEffect : InteractiveObjectModel
{
    public bool IsPress = false; //是否按下

    void Start()
    {
        ButtonLockEffect();
        if (gameObject.GetComponent<ButtonLock>().buttonIsUnlock == 1)
            ColorChange();
    }
    public override void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)&& PlayerState.Instance.GetPlayerTakeOnHandState())
        {
            ButtonLock();
        }
    }
    public void ButtonLock()
    {
        if (gameObject.GetComponent<ButtonLock>().buttonIsUnlock == 1)
            ChangeButtonStatus();
    }
    public void ChangeButtonStatus()
    {  //每點下按鈕一次，更新一次狀態。
        SpriteRenderer Sprite = this.GetComponent<SpriteRenderer>();

        ColorChange();

        if (IsPress)
            Sprite.color = new Color(Sprite.color.r, Sprite.color.g, Sprite.color.b, 160f/255f);  //IsPress為按下狀態，按鈕變更為黑色。
        else
            Sprite.color = new Color(Sprite.color.r, Sprite.color.g, Sprite.color.b, 1f);  //IsPress為沒按下的狀態，按鈕變更為紅色。
    }
    public void ColorChange()
    {
        string buttonSceneName = GetComponent<ButtonLock>().buttonSceneName;
        SpriteRenderer Sprite = this.GetComponent<SpriteRenderer>();

        if (buttonSceneName == "DressingRoomDoorButton")
        {
            Sprite.color = Color.red;
        }
        else if (buttonSceneName == "TheaterDoorButton")
        {
            Sprite.color = Color.yellow;
        }
        else if (buttonSceneName == "BasementDoorButton")
        {
            Sprite.color = new Color(0.8f,0.8f,0.8f, 1f);
        }
    }
    public void ButtonLockEffect()
    {
        int buttonIsUnlock = GetComponent<ButtonLock>().buttonIsUnlock;
        SpriteRenderer Sprite = this.GetComponent<SpriteRenderer>();

        if (buttonIsUnlock == 1)
        {
            Sprite.color = new Color(Sprite.color.r, Sprite.color.g, Sprite.color.b, 1f);
        }
        else
        {
            Sprite.color = new Color(Sprite.color.r, Sprite.color.g, Sprite.color.b, 50f/255f);
        }
    }
}
